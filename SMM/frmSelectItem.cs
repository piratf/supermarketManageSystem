using Model;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SMM
{
    /// <summary>
    /// 选择物品窗体
    /// </summary>
    public partial class frmSelectItem : Form
    {
        private ArrayList itemList = new ArrayList();

        // 移动窗体
        const int WM_NCLBUTTONDOWN = 0xA1;
        const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);


        /// <summary>
        /// 存储选中的物品
        /// 作为返回值
        /// </summary>
        public ArrayList ItemList
        {
            get { return itemList; }
            set { itemList = value; }
        }
        
        /// <summary>
        /// 无参默认构造窗体函数
        /// </summary>
        public frmSelectItem()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// 加载类别下拉列表内容
        /// 加载默认物品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSelectItem_Load(object sender, EventArgs e)
        {
            object[] paras = new object[1];
            paras[0] = cmbChooseClass;
            try
            {
                if (!BLL.MerchandiseManagement.delegateHelper(typeof(frmMerchandiseManagement).AssemblyQualifiedName, "loadItemClass", paras))
                {
                    MessageBox.Show("程序出错，请联系管理员");
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }

            flashTable();
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
            _lv.MultiSelect = true;//是否可以选择多行
            _lv.HeaderStyle = ColumnHeaderStyle.Clickable;//列头单击事件
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
        /// 填充商品列表的内容
        /// 物品item的Name是物品编号
        /// 物品item的Text是物品名称
        /// 其他的subitem依次填充
        /// </summary>
        private void setTableItem(ListView _listView)
        {
            DataTable dtItemList = BLL.MerchandiseManagement.getItemListFromClassID(cmbChooseClass.SelectedValue.ToString());
            _listView.Items.Clear();
            // 添加表格内容
            for (int i = 0; i < dtItemList.Rows.Count; i++)
            {
                // 建立新的item
                ListViewItem item = new ListViewItem();
                item.SubItems.Clear();
                // 这个item的Name和Text都是物品的编号
                item.Text = dtItemList.Rows[i][SubitemName.subitemName].ToString();
                item.Name = dtItemList.Rows[i][SubitemName.subitemID].ToString();
                // 依次添加subitems，此处只设置Text
                item.SubItems.Add(dtItemList.Rows[i][SubitemName.subitemPrice].ToString());
                item.SubItems.Add(dtItemList.Rows[i][SubitemName.subitemDiscount].ToString());
                item.SubItems.Add(dtItemList.Rows[i][SubitemName.subitemExtraNote].ToString());
                item.SubItems.Add(dtItemList.Rows[i][SubitemName.subitemCount].ToString());
                // 设置Subitem的Name属性便于索引
                setListViewItem(item);
                if ((i & 1) == 0)
                {
                    item.BackColor = Color.Azure;
                }
                _listView.Items.Add(item);
            }
        }

        /// <summary>
        /// 刷新物品列表
        /// </summary>
        private void flashTable()
        {
            setListView(listViewSelectItem);
            setTableHead(listViewSelectItem);
        }

        /// <summary>
        /// 类别选择下拉菜单提交事件
        /// 按选择的类别刷新物品栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbChooseClass_SelectionChangeCommitted(object sender, EventArgs e)
        {
            flashTable();
        }

        /// <summary>
        /// 提交按钮事件
        /// 提交所选商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in listViewSelectItem.SelectedItems)
            {
                itemList.Add(lvi);
            }
            listViewSelectItem.Items.Clear();
            this.Close();
        }

        /// <summary>
        /// 商品列表鼠标双击事件
        /// 直接提交当前选中的商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewSelectItem_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnSubmit_Click(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 窗体拖动函数
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left & this.WindowState == FormWindowState.Normal)
            {
                // 移动窗体
                this.Capture = false;
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
