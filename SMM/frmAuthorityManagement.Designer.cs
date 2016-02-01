namespace SMM
{
    partial class frmAuthorityManagement
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
            this.listViewAuthority = new System.Windows.Forms.ListView();
            this.labelCurrentSupermarket = new System.Windows.Forms.Label();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.gbSetLevel = new System.Windows.Forms.GroupBox();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnSetSeller = new System.Windows.Forms.Button();
            this.btnSetAdmin = new System.Windows.Forms.Button();
            this.btnSetRoot = new System.Windows.Forms.Button();
            this.treeAuthority = new System.Windows.Forms.TreeView();
            this.txtFindUser = new System.Windows.Forms.TextBox();
            this.btnFindUser = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.gbSetLevel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSubmitMain
            // 
            this.btnSubmitMain.Click += new System.EventHandler(this.btnSubmitMain_Click);
            // 
            // listViewAuthority
            // 
            this.listViewAuthority.Location = new System.Drawing.Point(159, 82);
            this.listViewAuthority.Name = "listViewAuthority";
            this.listViewAuthority.Size = new System.Drawing.Size(320, 270);
            this.listViewAuthority.TabIndex = 23;
            this.listViewAuthority.UseCompatibleStateImageBehavior = false;
            // 
            // labelCurrentSupermarket
            // 
            this.labelCurrentSupermarket.AutoSize = true;
            this.labelCurrentSupermarket.BackColor = System.Drawing.Color.Transparent;
            this.labelCurrentSupermarket.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelCurrentSupermarket.Location = new System.Drawing.Point(179, 34);
            this.labelCurrentSupermarket.Name = "labelCurrentSupermarket";
            this.labelCurrentSupermarket.Size = new System.Drawing.Size(77, 14);
            this.labelCurrentSupermarket.TabIndex = 38;
            this.labelCurrentSupermarket.Text = "当前超市：";
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.BackColor = System.Drawing.Color.Transparent;
            this.labelWelcome.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelWelcome.Location = new System.Drawing.Point(207, 52);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(49, 14);
            this.labelWelcome.TabIndex = 37;
            this.labelWelcome.Text = "欢迎：";
            // 
            // gbSetLevel
            // 
            this.gbSetLevel.BackColor = System.Drawing.Color.Transparent;
            this.gbSetLevel.Controls.Add(this.btnDeleteUser);
            this.gbSetLevel.Controls.Add(this.btnSetSeller);
            this.gbSetLevel.Controls.Add(this.btnSetAdmin);
            this.gbSetLevel.Controls.Add(this.btnSetRoot);
            this.gbSetLevel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbSetLevel.Location = new System.Drawing.Point(499, 86);
            this.gbSetLevel.Name = "gbSetLevel";
            this.gbSetLevel.Size = new System.Drawing.Size(166, 237);
            this.gbSetLevel.TabIndex = 44;
            this.gbSetLevel.TabStop = false;
            this.gbSetLevel.Text = "权限调整";
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDeleteUser.Location = new System.Drawing.Point(22, 182);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(125, 23);
            this.btnDeleteUser.TabIndex = 48;
            this.btnDeleteUser.Text = "删除用户";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnSetSeller
            // 
            this.btnSetSeller.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSetSeller.Location = new System.Drawing.Point(22, 53);
            this.btnSetSeller.Name = "btnSetSeller";
            this.btnSetSeller.Size = new System.Drawing.Size(125, 23);
            this.btnSetSeller.TabIndex = 47;
            this.btnSetSeller.Text = "设置为售货员";
            this.btnSetSeller.UseVisualStyleBackColor = true;
            this.btnSetSeller.Click += new System.EventHandler(this.btnSetSeller_Click);
            // 
            // btnSetAdmin
            // 
            this.btnSetAdmin.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSetAdmin.Location = new System.Drawing.Point(22, 96);
            this.btnSetAdmin.Name = "btnSetAdmin";
            this.btnSetAdmin.Size = new System.Drawing.Size(125, 23);
            this.btnSetAdmin.TabIndex = 46;
            this.btnSetAdmin.Text = "设置为店长";
            this.btnSetAdmin.UseVisualStyleBackColor = true;
            this.btnSetAdmin.Click += new System.EventHandler(this.btnSetAdmin_Click);
            // 
            // btnSetRoot
            // 
            this.btnSetRoot.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSetRoot.Location = new System.Drawing.Point(22, 139);
            this.btnSetRoot.Name = "btnSetRoot";
            this.btnSetRoot.Size = new System.Drawing.Size(125, 23);
            this.btnSetRoot.TabIndex = 45;
            this.btnSetRoot.Text = "设置为超级管理员";
            this.btnSetRoot.UseVisualStyleBackColor = true;
            this.btnSetRoot.Click += new System.EventHandler(this.btnSetRoot_Click);
            // 
            // treeAuthority
            // 
            this.treeAuthority.AllowDrop = true;
            this.treeAuthority.Location = new System.Drawing.Point(32, 82);
            this.treeAuthority.Name = "treeAuthority";
            this.treeAuthority.Size = new System.Drawing.Size(121, 270);
            this.treeAuthority.TabIndex = 50;
            this.treeAuthority.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeAuthority_ItemDrag);
            this.treeAuthority.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeAuthority_DragDrop);
            this.treeAuthority.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeAuthority_DragEnter);
            // 
            // txtFindUser
            // 
            this.txtFindUser.Location = new System.Drawing.Point(298, 358);
            this.txtFindUser.Name = "txtFindUser";
            this.txtFindUser.Size = new System.Drawing.Size(100, 21);
            this.txtFindUser.TabIndex = 51;
            this.txtFindUser.TextChanged += new System.EventHandler(this.txtFindUser_TextChanged);
            this.txtFindUser.Leave += new System.EventHandler(this.txtFindUser_Leave);
            // 
            // btnFindUser
            // 
            this.btnFindUser.Location = new System.Drawing.Point(404, 358);
            this.btnFindUser.Name = "btnFindUser";
            this.btnFindUser.Size = new System.Drawing.Size(75, 23);
            this.btnFindUser.TabIndex = 52;
            this.btnFindUser.Text = "查找用户";
            this.btnFindUser.UseVisualStyleBackColor = true;
            this.btnFindUser.Click += new System.EventHandler(this.btnFindUser_Click);
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(159, 358);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(75, 23);
            this.btnReload.TabIndex = 53;
            this.btnReload.Text = "刷新表格";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // frmAuthorityManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(703, 461);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnFindUser);
            this.Controls.Add(this.txtFindUser);
            this.Controls.Add(this.treeAuthority);
            this.Controls.Add(this.gbSetLevel);
            this.Controls.Add(this.labelCurrentSupermarket);
            this.Controls.Add(this.labelWelcome);
            this.Controls.Add(this.listViewAuthority);
            this.MaximumSize = new System.Drawing.Size(1281, 768);
            this.Name = "frmAuthorityManagement";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAuthorityManagement_FormClosing);
            this.Load += new System.EventHandler(this.frmAuthorityManagement_Load);
            this.Controls.SetChildIndex(this.btnSubmitMain, 0);
            this.Controls.SetChildIndex(this.labelNoticeMain, 0);
            this.Controls.SetChildIndex(this.listViewAuthority, 0);
            this.Controls.SetChildIndex(this.labelWelcome, 0);
            this.Controls.SetChildIndex(this.labelCurrentSupermarket, 0);
            this.Controls.SetChildIndex(this.gbSetLevel, 0);
            this.Controls.SetChildIndex(this.labelTitle, 0);
            this.Controls.SetChildIndex(this.treeAuthority, 0);
            this.Controls.SetChildIndex(this.txtFindUser, 0);
            this.Controls.SetChildIndex(this.btnFindUser, 0);
            this.Controls.SetChildIndex(this.btnReload, 0);
            this.gbSetLevel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewAuthority;
        private System.Windows.Forms.Label labelCurrentSupermarket;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.GroupBox gbSetLevel;
        private System.Windows.Forms.Button btnSetSeller;
        private System.Windows.Forms.Button btnSetAdmin;
        private System.Windows.Forms.Button btnSetRoot;
        private System.Windows.Forms.TreeView treeAuthority;
        private System.Windows.Forms.TextBox txtFindUser;
        private System.Windows.Forms.Button btnFindUser;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnReload;
    }
}
