namespace Cake_Screenshot
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.btnScreenshot = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.ptbPhotoPreview = new System.Windows.Forms.PictureBox();
            this.cmbDeviceList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPhotoPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabel
            // 
            this.linkLabel.AutoSize = true;
            this.linkLabel.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.linkLabel.LinkColor = System.Drawing.SystemColors.ActiveCaption;
            this.linkLabel.Location = new System.Drawing.Point(320, 839);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(169, 16);
            this.linkLabel.TabIndex = 2;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "www.caketech.com.tw";
            this.linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // btnScreenshot
            // 
            this.btnScreenshot.BackColor = System.Drawing.SystemColors.Control;
            this.btnScreenshot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnScreenshot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnScreenshot.Font = new System.Drawing.Font("Segoe Marker", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScreenshot.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnScreenshot.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnScreenshot.Location = new System.Drawing.Point(441, 681);
            this.btnScreenshot.Name = "btnScreenshot";
            this.btnScreenshot.Size = new System.Drawing.Size(160, 31);
            this.btnScreenshot.TabIndex = 1;
            this.btnScreenshot.Text = "Screenshot";
            this.btnScreenshot.UseVisualStyleBackColor = false;
            this.btnScreenshot.Click += new System.EventHandler(this.btnScreenshot_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Cake_Screenshot.Properties.Resources.CakeTechM;
            this.pictureBox2.Location = new System.Drawing.Point(188, 752);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(433, 70);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // ptbPhotoPreview
            // 
            this.ptbPhotoPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ptbPhotoPreview.Location = new System.Drawing.Point(99, 12);
            this.ptbPhotoPreview.Name = "ptbPhotoPreview";
            this.ptbPhotoPreview.Size = new System.Drawing.Size(600, 600);
            this.ptbPhotoPreview.TabIndex = 4;
            this.ptbPhotoPreview.TabStop = false;
            // 
            // cmbDeviceList
            // 
            this.cmbDeviceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeviceList.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmbDeviceList.FormattingEnabled = true;
            this.cmbDeviceList.Location = new System.Drawing.Point(188, 683);
            this.cmbDeviceList.Name = "cmbDeviceList";
            this.cmbDeviceList.Size = new System.Drawing.Size(200, 29);
            this.cmbDeviceList.TabIndex = 5;
            this.cmbDeviceList.DropDown += new System.EventHandler(this.ReloadDevice_DropDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(254, 720);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Marker", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(253, 655);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 22);
            this.label2.TabIndex = 7;
            this.label2.Text = "Devices";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Marker", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(491, 655);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 22);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ctrl+B";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe Marker", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(672, 825);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 30);
            this.label4.TabIndex = 9;
            this.label4.Text = "Ctrl + B 拍照\r\nCtrl  + V 貼上\r\n";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(820, 873);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbDeviceList);
            this.Controls.Add(this.ptbPhotoPreview);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.linkLabel);
            this.Controls.Add(this.btnScreenshot);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.RightToLeftLayout = true;
            this.Text = "CakeScreenShot";
            this.Activated += new System.EventHandler(this.Form_Activated);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPhotoPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnScreenshot;
        private System.Windows.Forms.LinkLabel linkLabel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox ptbPhotoPreview;
        private System.Windows.Forms.ComboBox cmbDeviceList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

