using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;

namespace SMM
{
    public partial class frmCheckpurchaseLog : SMM.frmMain
    {
        public frmCheckpurchaseLog()
        {
            InitializeComponent();
        }

        public frmCheckpurchaseLog(User _user, Supermarket _smk) : base(_user, _smk)
        {
            InitializeComponent();
        }

        private void frmCheckpurchaseLog_Load(object sender, EventArgs e)
        {
            // TODO:  这行代码将数据加载到表“supermarketManagementSystemDataSet.purchaseLog”中。您可以根据需要移动或删除它。
            this.purchaseLogTableAdapter.Fill(this.supermarketManagementSystemDataSet.purchaseLog);
            int width = 0;
            for (int i = 0; i < this.dgvPurchaseLog.Columns.Count; i++)//对于DataGridView的每一个列都调整
            {
                this.dgvPurchaseLog.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells);//将每一列都调整为自动适应模式
                width += this.dgvPurchaseLog.Columns[i].Width;//记录整个DataGridView的宽度
            }
            if (width > this.dgvPurchaseLog.Size.Width)//判断调整后的宽度与原来设定的宽度的关系，如果是调整后的宽度大于原来设定的宽度，则将DataGridView的列自动调整模式设置为显示的列即可，如果是小于原来设定的宽度，将模式改为填充。
            {
                this.dgvPurchaseLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            else
            {
                this.dgvPurchaseLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            labelCurrentSupermarket.Text += supermarket.Name;
            labelWelcome.Text += user.UserID;
        }

        private void btnSubmitMain_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
