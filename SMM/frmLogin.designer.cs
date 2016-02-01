namespace SMM
{
    partial class frmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lnkNewUser = new System.Windows.Forms.LinkLabel();
            this.picBoxPwdStatus = new System.Windows.Forms.PictureBox();
            this.imgListLogin = new System.Windows.Forms.ImageList(this.components);
            this.picBoxUserNameStatus = new System.Windows.Forms.PictureBox();
            this.lnkUserNameStatus = new System.Windows.Forms.LinkLabel();
            this.lnkPasswordStatus = new System.Windows.Forms.LinkLabel();
            this.lnkTips = new System.Windows.Forms.LinkLabel();
            this.lnkBlog = new System.Windows.Forms.LinkLabel();
            this.bgwLoadUserList = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbLoadSupermarket = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPwdStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserNameStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogin.Location = new System.Drawing.Point(144, 173);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(153, 36);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "启动";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            this.btnLogin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnLogin_KeyUp);
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.Location = new System.Drawing.Point(12, 178);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(66, 31);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.Font = new System.Drawing.Font("宋体", 12F);
            this.txtUserName.Location = new System.Drawing.Point(144, 31);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(153, 26);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            this.txtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserName_KeyDown);
            this.txtUserName.Leave += new System.EventHandler(this.txtUserName_Leave);
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("宋体", 12F);
            this.txtPassword.Location = new System.Drawing.Point(144, 85);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(153, 26);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            this.txtPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyUp);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // lnkNewUser
            // 
            this.lnkNewUser.AutoSize = true;
            this.lnkNewUser.BackColor = System.Drawing.Color.Transparent;
            this.lnkNewUser.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lnkNewUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lnkNewUser.LinkColor = System.Drawing.SystemColors.ControlText;
            this.lnkNewUser.Location = new System.Drawing.Point(42, 57);
            this.lnkNewUser.Name = "lnkNewUser";
            this.lnkNewUser.Size = new System.Drawing.Size(65, 20);
            this.lnkNewUser.TabIndex = 5;
            this.lnkNewUser.TabStop = true;
            this.lnkNewUser.Text = "新用户？";
            this.lnkNewUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNewUser_LinkClicked);
            // 
            // picBoxPwdStatus
            // 
            this.picBoxPwdStatus.BackColor = System.Drawing.Color.Transparent;
            this.picBoxPwdStatus.Location = new System.Drawing.Point(303, 85);
            this.picBoxPwdStatus.Name = "picBoxPwdStatus";
            this.picBoxPwdStatus.Size = new System.Drawing.Size(32, 32);
            this.picBoxPwdStatus.TabIndex = 7;
            this.picBoxPwdStatus.TabStop = false;
            // 
            // imgListLogin
            // 
            this.imgListLogin.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListLogin.ImageStream")));
            this.imgListLogin.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListLogin.Images.SetKeyName(0, "NO");
            this.imgListLogin.Images.SetKeyName(1, "OK");
            // 
            // picBoxUserNameStatus
            // 
            this.picBoxUserNameStatus.BackColor = System.Drawing.Color.Transparent;
            this.picBoxUserNameStatus.Location = new System.Drawing.Point(303, 26);
            this.picBoxUserNameStatus.Name = "picBoxUserNameStatus";
            this.picBoxUserNameStatus.Size = new System.Drawing.Size(32, 32);
            this.picBoxUserNameStatus.TabIndex = 8;
            this.picBoxUserNameStatus.TabStop = false;
            // 
            // lnkUserNameStatus
            // 
            this.lnkUserNameStatus.AutoSize = true;
            this.lnkUserNameStatus.BackColor = System.Drawing.Color.Transparent;
            this.lnkUserNameStatus.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lnkUserNameStatus.Location = new System.Drawing.Point(145, 64);
            this.lnkUserNameStatus.Name = "lnkUserNameStatus";
            this.lnkUserNameStatus.Size = new System.Drawing.Size(65, 12);
            this.lnkUserNameStatus.TabIndex = 9;
            this.lnkUserNameStatus.TabStop = true;
            this.lnkUserNameStatus.Text = "linkLabel1";
            // 
            // lnkPasswordStatus
            // 
            this.lnkPasswordStatus.AutoSize = true;
            this.lnkPasswordStatus.BackColor = System.Drawing.Color.Transparent;
            this.lnkPasswordStatus.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lnkPasswordStatus.Location = new System.Drawing.Point(145, 116);
            this.lnkPasswordStatus.Name = "lnkPasswordStatus";
            this.lnkPasswordStatus.Size = new System.Drawing.Size(65, 12);
            this.lnkPasswordStatus.TabIndex = 11;
            this.lnkPasswordStatus.TabStop = true;
            this.lnkPasswordStatus.Text = "linkLabel1";
            // 
            // lnkTips
            // 
            this.lnkTips.AutoSize = true;
            this.lnkTips.BackColor = System.Drawing.Color.Transparent;
            this.lnkTips.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lnkTips.Location = new System.Drawing.Point(145, 132);
            this.lnkTips.Name = "lnkTips";
            this.lnkTips.Size = new System.Drawing.Size(65, 12);
            this.lnkTips.TabIndex = 12;
            this.lnkTips.TabStop = true;
            this.lnkTips.Text = "linkLabel1";
            // 
            // lnkBlog
            // 
            this.lnkBlog.AutoSize = true;
            this.lnkBlog.BackColor = System.Drawing.Color.Transparent;
            this.lnkBlog.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lnkBlog.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lnkBlog.LinkColor = System.Drawing.SystemColors.ControlText;
            this.lnkBlog.Location = new System.Drawing.Point(28, 30);
            this.lnkBlog.Name = "lnkBlog";
            this.lnkBlog.Size = new System.Drawing.Size(79, 20);
            this.lnkBlog.TabIndex = 6;
            this.lnkBlog.TabStop = true;
            this.lnkBlog.Text = "制作者博客";
            this.lnkBlog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkBlog_LinkClicked);
            // 
            // bgwLoadUserList
            // 
            this.bgwLoadUserList.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwLoadUserList_DoWork);
            this.bgwLoadUserList.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwLoadUserList_RunWorkerCompleted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(42, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "选择超市：";
            this.label1.Visible = false;
            // 
            // cmbLoadSupermarket
            // 
            this.cmbLoadSupermarket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbLoadSupermarket.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbLoadSupermarket.FormattingEnabled = true;
            this.cmbLoadSupermarket.Location = new System.Drawing.Point(12, 105);
            this.cmbLoadSupermarket.Name = "cmbLoadSupermarket";
            this.cmbLoadSupermarket.Size = new System.Drawing.Size(95, 25);
            this.cmbLoadSupermarket.TabIndex = 14;
            this.cmbLoadSupermarket.Visible = false;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(334, 232);
            this.ControlBox = false;
            this.Controls.Add(this.cmbLoadSupermarket);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lnkBlog);
            this.Controls.Add(this.lnkTips);
            this.Controls.Add(this.lnkPasswordStatus);
            this.Controls.Add(this.lnkUserNameStatus);
            this.Controls.Add(this.picBoxUserNameStatus);
            this.Controls.Add(this.picBoxPwdStatus);
            this.Controls.Add(this.lnkNewUser);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.Shown += new System.EventHandler(this.frmLogin_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPwdStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxUserNameStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.LinkLabel lnkNewUser;
        private System.Windows.Forms.PictureBox picBoxPwdStatus;
        private System.Windows.Forms.ImageList imgListLogin;
        private System.Windows.Forms.PictureBox picBoxUserNameStatus;
        private System.Windows.Forms.LinkLabel lnkUserNameStatus;
        private System.Windows.Forms.LinkLabel lnkPasswordStatus;
        private System.Windows.Forms.LinkLabel lnkTips;
        private System.Windows.Forms.LinkLabel lnkBlog;
        private System.ComponentModel.BackgroundWorker bgwLoadUserList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbLoadSupermarket;
    }
}