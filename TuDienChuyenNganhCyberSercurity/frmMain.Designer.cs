namespace TuDienChuyenNganhCyberSecurity
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            flowPanel = new FlowLayoutPanel();
            btnTraCuu = new Button();
            imageList1 = new ImageList(components);
            btnThem = new Button();
            btnCapNhat = new Button();
            btnLuu = new Button();
            btnTaiLai = new Button();
            btnXoa = new Button();
            btnPhucHoi = new Button();
            btnThoat = new Button();
            panel1 = new Panel();
            cmbLinhVuc1 = new ComboBox();
            lbLinhVuc = new Label();
            txtTuDayDu = new TextBox();
            txtTuVietTat = new TextBox();
            lbTuVietTat = new Label();
            lbTuDayDu = new Label();
            cmbTuVietTat = new ComboBox();
            cmbTuDayDu = new ComboBox();
            label5 = new Label();
            cmbLinhVuc = new ComboBox();
            splitContainer1 = new SplitContainer();
            dgvDSTU = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            TUVIETTAT = new DataGridViewTextBoxColumn();
            TUDAYDU = new DataGridViewTextBoxColumn();
            NOIDUNG = new DataGridViewTextBoxColumn();
            GHICHU = new DataGridViewTextBoxColumn();
            LINHVUC = new DataGridViewTextBoxColumn();
            CreatedDate = new DataGridViewTextBoxColumn();
            ModifiedDate = new DataGridViewTextBoxColumn();
            panel6 = new Panel();
            btnLastPage = new Button();
            btnNextPage = new Button();
            btnPrePage = new Button();
            btnFirstPage = new Button();
            txtPage = new TextBox();
            panel2 = new Panel();
            label3 = new Label();
            panelLoc = new Panel();
            cmbNgaySua = new ComboBox();
            label2 = new Label();
            cmbNgayTao = new ComboBox();
            label1 = new Label();
            panel5 = new Panel();
            txtGhiChu = new RichTextBox();
            panel4 = new Panel();
            label6 = new Label();
            panelFormatText = new Panel();
            btnShowSymbol = new Button();
            btnSymbolMenu = new Button();
            label9 = new Label();
            btnShowColor = new Button();
            btnColorMenu = new Button();
            label8 = new Label();
            label7 = new Label();
            btnItalic = new Button();
            btnUnderline = new Button();
            btnBold = new Button();
            txtNoiDung = new RichTextBox();
            panel3 = new Panel();
            label4 = new Label();
            colorDialog1 = new ColorDialog();
            colorMenu = new ContextMenuStrip(components);
            btnMoreColors = new ToolStripMenuItem();
            symbolMenu = new ContextMenuStrip(components);
            flowPanel.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDSTU).BeginInit();
            panel6.SuspendLayout();
            panel2.SuspendLayout();
            panelLoc.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panelFormatText.SuspendLayout();
            panel3.SuspendLayout();
            colorMenu.SuspendLayout();
            SuspendLayout();
            // 
            // flowPanel
            // 
            flowPanel.AutoSize = true;
            flowPanel.BackColor = SystemColors.GradientActiveCaption;
            flowPanel.BorderStyle = BorderStyle.Fixed3D;
            flowPanel.Controls.Add(btnTraCuu);
            flowPanel.Controls.Add(btnThem);
            flowPanel.Controls.Add(btnCapNhat);
            flowPanel.Controls.Add(btnLuu);
            flowPanel.Controls.Add(btnTaiLai);
            flowPanel.Controls.Add(btnXoa);
            flowPanel.Controls.Add(btnPhucHoi);
            flowPanel.Controls.Add(btnThoat);
            flowPanel.Dock = DockStyle.Top;
            flowPanel.Location = new Point(0, 0);
            flowPanel.Margin = new Padding(4);
            flowPanel.Name = "flowPanel";
            flowPanel.Size = new Size(1924, 47);
            flowPanel.TabIndex = 100;
            // 
            // btnTraCuu
            // 
            btnTraCuu.AutoSize = true;
            btnTraCuu.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnTraCuu.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTraCuu.ImageAlign = ContentAlignment.MiddleRight;
            btnTraCuu.ImageIndex = 0;
            btnTraCuu.ImageList = imageList1;
            btnTraCuu.Location = new Point(4, 4);
            btnTraCuu.Margin = new Padding(4);
            btnTraCuu.Name = "btnTraCuu";
            btnTraCuu.Size = new Size(102, 35);
            btnTraCuu.TabIndex = 20;
            btnTraCuu.TabStop = false;
            btnTraCuu.Text = "Tra cứu";
            btnTraCuu.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnTraCuu.UseVisualStyleBackColor = true;
            btnTraCuu.Click += btnTraCuu_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "SearchIcon.png");
            imageList1.Images.SetKeyName(1, "Add.png");
            imageList1.Images.SetKeyName(2, "Edit.png");
            imageList1.Images.SetKeyName(3, "Save.png");
            imageList1.Images.SetKeyName(4, "Delete.png");
            imageList1.Images.SetKeyName(5, "Exit.png");
            imageList1.Images.SetKeyName(6, "Reload.png");
            imageList1.Images.SetKeyName(7, "Rollback.png");
            imageList1.Images.SetKeyName(8, "Filter1.png");
            imageList1.Images.SetKeyName(9, "filter.png");
            imageList1.Images.SetKeyName(10, "ColorMenu.png");
            imageList1.Images.SetKeyName(11, "GoTo1stPage.png");
            imageList1.Images.SetKeyName(12, "GoToLasttPage.png");
            imageList1.Images.SetKeyName(13, "GoToNextPage.png");
            imageList1.Images.SetKeyName(14, "GoToPrePage.png");
            imageList1.Images.SetKeyName(15, "Omega.png");
            // 
            // btnThem
            // 
            btnThem.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThem.ImageAlign = ContentAlignment.MiddleRight;
            btnThem.ImageIndex = 1;
            btnThem.ImageList = imageList1;
            btnThem.Location = new Point(114, 4);
            btnThem.Margin = new Padding(4);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(149, 32);
            btnThem.TabIndex = 21;
            btnThem.TabStop = false;
            btnThem.Text = "Thêm từ mới";
            btnThem.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnCapNhat
            // 
            btnCapNhat.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCapNhat.ImageAlign = ContentAlignment.MiddleRight;
            btnCapNhat.ImageIndex = 2;
            btnCapNhat.ImageList = imageList1;
            btnCapNhat.Location = new Point(271, 4);
            btnCapNhat.Margin = new Padding(4);
            btnCapNhat.Name = "btnCapNhat";
            btnCapNhat.Size = new Size(120, 32);
            btnCapNhat.TabIndex = 22;
            btnCapNhat.TabStop = false;
            btnCapNhat.Text = "Cập nhật";
            btnCapNhat.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCapNhat.UseVisualStyleBackColor = true;
            btnCapNhat.Click += btnCapNhat_Click;
            // 
            // btnLuu
            // 
            btnLuu.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLuu.ImageAlign = ContentAlignment.MiddleRight;
            btnLuu.ImageIndex = 3;
            btnLuu.ImageList = imageList1;
            btnLuu.Location = new Point(399, 4);
            btnLuu.Margin = new Padding(4);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(84, 32);
            btnLuu.TabIndex = 23;
            btnLuu.TabStop = false;
            btnLuu.Text = "Lưu";
            btnLuu.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnTaiLai
            // 
            btnTaiLai.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTaiLai.ImageAlign = ContentAlignment.MiddleRight;
            btnTaiLai.ImageIndex = 6;
            btnTaiLai.ImageList = imageList1;
            btnTaiLai.Location = new Point(491, 4);
            btnTaiLai.Margin = new Padding(4);
            btnTaiLai.Name = "btnTaiLai";
            btnTaiLai.Size = new Size(97, 32);
            btnTaiLai.TabIndex = 24;
            btnTaiLai.TabStop = false;
            btnTaiLai.Text = "Tải lại";
            btnTaiLai.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnTaiLai.UseVisualStyleBackColor = true;
            btnTaiLai.Click += btnTaiLai_Click;
            // 
            // btnXoa
            // 
            btnXoa.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoa.ImageAlign = ContentAlignment.MiddleRight;
            btnXoa.ImageIndex = 4;
            btnXoa.ImageList = imageList1;
            btnXoa.Location = new Point(596, 4);
            btnXoa.Margin = new Padding(4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(81, 32);
            btnXoa.TabIndex = 25;
            btnXoa.TabStop = false;
            btnXoa.Text = "Xóa";
            btnXoa.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnPhucHoi
            // 
            btnPhucHoi.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPhucHoi.ImageAlign = ContentAlignment.MiddleRight;
            btnPhucHoi.ImageIndex = 7;
            btnPhucHoi.ImageList = imageList1;
            btnPhucHoi.Location = new Point(685, 4);
            btnPhucHoi.Margin = new Padding(4);
            btnPhucHoi.Name = "btnPhucHoi";
            btnPhucHoi.Size = new Size(113, 32);
            btnPhucHoi.TabIndex = 26;
            btnPhucHoi.TabStop = false;
            btnPhucHoi.Text = "Phục hồi";
            btnPhucHoi.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPhucHoi.UseVisualStyleBackColor = true;
            btnPhucHoi.Click += btnPhucHoi_Click;
            // 
            // btnThoat
            // 
            btnThoat.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThoat.ImageAlign = ContentAlignment.MiddleRight;
            btnThoat.ImageIndex = 5;
            btnThoat.ImageList = imageList1;
            btnThoat.Location = new Point(806, 4);
            btnThoat.Margin = new Padding(4);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(97, 32);
            btnThoat.TabIndex = 27;
            btnThoat.TabStop = false;
            btnThoat.Text = "Thoát";
            btnThoat.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.BackColor = SystemColors.GradientActiveCaption;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(cmbLinhVuc1);
            panel1.Controls.Add(lbLinhVuc);
            panel1.Controls.Add(txtTuDayDu);
            panel1.Controls.Add(txtTuVietTat);
            panel1.Controls.Add(lbTuVietTat);
            panel1.Controls.Add(lbTuDayDu);
            panel1.Controls.Add(cmbTuVietTat);
            panel1.Controls.Add(cmbTuDayDu);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 47);
            panel1.Name = "panel1";
            panel1.Size = new Size(1924, 43);
            panel1.TabIndex = 100;
            // 
            // cmbLinhVuc1
            // 
            cmbLinhVuc1.BackColor = Color.Thistle;
            cmbLinhVuc1.Font = new Font("Times New Roman", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbLinhVuc1.FormattingEnabled = true;
            cmbLinhVuc1.Location = new Point(1249, 3);
            cmbLinhVuc1.Name = "cmbLinhVuc1";
            cmbLinhVuc1.Size = new Size(247, 28);
            cmbLinhVuc1.TabIndex = 3;
            cmbLinhVuc1.Visible = false;
            cmbLinhVuc1.KeyDown += cmbLinhVuc1_KeyDown;
            cmbLinhVuc1.PreviewKeyDown += cmbLinhVuc1_PreviewKeyDown;
            // 
            // lbLinhVuc
            // 
            lbLinhVuc.AutoSize = true;
            lbLinhVuc.Location = new Point(1159, 6);
            lbLinhVuc.Name = "lbLinhVuc";
            lbLinhVuc.Size = new Size(84, 25);
            lbLinhVuc.TabIndex = 101;
            lbLinhVuc.Text = "Lĩnh vực";
            lbLinhVuc.Visible = false;
            // 
            // txtTuDayDu
            // 
            txtTuDayDu.BackColor = Color.Thistle;
            txtTuDayDu.Font = new Font("Times New Roman", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTuDayDu.ForeColor = Color.Black;
            txtTuDayDu.Location = new Point(547, 4);
            txtTuDayDu.Name = "txtTuDayDu";
            txtTuDayDu.Size = new Size(579, 29);
            txtTuDayDu.TabIndex = 2;
            txtTuDayDu.Visible = false;
            txtTuDayDu.KeyDown += txtTuDayDu_KeyDown;
            // 
            // txtTuVietTat
            // 
            txtTuVietTat.BackColor = Color.Thistle;
            txtTuVietTat.Font = new Font("Times New Roman", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTuVietTat.ForeColor = Color.Black;
            txtTuVietTat.Location = new Point(110, 4);
            txtTuVietTat.Name = "txtTuVietTat";
            txtTuVietTat.Size = new Size(304, 29);
            txtTuVietTat.TabIndex = 1;
            txtTuVietTat.Visible = false;
            txtTuVietTat.KeyDown += txtTuVietTat_KeyDown;
            // 
            // lbTuVietTat
            // 
            lbTuVietTat.AutoSize = true;
            lbTuVietTat.Location = new Point(6, 6);
            lbTuVietTat.Name = "lbTuVietTat";
            lbTuVietTat.Size = new Size(101, 25);
            lbTuVietTat.TabIndex = 100;
            lbTuVietTat.Text = "Từ viết tắt";
            // 
            // lbTuDayDu
            // 
            lbTuDayDu.AutoSize = true;
            lbTuDayDu.Location = new Point(443, 6);
            lbTuDayDu.Name = "lbTuDayDu";
            lbTuDayDu.Size = new Size(98, 25);
            lbTuDayDu.TabIndex = 100;
            lbTuDayDu.Text = "Từ đầy đủ";
            // 
            // cmbTuVietTat
            // 
            cmbTuVietTat.FormattingEnabled = true;
            cmbTuVietTat.Location = new Point(110, 3);
            cmbTuVietTat.Name = "cmbTuVietTat";
            cmbTuVietTat.Size = new Size(304, 33);
            cmbTuVietTat.TabIndex = 1;
            cmbTuVietTat.SelectionChangeCommitted += cmbTuVietTat_SelectionChangeCommitted;
            cmbTuVietTat.KeyDown += cmbTuVietTat_KeyDown;
            cmbTuVietTat.Leave += cmbTuVietTat_Leave;
            // 
            // cmbTuDayDu
            // 
            cmbTuDayDu.FormattingEnabled = true;
            cmbTuDayDu.Location = new Point(547, 3);
            cmbTuDayDu.Name = "cmbTuDayDu";
            cmbTuDayDu.Size = new Size(579, 33);
            cmbTuDayDu.TabIndex = 2;
            cmbTuDayDu.SelectionChangeCommitted += cmbTuDayDu_SelectionChangeCommitted;
            cmbTuDayDu.KeyDown += cmbTuDayDu_KeyDown;
            cmbTuDayDu.Leave += cmbTuDayDu_Leave;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.White;
            label5.Location = new Point(6, 6);
            label5.Name = "label5";
            label5.Size = new Size(84, 25);
            label5.TabIndex = 102;
            label5.Text = "Lĩnh vực";
            // 
            // cmbLinhVuc
            // 
            cmbLinhVuc.BackColor = Color.White;
            cmbLinhVuc.FormattingEnabled = true;
            cmbLinhVuc.Location = new Point(96, 3);
            cmbLinhVuc.Name = "cmbLinhVuc";
            cmbLinhVuc.Size = new Size(239, 33);
            cmbLinhVuc.TabIndex = 20;
            cmbLinhVuc.SelectedIndexChanged += cmbLinhVuc_SelectedIndexChanged;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 90);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dgvDSTU);
            splitContainer1.Panel1.Controls.Add(panel6);
            splitContainer1.Panel1.Controls.Add(panel2);
            splitContainer1.Panel1.Controls.Add(panelLoc);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel5);
            splitContainer1.Panel2.Controls.Add(panel3);
            splitContainer1.Size = new Size(1924, 797);
            splitContainer1.SplitterDistance = 822;
            splitContainer1.TabIndex = 100;
            splitContainer1.TabStop = false;
            // 
            // dgvDSTU
            // 
            dgvDSTU.AllowUserToAddRows = false;
            dgvDSTU.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDSTU.BackgroundColor = SystemColors.GradientInactiveCaption;
            dgvDSTU.BorderStyle = BorderStyle.Fixed3D;
            dgvDSTU.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.LightSkyBlue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.LightSkyBlue;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvDSTU.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvDSTU.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDSTU.Columns.AddRange(new DataGridViewColumn[] { ID, TUVIETTAT, TUDAYDU, NOIDUNG, GHICHU, LINHVUC, CreatedDate, ModifiedDate });
            dgvDSTU.Dock = DockStyle.Fill;
            dgvDSTU.EnableHeadersVisualStyles = false;
            dgvDSTU.Location = new Point(0, 84);
            dgvDSTU.Name = "dgvDSTU";
            dgvDSTU.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = SystemColors.Control;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = Color.White;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvDSTU.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvDSTU.RowHeadersWidth = 51;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = Color.White;
            dgvDSTU.RowsDefaultCellStyle = dataGridViewCellStyle8;
            dgvDSTU.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDSTU.Size = new Size(822, 669);
            dgvDSTU.TabIndex = 101;
            dgvDSTU.SelectionChanged += dgvDSTU_SelectionChanged;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.FillWeight = 96.25668F;
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Visible = false;
            // 
            // TUVIETTAT
            // 
            TUVIETTAT.DataPropertyName = "TUVIETTAT";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            TUVIETTAT.DefaultCellStyle = dataGridViewCellStyle2;
            TUVIETTAT.FillWeight = 50F;
            TUVIETTAT.HeaderText = "Từ viết tắt";
            TUVIETTAT.MinimumWidth = 6;
            TUVIETTAT.Name = "TUVIETTAT";
            TUVIETTAT.ReadOnly = true;
            // 
            // TUDAYDU
            // 
            TUDAYDU.DataPropertyName = "TUDAYDU";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            TUDAYDU.DefaultCellStyle = dataGridViewCellStyle3;
            TUDAYDU.FillWeight = 125F;
            TUDAYDU.HeaderText = "Từ đầy đủ";
            TUDAYDU.MinimumWidth = 6;
            TUDAYDU.Name = "TUDAYDU";
            TUDAYDU.ReadOnly = true;
            // 
            // NOIDUNG
            // 
            NOIDUNG.DataPropertyName = "NOIDUNG";
            NOIDUNG.HeaderText = "Nội dung";
            NOIDUNG.MinimumWidth = 6;
            NOIDUNG.Name = "NOIDUNG";
            NOIDUNG.ReadOnly = true;
            NOIDUNG.Visible = false;
            // 
            // GHICHU
            // 
            GHICHU.DataPropertyName = "GHICHU";
            GHICHU.HeaderText = "Ghi chú";
            GHICHU.MinimumWidth = 6;
            GHICHU.Name = "GHICHU";
            GHICHU.ReadOnly = true;
            GHICHU.Visible = false;
            // 
            // LINHVUC
            // 
            LINHVUC.DataPropertyName = "LINHVUC";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            LINHVUC.DefaultCellStyle = dataGridViewCellStyle4;
            LINHVUC.FillWeight = 60F;
            LINHVUC.HeaderText = "Lĩnh vực";
            LINHVUC.MinimumWidth = 6;
            LINHVUC.Name = "LINHVUC";
            LINHVUC.ReadOnly = true;
            // 
            // CreatedDate
            // 
            CreatedDate.DataPropertyName = "CreatedDate";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.Black;
            CreatedDate.DefaultCellStyle = dataGridViewCellStyle5;
            CreatedDate.HeaderText = "Ngày tạo";
            CreatedDate.MinimumWidth = 6;
            CreatedDate.Name = "CreatedDate";
            CreatedDate.ReadOnly = true;
            CreatedDate.Resizable = DataGridViewTriState.False;
            CreatedDate.Visible = false;
            // 
            // ModifiedDate
            // 
            ModifiedDate.DataPropertyName = "ModifiedDate";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = Color.Black;
            ModifiedDate.DefaultCellStyle = dataGridViewCellStyle6;
            ModifiedDate.HeaderText = "Ngày sửa";
            ModifiedDate.MinimumWidth = 6;
            ModifiedDate.Name = "ModifiedDate";
            ModifiedDate.ReadOnly = true;
            ModifiedDate.Resizable = DataGridViewTriState.False;
            ModifiedDate.Visible = false;
            // 
            // panel6
            // 
            panel6.BackColor = SystemColors.Highlight;
            panel6.BorderStyle = BorderStyle.Fixed3D;
            panel6.Controls.Add(btnLastPage);
            panel6.Controls.Add(btnNextPage);
            panel6.Controls.Add(btnPrePage);
            panel6.Controls.Add(btnFirstPage);
            panel6.Controls.Add(txtPage);
            panel6.Dock = DockStyle.Bottom;
            panel6.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            panel6.Location = new Point(0, 753);
            panel6.Name = "panel6";
            panel6.Size = new Size(822, 44);
            panel6.TabIndex = 103;
            // 
            // btnLastPage
            // 
            btnLastPage.Anchor = AnchorStyles.None;
            btnLastPage.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLastPage.ImageIndex = 12;
            btnLastPage.ImageList = imageList1;
            btnLastPage.Location = new Point(484, 5);
            btnLastPage.Name = "btnLastPage";
            btnLastPage.Size = new Size(29, 29);
            btnLastPage.TabIndex = 2;
            btnLastPage.UseVisualStyleBackColor = true;
            btnLastPage.Click += btnLastPage_Click;
            // 
            // btnNextPage
            // 
            btnNextPage.Anchor = AnchorStyles.None;
            btnNextPage.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNextPage.ImageIndex = 13;
            btnNextPage.ImageList = imageList1;
            btnNextPage.Location = new Point(449, 5);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.Size = new Size(29, 29);
            btnNextPage.TabIndex = 2;
            btnNextPage.UseVisualStyleBackColor = true;
            btnNextPage.Click += btnNextPage_Click;
            // 
            // btnPrePage
            // 
            btnPrePage.Anchor = AnchorStyles.None;
            btnPrePage.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrePage.ImageIndex = 14;
            btnPrePage.ImageList = imageList1;
            btnPrePage.Location = new Point(338, 5);
            btnPrePage.Name = "btnPrePage";
            btnPrePage.Size = new Size(29, 29);
            btnPrePage.TabIndex = 2;
            btnPrePage.UseVisualStyleBackColor = true;
            btnPrePage.Click += btnPrePage_Click;
            // 
            // btnFirstPage
            // 
            btnFirstPage.Anchor = AnchorStyles.None;
            btnFirstPage.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFirstPage.ImageIndex = 11;
            btnFirstPage.ImageList = imageList1;
            btnFirstPage.Location = new Point(303, 5);
            btnFirstPage.Name = "btnFirstPage";
            btnFirstPage.Size = new Size(29, 29);
            btnFirstPage.TabIndex = 2;
            btnFirstPage.UseVisualStyleBackColor = true;
            btnFirstPage.Click += btnFirstPage_Click;
            // 
            // txtPage
            // 
            txtPage.Anchor = AnchorStyles.None;
            txtPage.BackColor = SystemColors.Window;
            txtPage.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtPage.Location = new Point(375, 5);
            txtPage.Name = "txtPage";
            txtPage.ReadOnly = true;
            txtPage.Size = new Size(66, 30);
            txtPage.TabIndex = 100;
            txtPage.TextAlign = HorizontalAlignment.Center;
            txtPage.KeyDown += txtPage_KeyDown;
            txtPage.Leave += txtPage_Leave;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Highlight;
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(label3);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 44);
            panel2.Name = "panel2";
            panel2.Size = new Size(822, 40);
            panel2.TabIndex = 100;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.BorderStyle = BorderStyle.Fixed3D;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(329, 5);
            label3.Name = "label3";
            label3.Size = new Size(151, 27);
            label3.TabIndex = 0;
            label3.Text = "DANH SÁCH TỪ";
            // 
            // panelLoc
            // 
            panelLoc.BackColor = SystemColors.Highlight;
            panelLoc.BorderStyle = BorderStyle.Fixed3D;
            panelLoc.Controls.Add(cmbNgaySua);
            panelLoc.Controls.Add(label2);
            panelLoc.Controls.Add(cmbNgayTao);
            panelLoc.Controls.Add(label1);
            panelLoc.Controls.Add(cmbLinhVuc);
            panelLoc.Controls.Add(label5);
            panelLoc.Dock = DockStyle.Top;
            panelLoc.Location = new Point(0, 0);
            panelLoc.Name = "panelLoc";
            panelLoc.Size = new Size(822, 44);
            panelLoc.TabIndex = 102;
            // 
            // cmbNgaySua
            // 
            cmbNgaySua.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNgaySua.FormattingEnabled = true;
            cmbNgaySua.Items.AddRange(new object[] { "--None--", "Tăng dần", "Giảm dần" });
            cmbNgaySua.Location = new Point(679, 3);
            cmbNgaySua.Name = "cmbNgaySua";
            cmbNgaySua.Size = new Size(130, 33);
            cmbNgaySua.TabIndex = 20;
            cmbNgaySua.SelectionChangeCommitted += cmbNgaySua_SelectionChangeCommitted;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(589, 6);
            label2.Name = "label2";
            label2.Size = new Size(92, 25);
            label2.TabIndex = 102;
            label2.Text = "Ngày sửa";
            // 
            // cmbNgayTao
            // 
            cmbNgayTao.BackColor = Color.White;
            cmbNgayTao.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNgayTao.FormattingEnabled = true;
            cmbNgayTao.Items.AddRange(new object[] { "--None--", "Tăng dần", "Giảm dần" });
            cmbNgayTao.Location = new Point(442, 3);
            cmbNgayTao.Name = "cmbNgayTao";
            cmbNgayTao.Size = new Size(126, 33);
            cmbNgayTao.TabIndex = 20;
            cmbNgayTao.SelectionChangeCommitted += cmbNgayTao_SelectionChangeCommitted;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(352, 6);
            label1.Name = "label1";
            label1.Size = new Size(90, 25);
            label1.TabIndex = 102;
            label1.Text = "Ngày tạo";
            // 
            // panel5
            // 
            panel5.Controls.Add(txtGhiChu);
            panel5.Controls.Add(panel4);
            panel5.Controls.Add(panelFormatText);
            panel5.Controls.Add(txtNoiDung);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 40);
            panel5.Name = "panel5";
            panel5.Size = new Size(1098, 757);
            panel5.TabIndex = 102;
            // 
            // txtGhiChu
            // 
            txtGhiChu.BackColor = SystemColors.GradientInactiveCaption;
            txtGhiChu.Dock = DockStyle.Fill;
            txtGhiChu.Font = new Font("Times New Roman", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtGhiChu.Location = new Point(0, 419);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(1098, 338);
            txtGhiChu.TabIndex = 4;
            txtGhiChu.Text = "";
            txtGhiChu.KeyDown += txtGhiChu_KeyDown;
            txtGhiChu.Leave += txtGhiChu_Leave;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.Highlight;
            panel4.BorderStyle = BorderStyle.Fixed3D;
            panel4.Controls.Add(label6);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 375);
            panel4.Name = "panel4";
            panel4.Size = new Size(1098, 44);
            panel4.TabIndex = 101;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.BackColor = Color.White;
            label6.BorderStyle = BorderStyle.Fixed3D;
            label6.Location = new Point(505, 7);
            label6.Name = "label6";
            label6.Size = new Size(90, 27);
            label6.TabIndex = 1;
            label6.Text = "GHI CHÚ";
            // 
            // panelFormatText
            // 
            panelFormatText.BackColor = SystemColors.GradientActiveCaption;
            panelFormatText.BorderStyle = BorderStyle.Fixed3D;
            panelFormatText.Controls.Add(btnShowSymbol);
            panelFormatText.Controls.Add(btnSymbolMenu);
            panelFormatText.Controls.Add(label9);
            panelFormatText.Controls.Add(btnShowColor);
            panelFormatText.Controls.Add(btnColorMenu);
            panelFormatText.Controls.Add(label8);
            panelFormatText.Controls.Add(label7);
            panelFormatText.Controls.Add(btnItalic);
            panelFormatText.Controls.Add(btnUnderline);
            panelFormatText.Controls.Add(btnBold);
            panelFormatText.Dock = DockStyle.Top;
            panelFormatText.Location = new Point(0, 331);
            panelFormatText.Name = "panelFormatText";
            panelFormatText.Size = new Size(1098, 44);
            panelFormatText.TabIndex = 6;
            panelFormatText.Visible = false;
            // 
            // btnShowSymbol
            // 
            btnShowSymbol.Anchor = AnchorStyles.None;
            btnShowSymbol.BackColor = Color.MediumAquamarine;
            btnShowSymbol.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnShowSymbol.ForeColor = SystemColors.ActiveCaptionText;
            btnShowSymbol.ImageList = imageList1;
            btnShowSymbol.Location = new Point(559, 6);
            btnShowSymbol.Name = "btnShowSymbol";
            btnShowSymbol.Size = new Size(35, 29);
            btnShowSymbol.TabIndex = 108;
            btnShowSymbol.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnShowSymbol.UseVisualStyleBackColor = false;
            btnShowSymbol.Click += btnShowSymbol_Click;
            // 
            // btnSymbolMenu
            // 
            btnSymbolMenu.Anchor = AnchorStyles.None;
            btnSymbolMenu.BackColor = Color.Pink;
            btnSymbolMenu.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSymbolMenu.ForeColor = SystemColors.ActiveCaptionText;
            btnSymbolMenu.ImageIndex = 15;
            btnSymbolMenu.ImageList = imageList1;
            btnSymbolMenu.Location = new Point(524, 6);
            btnSymbolMenu.Name = "btnSymbolMenu";
            btnSymbolMenu.Size = new Size(35, 29);
            btnSymbolMenu.TabIndex = 107;
            btnSymbolMenu.TextAlign = ContentAlignment.MiddleRight;
            btnSymbolMenu.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSymbolMenu.UseVisualStyleBackColor = false;
            btnSymbolMenu.Click += btnSymbolMenu_Click_1;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.None;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(391, 9);
            label9.Name = "label9";
            label9.Size = new Size(127, 23);
            label9.TabIndex = 106;
            label9.Text = "Ký tự đặc biệt:";
            // 
            // btnShowColor
            // 
            btnShowColor.Anchor = AnchorStyles.None;
            btnShowColor.BackColor = Color.Black;
            btnShowColor.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnShowColor.Location = new Point(338, 5);
            btnShowColor.Name = "btnShowColor";
            btnShowColor.Size = new Size(35, 29);
            btnShowColor.TabIndex = 105;
            btnShowColor.Text = " ";
            btnShowColor.UseVisualStyleBackColor = false;
            btnShowColor.Click += btnShowColor_Click;
            // 
            // btnColorMenu
            // 
            btnColorMenu.Anchor = AnchorStyles.None;
            btnColorMenu.BackColor = Color.Pink;
            btnColorMenu.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnColorMenu.ForeColor = SystemColors.ActiveCaptionText;
            btnColorMenu.ImageIndex = 10;
            btnColorMenu.ImageList = imageList1;
            btnColorMenu.Location = new Point(303, 5);
            btnColorMenu.Name = "btnColorMenu";
            btnColorMenu.Size = new Size(35, 29);
            btnColorMenu.TabIndex = 104;
            btnColorMenu.TextAlign = ContentAlignment.MiddleRight;
            btnColorMenu.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnColorMenu.UseVisualStyleBackColor = false;
            btnColorMenu.Click += btnColorMenu_Click;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.None;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(213, 9);
            label8.Name = "label8";
            label8.Size = new Size(84, 23);
            label8.TabIndex = 103;
            label8.Text = "Màu chữ:";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(3, 8);
            label7.Name = "label7";
            label7.Size = new Size(84, 23);
            label7.TabIndex = 102;
            label7.Text = "Kiểu chữ:";
            // 
            // btnItalic
            // 
            btnItalic.Anchor = AnchorStyles.None;
            btnItalic.BackColor = Color.Pink;
            btnItalic.Font = new Font("Times New Roman", 10.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btnItalic.Location = new Point(159, 5);
            btnItalic.Name = "btnItalic";
            btnItalic.Size = new Size(31, 29);
            btnItalic.TabIndex = 2;
            btnItalic.Text = "I";
            btnItalic.UseVisualStyleBackColor = false;
            btnItalic.Click += btnItalic_Click;
            // 
            // btnUnderline
            // 
            btnUnderline.Anchor = AnchorStyles.None;
            btnUnderline.BackColor = Color.Pink;
            btnUnderline.Font = new Font("Times New Roman", 10.8F, FontStyle.Underline, GraphicsUnit.Point, 0);
            btnUnderline.Location = new Point(125, 5);
            btnUnderline.Name = "btnUnderline";
            btnUnderline.Size = new Size(31, 29);
            btnUnderline.TabIndex = 1;
            btnUnderline.Text = "U";
            btnUnderline.UseVisualStyleBackColor = false;
            btnUnderline.Click += btnUnderline_Click;
            // 
            // btnBold
            // 
            btnBold.Anchor = AnchorStyles.None;
            btnBold.BackColor = Color.Pink;
            btnBold.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBold.Location = new Point(91, 5);
            btnBold.Name = "btnBold";
            btnBold.Size = new Size(31, 29);
            btnBold.TabIndex = 0;
            btnBold.Text = "B";
            btnBold.UseVisualStyleBackColor = false;
            btnBold.Click += btnBold_Click;
            // 
            // txtNoiDung
            // 
            txtNoiDung.BackColor = SystemColors.GradientInactiveCaption;
            txtNoiDung.Dock = DockStyle.Top;
            txtNoiDung.Font = new Font("Times New Roman", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNoiDung.Location = new Point(0, 0);
            txtNoiDung.Name = "txtNoiDung";
            txtNoiDung.Size = new Size(1098, 331);
            txtNoiDung.TabIndex = 3;
            txtNoiDung.Text = "";
            txtNoiDung.KeyDown += txtNoiDung_KeyDown;
            txtNoiDung.Leave += txtNoiDung_Leave;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Highlight;
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Controls.Add(label4);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1098, 40);
            panel3.TabIndex = 100;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.BorderStyle = BorderStyle.Fixed3D;
            label4.Location = new Point(495, 5);
            label4.Name = "label4";
            label4.Size = new Size(106, 27);
            label4.TabIndex = 0;
            label4.Text = "NỘI DUNG";
            // 
            // colorMenu
            // 
            colorMenu.ImageScalingSize = new Size(20, 20);
            colorMenu.Items.AddRange(new ToolStripItem[] { btnMoreColors });
            colorMenu.Name = "colorMenu";
            colorMenu.Size = new Size(167, 28);
            // 
            // btnMoreColors
            // 
            btnMoreColors.Name = "btnMoreColors";
            btnMoreColors.Size = new Size(166, 24);
            btnMoreColors.Text = "More colors...";
            btnMoreColors.Click += btnMoreColors_Click;
            // 
            // symbolMenu
            // 
            symbolMenu.ImageScalingSize = new Size(20, 20);
            symbolMenu.Name = "symbolMenu";
            symbolMenu.Size = new Size(61, 4);
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 887);
            Controls.Add(splitContainer1);
            Controls.Add(panel1);
            Controls.Add(flowPanel);
            Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Margin = new Padding(4);
            Name = "frmMain";
            Text = "Cẩm nang Cyber";
            Load += frmMain_Load;
            KeyDown += frmMain_KeyDown;
            flowPanel.ResumeLayout(false);
            flowPanel.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDSTU).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panelLoc.ResumeLayout(false);
            panelLoc.PerformLayout();
            panel5.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panelFormatText.ResumeLayout(false);
            panelFormatText.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            colorMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowPanel;
        private ImageList imageList1;
        private Panel panel1;
        private Label lbTuVietTat;
        private Label lbTuDayDu;
        private ComboBox cmbTuVietTat;
        private ComboBox cmbTuDayDu;
        private Button btnThem;
        private Button btnCapNhat;
        private Button btnLuu;
        private Button btnXoa;
        private Button btnThoat;
        private Button btnTraCuu;
        private SplitContainer splitContainer1;
        private Panel panel2;
        private Label label3;
        private Panel panel3;
        private Label label4;
        private RichTextBox txtNoiDung;
        private RichTextBox txtGhiChu;
        private Button btnTaiLai;
        private Button btnPhucHoi;
        private Label label5;
        private ComboBox cmbLinhVuc;
        private Panel panel4;
        private Label label6;
        private DataGridView dgvDSTU;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn TUVIETTAT;
        private DataGridViewTextBoxColumn TUDAYDU;
        private DataGridViewTextBoxColumn NOIDUNG;
        private DataGridViewTextBoxColumn GHICHU;
        private DataGridViewTextBoxColumn LINHVUC;
        private Panel panel5;
        private Panel panelLoc;
        private TextBox txtTuDayDu;
        private TextBox txtTuVietTat;
        private Label lbLinhVuc;
        private ComboBox cmbLinhVuc1;
        private DataGridViewTextBoxColumn CreatedDate;
        private DataGridViewTextBoxColumn ModifiedDate;
        private ComboBox cmbNgayTao;
        private Label label1;
        private ComboBox cmbNgaySua;
        private Label label2;
        private Panel panelFormatText;
        private Button btnItalic;
        private Button btnUnderline;
        private Button btnBold;
        private ColorDialog colorDialog1;
        private Label label7;
        private Button btnColorMenu;
        private Label label8;
        private ContextMenuStrip colorMenu;
        private ToolStripMenuItem btnMoreColors;
        private Button btnShowColor;
        private Panel panel6;
        private TextBox txtPage;
        private Button btnFirstPage;
        private Button btnPrePage;
        private Button btnLastPage;
        private Button btnNextPage;
        private Label label9;
        private Button btnSymbolMenu;
        private Button btnShowSymbol;
        private ContextMenuStrip symbolMenu;
    }
}
