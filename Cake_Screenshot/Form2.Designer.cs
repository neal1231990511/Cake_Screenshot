namespace Cake_Screenshot
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.tbx_Dialog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbx_Dialog
            // 
            this.tbx_Dialog.BackColor = System.Drawing.SystemColors.Control;
            this.tbx_Dialog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbx_Dialog.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbx_Dialog.Location = new System.Drawing.Point(133, 59);
            this.tbx_Dialog.Multiline = true;
            this.tbx_Dialog.Name = "tbx_Dialog";
            this.tbx_Dialog.Size = new System.Drawing.Size(522, 121);
            this.tbx_Dialog.TabIndex = 0;
            this.tbx_Dialog.Text = "系統偵測您沒有安裝ADB Tool\r\n請檢查您的ADB Tool是否正確安裝\r\n於Command模式下輸入 adb device\r\n若出現\'adb\'不是內部或外部" +
    "命令、可執行的程式或批次檔。\r\n代表您沒有安裝ADB Tool\r\n安裝請參考 : http://wangwangtc.blogspot.tw/2015/03/a" +
    "dbandroid.html";
            this.tbx_Dialog.TextChanged += new System.EventHandler(this.tbx_Dialog_TextChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 248);
            this.Controls.Add(this.tbx_Dialog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "警告";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbx_Dialog;
    }
}