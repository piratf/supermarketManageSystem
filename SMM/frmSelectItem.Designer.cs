namespace SMM
{
    partial class frmSelectItem
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
            this.listViewSelectItem = new System.Windows.Forms.ListView();
            this.labelSelectItem = new System.Windows.Forms.Label();
            this.cmbChooseClass = new System.Windows.Forms.ComboBox();
            this.labelChooseClass = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewSelectItem
            // 
            this.listViewSelectItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewSelectItem.Location = new System.Drawing.Point(12, 70);
            this.listViewSelectItem.Name = "listViewSelectItem";
            this.listViewSelectItem.Size = new System.Drawing.Size(465, 335);
            this.listViewSelectItem.TabIndex = 0;
            this.listViewSelectItem.UseCompatibleStateImageBehavior = false;
            this.listViewSelectItem.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewSelectItem_MouseDoubleClick);
            // 
            // labelSelectItem
            // 
            this.labelSelectItem.AutoSize = true;
            this.labelSelectItem.BackColor = System.Drawing.Color.Transparent;
            this.labelSelectItem.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSelectItem.Location = new System.Drawing.Point(35, 21);
            this.labelSelectItem.Name = "labelSelectItem";
            this.labelSelectItem.Size = new System.Drawing.Size(133, 38);
            this.labelSelectItem.TabIndex = 32;
            this.labelSelectItem.Text = "选择商品";
            // 
            // cmbChooseClass
            // 
            this.cmbChooseClass.FormattingEnabled = true;
            this.cmbChooseClass.Location = new System.Drawing.Point(298, 38);
            this.cmbChooseClass.Name = "cmbChooseClass";
            this.cmbChooseClass.Size = new System.Drawing.Size(121, 20);
            this.cmbChooseClass.TabIndex = 34;
            this.cmbChooseClass.SelectionChangeCommitted += new System.EventHandler(this.cmbChooseClass_SelectionChangeCommitted);
            // 
            // labelChooseClass
            // 
            this.labelChooseClass.AutoSize = true;
            this.labelChooseClass.BackColor = System.Drawing.Color.Transparent;
            this.labelChooseClass.Location = new System.Drawing.Point(236, 42);
            this.labelChooseClass.Name = "labelChooseClass";
            this.labelChooseClass.Size = new System.Drawing.Size(65, 12);
            this.labelChooseClass.TabIndex = 33;
            this.labelChooseClass.Text = "选择类别：";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSubmit.Location = new System.Drawing.Point(402, 418);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 30);
            this.btnSubmit.TabIndex = 35;
            this.btnSubmit.Text = "提交";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(321, 418);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 36;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmSelectItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SMM.Properties.Resources.bgImg;
            this.ClientSize = new System.Drawing.Size(489, 460);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.cmbChooseClass);
            this.Controls.Add(this.labelChooseClass);
            this.Controls.Add(this.labelSelectItem);
            this.Controls.Add(this.listViewSelectItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSelectItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSelectItem";
            this.Load += new System.EventHandler(this.frmSelectItem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewSelectItem;
        private System.Windows.Forms.Label labelSelectItem;
        private System.Windows.Forms.ComboBox cmbChooseClass;
        private System.Windows.Forms.Label labelChooseClass;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
    }
}