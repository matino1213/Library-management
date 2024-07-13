
namespace نرم_افزار_مدیریت_کتابخانه
{
    partial class VirayeshKetabdar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VirayeshKetabdar));
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtPas = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpdatePas = new System.Windows.Forms.Button();
            this.lblUserName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNewPas = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNewPasAgain = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.mskNCode = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnUpdateNCode = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(608, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.button8_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(242, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(197, 40);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // txtPas
            // 
            this.txtPas.Location = new System.Drawing.Point(390, 292);
            this.txtPas.Name = "txtPas";
            this.txtPas.Size = new System.Drawing.Size(195, 31);
            this.txtPas.TabIndex = 18;
            this.txtPas.TextChanged += new System.EventHandler(this.txtPas_TextChanged);
            this.txtPas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPas_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(390, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 24);
            this.label1.TabIndex = 19;
            this.label1.Text = "نام کاربری :";
            // 
            // btnUpdatePas
            // 
            this.btnUpdatePas.Location = new System.Drawing.Point(390, 505);
            this.btnUpdatePas.Name = "btnUpdatePas";
            this.btnUpdatePas.Size = new System.Drawing.Size(195, 36);
            this.btnUpdatePas.TabIndex = 20;
            this.btnUpdatePas.Text = "تغییر رمز";
            this.btnUpdatePas.UseVisualStyleBackColor = true;
            this.btnUpdatePas.Click += new System.EventHandler(this.btnUpdatePas_Click);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(261, 107);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(0, 24);
            this.lblUserName.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(443, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 24);
            this.label2.TabIndex = 19;
            this.label2.Text = "تغییر رمز عبور";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(416, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 24);
            this.label3.TabIndex = 19;
            this.label3.Text = "رمز عبور قدیمی را وارد نمایید";
            // 
            // txtNewPas
            // 
            this.txtNewPas.Location = new System.Drawing.Point(390, 372);
            this.txtNewPas.Name = "txtNewPas";
            this.txtNewPas.Size = new System.Drawing.Size(195, 31);
            this.txtNewPas.TabIndex = 18;
            this.txtNewPas.TextChanged += new System.EventHandler(this.txtNewPas_TextChanged);
            this.txtNewPas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNewPas_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(503, 345);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 24);
            this.label4.TabIndex = 19;
            this.label4.Text = "رمز عبور جدید";
            // 
            // txtNewPasAgain
            // 
            this.txtNewPasAgain.Location = new System.Drawing.Point(390, 438);
            this.txtNewPasAgain.Name = "txtNewPasAgain";
            this.txtNewPasAgain.Size = new System.Drawing.Size(195, 31);
            this.txtNewPasAgain.TabIndex = 18;
            this.txtNewPasAgain.TextChanged += new System.EventHandler(this.txtNewPasAgain_TextChanged);
            this.txtNewPasAgain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNewPasAgain_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(498, 411);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 24);
            this.label5.TabIndex = 19;
            this.label5.Text = "تکرار رمز عبور";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(131, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 24);
            this.label6.TabIndex = 19;
            this.label6.Text = "تغییر کد ملی";
            // 
            // mskNCode
            // 
            this.mskNCode.Location = new System.Drawing.Point(75, 292);
            this.mskNCode.Mask = "0000000000";
            this.mskNCode.Name = "mskNCode";
            this.mskNCode.Size = new System.Drawing.Size(195, 31);
            this.mskNCode.TabIndex = 21;
            this.mskNCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mskNCode.TextChanged += new System.EventHandler(this.mskNCode_TextChanged);
            this.mskNCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mskNCode_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(123, 265);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 24);
            this.label7.TabIndex = 19;
            this.label7.Text = "کد ملی جدید را وارد نمایید";
            // 
            // btnUpdateNCode
            // 
            this.btnUpdateNCode.Location = new System.Drawing.Point(75, 369);
            this.btnUpdateNCode.Name = "btnUpdateNCode";
            this.btnUpdateNCode.Size = new System.Drawing.Size(195, 36);
            this.btnUpdateNCode.TabIndex = 20;
            this.btnUpdateNCode.Text = "تغییر کد ملی";
            this.btnUpdateNCode.UseVisualStyleBackColor = true;
            this.btnUpdateNCode.Click += new System.EventHandler(this.btnUpdateNCode_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.RightToLeft = true;
            // 
            // VirayeshKetabdar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 588);
            this.Controls.Add(this.mskNCode);
            this.Controls.Add(this.btnUpdateNCode);
            this.Controls.Add(this.btnUpdatePas);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNewPasAgain);
            this.Controls.Add(this.txtNewPas);
            this.Controls.Add(this.txtPas);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Khandevane", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "VirayeshKetabdar";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ویرایش کتابدار";
            this.Load += new System.EventHandler(this.VirayeshKetabdar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtPas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpdatePas;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNewPas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNewPasAgain;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox mskNCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnUpdateNCode;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}