using System;
using System.Collections;
using System.Windows.Forms;
using Model;

namespace SMM
{
    /// <summary>
    /// 售货员结账窗体
    /// </summary>
    public partial class frmPaymentTermial : SMM.frmMain
    {
        //保存当前账单的收入
        decimal price = 0;
        //保存当前账单
        ArrayList payList = null;

        /// <summary>
        /// 无参构造函数
        /// 内容初始化为测试模式
        /// 需要参数的内容为null
        /// </summary>
        public frmPaymentTermial()
        {
            labelTitle.Text = frmSetting.paymentTitle;
            user = new User("pirat", -1, "-1") ;
            supermarket = null;
            InitializeComponent();
        }

        /// <summary>
        /// 载入信息
        /// </summary>
        /// <param name="_user"></param>
        /// <param name="_supermarket"></param>
        public frmPaymentTermial(Model.User _user, Model.Supermarket _supermarket)
            :base(_user, _supermarket)
        {
            labelTitle.Text = frmSetting.paymentTitle;
            InitializeComponent();
        }

        /// <summary>
        /// 填充待支付表格
        /// </summary>
        private void setPayList()
        {
            if (payList != null)
            {
                foreach (ListViewItem lvi in payList)
                {
                    if (listViewPurchase.FindItemWithText(lvi.Text) != null)
                    {
                        MessageBox.Show(lvi.Text + "已存在");
                        continue;
                    }
                    lvi.SubItems.Add("0");
                    lvi.SubItems[lvi.SubItems.Count - 1].Name = SubitemName.payCount;
                    listViewPurchase.Items.Add(lvi);
                }

                payList.Clear();
            }
        }


        /// <summary>
        /// 进入添加商品窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            frmSelectItem fsi = new frmSelectItem();
            fsi.Owner = this;
            fsi.ShowDialog();
            payList = fsi.ItemList;

            setPayList();
            countPrice();

            reportNotice(false);
        }

        /// <summary>
        /// 设置表头
        /// 在默认表头的末尾添加购买数量这一列
        /// </summary>
        private void setTableHead()
        {
            listViewPurchase.Columns[listViewPurchase.Columns.Count - 1].Width = 0;
            listViewPurchase.Columns.Add(SubitemName.payCount, "购买数量", -2);
            listViewPurchase.Columns[listViewPurchase.Columns.Count - 1].TextAlign =  HorizontalAlignment.Center;
        }

        /// <summary>
        /// 设置用户名和超市名
        /// </summary>
        private void setWelcome()
        {
            if (user != null && supermarket != null)
            {
                labelWelcome.Text += user.UserID;
                labelCurrentSupermarket.Text += supermarket.Name;
            }
            else
            {
                labelWelcome.Text += "超级管理员";
                labelCurrentSupermarket.Text += "测试模式";
            }
        }

