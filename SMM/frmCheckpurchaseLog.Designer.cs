namespace SMM
{
    partial class frmCheckpurchaseLog
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPurchaseLog = new System.Windows.Forms.DataGridView();
            this.userIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchaseContentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchaseDiscountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchaseCostDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchaseCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchaseTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.putchaseNoteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchaseLogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.supermarketManagementSystemDataSet = new SMM.SupermarketManagementSystemDataSet();
            this.purchaseLogTableAdapter = new SMM.SupermarketManagementSystemDataSetTableAdapters.purchaseLogTableAdapter();
            this.labelCurrentSupermarket = new System.Windows.Forms.Label();
            this.labelWelcome = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseLogBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supermarketManagementSystemDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Size = new System.Drawing.Size(191, 38);
            this.labelTitle.Text = "查看购买日志";
            // 
            // labelNoticeMain
            // 
            this.labelNoticeMain.Location = new System.Drawing.Point(241, 396);
            // 
            // btnSubmitMain
            // 
            this.btnSubmitMain.Location = new System.Drawing.Point(544, 386);
            this.btnSubmitMain.Text = "退出";
            this.btnSubmitMain.Click += new System.EventHandler(this.btnSubmitMain_Click);
            // 
            // dgvPurchaseLog
            // 
            this.dgvPurchaseLog.AllowUserToAddRows = false;
            this.dgvPurchaseLog.AllowUserToDeleteRows = false;
            this.dgvPurchaseLog.AllowUserToOrderColumns = true;
            this.dgvPurchaseLog.AllowUserToResizeRows = false;
            this.dgvPurchaseLog.AutoGenerateColumns = false;
            this.dgvPurchaseLog.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPurchaseLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPurchaseLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchaseLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userIDDataGridViewTextBoxColumn,
            this.purchaseContentDataGridViewTextBoxColumn,
            this.purchaseDiscountDataGridViewTextBoxColumn,
            this.purchaseCostDataGridViewTextBoxColumn,
            this.purchaseCountDataGridViewTextBoxColumn,
            this.purchaseTimeDataGridViewTextBoxColumn,
            this.putchaseNoteDataGridViewTextBoxColumn});
            this.dgvPurchaseLog.DataSource = this.purchaseLogBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPurchaseLog.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPurchaseLog.Location = new System.Drawing.Point(12, 78);
            this.dgvPurchaseLog.Name = "dgvPurchaseLog";
            this.dgvPurchaseLog.ReadOnly = true;
            this.dgvPurchaseLog.RowHeadersVisible = false;
            this.dgvPurchaseLog.RowTemplate.Height = 23;
            this.dgvPurchaseLog.Size = new System.Drawing.Size(679, 301);
            this.dgvPurchaseLog.TabIndex = 50;
            // 
            // userIDDataGridViewTextBoxColumn
            // 
            this.userIDDataGridViewTextBoxColumn.DataPropertyName = "userID";
            this.userIDDataGridViewTextBoxColumn.HeaderText = "用户名";
            this.userIDDataGridViewTextBoxColumn.Name = "userIDDataGridViewTextBoxColumn";
            this.userIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.userIDDataGridViewTextBoxColumn.Width = 90;
            // 
            // purchaseContentDataGridViewTextBoxColumn
            // 
            this.purchaseContentDataGridViewTextBoxColumn.DataPropertyName = "purchaseContent";
            this.purchaseContentDataGridViewTextBoxColumn.HeaderText = "物品";
            this.purchaseContentDataGridViewTextBoxColumn.Name = "purchaseContentDataGridViewTextBoxColumn";
            this.purchaseContentDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // purchaseDiscountDataGridViewTextBoxColumn
            // 
            this.purchaseDiscountDataGridViewTextBoxColumn.DataPropertyName = "purchaseDiscount";
            this.purchaseDiscountDataGridViewTextBoxColumn.HeaderText = "折扣";
            this.purchaseDiscountDataGridViewTextBoxColumn.Name = "purchaseDiscountDataGridViewTextBoxColumn";
            this.purchaseDiscountDataGridViewTextBoxColumn.ReadOnly = true;
            this.purchaseDiscountDataGridViewTextBoxColumn.Width = 60;
            // 
            // purchaseCostDataGridViewTextBoxColumn
            // 
            this.purchaseCostDataGridViewTextBoxColumn.DataPropertyName = "purchaseCost";
            this.purchaseCostDataGridViewTextBoxColumn.HeaderText = "金额";
            this.purchaseCostDataGridViewTextBoxColumn.Name = "purchaseCostDataGridViewTextBoxColumn";
            this.purchaseCostDataGridViewTextBoxColumn.ReadOnly = true;
            this.purchaseCostDataGridViewTextBoxColumn.Width = 60;
            // 
            // purchaseCountDataGridViewTextBoxColumn
            // 
            this.purchaseCountDataGridViewTextBoxColumn.DataPropertyName = "purchaseCount";
            this.purchaseCountDataGridViewTextBoxColumn.HeaderText = "计数";
            this.purchaseCountDataGridViewTextBoxColumn.Name = "purchaseCountDataGridViewTextBoxColumn";
            this.purchaseCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.purchaseCountDataGridViewTextBoxColumn.Width = 60;
            // 
            // purchaseTimeDataGridViewTextBoxColumn
            // 
            this.purchaseTimeDataGridViewTextBoxColumn.DataPropertyName = "purchaseTime";
            this.purchaseTimeDataGridViewTextBoxColumn.HeaderText = "操作时间";
            this.purchaseTimeDataGridViewTextBoxColumn.Name = "purchaseTimeDataGridViewTextBoxColumn";
            this.purchaseTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.purchaseTimeDataGridViewTextBoxColumn.Width = 120;
            // 
            // putchaseNoteDataGridViewTextBoxColumn
            // 
            this.putchaseNoteDataGridViewTextBoxColumn.DataPropertyName = "putchaseNote";
            this.putchaseNoteDataGridViewTextBoxColumn.HeaderText = "额外日志";
            this.putchaseNoteDataGridViewTextBoxColumn.Name = "putchaseNoteDataGridViewTextBoxColumn";
            this.putchaseNoteDataGridViewTextBoxColumn.ReadOnly = true;
            this.putchaseNoteDataGridViewTextBoxColumn.Width = 80;
            // 
            // purchaseLogBindingSource
            // 
            this.purchaseLogBindingSource.DataMember = "purchaseLog";
            this.purchaseLogBindingSource.DataSource = this.supermarketManagementSystemDataSet;
            // 
            // supermarketManagementSystemDataSet
            // 
            this.supermarketManagementSystemDataSet.DataSetName = "SupermarketManagementSystemDataSet";
            this.supermarketManagementSystemDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // purchaseLogTableAdapter
            // 
            this.purchaseLogTableAdapter.ClearBeforeFill = true;
            // 
            // labelCurrentSupermarket
            // 
            this.labelCurrentSupermarket.AutoSize = true;
            this.labelCurrentSupermarket.BackColor = System.Drawing.Color.Transparent;
            this.labelCurrentSupermarket.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelCurrentSupermarket.Location = new System.Drawing.Point(230, 35);
            this.labelCurrentSupermarket.Name = "labelCurrentSupermarket";
            this.labelCurrentSupermarket.Size = new System.Drawing.Size(77, 14);
            this.labelCurrentSupermarket.TabIndex = 52;
            this.labelCurrentSupermarket.Text = "当前超市：";
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.BackColor = System.Drawing.Color.Transparent;
            this.labelWelcome.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelWelcome.Location = new System.Drawing.Point(258, 53);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(49, 14);
            this.labelWelcome.TabIndex = 51;
            this.labelWelcome.Text = "欢迎：";
            // 
            // frmCheckpurchaseLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(703, 461);
            this.Controls.Add(this.labelCurrentSupermarket);
            this.Controls.Add(this.labelWelcome);
            this.Controls.Add(this.dgvPurchaseLog);
            this.MaximumSize = new System.Drawing.Size(1288, 768);
            this.Name = "frmCheckpurchaseLog";
            this.Load += new System.EventHandler(this.frmCheckpurchaseLog_Load);
            this.Controls.SetChildIndex(this.dgvPurchaseLog, 0);
            this.Controls.SetChildIndex(this.labelTitle, 0);
            this.Controls.SetChildIndex(this.btnSubmitMain, 0);
            this.Controls.SetChildIndex(this.labelNoticeMain, 0);
            this.Controls.SetChildIndex(this.labelWelcome, 0);
            this.Controls.SetChildIndex(this.labelCurrentSupermarket, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseLogBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supermarketManagementSystemDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPurchaseLog;
        private SupermarketManagementSystemDataSet supermarketManagementSystemDataSet;
        private System.Windows.Forms.BindingSource purchaseLogBindingSource;
        private SupermarketManagementSystemDataSetTableAdapters.purchaseLogTableAdapter purchaseLogTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn userIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchaseContentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchaseDiscountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchaseCostDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchaseCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchaseTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn putchaseNoteDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label labelCurrentSupermarket;
        private System.Windows.Forms.Label labelWelcome;
    }
}
