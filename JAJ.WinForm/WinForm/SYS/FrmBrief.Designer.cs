namespace JAJ.WinForm.SYS
{
    partial class FrmBrief
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
            this.txtMemo = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtMemo
            // 
            this.txtMemo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtMemo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMemo.Location = new System.Drawing.Point(0, 0);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(447, 337);
            this.txtMemo.TabIndex = 0;
            this.txtMemo.Text = "";
            // 
            // FrmBrief
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 337);
            this.Controls.Add(this.txtMemo);
            this.Name = "FrmBrief";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "简要说明";
            this.Load += new System.EventHandler(this.FrmBrief_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtMemo;
    }
}