using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Model;

namespace SMM
{
    /// <summary>
    /// 仓储，物品管理窗体
    /// 
    /// 所有缓冲日志通过物品的名称区分
    /// 
    /// 用户可以通过双击条目进入编辑，点击取消编辑可以取消编辑
    /// 用户可以通过下方的文本框添加条目
    /// 
    /// 进入系统后，将当前加载表格的商品添加到 tableSet 中
    /// 添加商品后，添加的商品记录也要加入到 tableSet 中
    /// 修改商品后，tableSet 不变，添加到 modify 集合中
    /// 
    /// </summary>
    public partial class frmMerchandiseManagement : SMM.frmMain
    {
        string waitingForSelect = string.Empty;

        // 当前物品类别
        int currentClassIndex = 0;

        // 判断当前工作类型
        enum InsertType { INSERT, MODIFY };
        InsertType insertType;

        // 按钮使用的文本
        readonly static string insertBtnTxt = "插入商品";
        readonly static string modifyBtnTxt = "修改商品";
        readonly static string undoInsertBtnTxt = "重新输入";
        readonly static string undoModifyBtnTxt = "取消修改";

        //当前表中物品的记录
        HashSet<string> tableSet = new HashSet<string>();
        // 添加商品的名称记录，同一类别中不能有同名商品
        Dictionary<string, Model.Item> addItemDictionary = new Dictionary<string, Item>();
        // 修改日志，string表示商品名称，item表示商品信息，新建的商品没有编号，所以不能用编号做键
        Dictionary<string, Model.Item> modifyDictionary = new Dictionary<string, Item>();
        //删除商品的名称记录，同一类别中不能有同名商品
        Dictionary<string, ListViewItem> deleteDictionary = new Dictionary<string, ListViewItem>();

        /// <summary>
        /// 默认构造函数
        /// 显示的UI为测试模式
        /// </summary>
        public frmMerchandiseManagement()
        {
            user = null;
            supermarket = null;
            labelTitle.Text = Model.frmSetting.itemTitle;
            InitializeComponent();
        }

        /// <summary>
        /// 继承的构造函数
        /// </summary>
        /// <param name="_user"></param>
        /// <param name="_supermarket"></param>
        public frmMerchandiseManagement(User _user, Supermarket _supermarket)
            :base(_user, _supermarket)
        {
            labelTitle.Text = Model.frmSetting.itemTitle;
            InitializeComponent();
        }

        /// <summary>
        /// 加载欢迎信息的UI
        /// </summary>
        private void setWelcome()
        {
            labelWelcome.Text += user.UserID;
            labelCurrentSupermarket.Text += supermarket.Name;
        }

        /// <summary>
        /// 加载商品类别的下拉菜单
        /// </summary>
        private void loadItemClass(ComboBox _cmb)
        {
            DataTable dtItemClass = BLL.TableMethod.GetitemClassTable();
            _cmb.DataSource = dtItemClass;
            _cmb.DisplayMember = Model.itemClassTable.className;
            _cmb.ValueMember = Model.itemClassTable.classID;
            _cmb.SelectedIndex = 0;
        }

        /// <summary>
        /// 进入添加模式
        /// UI的改动
        /// </summary>
        private void gotoInsertMode()
        {
            // 相关按钮的内容
            insertType = InsertType.INSERT;
            btnInsert.Text = insertBtnTxt;
            btnUndoInsert.Text = undoInsertBtnTxt;

            txtCount.Enabled = true;

            txtItemName.Enabled = true;
        }

        /// <summary>
        /// 进入修改模式
        /// UI的改动
        /// </summary>
        private void gotoModifyMode()
        {
            // 修改相关按钮的内容
            insertType = InsertType.MODIFY;
            btnInsert.Text = modifyBtnTxt;
            btnUndoInsert.Text = undoModifyBtnTxt;

            // 物品数量禁止修改
            txtCount.Enabled = false;

            txtItemName.Enabled = false;
        }

        /// <summary>
        /// 加载窗体时的任务
        /// 设置物品列表的属性
        /// 加载类别的下拉菜单
        /// 加载列表内容
        /// 进入添加商品模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMerchandiseManagement_Load(object sender, EventArgs e)
        {
            // 加载物品类别列表
            loadItemClass(cmbChooseClass);
            // 刷新物品列表
            flashTable(listViewItemList, cmbChooseClass.SelectedValue.ToString());
            // 进入插入模式
            gotoInsertMode();
            AnimateWindow(this.Handle, 200, AnimateWindowCV.AW_BLEND | AnimateWindowCV.AW_ACTIVATE);
        }

