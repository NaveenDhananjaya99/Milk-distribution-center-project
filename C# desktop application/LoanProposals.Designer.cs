
namespace ProjectZ
{
    partial class LoanProposals
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAddApplicant = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEditSave = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dgvLoanProposal = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.cmbYearFilter = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panelData = new System.Windows.Forms.Panel();
            this.lblID = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpStartedDate = new System.Windows.Forms.DateTimePicker();
            this.cmbApplicantType = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtApplicantType = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbCurrentStatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCurrentStatus = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtvalue = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNoOfInstallments = new System.Windows.Forms.TextBox();
            this.txtRepaymentPeriod = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtInterestRate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtInterestMode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStartededate = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoanProposal)).BeginInit();
            this.panel5.SuspendLayout();
            this.panelData.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAddApplicant);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnEditSave);
            this.panel2.Controls.Add(this.btnAddNew);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 667);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1283, 89);
            this.panel2.TabIndex = 1;
            // 
            // btnAddApplicant
            // 
            this.btnAddApplicant.AutoEllipsis = true;
            this.btnAddApplicant.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAddApplicant.FlatAppearance.BorderSize = 5;
            this.btnAddApplicant.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddApplicant.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddApplicant.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.btnAddApplicant.Location = new System.Drawing.Point(937, 15);
            this.btnAddApplicant.Name = "btnAddApplicant";
            this.btnAddApplicant.Size = new System.Drawing.Size(270, 60);
            this.btnAddApplicant.TabIndex = 0;
            this.btnAddApplicant.Text = "Add Applicant";
            this.btnAddApplicant.UseVisualStyleBackColor = true;
            this.btnAddApplicant.Click += new System.EventHandler(this.btnAddApplicant_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoEllipsis = true;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDelete.FlatAppearance.BorderSize = 5;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.btnDelete.Location = new System.Drawing.Point(623, 15);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(270, 60);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEditSave
            // 
            this.btnEditSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnEditSave.FlatAppearance.BorderSize = 5;
            this.btnEditSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditSave.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.btnEditSave.Location = new System.Drawing.Point(312, 15);
            this.btnEditSave.Name = "btnEditSave";
            this.btnEditSave.Size = new System.Drawing.Size(270, 60);
            this.btnEditSave.TabIndex = 0;
            this.btnEditSave.Text = "Edit";
            this.btnEditSave.UseVisualStyleBackColor = true;
            this.btnEditSave.Click += new System.EventHandler(this.btnEditSave_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAddNew.FlatAppearance.BorderSize = 5;
            this.btnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.btnAddNew.Location = new System.Drawing.Point(12, 15);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(270, 60);
            this.btnAddNew.TabIndex = 0;
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.dgvLoanProposal);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(587, 667);
            this.panel1.TabIndex = 5;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(385, 185);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 32);
            this.label13.TabIndex = 52;
            this.label13.Text = "Name";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(95, 185);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 32);
            this.label14.TabIndex = 53;
            this.label14.Text = "ID";
            // 
            // dgvLoanProposal
            // 
            this.dgvLoanProposal.AllowUserToAddRows = false;
            this.dgvLoanProposal.AllowUserToDeleteRows = false;
            this.dgvLoanProposal.AllowUserToResizeColumns = false;
            this.dgvLoanProposal.AllowUserToResizeRows = false;
            this.dgvLoanProposal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLoanProposal.BackgroundColor = System.Drawing.Color.Navy;
            this.dgvLoanProposal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLoanProposal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoanProposal.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLoanProposal.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLoanProposal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvLoanProposal.Location = new System.Drawing.Point(0, 232);
            this.dgvLoanProposal.Name = "dgvLoanProposal";
            this.dgvLoanProposal.ReadOnly = true;
            this.dgvLoanProposal.RowHeadersVisible = false;
            this.dgvLoanProposal.RowHeadersWidth = 51;
            this.dgvLoanProposal.RowTemplate.Height = 24;
            this.dgvLoanProposal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoanProposal.Size = new System.Drawing.Size(587, 435);
            this.dgvLoanProposal.TabIndex = 6;
            this.dgvLoanProposal.SelectionChanged += new System.EventHandler(this.dgvLoanProposal_SelectionChanged);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(53)))));
            this.panel5.Controls.Add(this.cmbStatusFilter);
            this.panel5.Controls.Add(this.cmbYearFilter);
            this.panel5.Controls.Add(this.label12);
            this.panel5.Controls.Add(this.label15);
            this.panel5.Controls.Add(this.label16);
            this.panel5.Controls.Add(this.txtSearch);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(587, 153);
            this.panel5.TabIndex = 5;
            // 
            // cmbStatusFilter
            // 
            this.cmbStatusFilter.FormattingEnabled = true;
            this.cmbStatusFilter.Items.AddRange(new object[] {
            "All",
            "Started",
            "Finished"});
            this.cmbStatusFilter.Location = new System.Drawing.Point(348, 118);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(184, 24);
            this.cmbStatusFilter.TabIndex = 9;
            this.cmbStatusFilter.SelectedIndexChanged += new System.EventHandler(this.cmbStatusFilter_SelectedIndexChanged);
            // 
            // cmbYearFilter
            // 
            this.cmbYearFilter.FormattingEnabled = true;
            this.cmbYearFilter.Location = new System.Drawing.Point(59, 118);
            this.cmbYearFilter.Name = "cmbYearFilter";
            this.cmbYearFilter.Size = new System.Drawing.Size(184, 24);
            this.cmbYearFilter.TabIndex = 10;
            this.cmbYearFilter.SelectedIndexChanged += new System.EventHandler(this.cmbYearFilter_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(344, 90);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(118, 20);
            this.label12.TabIndex = 6;
            this.label12.Text = "Current Status";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(55, 90);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 20);
            this.label15.TabIndex = 7;
            this.label15.Text = "Year";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(55, 11);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(188, 20);
            this.label16.TabIndex = 8;
            this.label16.Text = "Search with ID or Name";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(59, 34);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(473, 30);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // panelData
            // 
            this.panelData.Controls.Add(this.lblID);
            this.panelData.Controls.Add(this.lblName);
            this.panelData.Controls.Add(this.panel6);
            this.panelData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelData.ForeColor = System.Drawing.Color.White;
            this.panelData.Location = new System.Drawing.Point(587, 0);
            this.panelData.Name = "panelData";
            this.panelData.Size = new System.Drawing.Size(696, 667);
            this.panelData.TabIndex = 6;
            this.panelData.Paint += new System.Windows.Forms.PaintEventHandler(this.panelData_Paint);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.Color.White;
            this.lblID.Location = new System.Drawing.Point(13, 9);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(87, 25);
            this.lblID.TabIndex = 51;
            this.lblID.Text = "Loan ID";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(251, 8);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(126, 44);
            this.lblName.TabIndex = 50;
            this.lblName.Text = "Name";
            // 
            // panel6
            // 
            this.panel6.AutoScroll = true;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.dtpStartedDate);
            this.panel6.Controls.Add(this.cmbApplicantType);
            this.panel6.Controls.Add(this.label10);
            this.panel6.Controls.Add(this.txtApplicantType);
            this.panel6.Controls.Add(this.label9);
            this.panel6.Controls.Add(this.cmbCurrentStatus);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.txtCurrentStatus);
            this.panel6.Controls.Add(this.txtDescription);
            this.panel6.Controls.Add(this.txtvalue);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.txtNoOfInstallments);
            this.panel6.Controls.Add(this.txtRepaymentPeriod);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Controls.Add(this.txtInterestRate);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.label11);
            this.panel6.Controls.Add(this.txtInterestMode);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.txtStartededate);
            this.panel6.Location = new System.Drawing.Point(27, 31);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(617, 592);
            this.panel6.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(270, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 49;
            this.label2.Text = "Rs : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(13, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 20);
            this.label4.TabIndex = 41;
            this.label4.Text = "Maximum Value";
            // 
            // dtpStartedDate
            // 
            this.dtpStartedDate.CustomFormat = "yyyy-MM-dd";
            this.dtpStartedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartedDate.Location = new System.Drawing.Point(441, 320);
            this.dtpStartedDate.Name = "dtpStartedDate";
            this.dtpStartedDate.Size = new System.Drawing.Size(135, 27);
            this.dtpStartedDate.TabIndex = 48;
            // 
            // cmbApplicantType
            // 
            this.cmbApplicantType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbApplicantType.FormattingEnabled = true;
            this.cmbApplicantType.Items.AddRange(new object[] {
            "All",
            "Farmer",
            "Sales Rep"});
            this.cmbApplicantType.Location = new System.Drawing.Point(275, 272);
            this.cmbApplicantType.Name = "cmbApplicantType";
            this.cmbApplicantType.Size = new System.Drawing.Size(301, 28);
            this.cmbApplicantType.TabIndex = 42;
            this.cmbApplicantType.SelectedIndexChanged += new System.EventHandler(this.cmbApplicantType_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Gray;
            this.label10.Location = new System.Drawing.Point(13, 525);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(132, 20);
            this.label10.TabIndex = 44;
            this.label10.Text = "Current Status";
            // 
            // txtApplicantType
            // 
            this.txtApplicantType.BackColor = System.Drawing.Color.Navy;
            this.txtApplicantType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtApplicantType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApplicantType.ForeColor = System.Drawing.Color.White;
            this.txtApplicantType.Location = new System.Drawing.Point(275, 275);
            this.txtApplicantType.Name = "txtApplicantType";
            this.txtApplicantType.ReadOnly = true;
            this.txtApplicantType.Size = new System.Drawing.Size(301, 20);
            this.txtApplicantType.TabIndex = 30;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Gray;
            this.label9.Location = new System.Drawing.Point(13, 383);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 20);
            this.label9.TabIndex = 45;
            this.label9.Text = "Description";
            // 
            // cmbCurrentStatus
            // 
            this.cmbCurrentStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCurrentStatus.FormattingEnabled = true;
            this.cmbCurrentStatus.Items.AddRange(new object[] {
            "Started",
            "Finished"});
            this.cmbCurrentStatus.Location = new System.Drawing.Point(275, 517);
            this.cmbCurrentStatus.Name = "cmbCurrentStatus";
            this.cmbCurrentStatus.Size = new System.Drawing.Size(301, 28);
            this.cmbCurrentStatus.TabIndex = 47;
            this.cmbCurrentStatus.SelectedIndexChanged += new System.EventHandler(this.cmbCurrentStatus_SelectedIndexChanged_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(13, 325);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 20);
            this.label3.TabIndex = 46;
            this.label3.Text = "Started date";
            // 
            // txtCurrentStatus
            // 
            this.txtCurrentStatus.BackColor = System.Drawing.Color.Navy;
            this.txtCurrentStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCurrentStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentStatus.ForeColor = System.Drawing.Color.White;
            this.txtCurrentStatus.Location = new System.Drawing.Point(275, 520);
            this.txtCurrentStatus.Name = "txtCurrentStatus";
            this.txtCurrentStatus.ReadOnly = true;
            this.txtCurrentStatus.Size = new System.Drawing.Size(301, 23);
            this.txtCurrentStatus.TabIndex = 32;
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.Navy;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.ForeColor = System.Drawing.Color.White;
            this.txtDescription.Location = new System.Drawing.Point(275, 380);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(301, 94);
            this.txtDescription.TabIndex = 43;
            // 
            // txtvalue
            // 
            this.txtvalue.BackColor = System.Drawing.Color.Navy;
            this.txtvalue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtvalue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtvalue.ForeColor = System.Drawing.Color.White;
            this.txtvalue.Location = new System.Drawing.Point(327, 48);
            this.txtvalue.Name = "txtvalue";
            this.txtvalue.ReadOnly = true;
            this.txtvalue.Size = new System.Drawing.Size(249, 20);
            this.txtvalue.TabIndex = 36;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(13, 275);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 20);
            this.label8.TabIndex = 37;
            this.label8.Text = "Applicant Type";
            // 
            // txtNoOfInstallments
            // 
            this.txtNoOfInstallments.BackColor = System.Drawing.Color.Navy;
            this.txtNoOfInstallments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNoOfInstallments.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoOfInstallments.ForeColor = System.Drawing.Color.White;
            this.txtNoOfInstallments.Location = new System.Drawing.Point(275, 136);
            this.txtNoOfInstallments.Name = "txtNoOfInstallments";
            this.txtNoOfInstallments.ReadOnly = true;
            this.txtNoOfInstallments.Size = new System.Drawing.Size(301, 20);
            this.txtNoOfInstallments.TabIndex = 35;
            // 
            // txtRepaymentPeriod
            // 
            this.txtRepaymentPeriod.BackColor = System.Drawing.Color.Navy;
            this.txtRepaymentPeriod.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRepaymentPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRepaymentPeriod.ForeColor = System.Drawing.Color.White;
            this.txtRepaymentPeriod.Location = new System.Drawing.Point(275, 93);
            this.txtRepaymentPeriod.Name = "txtRepaymentPeriod";
            this.txtRepaymentPeriod.ReadOnly = true;
            this.txtRepaymentPeriod.Size = new System.Drawing.Size(301, 20);
            this.txtRepaymentPeriod.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(13, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 20);
            this.label7.TabIndex = 38;
            this.label7.Text = "Interest Mode";
            // 
            // txtInterestRate
            // 
            this.txtInterestRate.BackColor = System.Drawing.Color.Navy;
            this.txtInterestRate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInterestRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInterestRate.ForeColor = System.Drawing.Color.White;
            this.txtInterestRate.Location = new System.Drawing.Point(275, 178);
            this.txtInterestRate.Name = "txtInterestRate";
            this.txtInterestRate.ReadOnly = true;
            this.txtInterestRate.Size = new System.Drawing.Size(111, 20);
            this.txtInterestRate.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(392, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 20);
            this.label1.TabIndex = 39;
            this.label1.Text = "%";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(13, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 20);
            this.label6.TabIndex = 39;
            this.label6.Text = "Interest Rate";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Gray;
            this.label11.Location = new System.Drawing.Point(13, 136);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(198, 20);
            this.label11.TabIndex = 40;
            this.label11.Text = "Min No of Installments";
            // 
            // txtInterestMode
            // 
            this.txtInterestMode.BackColor = System.Drawing.Color.Navy;
            this.txtInterestMode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInterestMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInterestMode.ForeColor = System.Drawing.Color.White;
            this.txtInterestMode.Location = new System.Drawing.Point(275, 220);
            this.txtInterestMode.Name = "txtInterestMode";
            this.txtInterestMode.ReadOnly = true;
            this.txtInterestMode.Size = new System.Drawing.Size(301, 20);
            this.txtInterestMode.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(13, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 20);
            this.label5.TabIndex = 40;
            this.label5.Text = "Repayment period";
            // 
            // txtStartededate
            // 
            this.txtStartededate.BackColor = System.Drawing.Color.Navy;
            this.txtStartededate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStartededate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartededate.ForeColor = System.Drawing.Color.White;
            this.txtStartededate.Location = new System.Drawing.Point(275, 327);
            this.txtStartededate.Name = "txtStartededate";
            this.txtStartededate.ReadOnly = true;
            this.txtStartededate.Size = new System.Drawing.Size(134, 20);
            this.txtStartededate.TabIndex = 33;
            // 
            // LoanProposals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(1283, 756);
            this.Controls.Add(this.panelData);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoanProposals";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "LoanProposals";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LoanProposals_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoanProposal)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panelData.ResumeLayout(false);
            this.panelData.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEditSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvLoanProposal;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpStartedDate;
        private System.Windows.Forms.ComboBox cmbApplicantType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtApplicantType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbCurrentStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCurrentStatus;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtvalue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRepaymentPeriod;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtInterestRate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtInterestMode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStartededate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNoOfInstallments;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnAddApplicant;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.ComboBox cmbYearFilter;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtSearch;
    }
}