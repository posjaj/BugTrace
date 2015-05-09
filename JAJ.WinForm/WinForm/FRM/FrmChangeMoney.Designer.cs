namespace JAJ.WinForm.FRM
{
    partial class FrmChangeMoney
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSmallMoney = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblBigMoney = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(35, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "小写金额：";
            // 
            // txtSmallMoney
            // 
            this.txtSmallMoney.Font = new System.Drawing.Font("宋体", 20F);
            this.txtSmallMoney.Location = new System.Drawing.Point(126, 22);
            this.txtSmallMoney.MaxLength = 10;
            this.txtSmallMoney.Multiline = true;
            this.txtSmallMoney.Name = "txtSmallMoney";
            this.txtSmallMoney.Size = new System.Drawing.Size(286, 39);
            this.txtSmallMoney.TabIndex = 1;
            this.txtSmallMoney.TextChanged += new System.EventHandler(this.txtSmallMoney_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(35, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "大写金额：";
            // 
            // lblBigMoney
            // 
            this.lblBigMoney.AutoSize = true;
            this.lblBigMoney.Font = new System.Drawing.Font("宋体", 30F);
            this.lblBigMoney.Location = new System.Drawing.Point(129, 102);
            this.lblBigMoney.Name = "lblBigMoney";
            this.lblBigMoney.Size = new System.Drawing.Size(0, 40);
            this.lblBigMoney.TabIndex = 3;
            // 
            // FrmChangeMoney
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 260);
            this.Controls.Add(this.lblBigMoney);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSmallMoney);
            this.Controls.Add(this.label1);
            this.Name = "FrmChangeMoney";
            this.Text = "FrmChangeMoney";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSmallMoney;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblBigMoney;
    }
}