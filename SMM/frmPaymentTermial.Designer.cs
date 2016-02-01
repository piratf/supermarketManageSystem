namespace SMM
{
    partial class frmPaymentTermial
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
            this.labelFinalPrice = new System.Windows.Forms.Label();
            this.labelAfterDiscount = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelWhole = new System.Windows.Forms.Label();
            this.gbMemberInfomation = new System.Windows.Forms.GroupBox();
            this.labelPoints = new System.Windows.Forms.Label();
            this.labelPointsValve = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelDiscountPer = new System.Windows.Forms.Label();
            this.labelCurrentMember = new System.Windows.Forms.Label();
            this.labelMemberName = new System.Windows.Forms.Label();
            this.labelDiscount = new System.Windows.Forms.Label();
            this.listViewPurchase = new System.Windows.Forms.ListView();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.txtSetNum = new System.Windows.Forms.TextBox();
            this.btnSetNum = new System.Windows.Forms.Button();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.labelCurrentSupermarket = new System.Windows.Forms.Label();
            this.btnClearPayList = new System.Windows.Forms.Button();
            this.gbMemberInfomation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNoticeMain
            // 
            this.labelNoticeMain.Location = new System.Drawing.Point(540, 352);
            // 
            // btnSubmitMain
            // 
            this.btnSubmitMain.Click += new System.EventHandler(this.btnSubmitMain_Click);
            // 
            // labelFinalPrice
            // 
            this.labelFinalPrice.AutoSize = true;
            this.labelFinalPrice.BackColor = System.Drawing.Color.Transparent;
            this.labelFinalPrice.Location = new System.Drawing.Point(71, 397);
            this.labelFinalPrice.Name = "labelFinalPrice";
            this.labelFinalPrice.Size = new System.Drawing.Size(29, 12);
            this.labelFinalPrice.TabIndex = 30;
            this.labelFinalPrice.Text = "——";
            // 
            // labelAfterDiscount
            // 
            this.labelAfterDiscount.AutoSize = true;
            this.labelAfterDiscount.BackColor = System.Drawing.Color.Transparent;
            this.labelAfterDiscount.Location = new System.Drawing.Point(36, 397);
            this.labelAfterDiscount.Name = "labelAfterDiscount";
            this.labelAfterDiscount.Size = new System.Drawing.Size(41, 12);
            this.labelAfterDiscount.TabIndex = 29;
            this.labelAfterDiscount.Text = "折后：";
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.BackColor = System.Drawing.Color.Transparent;
            this.labelPrice.Location = new System.Drawing.Point(71, 381);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(29, 12);
            this.labelPrice.TabIndex = 28;
            this.labelPrice.Text = "——";
            // 
            // labelWhole
            // 
            this.labelWhole.AutoSize = true;
            this.labelWhole.BackColor = System.Drawing.Color.Transparent;
            this.labelWhole.Location = new System.Drawing.Point(36, 381);
            this.labelWhole.Name = "labelWhole";
            this.labelWhole.Size = new System.Drawing.Size(41, 12);
            this.labelWhole.TabIndex = 25;
            this.labelWhole.Text = "总计：";
            // 
            // gbMemberInfomation
            // 
            this.gbMemberInfomation.BackColor = System.Drawing.Color.Transparent;
            this.gbMemberInfomation.Controls.Add(this.labelPoints);
            this.gbMemberInfomation.Controls.Add(this.labelPointsValve);
            this.gbMemberInfomation.Controls.Add(this.pictureBox1);
            this.gbMemberInfomation.Controls.Add(this.labelDiscountPer);
            this.gbMemberInfomation.Controls.Add(this.labelCurrentMember);
            this.gbMemberInfomation.Controls.Add(this.labelMemberName);
            this.gbMemberInfomation.Controls.Add(this.labelDiscount);
            this.gbMemberInfomation.Location = new System.Drawing.Point(522, 86);
            this.gbMemberInfomation.Name = "gbMemberInfomation";
            this.gbMemberInfomation.Size = new System.Drawing.Size(145, 195);
            this.gbMemberInfomation.TabIndex = 26;
            this.gbMemberInfomation.TabStop = false;
            this.gbMemberInfomation.Text = "会员信息";
            // 
            // labelPoints
            // 
            this.labelPoints.AutoSize = true;
            this.labelPoints.BackColor = System.Drawing.Color.Transparent;
            this.labelPoints.Location = new System.Drawing.Point(17, 149);
            this.labelPoints.Name = "labelPoints";
            this.labelPoints.Size = new System.Drawing.Size(65, 12);
            this.labelPoints.TabIndex = 4;
            this.labelPoints.Text = "已存积分：";
            // 
            // labelPointsValve
            // 
            this.labelPointsValve.AutoSize = true;
            this.labelPointsValve.BackColor = System.Drawing.Color.Transparent;
            this.labelPointsValve.Location = new System.Drawing.Point(77, 149);
            this.labelPointsValve.Name = "labelPointsValve";
            this.labelPointsValve.Size = new System.Drawing.Size(29, 12);
            this.labelPointsValve.TabIndex = 7;
            this.labelPointsValve.Text = "——";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(19, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(67, 60);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // labelDiscountPer
            // 
            this.labelDiscountPer.AutoSize = true;
            this.labelDiscountPer.BackColor = System.Drawing.Color.Transparent;
            this.labelDiscountPer.Location = new System.Drawing.Point(78, 128);
            this.labelDiscountPer.Name = "labelDiscountPer";
            this.labelDiscountPer.Size = new System.Drawing.Size(29, 12);
            this.labelDiscountPer.TabIndex = 6;
            this.labelDiscountPer.Text = "——";
            // 
            // labelCurrentMember
            // 
            this.labelCurrentMember.AutoSize = true;
            this.labelCurrentMember.BackColor = System.Drawing.Color.Transparent;
            this.labelCurrentMember.Location = new System.Drawing.Point(17, 107);
            this.labelCurrentMember.Name = "labelCurrentMember";
            this.labelCurrentMember.Size = new System.Drawing.Size(65, 12);
            this.labelCurrentMember.TabIndex = 2;
            this.labelCurrentMember.Text = "当前会员：";
            // 
            // labelMemberName
            // 
            this.labelMemberName.AutoSize = true;
            this.labelMemberName.BackColor = System.Drawing.Color.Transparent;
            this.labelMemberName.Location = new System.Drawing.Point(78, 107);
            this.labelMemberName.Name = "labelMemberName";
            this.labelMemberName.Size = new System.Drawing.Size(29, 12);
            this.labelMemberName.TabIndex = 5;
            this.labelMemberName.Text = "——";
            // 
            // labelDiscount
            // 
            this.labelDiscount.AutoSize = true;
            this.labelDiscount.BackColor = System.Drawing.Color.Transparent;
            this.labelDiscount.Location = new System.Drawing.Point(17, 128);
            this.labelDiscount.Name = "labelDiscount";
            this.labelDiscount.Size = new System.Drawing.Size(65, 12);
            this.labelDiscount.TabIndex = 3;
            this.labelDiscount.Text = "享有折扣：";
            // 
            // listViewPurchase
            // 
            this.listViewPurchase.Location = new System.Drawing.Point(41, 75);
            this.listViewPurchase.Name = "listViewPurchase";
            this.listViewPurchase.Size = new System.Drawing.Size(450, 280);
            this.listViewPurchase.TabIndex = 23;
            this.listViewPurchase.UseCompatibleStateImageBehavior = false;
            this.listViewPurchase.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewPurchase_MouseDoubleClick);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(391, 365);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(100, 27);
            this.btnAddItem.TabIndex = 32;
            this.btnAddItem.Text = "手动添加商品";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // txtSetNum
            // 
            this.txtSetNum.Location = new System.Drawing.Point(125, 383);
            this.txtSetNum.Name = "txtSetNum";
            this.txtSetNum.Size = new System.Drawing.Size(100, 21);
            this.txtSetNum.TabIndex = 33;
            this.txtSetNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSetNum_KeyDown);
            // 
            // btnSetNum
            // 
            this.btnSetNum.Location = new System.Drawing.Point(231, 381);
            this.btnSetNum.Name = "btnSetNum";
            this.btnSetNum.Size = new System.Drawing.Size(75, 27);
            this.btnSetNum.TabIndex = 34;
            this.btnSetNum.Text = "设置数量";
            this.btnSetNum.UseVisualStyleBackColor = true;
            this.btnSetNum.Click += new System.EventHandler(this.btnSetNum_Click);
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.BackColor = System.Drawing.Color.Transparent;
            this.labelWelcome.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelWelcome.Location = new System.Drawing.Point(204, 52);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(49, 14);
            this.labelWelcome.TabIndex = 35;
            this.labelWelcome.Text = "欢迎：";
            // 
            // labelCurrentSupermarket
            // 
            this.labelCurrentSupermarket.AutoSize = true;
            this.labelCurrentSupermarket.BackColor = System.Drawing.Color.Transparent;
            this.labelCurrentSupermarket.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelCurrentSupermarket.Location = new System.Drawing.Point(176, 34);
            this.labelCurrentSupermarket.Name = "labelCurrentSupermarket";
            this.labelCurrentSupermarket.Size = new System.Drawing.Size(77, 14);
            this.labelCurrentSupermarket.TabIndex = 36;
            this.labelCurrentSupermarket.Text = "当前超市：";
            // 
            // btnClearPayList
            // 
            this.btnClearPayList.Location = new System.Drawing.Point(391, 398);
            this.btnClearPayList.Name = "btnClearPayList";
            this.btnClearPayList.Size = new System.Drawing.Size(100, 27);
            this.btnClearPayList.TabIndex = 37;
            this.btnClearPayList.Text = "清空商品列表";
            this.btnClearPayList.UseVisualStyleBackColor = true;
            this.btnClearPayList.Click += new System.EventHandler(this.btnClearPayList_Click);
            // 
            // frmPaymentTermial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.BackgroundImage = global::SMM.Properties.Resources.bgImg;
            this.ClientSize = new System.Drawing.Size(703, 461);
            this.Controls.Add(this.btnClearPayList);
            this.Controls.Add(this.labelCurrentSupermarket);
            this.Controls.Add(this.labelWelcome);
            this.Controls.Add(this.btnSetNum);
            this.Controls.Add(this.txtSetNum);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.labelFinalPrice);
            this.Controls.Add(this.labelAfterDiscount);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.labelWhole);
            this.Controls.Add(this.gbMemberInfomation);
            this.Controls.Add(this.listViewPurchase);
            this.MaximumSize = new System.Drawing.Size(1281, 768);
            this.Name = "frmPaymentTermial";
            this.Load += new System.EventHandler(this.frmPaymentTermial_Load);
            this.Controls.SetChildIndex(this.labelNoticeMain, 0);
            this.Controls.SetChildIndex(this.listViewPurchase, 0);
            this.Controls.SetChildIndex(this.gbMemberInfomation, 0);
            this.Controls.SetChildIndex(this.labelWhole, 0);
            this.Controls.SetChildIndex(this.labelPrice, 0);
            this.Controls.SetChildIndex(this.labelAfterDiscount, 0);
            this.Controls.SetChildIndex(this.labelFinalPrice, 0);
            this.Controls.SetChildIndex(this.btnAddItem, 0);
            this.Controls.SetChildIndex(this.txtSetNum, 0);
            this.Controls.SetChildIndex(this.btnSetNum, 0);
            this.Controls.SetChildIndex(this.labelWelcome, 0);
            this.Controls.SetChildIndex(this.labelCurrentSupermarket, 0);
            this.Controls.SetChildIndex(this.btnClearPayList, 0);
            this.Controls.SetChildIndex(this.labelTitle, 0);
            this.Controls.SetChildIndex(this.btnSubmitMain, 0);
            this.gbMemberInfomation.ResumeLayout(false);
            this.gbMemberInfomation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFinalPrice;
        private System.Windows.Forms.Label labelAfterDiscount;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelWhole;
        private System.Windows.Forms.GroupBox gbMemberInfomation;
        private System.Windows.Forms.Label labelPoints;
        private System.Windows.Forms.Label labelPointsValve;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelDiscountPer;
        private System.Windows.Forms.Label labelCurrentMember;
        private System.Windows.Forms.Label labelMemberName;
        private System.Windows.Forms.Label labelDiscount;
        private System.Windows.Forms.ListView listViewPurchase;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.TextBox txtSetNum;
        private System.Windows.Forms.Button btnSetNum;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Label labelCurrentSupermarket;
        private System.Windows.Forms.Button btnClearPayList;
    }
}
