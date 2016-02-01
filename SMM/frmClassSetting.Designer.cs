namespace SMM
{
    partial class frmClassSetting
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
            this.listViewClassSetting = new System.Windows.Forms.ListView();
            this.txtClassID = new System.Windows.Forms.TextBox();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.rtxtClassNote = new System.Windows.Forms.RichTextBox();
            this.labelClassID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddClass = new System.Windows.Forms.Button();
            this.btnDeleteClass = new System.Windows.Forms.Button();
            this.listViewForDelete = new System.Windows.Forms.ListView();
            this.btnRefreshTable = new System.Windows.Forms.Button();
            this.btnUndoDelete = new System.Windows.Forms.Button();
            this.labelCurrentSupermarket = new System.Windows.Forms.Label();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.txtFindClass = new System.Windows.Forms.TextBox();
            this.btnFindClass = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSubmitMain
            // 
            this.btnSubmitMain.Click += new System.EventHandler(this.btnSubmitMain_Click);
            // 
            // listViewClassSetting
            // 
            this.listViewClassSetting.Location = new System.Drawing.Point(155, 89);
            this.listViewClassSetting.Name = "listViewClassSetting";
            this.listViewClassSetting.Size = new System.Drawing.Size(315, 250);
            this.listViewClassSetting.TabIndex = 24;
            this.listViewClassSetting.UseCompatibleStateImageBehavior = false;
            this.listViewClassSetting.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewClassSetting_MouseClick);
            // 
            // txtClassID
            // 
            this.txtClassID.Location = new System.Drawing.Point(550, 89);
            this.txtClassID.MaxLength = 4;
            this.txtClassID.Name = "txtClassID";
            this.txtClassID.Size = new System.Drawing.Size(130, 21);
            this.txtClassID.TabIndex = 28;
            this.txtClassID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtClassID_KeyDown);
            // 
            // txtClassName
            // 
            this.txtClassName.Location = new System.Drawing.Point(550, 116);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(130, 21);
            this.txtClassName.TabIndex = 29;
            // 
            // rtxtClassNote
            // 
            this.rtxtClassNote.Location = new System.Drawing.Point(491, 153);
            this.rtxtClassNote.Name = "rtxtClassNote";
            this.rtxtClassNote.Size = new System.Drawing.Size(190, 140);
            this.rtxtClassNote.TabIndex = 30;
            this.rtxtClassNote.Text = "类别注释：";
            this.rtxtClassNote.Enter += new System.EventHandler(this.rtxtClassNote_Enter);
            // 
            // labelClassID
            // 
            this.labelClassID.AutoSize = true;
            this.labelClassID.BackColor = System.Drawing.Color.Transparent;
            this.labelClassID.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelClassID.Location = new System.Drawing.Point(490, 93);
            this.labelClassID.Name = "labelClassID";
            this.labelClassID.Size = new System.Drawing.Size(65, 12);
            this.labelClassID.TabIndex = 31;
            this.labelClassID.Text = "类别编号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(490, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 32;
            this.label1.Text = "类别名称：";
            // 
            // btnAddClass
            // 
            this.btnAddClass.Location = new System.Drawing.Point(606, 306);
            this.btnAddClass.Name = "btnAddClass";
            this.btnAddClass.Size = new System.Drawing.Size(75, 30);
            this.btnAddClass.TabIndex = 33;
            this.btnAddClass.Text = "添加一个类";
            this.btnAddClass.UseVisualStyleBackColor = true;
            this.btnAddClass.Click += new System.EventHandler(this.btnAddClass_Click);
            // 
            // btnDeleteClass
            // 
            this.btnDeleteClass.Location = new System.Drawing.Point(492, 306);
            this.btnDeleteClass.Name = "btnDeleteClass";
            this.btnDeleteClass.Size = new System.Drawing.Size(100, 30);
            this.btnDeleteClass.TabIndex = 34;
            this.btnDeleteClass.Text = "删除选中的类";
            this.btnDeleteClass.UseVisualStyleBackColor = true;
            this.btnDeleteClass.Click += new System.EventHandler(this.btnDeleteClass_Click);
            // 
            // listViewForDelete
            // 
            this.listViewForDelete.Location = new System.Drawing.Point(27, 89);
            this.listViewForDelete.Name = "listViewForDelete";
            this.listViewForDelete.Size = new System.Drawing.Size(110, 250);
            this.listViewForDelete.TabIndex = 35;
            this.listViewForDelete.UseCompatibleStateImageBehavior = false;
            // 
            // btnRefreshTable
            // 
            this.btnRefreshTable.Location = new System.Drawing.Point(384, 349);
            this.btnRefreshTable.Name = "btnRefreshTable";
            this.btnRefreshTable.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshTable.TabIndex = 36;
            this.btnRefreshTable.Text = "刷新表格";
            this.btnRefreshTable.UseVisualStyleBackColor = true;
            this.btnRefreshTable.Click += new System.EventHandler(this.btnRefreshTable_Click);
            // 
            // btnUndoDelete
            // 
            this.btnUndoDelete.Location = new System.Drawing.Point(40, 349);
            this.btnUndoDelete.Name = "btnUndoDelete";
            this.btnUndoDelete.Size = new System.Drawing.Size(75, 23);
            this.btnUndoDelete.TabIndex = 37;
            this.btnUndoDelete.Text = "撤销删除";
            this.btnUndoDelete.UseVisualStyleBackColor = true;
            this.btnUndoDelete.Click += new System.EventHandler(this.btnUndoDelete_Click);
            // 
            // labelCurrentSupermarket
            // 
            this.labelCurrentSupermarket.AutoSize = true;
            this.labelCurrentSupermarket.BackColor = System.Drawing.Color.Transparent;
            this.labelCurrentSupermarket.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelCurrentSupermarket.Location = new System.Drawing.Point(172, 37);
            this.labelCurrentSupermarket.Name = "labelCurrentSupermarket";
            this.labelCurrentSupermarket.Size = new System.Drawing.Size(77, 14);
            this.labelCurrentSupermarket.TabIndex = 39;
            this.labelCurrentSupermarket.Text = "当前超市：";
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.BackColor = System.Drawing.Color.Transparent;
            this.labelWelcome.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelWelcome.Location = new System.Drawing.Point(207, 55);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(49, 14);
            this.labelWelcome.TabIndex = 38;
            this.labelWelcome.Text = "欢迎：";
            // 
            // txtFindClass
            // 
            this.txtFindClass.Location = new System.Drawing.Point(156, 349);
            this.txtFindClass.Name = "txtFindClass";
            this.txtFindClass.Size = new System.Drawing.Size(100, 21);
            this.txtFindClass.TabIndex = 50;
            this.txtFindClass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFindClass_KeyDown);
            // 
            // btnFindClass
            // 
            this.btnFindClass.Location = new System.Drawing.Point(262, 349);
            this.btnFindClass.Name = "btnFindClass";
            this.btnFindClass.Size = new System.Drawing.Size(75, 23);
            this.btnFindClass.TabIndex = 51;
            this.btnFindClass.Text = "查找类别";
            this.btnFindClass.UseVisualStyleBackColor = true;
            this.btnFindClass.Click += new System.EventHandler(this.btnFindClass_Click);
            // 
            // frmClassSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.BackgroundImage = global::SMM.Properties.Resources.bgImg;
            this.ClientSize = new System.Drawing.Size(703, 461);
            this.Controls.Add(this.btnFindClass);
            this.Controls.Add(this.txtFindClass);
            this.Controls.Add(this.labelCurrentSupermarket);
            this.Controls.Add(this.labelWelcome);
            this.Controls.Add(this.btnUndoDelete);
            this.Controls.Add(this.btnRefreshTable);
            this.Controls.Add(this.listViewForDelete);
            this.Controls.Add(this.btnDeleteClass);
            this.Controls.Add(this.txtClassName);
            this.Controls.Add(this.txtClassID);
            this.Controls.Add(this.btnAddClass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelClassID);
            this.Controls.Add(this.rtxtClassNote);
            this.Controls.Add(this.listViewClassSetting);
            this.MaximumSize = new System.Drawing.Size(1281, 768);
            this.Name = "frmClassSetting";
            this.Load += new System.EventHandler(this.frmClassSetting_Load);
            this.Shown += new System.EventHandler(this.frmClassSetting_Shown);
            this.Controls.SetChildIndex(this.btnSubmitMain, 0);
            this.Controls.SetChildIndex(this.labelNoticeMain, 0);
            this.Controls.SetChildIndex(this.labelTitle, 0);
            this.Controls.SetChildIndex(this.listViewClassSetting, 0);
            this.Controls.SetChildIndex(this.rtxtClassNote, 0);
            this.Controls.SetChildIndex(this.labelClassID, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnAddClass, 0);
            this.Controls.SetChildIndex(this.txtClassID, 0);
            this.Controls.SetChildIndex(this.txtClassName, 0);
            this.Controls.SetChildIndex(this.btnDeleteClass, 0);
            this.Controls.SetChildIndex(this.listViewForDelete, 0);
            this.Controls.SetChildIndex(this.btnRefreshTable, 0);
            this.Controls.SetChildIndex(this.btnUndoDelete, 0);
            this.Controls.SetChildIndex(this.labelWelcome, 0);
            this.Controls.SetChildIndex(this.labelCurrentSupermarket, 0);
            this.Controls.SetChildIndex(this.txtFindClass, 0);
            this.Controls.SetChildIndex(this.btnFindClass, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewClassSetting;
        private System.Windows.Forms.TextBox txtClassID;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.RichTextBox rtxtClassNote;
        private System.Windows.Forms.Label labelClassID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddClass;
        private System.Windows.Forms.Button btnDeleteClass;
        private System.Windows.Forms.ListView listViewForDelete;
        private System.Windows.Forms.Button btnRefreshTable;
        private System.Windows.Forms.Button btnUndoDelete;
        private System.Windows.Forms.Label labelCurrentSupermarket;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.TextBox txtFindClass;
        private System.Windows.Forms.Button btnFindClass;
    }
}
