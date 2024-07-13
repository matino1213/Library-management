
namespace نرم_افزار_مدیریت_کتابخانه
{
    partial class AddDate
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
            this.mskd1 = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mskd2 = new System.Windows.Forms.MaskedTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(450, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "گزارش از تاریخ";
            // 
            // mskd1
            // 
            this.mskd1.Location = new System.Drawing.Point(304, 69);
            this.mskd1.Mask = "00/00/0000";
            this.mskd1.Name = "mskd1";
            this.mskd1.Size = new System.Drawing.Size(105, 31);
            this.mskd1.TabIndex = 1;
            this.mskd1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mskd1.ValidatingType = typeof(System.DateTime);
            this.mskd1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mskd1_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(239, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "تا";
            // 
            // mskd2
            // 
            this.mskd2.Location = new System.Drawing.Point(93, 69);
            this.mskd2.Mask = "00/00/0000";
            this.mskd2.Name = "mskd2";
            this.mskd2.Size = new System.Drawing.Size(105, 31);
            this.mskd2.TabIndex = 1;
            this.mskd2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mskd2.ValidatingType = typeof(System.DateTime);
            this.mskd2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mskd2_KeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(183, 138);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(237, 41);
            this.button1.TabIndex = 2;
            this.button1.Text = "تایید";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Red;
            this.button8.Location = new System.Drawing.Point(538, 12);
            this.button8.Name = "button8";
            this.button8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button8.Size = new System.Drawing.Size(40, 40);
            this.button8.TabIndex = 16;
            this.button8.Text = "X";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // AddDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 220);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mskd2);
            this.Controls.Add(this.mskd1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Khandevane", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AddDate";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddDate";
            this.Load += new System.EventHandler(this.AddDate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mskd1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mskd2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button8;
    }
}