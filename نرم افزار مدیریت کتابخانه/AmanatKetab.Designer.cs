
namespace نرم_افزار_مدیریت_کتابخانه
{
    partial class AmanatKetab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AmanatKetab));
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.mskDate = new System.Windows.Forms.MaskedTextBox();
            this.btnBookLoan = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column9 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Column13 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Column10 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Column11 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Column12 = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.Column14 = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.Column16 = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.Column15 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.mskReturnDate = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Column1 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Column2 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Column3 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Column4 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Column17 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.txtSearchUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSearchDoc = new System.Windows.Forms.TextBox();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.Column5 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Column6 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Column7 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Column18 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.Column8 = new DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn();
            this.btnUserChoose = new System.Windows.Forms.Button();
            this.btnDocChoose = new System.Windows.Forms.Button();
            this.btnRecive = new System.Windows.Forms.Button();
            this.btnReserve = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.btnReserveBookLoan = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.btnClose = new System.Windows.Forms.Button();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnShowInfo = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1218, 480);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "تاریخ امانت";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(758, 579);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(532, 31);
            this.txtDescription.TabIndex = 1;
            this.txtDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // mskDate
            // 
            this.mskDate.Location = new System.Drawing.Point(1116, 507);
            this.mskDate.Mask = "00/00/0000";
            this.mskDate.Name = "mskDate";
            this.mskDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mskDate.Size = new System.Drawing.Size(174, 31);
            this.mskDate.TabIndex = 3;
            this.mskDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mskDate.ValidatingType = typeof(System.DateTime);
            this.mskDate.TextChanged += new System.EventHandler(this.maskedTextBox1_TextChanged);
            this.mskDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maskedTextBox1_KeyDown);
            // 
            // btnBookLoan
            // 
            this.btnBookLoan.BackColor = System.Drawing.Color.Lime;
            this.btnBookLoan.Location = new System.Drawing.Point(1035, 640);
            this.btnBookLoan.Name = "btnBookLoan";
            this.btnBookLoan.Size = new System.Drawing.Size(255, 56);
            this.btnBookLoan.TabIndex = 4;
            this.btnBookLoan.Text = "امانت کتاب";
            this.btnBookLoan.UseVisualStyleBackColor = false;
            this.btnBookLoan.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column9,
            this.Column13,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column14,
            this.Column16,
            this.Column15});
            this.dataGridView1.Location = new System.Drawing.Point(12, 117);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 26;
            this.dataGridView1.Size = new System.Drawing.Size(685, 539);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column9.DataPropertyName = "id";
            this.Column9.HeaderText = "ردیف";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.TextAlignment = System.Drawing.StringAlignment.Center;
            this.Column9.Width = 46;
            // 
            // Column13
            // 
            this.Column13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column13.DataPropertyName = "Condition";
            this.Column13.HeaderText = "وضعیت";
            this.Column13.MinimumWidth = 6;
            this.Column13.Name = "Column13";
            this.Column13.TextAlignment = System.Drawing.StringAlignment.Center;
            this.Column13.Width = 59;
            // 
            // Column10
            // 
            this.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column10.DataPropertyName = "Name";
            this.Column10.HeaderText = "نام کاربر";
            this.Column10.MinimumWidth = 6;
            this.Column10.Name = "Column10";
            this.Column10.TextAlignment = System.Drawing.StringAlignment.Center;
            this.Column10.Width = 66;
            // 
            // Column11
            // 
            this.Column11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column11.DataPropertyName = "BookName";
            this.Column11.HeaderText = "نام کتاب";
            this.Column11.MinimumWidth = 6;
            this.Column11.Name = "Column11";
            this.Column11.TextAlignment = System.Drawing.StringAlignment.Center;
            this.Column11.Width = 67;
            // 
            // Column12
            // 
            this.Column12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            // 
            // 
            // 
            this.Column12.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.Column12.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.Column12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Column12.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText;
            this.Column12.DataPropertyName = "Date";
            this.Column12.HeaderText = "تاریخ تحویل";
            this.Column12.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.Column12.MinDate = new System.DateTime(622, 3, 22, 0, 0, 0, 0);
            this.Column12.MinimumWidth = 6;
            // 
            // 
            // 
            // 
            // 
            // 
            this.Column12.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Column12.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            // 
            // 
            // 
            this.Column12.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Column12.MonthCalendar.DisplayMonth = new System.DateTime(2022, 10, 1, 0, 0, 0, 0);
            this.Column12.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Saturday;
            // 
            // 
            // 
            this.Column12.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Column12.Name = "Column12";
            this.Column12.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column12.Width = 82;
            // 
            // Column14
            // 
            this.Column14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            // 
            // 
            // 
            this.Column14.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.Column14.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.Column14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Column14.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText;
            this.Column14.DataPropertyName = "ReturnDate";
            this.Column14.HeaderText = "تاریخ برگشت";
            this.Column14.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.Column14.MinDate = new System.DateTime(622, 3, 22, 0, 0, 0, 0);
            this.Column14.MinimumWidth = 6;
            // 
            // 
            // 
            // 
            // 
            // 
            this.Column14.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Column14.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            // 
            // 
            // 
            this.Column14.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Column14.MonthCalendar.DisplayMonth = new System.DateTime(2022, 10, 1, 0, 0, 0, 0);
            this.Column14.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Saturday;
            // 
            // 
            // 
            this.Column14.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Column14.Name = "Column14";
            this.Column14.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column14.Width = 92;
            // 
            // Column16
            // 
            this.Column16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            // 
            // 
            // 
            this.Column16.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.Column16.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.Column16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Column16.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText;
            this.Column16.DataPropertyName = "DateReceived";
            this.Column16.HeaderText = "تاریخ دریافت";
            this.Column16.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.Column16.MinDate = new System.DateTime(622, 3, 22, 0, 0, 0, 0);
            this.Column16.MinimumWidth = 6;
            // 
            // 
            // 
            // 
            // 
            // 
            this.Column16.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Column16.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            // 
            // 
            // 
            this.Column16.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Column16.MonthCalendar.DisplayMonth = new System.DateTime(2022, 10, 1, 0, 0, 0, 0);
            this.Column16.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Saturday;
            // 
            // 
            // 
            this.Column16.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Column16.Name = "Column16";
            this.Column16.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column16.Width = 88;
            // 
            // Column15
            // 
            this.Column15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column15.DataPropertyName = "Description";
            this.Column15.HeaderText = "توضیحات";
            this.Column15.MinimumWidth = 6;
            this.Column15.Name = "Column15";
            this.Column15.TextAlignment = System.Drawing.StringAlignment.Center;
            this.Column15.Width = 68;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(850, 480);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "تاریخ برگشت";
            // 
            // mskReturnDate
            // 
            this.mskReturnDate.Location = new System.Drawing.Point(758, 507);
            this.mskReturnDate.Mask = "00/00/0000";
            this.mskReturnDate.Name = "mskReturnDate";
            this.mskReturnDate.Size = new System.Drawing.Size(174, 31);
            this.mskReturnDate.TabIndex = 3;
            this.mskReturnDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mskReturnDate.ValidatingType = typeof(System.DateTime);
            this.mskReturnDate.TextChanged += new System.EventHandler(this.maskedTextBox3_TextChanged);
            this.mskReturnDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maskedTextBox3_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1232, 552);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 24);
            this.label6.TabIndex = 0;
            this.label6.Text = "توضیحات";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(615, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 24);
            this.label7.TabIndex = 0;
            this.label7.Text = "جستجو امانت";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(346, 80);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(351, 31);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(12, 80);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(98, 31);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "حذف امانت";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column17});
            this.dataGridView2.Location = new System.Drawing.Point(758, 117);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 26;
            this.dataGridView2.Size = new System.Drawing.Size(532, 130);
            this.dataGridView2.TabIndex = 5;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "id";
            this.Column1.HeaderText = "ردیف";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.TextAlignment = System.Drawing.StringAlignment.Center;
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Name";
            this.Column2.HeaderText = "نام کاربر";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.TextAlignment = System.Drawing.StringAlignment.Center;
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "NationalCode";
            this.Column3.HeaderText = "کد ملی";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.TextAlignment = System.Drawing.StringAlignment.Center;
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "UserType";
            this.Column4.HeaderText = "نوع کاربر";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.TextAlignment = System.Drawing.StringAlignment.Center;
            this.Column4.Width = 125;
            // 
            // Column17
            // 
            this.Column17.DataPropertyName = "Status";
            this.Column17.HeaderText = "وضعیت";
            this.Column17.MinimumWidth = 6;
            this.Column17.Name = "Column17";
            this.Column17.TextAlignment = System.Drawing.StringAlignment.Center;
            this.Column17.Width = 79;
            // 
            // txtSearchUser
            // 
            this.txtSearchUser.Location = new System.Drawing.Point(962, 80);
            this.txtSearchUser.Name = "txtSearchUser";
            this.txtSearchUser.Size = new System.Drawing.Size(328, 31);
            this.txtSearchUser.TabIndex = 1;
            this.txtSearchUser.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1214, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "جستجو کاربر";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1214, 272);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 24);
            this.label5.TabIndex = 0;
            this.label5.Text = "جستجو کتاب";
            // 
            // txtSearchDoc
            // 
            this.txtSearchDoc.Location = new System.Drawing.Point(1028, 299);
            this.txtSearchDoc.Name = "txtSearchDoc";
            this.txtSearchDoc.Size = new System.Drawing.Size(262, 31);
            this.txtSearchDoc.TabIndex = 1;
            this.txtSearchDoc.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column18,
            this.Column8});
            this.dataGridView3.Location = new System.Drawing.Point(758, 336);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersWidth = 51;
            this.dataGridView3.RowTemplate.Height = 26;
            this.dataGridView3.Size = new System.Drawing.Size(532, 130);
            this.dataGridView3.TabIndex = 5;
            this.dataGridView3.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellContentClick);
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column5.DataPropertyName = "id";
            this.Column5.HeaderText = "ردیف";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column5.TextAlignment = System.Drawing.StringAlignment.Center;
            this.Column5.Width = 69;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column6.DataPropertyName = "BookName";
            this.Column6.HeaderText = "نام کتاب";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column7.DataPropertyName = "Writer";
            this.Column7.HeaderText = "نویسنده";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.TextAlignment = System.Drawing.StringAlignment.Center;
            this.Column7.Width = 63;
            // 
            // Column18
            // 
            this.Column18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column18.DataPropertyName = "HelpNumber";
            this.Column18.HeaderText = "شماره راهنما";
            this.Column18.MinimumWidth = 6;
            this.Column18.Name = "Column18";
            this.Column18.TextAlignment = System.Drawing.StringAlignment.Center;
            this.Column18.Width = 92;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column8.DataPropertyName = "Inventory";
            this.Column8.HeaderText = "موجودی";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.TextAlignment = System.Drawing.StringAlignment.Center;
            this.Column8.Width = 61;
            // 
            // btnUserChoose
            // 
            this.btnUserChoose.BackColor = System.Drawing.Color.Lime;
            this.btnUserChoose.Enabled = false;
            this.btnUserChoose.Location = new System.Drawing.Point(758, 80);
            this.btnUserChoose.Name = "btnUserChoose";
            this.btnUserChoose.Size = new System.Drawing.Size(198, 31);
            this.btnUserChoose.TabIndex = 6;
            this.btnUserChoose.Text = "انتخاب کاربر";
            this.btnUserChoose.UseVisualStyleBackColor = false;
            this.btnUserChoose.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnDocChoose
            // 
            this.btnDocChoose.BackColor = System.Drawing.Color.Lime;
            this.btnDocChoose.Enabled = false;
            this.btnDocChoose.Location = new System.Drawing.Point(758, 299);
            this.btnDocChoose.Name = "btnDocChoose";
            this.btnDocChoose.Size = new System.Drawing.Size(132, 31);
            this.btnDocChoose.TabIndex = 6;
            this.btnDocChoose.Text = "انتخاب کتاب";
            this.btnDocChoose.UseVisualStyleBackColor = false;
            this.btnDocChoose.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnRecive
            // 
            this.btnRecive.BackColor = System.Drawing.Color.Lime;
            this.btnRecive.Enabled = false;
            this.btnRecive.Location = new System.Drawing.Point(116, 80);
            this.btnRecive.Name = "btnRecive";
            this.btnRecive.Size = new System.Drawing.Size(109, 31);
            this.btnRecive.TabIndex = 6;
            this.btnRecive.Text = "دریافت امانت";
            this.btnRecive.UseVisualStyleBackColor = false;
            this.btnRecive.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnReserve
            // 
            this.btnReserve.Location = new System.Drawing.Point(758, 640);
            this.btnReserve.Name = "btnReserve";
            this.btnReserve.Size = new System.Drawing.Size(255, 56);
            this.btnReserve.TabIndex = 8;
            this.btnReserve.Text = "رزرو کتاب";
            this.btnReserve.UseVisualStyleBackColor = true;
            this.btnReserve.Click += new System.EventHandler(this.button6_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(991, 38);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 24);
            this.lblError.TabIndex = 0;
            // 
            // btnReserveBookLoan
            // 
            this.btnReserveBookLoan.Location = new System.Drawing.Point(231, 80);
            this.btnReserveBookLoan.Name = "btnReserveBookLoan";
            this.btnReserveBookLoan.Size = new System.Drawing.Size(109, 31);
            this.btnReserveBookLoan.TabIndex = 10;
            this.btnReserveBookLoan.Text = "امانت رزرو";
            this.btnReserveBookLoan.UseVisualStyleBackColor = true;
            this.btnReserveBookLoan.Click += new System.EventHandler(this.button7_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(12, 51);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radioButton1.Size = new System.Drawing.Size(168, 28);
            this.radioButton1.TabIndex = 11;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "نمایش امانت های فعال";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(186, 51);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radioButton2.Size = new System.Drawing.Size(118, 28);
            this.radioButton2.TabIndex = 12;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "نمایش رزرو ها";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(443, 51);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radioButton3.Size = new System.Drawing.Size(102, 28);
            this.radioButton3.TabIndex = 13;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "نمایش همه";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(1278, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.button8_Click);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(310, 51);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radioButton4.Size = new System.Drawing.Size(127, 28);
            this.radioButton4.TabIndex = 15;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "نمایش جریمه ها";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(599, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(197, 40);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // btnShowInfo
            // 
            this.btnShowInfo.Enabled = false;
            this.btnShowInfo.Location = new System.Drawing.Point(896, 299);
            this.btnShowInfo.Name = "btnShowInfo";
            this.btnShowInfo.Size = new System.Drawing.Size(126, 31);
            this.btnShowInfo.TabIndex = 18;
            this.btnShowInfo.Text = "اطلاعات کتاب";
            this.btnShowInfo.UseVisualStyleBackColor = true;
            this.btnShowInfo.Click += new System.EventHandler(this.button9_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.RightToLeft = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button1.Location = new System.Drawing.Point(12, 662);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 34);
            this.button1.TabIndex = 19;
            this.button1.Text = "بازنشانی جدول امانات";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // AmanatKetab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1330, 708);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnShowInfo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.btnReserveBookLoan);
            this.Controls.Add(this.btnReserve);
            this.Controls.Add(this.btnDocChoose);
            this.Controls.Add(this.btnUserChoose);
            this.Controls.Add(this.btnRecive);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnBookLoan);
            this.Controls.Add(this.mskReturnDate);
            this.Controls.Add(this.mskDate);
            this.Controls.Add(this.txtSearchDoc);
            this.Controls.Add(this.txtSearchUser);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Khandevane", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AmanatKetab";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "امانت کتاب";
            this.Load += new System.EventHandler(this.AmanatKetab_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.MaskedTextBox mskDate;
        private System.Windows.Forms.Button btnBookLoan;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox mskReturnDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox txtSearchUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSearchDoc;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Button btnUserChoose;
        private System.Windows.Forms.Button btnDocChoose;
        private System.Windows.Forms.Button btnRecive;
        private System.Windows.Forms.Button btnReserve;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnReserveBookLoan;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Column9;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Column13;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Column10;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Column11;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn Column12;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn Column14;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn Column16;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Column15;
        private System.Windows.Forms.Button btnShowInfo;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Column5;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Column6;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Column7;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Column18;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Column8;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Column1;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Column2;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Column3;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Column4;
        private DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn Column17;
        private System.Windows.Forms.Button button1;
    }
}