        /// <summary>
        /// 设置表头
        /// </summary>
        private void setTableHead(ListView _listView)
        {
            //添加表头（列）
            if (_listView.Columns.Count <= 0)
            {
                _listView.Columns.Add("商品名称", 100, HorizontalAlignment.Center);
                _listView.Columns.Add("商品价格/元", 90, HorizontalAlignment.Center);
                _listView.Columns.Add("商品折扣", 60, HorizontalAlignment.Center);
                _listView.Columns.Add("附加信息(50字以内)", 130, HorizontalAlignment.Center);
                _listView.Columns.Add("商品数量", -2, HorizontalAlignment.Center);
            }
            foreach (ColumnHeader ch in _listView.Columns)
            {
                ch.TextAlign = HorizontalAlignment.Center;
            }
        }

        /// <summary>
        /// 填充商品列表的内容
        /// 物品item的Name是物品编号
        /// 物品item的Text是物品名称
        /// 其他的subitem依次填充
        /// </summary>
        private void setTableItem(ListView _listView, DataTable _dtItemList)
        {
                _listView.Items.Clear();
                if (this.tableSet != null)
                {
                    tableSet.Clear();
                }
                // 添加表格内容
                for (int i = 0; i < _dtItemList.Rows.Count; i++)
                {
                    // 建立新的item
                    ListViewItem item = new ListViewItem();
                    item.SubItems.Clear();
                    // 这个item的Name和Text都是物品的编号
                    item.Text = _dtItemList.Rows[i][SubitemName.subitemName].ToString();
                    item.Name = _dtItemList.Rows[i][SubitemName.subitemID].ToString();
                    // 依次添加subitems，此处只设置Text
                    item.SubItems.Add(_dtItemList.Rows[i][SubitemName.subitemPrice].ToString());
                    item.SubItems.Add(_dtItemList.Rows[i][SubitemName.subitemDiscount].ToString());
                    item.SubItems.Add(_dtItemList.Rows[i][SubitemName.subitemExtraNote].ToString());
                    item.SubItems.Add(_dtItemList.Rows[i][SubitemName.subitemCount].ToString());
                    // 设置Subitem的Name属性便于索引
                    setListViewItem(item);
                    if ((i & 1) == 0)
                    {
                        item.BackColor = Color.Azure;
                    }
                    _listView.Items.Add(item);
                    if (this.tableSet != null)
                    {
                        tableSet.Add(item.Text);
                    }
                }
        }

        /// <summary>
        /// 设置Subitem的Name属性便于索引
        /// </summary>
        /// <param name="_item"></param>
        private void setListViewItem(ListViewItem _item)
        {
            _item.SubItems[1].Name = SubitemName.subitemPrice;
            _item.SubItems[2].Name = SubitemName.subitemDiscount;
            _item.SubItems[3].Name = SubitemName.subitemExtraNote;
            _item.SubItems[4].Name = SubitemName.subitemCount;
        }

        /// <summary>
        /// 刷新表格部分，包括表头和重新获取内容
        /// </summary>
        private void flashTable(ListView _listView, string _classID)
        {
            // 获取当前类的编号
            object[] paras = new object[2];
            paras[0] = _listView;
            paras[1] = _classID;
            bgwLoadItemList.RunWorkerAsync(paras);
        }

        /// <summary>
        /// 当调整窗口大小时要重绘最右侧一栏的大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMerchandiseManagement_Resize(object sender, EventArgs e)
        {
            if (listViewItemList.Columns.Count > 0)
            {
                listViewItemList.Columns[listViewItemList.Columns.Count - 1].Width = -2;
            }
        }

        /// <summary>
        /// 将商品的属性拷贝到文本框
        /// </summary>
        private void setTableToTxt()
        {
            txtItemName.Text = listViewItemList.SelectedItems[0].Text;
            txtItemPrice.Text = listViewItemList.SelectedItems[0].SubItems[SubitemName.subitemPrice].Text;
            txtItemDiscount.Text = listViewItemList.SelectedItems[0].SubItems[SubitemName.subitemDiscount].Text;
            txtExtraNote.Text = listViewItemList.SelectedItems[0].SubItems[SubitemName.subitemExtraNote].Text;
            txtCount.Text = listViewItemList.SelectedItems[0].SubItems[SubitemName.subitemCount].Text;
        }