        /// <summary>
        /// 加载窗体时
        /// 设置表格属性
        /// 设置欢迎信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPaymentTermial_Load(object sender, EventArgs e)
        {
            frmClassSetting.setListView(listViewPurchase);

            // 设置表头
            try
            {
                object[] paras = new object[1];
                paras[0] = listViewPurchase;
                if (!BLL.MerchandiseManagement.delegateHelper(typeof(frmMerchandiseManagement).AssemblyQualifiedName, "setTableHead", paras))
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
            setTableHead();
            setWelcome();

            this.btnSubmitMain.Text = "提交支付";
            AnimateWindow(this.Handle, 200, AnimateWindowCV.AW_BLEND | AnimateWindowCV.AW_ACTIVATE);
        }

        /// <summary>
        /// 计算总价
        /// Subitems[3]是价格
        /// Subitems[5]是购买数量
        /// </summary>
        private void countPrice()
        {
            price = 0;
            foreach (ListViewItem lvi in listViewPurchase.Items)
            {
                int discount = int.Parse(lvi.SubItems[SubitemName.subitemDiscount].Text);
                
                if (lvi.SubItems[SubitemName.payCount].Text.Trim() != "")
                {
                    if (discount == -1)
                    {
                        price += decimal.Parse(lvi.SubItems[SubitemName.subitemPrice].Text) * int.Parse(lvi.SubItems[SubitemName.payCount].Text);
                    }
                    else
                    {
                        price += decimal.Parse(lvi.SubItems[SubitemName.subitemPrice].Text) * int.Parse(lvi.SubItems[SubitemName.payCount].Text) * discount / 100;
                    }
                }
            }
            labelPrice.Text = Math.Round(price, 2).ToString();
        }

        /// <summary>
        /// 修改所有选中商品的购买数量
        /// 数量的列用SubItems[5]关联
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetNum_Click(object sender, EventArgs e)
        {
            if (txtSetNum.Text != "")
            {
                int num = 0;
                try
                {
                    num = int.Parse(txtSetNum.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("请输入数字");
                    return;
                }

                if (num < 0)
                {
                    MessageBox.Show("数量必须大于0");
                    return;
                }

                for (int i = 0; i < listViewPurchase.SelectedItems.Count; i++)
                {
                    int currentCount = BLL.Payment.getCurrentCount(listViewPurchase.SelectedItems[0].Name);
                    if (num > currentCount)
                    {
                        MessageBox.Show("库存量不足，无法设置数量");
                        listViewPurchase.SelectedItems[i].Selected = true;
                        listViewPurchase.SelectedItems[i].Focused = true;
                        listViewPurchase.Focus();
                        return;
                    }
                    listViewPurchase.SelectedItems[i].SubItems[SubitemName.payCount].Text = txtSetNum.Text;
                }
            }
            // 计算物品的金额
            countPrice();
        }

        /// <summary>
        /// 购物列表鼠标双击事件
        /// 暂时不用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewPurchase_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        /// <summary>
        /// 提示当前操作
        /// 返回操作结果
        /// </summary>
        /// <param name="_flag"></param>
        private void reportNotice(bool _flag = false)
        {
            if (_flag == true)
            {
                labelNoticeMain.Text = "处理成功";
            }
            else
            {
                labelNoticeMain.Text = "当前操作：结账";
            }
        }

        /// <summary>
        /// 清除购物列表
        /// </summary>
        private void clearPayList()
        {
            listViewPurchase.Items.Clear();
            txtSetNum.Text = "";
            labelPrice.Text = "0.00";
        }

        /// <summary>
        /// 清除购物栏按钮单击事件
        /// 清除购物列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearPayList_Click(object sender, EventArgs e)
        {
            clearPayList();
        }

        /// <summary>
        /// 提交按钮单击事件
        /// 提交钱数
        /// 更新UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmitMain_Click(object sender, EventArgs e)
        {
            // 处理数据库
            // 加钱
            decimal money = decimal.Parse(labelPrice.Text);
            reportNotice(BLL.Payment.addMoney(supermarket.Name, money));
            // 贩卖记录
            foreach (ListViewItem lvi in listViewPurchase.Items)
            {
                BLL.Payment.addPurchaseLog(user.UserID, lvi.SubItems[lvi.Name].Text, int.Parse(lvi.SubItems[SubitemName.subitemDiscount].Text),
                    decimal.Parse(lvi.SubItems[SubitemName.subitemPrice].Text), int.Parse(lvi.SubItems[SubitemName.payCount].Text), lvi.SubItems[SubitemName.subitemExtraNote].Text);
                BLL.Payment.setItemCount(lvi.Name, int.Parse(lvi.SubItems[SubitemName.payCount].Text));
            }

            // 更新UI
            labelPrice.Text = "——";
            listViewPurchase.Items.Clear();
            txtSetNum.Clear();
        }

        /// <summary>
        /// 按下Enter键设置数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSetNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSetNum_Click(sender, e);
            }
        }
    }
}
