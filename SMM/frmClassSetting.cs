using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SMM
{
    /// <summary>
    /// 物品类别管理窗体
    /// 可以增删改类别
    /// 修改可以撤销
    /// </summary>
    public partial class frmClassSetting : SMM.frmMain
    {
        // 获取类别列表
        DataTable classTable = null;
        // 改动存档
        // 存储插入内容的ID
        HashSet<string> insert = new HashSet<string>();
        // 存储等待删除内容的ID
        HashSet<string> delete = new HashSet<string>();
        HashSet<Model.itemClass> insertSet = new HashSet<Model.itemClass>();

        Model.itemClass itemClass = new Model.itemClass();
      
        /// <summary>
        /// 默认初始化窗体
        /// </summary>
        public frmClassSetting()
        {
            user = null;
            supermarket = null;
            labelTitle.Text = Model.frmSetting.classTitle;
            InitializeComponent();
        }

        /// <summary>
        /// 带参数初始化窗体
        /// </summary>
        /// <param name="_user"></param>
        /// <param name="_supermarket"></param>
        public frmClassSetting(Model.User _user, Model.Supermarket _supermarket, Model.WeatherNow _wn = null, Model.WeatherToday _wt = null)
            :base(_user, _supermarket, _wn, _wt)
        {
            labelTitle.Text = Model.frmSetting.classTitle;
            InitializeComponent();
        }

        /// <summary>
        /// 刷新表格
        /// </summary>
        private void flashTable()
        {
            classTable = BLL.TableMethod.GetitemClassTable();
            setTable(classTable);
        }

        /// <summary>
        /// 加载窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmClassSetting_Load(object sender, EventArgs e)
        {
            flashTable();
            AnimateWindow(this.Handle, 200, AnimateWindowCV.AW_BLEND | AnimateWindowCV.AW_ACTIVATE);
        }

        /// <summary>
        /// 设置ListView的属性
        /// </summary>
        /// <param name="_lv"></param>
        public static void setListView(ListView _lv)
        {
            _lv.GridLines = true;//表格是否显示网格线
            _lv.FullRowSelect = true;//是否选中整行
            _lv.View = View.Details;//设置显示方式
            _lv.Scrollable = true;//是否自动显示滚动条
            _lv.MultiSelect = false;//是否可以选择多行
            _lv.HeaderStyle = ColumnHeaderStyle.Clickable;//列头单击事件
        }

        /// <summary>
        /// 设置表格内容
        /// </summary>
        /// <param name="_dt"></param>
        private void setTable(DataTable _dt)
        {
            setListView(listViewClassSetting);
            setListView(listViewForDelete);
            //添加类别设置的表头（列）
            if (listViewClassSetting.Columns.Count <= 0)
            {
                listViewClassSetting.Columns.Add("", 0, HorizontalAlignment.Center);
                listViewClassSetting.Columns.Add("4位类别编号", 100, HorizontalAlignment.Center);
                listViewClassSetting.Columns.Add("类别名称", 100, HorizontalAlignment.Center);
                listViewClassSetting.Columns.Add("类别说明", -2, HorizontalAlignment.Center);
            }
            //添加待删除表的表头（列）
            if (listViewForDelete.Columns.Count <= 0)
            {
                listViewForDelete.Columns.Add("", 0, HorizontalAlignment.Center);
                listViewClassSetting.Columns.Add("4位类别编号", 0, HorizontalAlignment.Center);
                listViewForDelete.Columns.Add("准备删除的类", -2, HorizontalAlignment.Center);
                listViewClassSetting.Columns.Add("类别说明", 0, HorizontalAlignment.Center);
            }

            listViewClassSetting.Items.Clear();
            listViewForDelete.Items.Clear();

            //添加表格内容
            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.SubItems.Clear();
                for (int j = 0; j < _dt.Columns.Count; j++)
                {
                    item.SubItems.Add(_dt.Rows[i][j].ToString());
                    item.SubItems[item.SubItems.Count - 1].Name = _dt.Rows[i][j].ToString();
                }
                if ((i & 1) == 0)
                {
                    item.BackColor = Color.Azure;
                }
                listViewClassSetting.Items.Add(item);
            }

            
        }

        /// <summary>
        /// 鼠标单击事件
        /// 判断是否选中内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewClassSetting_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                Point tmpPoint = listViewClassSetting.PointToClient(Cursor.Position);
                ListViewItem.ListViewSubItem subitem = listViewClassSetting.HitTest(tmpPoint).SubItem;
                if (subitem != null)
                {
                    //listViewClassSetting.Items[listViewClassSetting.SelectedItems[0].Index].Remove();
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

        private void frmClassSetting_Shown(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 添加类别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddClass_Click(object sender, EventArgs e)
        {
            // 判断信息是否完整
            string classID = txtClassID.Text;
            string className = txtClassName.Text;
            string classNote = rtxtClassNote.Text;
            if (classNote == "类别注释：")
            {
                classNote = null;
            }
            if (classID == "" || className == "")
            {
                MessageBox.Show("信息不完整，添加失败");
            }

            ListViewItem lvi = new ListViewItem();
            lvi.SubItems.Clear();
            lvi.Text = classID;
            lvi.SubItems.Add(classID);
            lvi.SubItems.Add(className);
            lvi.SubItems.Add(classNote);

            // 判断表格中是否存在
            foreach (ListViewItem it in listViewClassSetting.Items)
            {
                if (it.SubItems[1].Text == classID)
                {
                    MessageBox.Show("该类别ID已存在");
                    return;
                }
            }

            // 判断是否在删除队列里
            if (delete.Contains(classID))
            {
                delete.Remove(classID);
                for (int i = 0; i < listViewForDelete.Items.Count; i++)
                {
                    if (listViewForDelete.Items[i].SubItems[1].Text == classID)
                    {
                        listViewForDelete.Items.Remove(listViewForDelete.Items[i]);
                        i--;
                    }
                }
            }
            else
            {
                // 放在待插入集合中
                insert.Add(classID);
                itemClass.ItemID = classID;
                itemClass.ItemName = className;
                itemClass.ItemNote = classNote;
                insertSet.Add(itemClass);
            }


            //在ListView中显示新添加的列
            listViewClassSetting.Items.Add(lvi);
            //修改颜色
            if ((listViewClassSetting.Items.Count & 1) == 0)
            {
                listViewClassSetting.Items[listViewClassSetting.Items.Count - 1].BackColor = Color.Gray;
            }
        }

        /// <summary>
        /// 注释文本框进入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rtxtClassNote_Enter(object sender, EventArgs e)
        {
            rtxtClassNote.Text = "";
        }

        /// <summary>
        /// 删除类别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteClass_Click(object sender, EventArgs e)
        {
            while (listViewClassSetting.SelectedItems.Count > 0)
            {
                //更新UI
                ListViewItem selected = listViewClassSetting.SelectedItems[0];
                string classID = selected.SubItems[1].Text;
                string className = selected.SubItems[2].Text;
                ListViewItem lvi = new ListViewItem();
                lvi.SubItems.Clear();
                lvi.Text = selected.SubItems[1].Text;
                lvi.SubItems.Add(selected.SubItems[1].Text);
                lvi.SubItems.Add(className);
                lvi.SubItems.Add(selected.SubItems[3].Text);
                listViewForDelete.Items.Add(lvi);
                selected.Remove();

                //更新内容
                if (insert.Contains(classID))
                {
                    insert.Remove(classID);
                }
                else {
                    // 在delete日志中插入classID
                    delete.Add(classID);
                }
            }
            updateDeleteCount();
        }

        /// <summary>
        /// 重绘表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefreshTable_Click(object sender, EventArgs e)
        {
            flashTable();
        }

        /// <summary>
        /// 撤销删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUndoDelete_Click(object sender, EventArgs e)
        {
            while (listViewForDelete.SelectedItems.Count > 0)
            {
                ListViewItem lvi = listViewForDelete.SelectedItems[0];
                listViewForDelete.Items.Remove(listViewForDelete.SelectedItems[0]);
                listViewClassSetting.Items.Add(lvi);
            }
            delete.Clear();
            foreach (ListViewItem lvi in listViewForDelete.Items)
            {
                delete.Add(lvi.SubItems[1].Text);
            }
            updateDeleteCount();
        }

        /// <summary>
        /// 提交内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmitMain_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认提交？", "提交修改", MessageBoxButtons.OKCancel) == DialogResult.Cancel) {
                return;
            }
            int failedCount = 0;
            // 插入内容
            if (insert.Count > 0)
            {
                foreach (Model.itemClass ic in insertSet)
                {
                    if (!BLL.TableMethod.insertItemClass(ic))
                    {
                        failedCount++;
                    }
                }
            }
            // 删除内容
            if (delete.Count > 0)
            {
                foreach (ListViewItem forDelete in listViewForDelete.Items)
                {
                    if (!BLL.TableMethod.deleteItemClass(forDelete.SubItems[1].Text))
                    {
                        failedCount++;
                    }
                }
            }

            //更新UI
            listViewForDelete.Items.Clear();

            if (failedCount <= 0)
            {
                MessageBox.Show("提交成功");
            }
            else
            {
                MessageBox.Show("有" + failedCount.ToString() + "条提交失败");
            }

            // 清除日志
            insert.Clear();
            delete.Clear();

            flashTable();
        }

        /// <summary>
        /// 显示delete的大小
        /// </summary>
        private void updateDeleteCount()
        {
            labelNoticeMain.Text = delete.Count.ToString();
        }

        private void btnFindClass_Click(object sender, EventArgs e)
        {
            if (txtFindClass.Text != "")
            {
                try
                {
                    ListViewItem lvi = listViewClassSetting.Items.Find(txtFindClass.Text, true)[0];
                    listViewClassSetting.Focus();
                    lvi.Selected = true;
                    lvi.Focused = true;
                }
                catch (IndexOutOfRangeException)
                {
                    MessageBox.Show("未找到");
                }
            }
        }

        private void txtFindClass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFindClass_Click(sender, e);
            }
        }

        private void txtClassID_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.KeyCode <= Keys.Z && e.KeyCode >= Keys.A))
            {
                return;
            }
        }
    }
}