        /// <summary>
        /// 双击商品可以进入修改模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewItemList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                Point tmpPoint = listViewItemList.PointToClient(Cursor.Position);
                ListViewItem.ListViewSubItem subitem = listViewItemList.HitTest(tmpPoint).SubItem;
                if (subitem != null)
                {
                    setTableToTxt();
                    gotoModifyMode();
                }
                else
                {
                    MessageBox.Show("space");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Click Error!");
            }
        }

        /// <summary>
        /// 清除文本框的内容
        /// </summary>
        private void clearTxt()
        {
            txtItemName.Text = "";
            txtItemPrice.Text = "";
            txtItemDiscount.Text = "";
            txtExtraNote.Text = "";
            txtCount.Text = "";
        }

        /// <summary>
        /// 取消插入
        /// 清除文本框内容
        /// 进入添加商品模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUndoInsert_Click(object sender, EventArgs e)
        {
            clearTxt();

            modifyDictionary.Clear();
            cmbChooseClass_SelectionChangeCommitted(sender, e);

            if (insertType == InsertType.MODIFY)
            {
                gotoInsertMode();
            }
        }

        /// <summary>
        /// 在列表中查找商品
        /// </summary>
        /// <param name="_itemName"></param>
        private void findItemInTable(string _itemName)
        {
            ListViewItem lvi = listViewItemList.FindItemWithText(_itemName);
            if (lvi != null)
            {
                listViewItemList.Focus();
                listViewItemList.Items[lvi.Index].Focused = true;
                listViewItemList.Items[lvi.Index].Selected = true;
            }
            else
            {
                MessageBox.Show("没找到");
            }
        }

        /// <summary>
        /// 添加商品
        /// 首先检查输入
        /// 然后添加到暂存数据集
        /// 新建商品的数量默认为0
        /// </summary>
        private void addItem()
        {
            ListViewItem lvi = checkAddItemInput();
            if (lvi == null)
            {
                return;
            }
            // 更新表格
            listViewItemList.Items.Add(lvi);
            tableSet.Add(lvi.Text);
            // 更新添加日志
            DictionaryAddAuto(addItemDictionary, lvi);
            return;
        }

