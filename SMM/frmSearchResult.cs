using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMM
{
    public partial class frmSearchResult : Form
    {
        public frmSearchResult()
        {
            InitializeComponent();
        }

        public frmSearchResult(DataTable _dt)
        {
            InitializeComponent();
            dt = _dt;
        }

        // 移动窗体
        const int WM_NCLBUTTONDOWN = 0xA1;
        const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        DataTable dt = new DataTable();
        public ListViewItem lviReturn = new ListViewItem();


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

        /// <summary>
        /// 设置表头
        /// </summary>
        private void setTableHead()
        {
            //添加表头（列）
            if (listViewResult.Columns.Count <= 0)
            {
                listViewResult.Columns.Add("商品类别", 80, HorizontalAlignment.Center);
                listViewResult.Columns.Add("商品名称", 100, HorizontalAlignment.Center);
                listViewResult.Columns.Add("商品价格/元", 90, HorizontalAlignment.Center);
                listViewResult.Columns.Add("商品折扣", 60, HorizontalAlignment.Center);
                listViewResult.Columns.Add("附加信息(50字以内)", 130, HorizontalAlignment.Center);
                listViewResult.Columns.Add("商品数量", -2, HorizontalAlignment.Center);
            }
        }

        private void frmSearchResult_Load(object sender, EventArgs e)
        {
            setTableHead();
            frmClassSetting.setListView(listViewResult);

            if (dt != null && dt.Rows.Count > 0)
            {
                loadItem();
            }
        }

        private void loadItem()
        {
            listViewResult.Items.Clear();
            // 添加表格内容
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                // 建立新的item
                ListViewItem item = new ListViewItem();
                item.SubItems.Clear();
                // 这个item的Name和Text都是物品的编号
                item.Text = dt.Rows[i][SubitemName.subitemClassName].ToString();
                item.Name = dt.Rows[i][SubitemName.subitemID].ToString();
                // 依次添加subitems，此处只设置Text
                item.SubItems.Add(dt.Rows[i][SubitemName.subitemName].ToString());
                item.SubItems.Add(dt.Rows[i][SubitemName.subitemPrice].ToString());
                item.SubItems.Add(dt.Rows[i][SubitemName.subitemDiscount].ToString());
                item.SubItems.Add(dt.Rows[i][SubitemName.subitemExtraNote].ToString());
                item.SubItems.Add(dt.Rows[i][SubitemName.subitemCount].ToString());
                // 设置Subitem的Name属性便于索引
                setListViewItem(item);
                if ((i & 1) == 0)
                {
                    item.BackColor = Color.Azure;
                }
                listViewResult.Items.Add(item);
            }
        }

        /// <summary>
        /// 设置Subitem的Name属性便于索引
        /// </summary>
        /// <param name="_item"></param>
        private void setListViewItem(ListViewItem _item)
        {
            _item.SubItems[1].Name = SubitemName.subitemName;
            _item.SubItems[2].Name = SubitemName.subitemPrice;
            _item.SubItems[3].Name = SubitemName.subitemDiscount;
            _item.SubItems[4].Name = SubitemName.subitemExtraNote;
            _item.SubItems[5].Name = SubitemName.subitemCount;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listViewResult_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                Point tmpPoint = listViewResult.PointToClient(Cursor.Position);
                ListViewItem item = listViewResult.HitTest(tmpPoint).Item;
                if (item != null)
                {
                    // MessageBox.Show(item.Name);
                    lviReturn = item;
                    this.Close();
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
    }
}
