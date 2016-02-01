namespace SMM
{
    partial class frmMerchandiseManagement
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
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.cmbChooseClass = new System.Windows.Forms.ComboBox();
            this.labelChooseClass = new System.Windows.Forms.Label();
            this.listViewItemList = new System.Windows.Forms.ListView();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.txtItemPrice = new System.Windows.Forms.TextBox();
            this.txtItemDiscount = new System.Windows.Forms.TextBox();
            this.txtExtraNote = new System.Windows.Forms.TextBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnUndoInsert = new System.Windows.Forms.Button();
            this.labelCurrentSupermarket = new System.Windows.Forms.Label();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.btnUndoDelete = new System.Windows.Forms.Button();
            this.txtPutIn = new System.Windows.Forms.TextBox();
            this.btnPutIn = new System.Windows.Forms.Button();
            this.btnOutBound = new System.Windows.Forms.Button();
            this.labelSetCount = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.picBatchExpand = new System.Windows.Forms.PictureBox();
            this.gbBatchProcess = new System.Windows.Forms.GroupBox();
            this.labelBatchNotice = new System.Windows.Forms.Label();
            this.bgwLoadItemList = new System.ComponentModel.BackgroundWorker();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReloadTable = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBatchExpand)).BeginInit();
            this.gbBatchProcess.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelNoticeMain
            // 
            this.labelNoticeMain.Size = new System.Drawing.Size(113, 12);
            this.labelNoticeMain.Text = "当前操作：管理系统";
            // 
            // btnSubmitMain
            // 
            this.btnSubmitMain.Font = new System.Drawing.Font("华文细黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmitMain.Click += new System.EventHandler(this.btnSubmitMain_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.LinkColor = System.Drawing.Color.MediumSeaGreen;
            this.linkLabel1.Location = new System.Drawing.Point(438, 49);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(77, 12);
            this.linkLabel1.TabIndex = 36;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "进入类别管理";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // cmbChooseClass
            // 
            this.cmbChooseClass.FormattingEnabled = true;
            this.cmbChooseClass.Location = new System.Drawing.Point(297, 45);
            this.cmbChooseClass.Name = "cmbChooseClass";
            this.cmbChooseClass.Size = new System.Drawing.Size(121, 20);
            this.cmbChooseClass.TabIndex = 32;
            this.cmbChooseClass.DropDown += new System.EventHandler(this.cmbChooseClass_DropDown);
            this.cmbChooseClass.SelectionChangeCommitted += new System.EventHandler(this.cmbChooseClass_SelectionChangeCommitted);
            // 
            // labelChooseClass
            // 
            this.labelChooseClass.AutoSize = true;
            this.labelChooseClass.BackColor = System.Drawing.Color.Transparent;
            this.labelChooseClass.Location = new System.Drawing.Point(235, 49);
            this.labelChooseClass.Name = "labelChooseClass";
            this.labelChooseClass.Size = new System.Drawing.Size(65, 12);
            this.labelChooseClass.TabIndex = 31;
            this.labelChooseClass.Text = "选择类别：";
            // 
            // listViewItemList
            // 
            this.listViewItemList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewItemList.Location = new System.Drawing.Point(40, 73);
            this.listViewItemList.Name = "listViewItemList";
            this.listViewItemList.Size = new System.Drawing.Size(475, 245);
            this.listViewItemList.TabIndex = 30;
            this.listViewItemList.UseCompatibleStateImageBehavior = false;
            this.listViewItemList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewItemList_MouseDoubleClick);
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(40, 328);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(100, 21);
            this.txtItemName.TabIndex = 37;
            // 
            // txtItemPrice
            // 
            this.txtItemPrice.Location = new System.Drawing.Point(140, 328);
            this.txtItemPrice.Name = "txtItemPrice";
            this.txtItemPrice.Size = new System.Drawing.Size(90, 21);
            this.txtItemPrice.TabIndex = 38;
            this.txtItemPrice.Leave += new System.EventHandler(this.txtItemPrice_Leave);
            // 
            // txtItemDiscount
            // 
            this.txtItemDiscount.Location = new System.Drawing.Point(230, 328);
            this.txtItemDiscount.Name = "txtItemDiscount";
            this.txtItemDiscount.Size = new System.Drawing.Size(90, 21);
            this.txtItemDiscount.TabIndex = 39;
            // 
            // txtExtraNote
            // 
            this.txtExtraNote.Location = new System.Drawing.Point(320, 328);
            this.txtExtraNote.Name = "txtExtraNote";
            this.txtExtraNote.Size = new System.Drawing.Size(100, 21);
            this.txtExtraNote.TabIndex = 40;
            // 
            // btnInsert
            // 
            this.btnInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInsert.Location = new System.Drawing.Point(521, 324);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 27);
            this.btnInsert.TabIndex = 41;
            this.btnInsert.Text = "添加商品";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Tan;
            this.label3.Location = new System.Drawing.Point(38, 362);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 20);
            this.label3.TabIndex = 48;
            this.label3.Text = "双击商品进行修改";
            // 
            // btnUndoInsert
            // 
            this.btnUndoInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUndoInsert.Location = new System.Drawing.Point(602, 324);
            this.btnUndoInsert.Name = "btnUndoInsert";
            this.btnUndoInsert.Size = new System.Drawing.Size(75, 27);
            this.btnUndoInsert.TabIndex = 49;
            this.btnUndoInsert.Text = "取消修改";
            this.btnUndoInsert.UseVisualStyleBackColor = true;
            this.btnUndoInsert.Click += new System.EventHandler(this.btnUndoInsert_Click);
            // 
            // labelCurrentSupermarket
            // 
            this.labelCurrentSupermarket.AutoSize = true;
            this.labelCurrentSupermarket.BackColor = System.Drawing.Color.Transparent;
            this.labelCurrentSupermarket.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelCurrentSupermarket.Location = new System.Drawing.Point(39, 391);
            this.labelCurrentSupermarket.Name = "labelCurrentSupermarket";
            this.labelCurrentSupermarket.Size = new System.Drawing.Size(77, 14);
            this.labelCurrentSupermarket.TabIndex = 51;
            this.labelCurrentSupermarket.Text = "当前超市：";
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.BackColor = System.Drawing.Color.Transparent;
            this.labelWelcome.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelWelcome.Location = new System.Drawing.Point(67, 409);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(49, 14);
            this.labelWelcome.TabIndex = 50;
            this.labelWelcome.Text = "欢迎：";
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteItem.Location = new System.Drawing.Point(521, 291);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(75, 27);
            this.btnDeleteItem.TabIndex = 52;
            this.btnDeleteItem.Text = "删除商品";
            this.btnDeleteItem.UseVisualStyleBackColor = true;
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // btnUndoDelete
            // 
            this.btnUndoDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUndoDelete.Location = new System.Drawing.Point(602, 291);
            this.btnUndoDelete.Name = "btnUndoDelete";
            this.btnUndoDelete.Size = new System.Drawing.Size(75, 27);
            this.btnUndoDelete.TabIndex = 53;
            this.btnUndoDelete.Text = "撤销删除";
            this.btnUndoDelete.UseVisualStyleBackColor = true;
            this.btnUndoDelete.Click += new System.EventHandler(this.btnUndoDelete_Click);
            // 
            // txtPutIn
            // 
            this.txtPutIn.Location = new System.Drawing.Point(21, 56);
            this.txtPutIn.Name = "txtPutIn";
            this.txtPutIn.Size = new System.Drawing.Size(100, 21);
            this.txtPutIn.TabIndex = 54;
            // 
            // btnPutIn
            // 
            this.btnPutIn.Location = new System.Drawing.Point(33, 130);
            this.btnPutIn.Name = "btnPutIn";
            this.btnPutIn.Size = new System.Drawing.Size(75, 23);
            this.btnPutIn.TabIndex = 55;
            this.btnPutIn.Text = "入库";
            this.btnPutIn.UseVisualStyleBackColor = true;
            this.btnPutIn.Click += new System.EventHandler(this.btnPutIn_Click);
            // 
            // btnOutBound
            // 
            this.btnOutBound.Location = new System.Drawing.Point(33, 100);
            this.btnOutBound.Name = "btnOutBound";
            this.btnOutBound.Size = new System.Drawing.Size(75, 23);
            this.btnOutBound.TabIndex = 56;
            this.btnOutBound.Text = "出库";
            this.btnOutBound.UseVisualStyleBackColor = true;
            this.btnOutBound.Click += new System.EventHandler(this.btnOutBound_Click);
            // 
            // labelSetCount
            // 
            this.labelSetCount.AutoSize = true;
            this.labelSetCount.BackColor = System.Drawing.Color.Transparent;
            this.labelSetCount.Location = new System.Drawing.Point(19, 31);
            this.labelSetCount.Name = "labelSetCount";
            this.labelSetCount.Size = new System.Drawing.Size(65, 12);
            this.labelSetCount.TabIndex = 57;
            this.labelSetCount.Text = "设置数量：";
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(420, 328);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(95, 21);
            this.txtCount.TabIndex = 41;
            // 
            // picBatchExpand
            // 
            this.picBatchExpand.BackColor = System.Drawing.Color.Transparent;
            this.picBatchExpand.BackgroundImage = global::SMM.Properties.Resources.expandImg;
            this.picBatchExpand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picBatchExpand.Location = new System.Drawing.Point(653, 86);
            this.picBatchExpand.Name = "picBatchExpand";
            this.picBatchExpand.Size = new System.Drawing.Size(21, 21);
            this.picBatchExpand.TabIndex = 42;
            this.picBatchExpand.TabStop = false;
            // 
            // gbBatchProcess
            // 
            this.gbBatchProcess.BackColor = System.Drawing.Color.Transparent;
            this.gbBatchProcess.Controls.Add(this.labelSetCount);
            this.gbBatchProcess.Controls.Add(this.txtPutIn);
            this.gbBatchProcess.Controls.Add(this.btnOutBound);
            this.gbBatchProcess.Controls.Add(this.btnPutIn);
            this.gbBatchProcess.Location = new System.Drawing.Point(525, 95);
            this.gbBatchProcess.Name = "gbBatchProcess";
            this.gbBatchProcess.Size = new System.Drawing.Size(155, 175);
            this.gbBatchProcess.TabIndex = 43;
            this.gbBatchProcess.TabStop = false;
            this.gbBatchProcess.Visible = false;
            // 
            // labelBatchNotice
            // 
            this.labelBatchNotice.BackColor = System.Drawing.Color.Transparent;
            this.labelBatchNotice.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelBatchNotice.Location = new System.Drawing.Point(549, 84);
            this.labelBatchNotice.Name = "labelBatchNotice";
            this.labelBatchNotice.Size = new System.Drawing.Size(130, 25);
            this.labelBatchNotice.TabIndex = 0;
            this.labelBatchNotice.Text = "出入库管理";
            this.labelBatchNotice.Click += new System.EventHandler(this.labelBatchNotice_Click);
            // 
            // bgwLoadItemList
            // 
            this.bgwLoadItemList.WorkerReportsProgress = true;
            this.bgwLoadItemList.WorkerSupportsCancellation = true;
            this.bgwLoadItemList.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwLoadItemList_DoWork);
            this.bgwLoadItemList.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwLoadItemList_RunWorkerCompleted);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(320, 363);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 21);
            this.txtSearch.TabIndex = 54;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(426, 362);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 55;
            this.btnSearch.Text = "按名称搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReloadTable
            // 
            this.btnReloadTable.Location = new System.Drawing.Point(237, 361);
            this.btnReloadTable.Name = "btnReloadTable";
            this.btnReloadTable.Size = new System.Drawing.Size(75, 23);
            this.btnReloadTable.TabIndex = 56;
            this.btnReloadTable.Text = "刷新表格";
            this.btnReloadTable.UseVisualStyleBackColor = true;
            this.btnReloadTable.Click += new System.EventHandler(this.btnReloadTable_Click);
            // 
            // frmMerchandiseManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(703, 461);
            this.Controls.Add(this.btnReloadTable);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.btnUndoDelete);
            this.Controls.Add(this.btnDeleteItem);
            this.Controls.Add(this.labelCurrentSupermarket);
            this.Controls.Add(this.labelWelcome);
            this.Controls.Add(this.btnUndoInsert);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.picBatchExpand);
            this.Controls.Add(this.labelBatchNotice);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.txtExtraNote);
            this.Controls.Add(this.txtItemDiscount);
            this.Controls.Add(this.txtItemPrice);
            this.Controls.Add(this.txtItemName);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.cmbChooseClass);
            this.Controls.Add(this.labelChooseClass);
            this.Controls.Add(this.listViewItemList);
            this.Controls.Add(this.gbBatchProcess);
            this.MaximumSize = new System.Drawing.Size(1281, 768);
            this.Name = "frmMerchandiseManagement";
            this.Load += new System.EventHandler(this.frmMerchandiseManagement_Load);
            this.Resize += new System.EventHandler(this.frmMerchandiseManagement_Resize);
            this.Controls.SetChildIndex(this.gbBatchProcess, 0);
            this.Controls.SetChildIndex(this.listViewItemList, 0);
            this.Controls.SetChildIndex(this.labelChooseClass, 0);
            this.Controls.SetChildIndex(this.cmbChooseClass, 0);
            this.Controls.SetChildIndex(this.linkLabel1, 0);
            this.Controls.SetChildIndex(this.txtItemName, 0);
            this.Controls.SetChildIndex(this.txtItemPrice, 0);
            this.Controls.SetChildIndex(this.txtItemDiscount, 0);
            this.Controls.SetChildIndex(this.txtExtraNote, 0);
            this.Controls.SetChildIndex(this.btnInsert, 0);
            this.Controls.SetChildIndex(this.labelBatchNotice, 0);
            this.Controls.SetChildIndex(this.picBatchExpand, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.btnUndoInsert, 0);
            this.Controls.SetChildIndex(this.labelWelcome, 0);
            this.Controls.SetChildIndex(this.labelCurrentSupermarket, 0);
            this.Controls.SetChildIndex(this.btnDeleteItem, 0);
            this.Controls.SetChildIndex(this.btnUndoDelete, 0);
            this.Controls.SetChildIndex(this.txtCount, 0);
            this.Controls.SetChildIndex(this.btnSubmitMain, 0);
            this.Controls.SetChildIndex(this.labelNoticeMain, 0);
            this.Controls.SetChildIndex(this.labelTitle, 0);
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.btnReloadTable, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picBatchExpand)).EndInit();
            this.gbBatchProcess.ResumeLayout(false);
            this.gbBatchProcess.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ComboBox cmbChooseClass;
        private System.Windows.Forms.Label labelChooseClass;
        private System.Windows.Forms.ListView listViewItemList;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.TextBox txtItemPrice;
        private System.Windows.Forms.TextBox txtItemDiscount;
        private System.Windows.Forms.TextBox txtExtraNote;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnUndoInsert;
        private System.Windows.Forms.Label labelCurrentSupermarket;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.Button btnUndoDelete;
        private System.Windows.Forms.TextBox txtPutIn;
        private System.Windows.Forms.Button btnPutIn;
        private System.Windows.Forms.Button btnOutBound;
        private System.Windows.Forms.Label labelSetCount;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.PictureBox picBatchExpand;
        private System.Windows.Forms.GroupBox gbBatchProcess;
        private System.Windows.Forms.Label labelBatchNotice;
        private System.ComponentModel.BackgroundWorker bgwLoadItemList;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReloadTable;
    }
}