        /// <summary>
        /// 检查输入的字符串
        /// 检查价格和折扣是否是数字
        /// 检查各项是否为空
        /// 附加信息可以为空，不可过长
        /// 如果附加信息为空，就赋值为null
        /// </summary>
        /// <returns></returns>
        private ListViewItem checkAddItemInput()
        {
            string itemName = txtItemName.Text.Trim();
            if (itemName == "")
            {
                MessageBox.Show("商品名称不能为空");
                return null;
            }

            if (tableSet.Contains(itemName) && insertType == InsertType.INSERT )
            {
                MessageBox.Show("商品已存在");
                findItemInTable(itemName);
                return null;
            }

            string itemExtraNote = txtExtraNote.Text.Trim();
            if (itemExtraNote.Length > 50)
            {
                MessageBox.Show("附加信息太长，添加失败");
            }
            else if (itemExtraNote == "")
            {
                itemExtraNote = string.Empty;
            }

            decimal itemPrice = 0;
            if (txtItemPrice.Text.Trim() == "")
            {
                MessageBox.Show("商品价格不能为空");
                return null;
            }
            else
            {
                try
                {
                    itemPrice = decimal.Parse(txtItemPrice.Text.Trim());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


            int itemDiscount = 0;
            if (txtItemDiscount.Text.Trim() == "")
            {
                MessageBox.Show("商品折扣不能为空");
                return null;
            }
            else
            {
                try
                {
                    itemDiscount = int.Parse(txtItemDiscount.Text.Trim());
                }
                catch (FormatException)
                {
                    MessageBox.Show("商品折扣需要是-1到100之间的数字");
                    return null;
                }
                if (itemDiscount > 100 || itemDiscount < -1)
                {
                    MessageBox.Show("商品折扣需要是-1到100之间的数字");
                    return null;
                }
            }
            if (itemDiscount == 0)
            {
                if (MessageBox.Show("这件商品将被免费卖出，是否确定？", "免费卖出？", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    return null;
                }
            }

            if (txtCount.Text == "")
            {
                txtCount.Text = "0";
            }
            int itemCount = checkCount(txtCount.Text);
            if (itemCount == -1)
            {
                return null;
            }

            // 建立并返回新的listViewItem
            ListViewItem lvi = new ListViewItem(itemName);
            // 新建的商品没有编号
            lvi.Name = "";
            lvi.SubItems.Add(itemPrice.ToString());
            lvi.SubItems.Add(itemDiscount.ToString());
            lvi.SubItems.Add(itemExtraNote);
            lvi.SubItems.Add(itemCount.ToString());
            setListViewItem(lvi);

            return lvi;
        }

        /// <summary>
        /// 修改物品的属性
        /// 先检测输入
        /// 检测通过后将修改显示在表中
        /// 将修改的记录和内容加入集合
        /// 
        /// subitem只有价格，折扣，附加信息三项
        /// </summary>
        private void modifyItem()
        {
            if (checkAddItemInput() == null)
            {
                return;
            }

            ListViewItem lvi = listViewItemList.SelectedItems[0];

            lvi.SubItems[SubitemName.subitemPrice].Text = txtItemPrice.Text;
            lvi.SubItems[SubitemName.subitemDiscount].Text = txtItemDiscount.Text;
            lvi.SubItems[SubitemName.subitemExtraNote].Text = txtExtraNote.Text;
            lvi.SubItems[SubitemName.subitemCount].Text = txtCount.Text;

            // 建立编号和内容的键值对插入日志
            if (lvi.Name != null)
            {
                DictionaryAddAuto(modifyDictionary, lvi);
            }
            else
            {
                DictionaryAddAuto(addItemDictionary, lvi);
            }

            // 更新UI
        }

        /// <summary>
        /// 自动获取列表item的内容，添加修改日志
        /// 如果物品的编号为空，则赋值为null
        /// </summary>
        /// <param name="_lvi"></param>
        private void DictionaryAddAuto(Dictionary<string, Item> _dictionary, ListViewItem _lvi)
        {
            if (_lvi.Name == "")
            {
                _lvi.Name = null;
            }
            DictionaryAdd(_dictionary, cmbChooseClass.SelectedValue.ToString(), _lvi.Name, _lvi.Text, _lvi.SubItems[SubitemName.subitemPrice].Text
                , _lvi.SubItems[SubitemName.subitemDiscount].Text, _lvi.SubItems[SubitemName.subitemExtraNote].Text, _lvi.SubItems[SubitemName.subitemCount].Text);
        }

        /// <summary>
        /// 根据输入的字段自动添加修改日志
        /// </summary>
        /// <param name="_classID"></param>
        /// <param name="_itemID"></param>
        /// <param name="_itemName"></param>
        /// <param name="_itemPrice"></param>
        /// <param name="_itemDiscount"></param>
        /// <param name="_itemExtraNote"></param>
        /// <param name="_itemCount"></param>
        private void DictionaryAdd(Dictionary<string, Model.Item> _dictionary, string _classID, string _itemID, string _itemName, string _itemPrice, string _itemDiscount, string _itemExtraNote, string _itemCount )
        {
            if (_dictionary.ContainsKey(_itemName))
            {
                try
                {
                    _dictionary[_itemName].ItemPrice = decimal.Parse(_itemPrice);
                    _dictionary[_itemName].ItemDiscount = int.Parse(_itemDiscount);
                    _dictionary[_itemName].ItemExtraNote = _itemExtraNote;
                    _dictionary[_itemName].ItemCount = int.Parse(_itemCount);
                }
                catch (FormatException)
                {
                    MessageBox.Show("输入的数值不正确");
                }
            }
            else
            {
                _dictionary.Add(_itemName, new Item(_classID, _itemID, _itemName, decimal.Parse(_itemPrice), int.Parse(_itemDiscount), _itemExtraNote, int.Parse(_itemCount)));
            }
        }

        /// <summary>
        /// 判断当前的模式进行不同的操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (insertType == InsertType.INSERT)
            {
                addItem();
            }
            else
            {
                modifyItem();
            }
            flashTableColor();
        }


        /// <summary>
        /// 通过item类的信息构造ListViewItem
        /// 构造的ListViewItem没有ID
        /// </summary>
        /// <param name="_item"></param>
        /// <returns></returns>
        private ListViewItem buildListViewItem(Model.Item _item)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.SubItems.Clear();
            lvi.Text = _item.ItemName;
            lvi.Name = _item.ItemName;
            lvi.SubItems.Add(_item.ItemName);//用名称代替了ID，在删除时不能取ID，而是从add集合中删除，注意
            lvi.SubItems.Add(_item.ItemName);
            lvi.SubItems.Add(_item.ItemPrice.ToString());
            lvi.SubItems.Add(_item.ItemDiscount.ToString());
            lvi.SubItems.Add(_item.ItemExtraNote);
            setListViewItem(lvi);
            return lvi;
        }

        /// <summary>
        /// 打开或关闭批量处理菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelBatchNotice_Click(object sender, EventArgs e)
        {
            if (gbBatchProcess.Visible == true)
            {
                gbBatchProcess.Visible = false;
            }
            else
            {
                gbBatchProcess.Visible = true;
            }
        }

        /// <summary>
        /// 提交所有的增添内容
        /// </summary>
        private bool submitInsert()
        {
            bool flag = true;
            foreach (KeyValuePair<string, Item> pair in addItemDictionary)
            {
                try
                {
                    BLL.MerchandiseManagement.insertItem(pair.Value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            addItemDictionary.Clear();
            return flag;
        }

        /// <summary>
        /// 提交所有的修改内容
        /// </summary>
        private bool submitModify()
        {
            bool flag = true;
            foreach (KeyValuePair<string, Model.Item> pair in modifyDictionary)
            {
                try
                {
                    flag = BLL.MerchandiseManagement.modifyItem(pair.Value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            modifyDictionary.Clear();
            return flag;
        }

        /// <summary>
        /// 向数据库中提交删除的内容
        /// </summary>
        /// <returns></returns>
        private bool submitDelete()
        {
            bool flag = true;
            foreach (KeyValuePair<string, ListViewItem> pair in deleteDictionary)
            {
                flag = BLL.MerchandiseManagement.deleteItem(pair.Value.Name);
            }

            deleteDictionary.Clear();
            return flag;
        }

        /// <summary>
        /// 处理所有的操作
        /// 包括添加的内容
        /// 修改的内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 切换类别
        /// 需要检查当前类别中是否有未保存的内容
        /// 重新加载表格内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbChooseClass_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (addItemDictionary.Count > 0 || modifyDictionary.Count > 0)
            {
                MessageBox.Show("当前页面未保存");
                cmbChooseClass.SelectedIndex = currentClassIndex;
                return;
            }
            flashTable(listViewItemList, cmbChooseClass.SelectedValue.ToString());
        }

        /// <summary>
        /// 从表格中删除内容
        /// 删除的内容进入暂存数据结构
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            while (listViewItemList.SelectedItems.Count > 0)
            {
                string itemName = listViewItemList.SelectedItems[0].Text;
                if (!addItemDictionary.ContainsKey(itemName))
                {
                    if (!deleteDictionary.ContainsKey(itemName))
                    {
                        deleteDictionary.Add(itemName, listViewItemList.SelectedItems[0]);
                    }
                    tableSet.Remove(itemName);
                    listViewItemList.Items[listViewItemList.SelectedItems[0].Index].Remove();
                }
                else
                {
                    addItemDictionary.Remove(itemName);
                }
            }
            flashTableColor();
        }

        /// <summary>
        /// 提交按钮事件
        /// 弹出确认框
        /// 提交内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmitMain_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定提交？", labelNoticeMain.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.OK)
            {
                bool flag = true;
                flag = submitInsert();
                flag = submitDelete();
                flag = submitModify();
                if (flag)
                {
                    MessageBox.Show("处理成功");
                }
                else
                {
                    MessageBox.Show("数据处理出现问题\n请联系管理员", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // 提交完成后刷新列表
            flashTable(listViewItemList, cmbChooseClass.SelectedValue.ToString());
        }

        /// <summary>
        /// 遍历表格的内容，重新隔行绘制颜色
        /// </summary>
        private void flashTableColor()
        {
            foreach (ListViewItem lvi in listViewItemList.Items)
            {
                if ((lvi.Index & 1) == 0)
                {
                    lvi.BackColor = Color.Azure;
                }
                else
                {
                    lvi.BackColor = Color.White;
                }
            }
        }

        /// <summary>
        /// 撤销删除按钮单击事件
        /// 撤销删除，还原原始列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUndoDelete_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, ListViewItem> pair in deleteDictionary)
            {
                tableSet.Add(pair.Key);
                listViewItemList.Items.Add(pair.Value);
            }
            deleteDictionary.Clear();
            flashTableColor();
        }

        /// <summary>
        /// 将输入修正为金额数量
        /// 如果金额小于0会报错
        /// 如果金额等于0会提示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtItemPrice_Leave(object sender, EventArgs e)
        {
            decimal itemMoney = 0;
            try
            {
                itemMoney = decimal.Parse(txtItemPrice.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("您输入的内容不正确，请输入一个正确的金额数");
                txtItemPrice.Focus();
                return;
            }
            if (itemMoney < 0)
                {
                    MessageBox.Show("您输入的内容不正确，请输入一个正确的金额数");
                    txtItemPrice.Focus();
                    return;
                }
                if (itemMoney == 0)
                {
                    if (MessageBox.Show("这件商品将被免费卖出，您确定吗？", "免费卖出", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        txtItemPrice.Focus();
                        return;
                    }
                }
            txtItemPrice.Text = itemMoney.ToString();
        }

        /// <summary>
        /// 商品入库
        /// 遍历选中的商品，批量入库
        /// 如果有多选，需要确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPutIn_Click(object sender, EventArgs e)
        {
            // 如果输入为空就把焦点置于输入框
            if (txtPutIn.Text == "")
            {
                txtPutIn.Focus();
                return;
            }

            int count = checkCount(txtPutIn.Text);
            int answer = 0;
            if (count == -1)
            {
                return;
            }

            // 设置确认修改的标记
            bool flagPutIn = false;

            // 如果多选要确认
            if (listViewItemList.SelectedItems.Count > 1)
            {
                if (MessageBox.Show("您选中了多个商品，是否确认批量入库？", "确认批量入库", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    flagPutIn = true;
                }
            }
            else
            {
                flagPutIn = true;
            }

            // 遍历选中的项进行修改
            if (flagPutIn)
            {
                foreach (ListViewItem lvi in listViewItemList.SelectedItems)
                {
                    // 修正数值
                    answer = count;
                    answer += int.Parse(lvi.SubItems[SubitemName.subitemCount].Text);
                    // 更新列表
                    lvi.SubItems[SubitemName.subitemCount].Text = answer.ToString();
                    // 添加修改日志
                    DictionaryAddAuto(modifyDictionary, lvi);
                }
            }
        }

        /// <summary>
        /// 物品出库
        /// 如果是多选需要确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOutBound_Click(object sender, EventArgs e)
        {
            int count = checkCount(txtPutIn.Text);
            int answer = 0;
            if (count == -1)
            {
                return;
            }

            // 设置确认修改的标记
            bool flagOutBound = false;

            // 如果多选要确认
            if (listViewItemList.SelectedItems.Count > 1)
            {
                if (MessageBox.Show("您选中了多个商品，是否确认批量入库？", "确认批量入库", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    flagOutBound = true;
                }
            }
            else
            {
                flagOutBound = true;
            }

            // 遍历选中的项进行修改
            if (flagOutBound)
            {
                foreach (ListViewItem lvi in listViewItemList.SelectedItems)
                {
                    // 修正数值
                    answer = count;
                    answer = int.Parse(lvi.SubItems[SubitemName.subitemCount].Text) - answer;
                    if (answer < 0)
                    {
                        MessageBox.Show("库存量不足，出库失败");
                        return;
                    }
                    // 更新列表
                    lvi.SubItems[SubitemName.subitemCount].Text = answer.ToString();
                    // 添加修改日志
                    DictionaryAddAuto(modifyDictionary, lvi);
                }
            }
        }

        /// <summary>
        /// 检查数量文本框的内容并返回转换后的值
        /// </summary>
        /// <returns>转换后的值或返回-1表示出错</returns>
        private int checkCount(string _count)
        {
            // 检查输入的内容是否是数字
            int count = 0;
            try
            {
                count = int.Parse(_count);
            }
            catch (Exception)
            {
                MessageBox.Show("物品数量输入的内容不正确，请输入一个0-65535之间的数量");
                return -1;
            }
            return count;
        }

        private void cmbChooseClass_DropDown(object sender, EventArgs e)
        {
            currentClassIndex = cmbChooseClass.SelectedIndex;
        }

        private void bgwLoadItemList_DoWork(object sender, DoWorkEventArgs e)
        {
            object[] paras = null;
            string itemClassID = string.Empty;
            try
            {
                paras = (object[])e.Argument;
                itemClassID = (string)paras[1];
            }
            catch (Exception)
            {
                MessageBox.Show("程序错误，加载失败");
                Application.Exit();
            }
            if (itemClassID != "")
            {
                DataTable dtItemList = null;
                // 通过当前类选择物品
                dtItemList = BLL.MerchandiseManagement.getItemListFromClassID(itemClassID);
                object[] resultParas = new object[2];
                resultParas[0] = dtItemList;
                resultParas[1] = paras[0];
                e.Result = resultParas;
            }
        }

        /// <summary>
        /// 填充表格
        /// 参数[0]为DataTable，[1]为ListView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwLoadItemList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            object[] paras = null;
            ListView listView = null;
            try
            {
                paras = (object[])e.Result;
                listView = (ListView)paras[1];
            }
            catch (Exception)
            {
                MessageBox.Show("程序错误，加载失败");
                Application.Exit();
            }
            // 设置列表属性
            frmClassSetting.setListView(listView);
            // 设置表头
            setTableHead(listView);
            // 设置列表项
            setTableItem(listView, (DataTable)paras[0]);

            if (waitingForSelect != "")
            {
                listView.Items[waitingForSelect].Selected = true;
                listView.Items[waitingForSelect].Focused = true;
                waitingForSelect = string.Empty;
            }
            listView.Focus();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmClassSetting fcs = new frmClassSetting(user, supermarket, wn, wt);
            fcs.Owner = this;
            fcs.ShowDialog();
            loadItemClass(cmbChooseClass);
        }


        /// <summary>
        /// 按名称搜索商品的功能
        /// 首先检测是否有未提交的修改，保证数据库数据的全面性
        /// 然后检测字符串的注入安全性
        /// 完成安全性检测后在数据库中使用通配符查询字符串，返回DataTable
        /// 查询完成后打开frmSearchItemResult窗口，显示内容
        /// 双击结果表中的项会回到本界面并定位结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string condition = txtSearch.Text.Trim();

            if (condition.Length > 32)
            {
                MessageBox.Show("字符串过长，请不要超过32字符");
            }
            if (addItemDictionary.Count > 0 || modifyDictionary.Count > 0 || deleteDictionary.Count > 0)
            {
                if (MessageBox.Show("您有尚未提交的修改，搜索将不包括这些内容 \n 是否返回提交？", "未提交的内容", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    return;
                }
            }

            DataTable dt = null;
            try
            {
                dt = BLL.MerchandiseManagement.searchItem(condition);
                if (dt == null || dt.Rows.Count <= 0)
                {
                    MessageBox.Show("没有找到结果");
                }
                else
                {
                    frmSearchResult fsr = new frmSearchResult(dt);
                    fsr.Owner = this;
                    fsr.ShowDialog();
                    ListViewItem lvi = fsr.lviReturn;
                    if (lvi != null)
                    {
                        // 定位到类别
                        cmbChooseClass.SelectedIndex = cmbChooseClass.FindString(lvi.Text);
                        //cmbChooseClass_SelectionChangeCommitted(sender, e);
                        waitingForSelect = lvi.Name;
                        flashTable(listViewItemList, cmbChooseClass.SelectedValue.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // 搜索成功之后
            listViewItemList.Focus();
            foreach (DataRow dr in dt.Rows)
            {
                //MessageBox.Show(dr[Model.itemTable.itemName].ToString());
                ListViewItem[] result = listViewItemList.Items.Find(dr[Model.itemTable.itemID].ToString(), false);
                if (result != null && result.Length > 0)
                {
                    result[0].Selected = true;
                    result[0].Focused = true;
                }
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }

        private void btnReloadTable_Click(object sender, EventArgs e)
        {
            if (addItemDictionary.Count > 0 || modifyDictionary.Count > 0 || deleteDictionary.Count > 0)
            {
                if (MessageBox.Show("您有尚未提交的修改，搜索将不包括这些内容 \n 是否返回提交？", "未提交的内容", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    return;
                }
            }
            cmbChooseClass_SelectionChangeCommitted(sender, e);
        }
    }
}
