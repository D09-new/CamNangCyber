using System.Data;
using System.Data.SQLite;
namespace TuDienChuyenNganhCyberSecurity
{
    public partial class frmMain : Form
    {
        DataTable dtOriginal = new DataTable(); // Chứa toàn bộ dữ liệu gốc
        int currentPage = 1;  // Trang hiện tại
        readonly int pageSize = 25;    // Số dòng trên một trang
        int totalPages = 1;   // Tổng số trang
        string kieuSapXep = "";
        public static BindingSource bds_dscmb = new BindingSource();
        public static BindingSource bds_dstu = new BindingSource();
        public static BindingSource bds_dslinhvuc = new BindingSource();
        public static BindingSource bds_dslinhvuc1 = new BindingSource();
        public static BindingSource bds_dsbuoihocfrom = new BindingSource();
        public static BindingSource bds_dsbuoihocto = new BindingSource();
        public static BindingSource bds_dskhoahoc = new BindingSource();
        public static BindingSource bds_dskhoahoc1 = new BindingSource();
        int position = 0;
        int buoiHocMax = 0;
        bool isAdd = false;
        bool isUpdate = false;
        bool isLoading = false;
        bool isSearching = false;
        string linhvuc = "Tất cả";
        string tuviettat = "";
        string tudaydu = "";
        //Loc theo khoa hoc va buoi hoc
        string lastFrom = "";
        string lastTo = "";
        string lastCourse = "Tất cả";
        RichTextBox targetRtb;
        int selectionStart = -1;
        int selectionLength = 0;

        public frmMain()
        {
            InitializeComponent();
            InitColorPicker();
            InitSymbolPicker();
            cmbTuDayDu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbTuDayDu.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbTuVietTat.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbTuVietTat.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbLinhVuc.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbLinhVuc.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbLinhVuc1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbLinhVuc1.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbKhoaHoc.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbKhoaHoc.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbKhoaHoc1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbKhoaHoc1.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbFrom.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbFrom.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbTo.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbTo.AutoCompleteSource = AutoCompleteSource.ListItems;
            lbTuDayDu.Visible = cmbTuDayDu.Visible = lbTuVietTat.Visible = cmbTuVietTat.Visible = false;
            txtNoiDung.ReadOnly = txtGhiChu.ReadOnly = true;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                isLoading = true;
                using (var connection = new SQLiteConnection(Program.connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM TUDIEN ORDER BY TUVIETTAT";
                    string query2 = "SELECT LINHVUC FROM TUDIEN GROUP BY LINHVUC";
                    string query3 = "SELECT KHOAHOC FROM TUDIEN GROUP BY KHOAHOC";
                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                        da.Fill(dtOriginal);
                        DisplayPage(1);
                        bds_dscmb.DataSource = dtOriginal;
                        cmbTuDayDu.DataSource = bds_dscmb;
                        cmbTuDayDu.DisplayMember = "TuDayDu";
                        cmbTuDayDu.ValueMember = "ID";
                        cmbTuDayDu.SelectedIndex = -1;
                        cmbTuVietTat.DataSource = bds_dscmb;
                        cmbTuVietTat.DisplayMember = "TuVietTat";
                        cmbTuVietTat.ValueMember = "ID";
                        cmbTuVietTat.SelectedIndex = -1;
                        dgvDSTU.DataSource = bds_dstu;
                    }
                    using (var cmd2 = new SQLiteCommand(query2, connection))
                    {
                        DataTable dt = new DataTable();
                        DataTable dt1 = new DataTable();
                        SQLiteDataAdapter da2 = new SQLiteDataAdapter(cmd2);
                        da2.Fill(dt);
                        da2.Fill(dt1);
                        bds_dslinhvuc1.DataSource = dt1;
                        cmbLinhVuc1.DataSource = bds_dslinhvuc1;
                        cmbLinhVuc1.DisplayMember = "LINHVUC";
                        cmbLinhVuc1.ValueMember = "LINHVUC";
                        cmbLinhVuc1.SelectedIndex = 0;
                        DataRow dr = dt.NewRow();
                        dr["LINHVUC"] = "Tất cả";
                        dt.Rows.InsertAt(dr, 0);
                        bds_dslinhvuc.DataSource = dt;
                        cmbLinhVuc.DataSource = bds_dslinhvuc;
                        cmbLinhVuc.DisplayMember = "LINHVUC";
                        cmbLinhVuc.ValueMember = "LINHVUC";
                        cmbLinhVuc.SelectedIndex = 0;
                    }
                    using (var cmd3 = new SQLiteCommand(query3, connection))
                    {
                        DataTable dt3 = new DataTable();
                        DataTable dt4 = new DataTable();
                        SQLiteDataAdapter da3 = new SQLiteDataAdapter(cmd3);
                        da3.Fill(dt3);
                        da3.Fill(dt4);
                        bds_dskhoahoc1.DataSource = dt4;
                        cmbKhoaHoc1.DataSource = bds_dskhoahoc1;
                        cmbKhoaHoc1.DisplayMember = "KHOAHOC";
                        cmbKhoaHoc1.ValueMember = "KHOAHOC";
                        cmbKhoaHoc1.SelectedIndex = -1;
                        DataRow dr = dt3.NewRow();
                        dr["KHOAHOC"] = "Tất cả";
                        dt3.Rows.InsertAt(dr, 0);
                        bds_dskhoahoc.DataSource = dt3;
                        cmbKhoaHoc.DataSource = bds_dskhoahoc;
                        cmbKhoaHoc.DisplayMember = "KHOAHOC";
                        cmbKhoaHoc.ValueMember = "KHOAHOC";
                        cmbKhoaHoc.SelectedIndex = 0;
                    }
                }
                cmbNgaySua.SelectedIndex = cmbNgayTao.SelectedIndex = 0;
                if (bds_dstu.Count > 0)
                {
                    bds_dstu.Position = 0;
                    DataRowView row = bds_dstu[0] as DataRowView;
                    GanNoiDungRichTextBox(txtNoiDung, row["NoiDung"]);
                    GanNoiDungRichTextBox(txtGhiChu, row["GhiChu"]);
                    cmbLinhVuc1.SelectedValue = row["LinhVuc"];
                }
                isLoading = false;

            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void InitSymbolPicker()
        {
            symbolMenu.AutoSize = true;
            symbolMenu.DropShadowEnabled = true;

            // 2. Khởi tạo và cấu hình lưới màu chặt chẽ
            TableLayoutPanel symbolGrid = new TableLayoutPanel();
            symbolGrid.ColumnCount = 8;
            symbolGrid.RowCount = 2;

            // ÉP CỐ ĐỊNH KÍCH THƯỚC LƯỚI (Chiều rộng 200px, Chiều cao 55px)
            // Điều này ngăn menu biến nó thành sọc dọc
            symbolGrid.Size = new Size(200, 55);
            symbolGrid.MaximumSize = new Size(300, 300);
            symbolGrid.MinimumSize = new Size(300, 300);
            symbolGrid.Padding = new Padding(2);
            symbolGrid.Margin = new Padding(0);

            // QUAN TRỌNG: Chia đều 8 cột, mỗi cột chiếm 12.5% độ rộng
            for (int i = 0; i < 8; i++)
            {
                symbolGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5f));
            }
            // Chia đều 2 hàng, mỗi hàng chiếm 50% độ cao
            for (int i = 0; i < 6; i++)
            {
                symbolGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
            }

            // Danh sách các ký tự đặc biệt phổ biến
            string[] symbols = {
                                    "©", "®", "™", "€", "£", "¥", "¢", "¤",
                                    "±", "×", "÷", "≠", "≈", "≤", "≥", "∞",
                                    "½", "⅓", "⅔", "¼", "¾", "‰", "°", "µ",
                                    "α", "β", "γ", "δ", "π", "Σ", "Ω", "λ",
                                    "←", "↑", "→", "↓", "↔", "⇒", "⇔", "♥",
                                    "★", "☎", "✂", "✔", "✖", "⚡", "☀", "☁"
                                };

            // 3. Tạo các ô màu nhỏ đưa vào lưới
            foreach (string col in symbols)
            {
                Button cell = new Button();
                cell.Dock = DockStyle.Fill; // Để ô tự lấp đầy ô lưới được chia
                cell.Margin = new Padding(2); // Khoảng cách giữa các ô 
                cell.Text = col;
                cell.FlatStyle = FlatStyle.Flat;
                cell.FlatAppearance.BorderSize = 1;
                cell.FlatAppearance.BorderColor = Color.Silver;
                cell.Cursor = Cursors.Hand;

                cell.Click += (s, ev) =>
                {
                    InsertSymbol(col);
                    symbolMenu.Close();
                };

                symbolGrid.Controls.Add(cell);
            }

            // 4. Nhúng lưới vào menu đã thiết kế bằng giao diện
            ToolStripControlHost host = new ToolStripControlHost(symbolGrid);
            host.AutoSize = false; // Tắt AutoSize của host để nó tuân theo kích thước 200x55 cố định ở trên
            host.Size = new Size(300, 300);
            host.Margin = Padding.Empty;
            host.Padding = Padding.Empty;
            host.Font = new Font("Segoe UI", 12); // Đặt font chữ cho các ký tự đặc biệt
            symbolMenu.Items.Insert(0, host);
            symbolMenu.Items.Insert(1, new ToolStripSeparator());
        }

        private void InitColorPicker()
        {
            colorMenu.AutoSize = true;
            colorMenu.DropShadowEnabled = true;

            // 2. Khởi tạo và cấu hình lưới màu chặt chẽ
            TableLayoutPanel colorGrid = new TableLayoutPanel();
            colorGrid.ColumnCount = 8;
            colorGrid.RowCount = 2;

            // ÉP CỐ ĐỊNH KÍCH THƯỚC LƯỚI MÀU (Chiều rộng 200px, Chiều cao 55px)
            // Điều này ngăn menu biến nó thành sọc dọc
            colorGrid.Size = new Size(200, 55);
            colorGrid.MaximumSize = new Size(200, 55);
            colorGrid.MinimumSize = new Size(200, 55);
            colorGrid.Padding = new Padding(2);
            colorGrid.Margin = new Padding(0);

            // QUAN TRỌNG: Chia đều 8 cột, mỗi cột chiếm 12.5% độ rộng
            for (int i = 0; i < 8; i++)
            {
                colorGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5f));
            }
            // Chia đều 2 hàng, mỗi hàng chiếm 50% độ cao
            for (int i = 0; i < 2; i++)
            {
                colorGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
            }

            // Mảng 16 màu phổ biến giống Word
            Color[] colors = {  Color.Black, Color.Gray, Color.Red, Color.Orange, Color.Yellow,
                                    Color.Green, Color.Blue, Color.Purple, Color.White, Color.LightGray,
                                    Color.Pink, Color.LightSalmon, Color.LightYellow, Color.LightGreen,
                                    Color.LightSkyBlue, Color.Lavender
                                  };

            // 3. Tạo các ô màu nhỏ đưa vào lưới
            foreach (Color col in colors)
            {
                Button cell = new Button();
                cell.Dock = DockStyle.Fill; // Để ô màu tự lấp đầy ô lưới được chia
                cell.Margin = new Padding(2); // Khoảng cách giữa các ô màu
                cell.BackColor = col;
                cell.FlatStyle = FlatStyle.Flat;
                cell.FlatAppearance.BorderSize = 1;
                cell.FlatAppearance.BorderColor = Color.Silver;
                cell.Cursor = Cursors.Hand;

                cell.Click += (s, ev) =>
                {
                    ChangeColor(col);
                    colorMenu.Close();
                };

                colorGrid.Controls.Add(cell);
            }

            // 4. Nhúng lưới màu vào menu đã thiết kế bằng giao diện
            ToolStripControlHost host = new ToolStripControlHost(colorGrid);
            host.AutoSize = false; // Tắt AutoSize của host để nó tuân theo kích thước 200x55 cố định ở trên
            host.Size = new Size(200, 55);
            host.Margin = Padding.Empty;
            host.Padding = Padding.Empty;
            colorMenu.Items.Insert(0, host);
            colorMenu.Items.Insert(1, new ToolStripSeparator());
        }


        private void InsertSymbol(string symbol)
        {
            btnShowSymbol.Text = symbol;
            if (targetRtb != null && selectionStart != -1)
            {
                targetRtb.SelectionStart = selectionStart;
                targetRtb.SelectionLength = selectionLength;
                targetRtb.SelectedText = symbol;
                targetRtb.SelectionStart = selectionStart + symbol.Length;
                targetRtb.SelectionLength = 0;
                targetRtb.Focus();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ô nhập liệu trước khi chèn ký tự đặc biệt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (isAdd)
                {
                    MessageBox.Show("Đang ở chế độ thêm. Vui lòng hoàn tất hoặc hủy bỏ trước khi tra cứu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (isSearching)
                {
                    btnTraCuu.Text = "Tra cứu";
                    lbTuDayDu.Visible = cmbTuDayDu.Visible = lbTuVietTat.Visible = cmbTuVietTat.Visible = false;
                    btnThem.Enabled = btnLuu.Enabled = btnXoa.Enabled = dgvDSTU.Enabled = true;
                    isSearching = false;
                    panelLoc.Visible = true;
                }
                else
                {
                    panelLoc.Visible = false;
                    isSearching = true;
                    btnTraCuu.Text = "Kết thúc tra cứu";
                    lbTuDayDu.Visible = cmbTuDayDu.Visible = lbTuVietTat.Visible = cmbTuVietTat.Visible = true;
                    btnThem.Enabled = btnLuu.Enabled = btnXoa.Enabled = dgvDSTU.Enabled = false;
                    cmbTuVietTat.Focus();
                }
            }
            catch (Exception)
            {

            }
        }

        private void GanNoiDungRichTextBox(
           RichTextBox richTextBox,
           object giaTri)
        {
            if (giaTri == null ||
                giaTri == DBNull.Value ||
                string.IsNullOrWhiteSpace(giaTri.ToString()))
            {
                richTextBox.Clear();
                return;
            }

            string noiDung = giaTri.ToString();

            try
            {
                /*
                 * Nếu dữ liệu là chuỗi RTF hợp lệ,
                 * giữ nguyên định dạng.
                 */
                richTextBox.Rtf = noiDung;
            }
            catch (ArgumentException)
            {
                /*
                 * Nếu dữ liệu chỉ là văn bản thường,
                 * hiển thị bằng thuộc tính Text.
                 */
                richTextBox.Text = noiDung;
            }
        }


        private void cmbTuDayDu_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbTuVietTat.SelectedIndex = cmbTuDayDu.SelectedIndex;
        }

        private void cmbTuVietTat_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbTuDayDu.SelectedIndex = cmbTuVietTat.SelectedIndex;
        }




        private void cmbTuDayDu_Leave(object sender, EventArgs e)
        {
            int index = cmbTuDayDu.FindStringExact(cmbTuDayDu.Text.Trim());
            if (index != -1)
            {
                cmbTuDayDu.SelectedIndex = index;
                cmbTuVietTat.SelectedIndex = index;
                DataRowView row = bds_dscmb[index] as DataRowView;
                GanNoiDungRichTextBox(txtNoiDung, row["NoiDung"]);
                GanNoiDungRichTextBox(txtGhiChu, row["GhiChu"]);
                this.BeginInvoke(new Action(() => { this.ActiveControl = null; }));
            }
            else
            {
                cmbTuDayDu.SelectedIndex = -1;
                cmbTuVietTat.SelectedIndex = -1;
            }
        }

        private void cmbTuVietTat_Leave(object sender, EventArgs e)
        {
            int index = cmbTuVietTat.FindStringExact(cmbTuVietTat.Text.Trim());
            if (index != -1)
            {
                cmbTuDayDu.SelectedIndex = index;
                cmbTuVietTat.SelectedIndex = index;
                DataRowView row = bds_dscmb[index] as DataRowView;
                GanNoiDungRichTextBox(txtNoiDung, row["NoiDung"]);
                GanNoiDungRichTextBox(txtGhiChu, row["GhiChu"]);
                this.BeginInvoke(new Action(() => { this.ActiveControl = null; }));
            }
            else
            {
                cmbTuDayDu.SelectedIndex = -1;
                cmbTuVietTat.SelectedIndex = -1;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }


        private void Reload()
        {
            try
            {
                isLoading = true;
                if (isAdd || isUpdate)
                {
                    linhvuc = cmbLinhVuc.SelectedValue.ToString();
                }
                using (var connection = new SQLiteConnection(Program.connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM TUDIEN ORDER BY TUVIETTAT";
                    string query2 = "SELECT LINHVUC FROM TUDIEN GROUP BY LINHVUC";
                    string query3 = "SELECT KHOAHOC FROM TUDIEN GROUP BY KHOAHOC";
                    string query4 = "SELECT BUOIHOC FROM TUDIEN WHERE KHOAHOC = @KHOAHOC GROUP BY BUOIHOC";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                        dtOriginal.Clear();
                        da.Fill(dtOriginal);
                        bds_dscmb.DataSource = dtOriginal;
                        cmbTuDayDu.DataSource = bds_dscmb;
                        cmbTuDayDu.DisplayMember = "TuDayDu";
                        cmbTuDayDu.ValueMember = "ID";
                        cmbTuDayDu.SelectedIndex = -1;
                        cmbTuVietTat.DataSource = bds_dscmb;
                        cmbTuVietTat.DisplayMember = "TuVietTat";
                        cmbTuVietTat.ValueMember = "ID";
                        cmbTuVietTat.SelectedIndex = -1;
                        if (position != -1)
                        {
                            DataRowView row = bds_dstu[position] as DataRowView;
                            GanNoiDungRichTextBox(txtNoiDung, row["NoiDung"]);
                            GanNoiDungRichTextBox(txtGhiChu, row["GhiChu"]);
                        }
                    }
                    using (SQLiteCommand cmd2 = new SQLiteCommand(query2, connection))
                    {
                        DataTable dt1 = new DataTable();
                        DataTable dt2 = new DataTable();
                        SQLiteDataAdapter da2 = new SQLiteDataAdapter(cmd2);
                        da2.Fill(dt1);
                        da2.Fill(dt2);
                        bds_dslinhvuc1.DataSource = dt2;
                        cmbLinhVuc1.DataSource = bds_dslinhvuc1;
                        cmbLinhVuc1.DisplayMember = "LINHVUC";
                        cmbLinhVuc1.ValueMember = "LINHVUC";
                        if (position != -1)
                        {
                            DataRowView row = bds_dstu[position] as DataRowView;
                            cmbLinhVuc1.SelectedValue = row["LinhVuc"];
                        }
                        else
                        {
                            cmbLinhVuc1.SelectedValue = -1;
                        }
                        DataRow dr = dt1.NewRow();
                        dr["LINHVUC"] = "Tất cả";
                        dt1.Rows.InsertAt(dr, 0);
                        bds_dslinhvuc.DataSource = dt1;
                        cmbLinhVuc.DataSource = bds_dslinhvuc;
                        cmbLinhVuc.DisplayMember = "LINHVUC";
                        cmbLinhVuc.ValueMember = "LINHVUC";
                        if (linhvuc != null && linhvuc != "")
                        {
                            cmbLinhVuc.SelectedValue = linhvuc;
                        }
                    }
                    using (var cmd3 = new SQLiteCommand(query3, connection))
                    {
                        DataTable dt3 = new DataTable();
                        DataTable dt4 = new DataTable();
                        SQLiteDataAdapter da3 = new SQLiteDataAdapter(cmd3);
                        da3.Fill(dt3);
                        da3.Fill(dt4);
                        bds_dskhoahoc1.DataSource = dt4;
                        cmbKhoaHoc1.DataSource = bds_dskhoahoc1;
                        cmbKhoaHoc1.DisplayMember = "KHOAHOC";
                        cmbKhoaHoc1.ValueMember = "KHOAHOC";
                        cmbKhoaHoc1.SelectedIndex = -1;
                        DataRow dr = dt3.NewRow();
                        dr["KHOAHOC"] = "Tất cả";
                        dt3.Rows.InsertAt(dr, 0);
                        bds_dskhoahoc.DataSource = dt3;
                        cmbKhoaHoc.DataSource = bds_dskhoahoc;
                        cmbKhoaHoc.DisplayMember = "KHOAHOC";
                        cmbKhoaHoc.ValueMember = "KHOAHOC";
                        cmbKhoaHoc.SelectedValue = lastCourse;
                    }
                    if (cmbKhoaHoc.SelectedIndex > 0 && cmbKhoaHoc.SelectedValue != null && cmbKhoaHoc.SelectedValue.ToString() != "--blank--")
                    {
                        using (var cmd4 = new SQLiteCommand(query4, connection))
                        {
                            cmd4.Parameters.AddWithValue("@KHOAHOC", cmbKhoaHoc.SelectedValue.ToString());
                            DataTable dt5 = new DataTable();
                            SQLiteDataAdapter da5 = new SQLiteDataAdapter(cmd4);
                            da5.Fill(dt5);
                            bds_dsbuoihocto.DataSource = dt5;
                            cmbFrom.DataSource = bds_dsbuoihocfrom;
                            cmbFrom.DisplayMember = "BUOIHOC";
                            cmbFrom.ValueMember = "BUOIHOC";
                            if (lastFrom != "") cmbFrom.SelectedValue = lastFrom;
                            bds_dsbuoihocfrom.DataSource = dt5;
                            cmbTo.DataSource = bds_dsbuoihocto;
                            cmbTo.DisplayMember = "BUOIHOC";
                            cmbTo.ValueMember = "BUOIHOC";
                            if (lastTo != "") cmbTo.SelectedValue = lastTo;
                        }
                    }

                }
                DisplayPage(currentPage);
                isLoading = false;
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            try
            {
                Reload();
            }
            catch (Exception)
            {

            }
        }

        private void btnPhucHoi_Click(object sender, EventArgs e)
        {
            txtGhiChu.ReadOnly = true;
            txtNoiDung.ReadOnly = true;
            panelLoc.Visible = true;
            txtNoiDung.BackColor = txtGhiChu.BackColor = SystemColors.GradientInactiveCaption;
            lbKhoaHoc.Visible = cmbKhoaHoc1.Visible = lbBuoiHoc.Visible = txtBuoiHoc.Visible = lbLinhVuc.Visible = cmbLinhVuc1.Visible = lbTuDayDu.Visible = txtTuDayDu.Visible = lbTuVietTat.Visible = txtTuVietTat.Visible = false;
            if (position != -1)
            {
                DataRowView row = bds_dstu[position] as DataRowView;
                GanNoiDungRichTextBox(txtNoiDung, row["NoiDung"]);
                GanNoiDungRichTextBox(txtGhiChu, row["GhiChu"]);
            }
            else
            {
                txtNoiDung.Clear();
                txtGhiChu.Clear();
            }
            cmbTuDayDu.SelectedIndex = -1;
            cmbTuVietTat.SelectedIndex = -1;
            dgvDSTU.Enabled = btnTraCuu.Enabled = btnThem.Enabled = btnCapNhat.Enabled = btnLuu.Enabled = btnTaiLai.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled = btnThoat.Enabled = true;
            if (isSearching)
            {
                lbTuDayDu.Visible = cmbTuDayDu.Visible = lbTuVietTat.Visible = cmbTuVietTat.Visible = false;
                btnTraCuu.Text = "Tra cứu";
                panelLoc.Visible = true;
            }
            if (isAdd || isUpdate)
            {
                panelFormatText.Visible = false;
            }
            cmbNgaySua.SelectedIndex = cmbNgayTao.SelectedIndex = 0;
            kieuSapXep = "";
            isAdd = false;
            isUpdate = false;
            isSearching = false;
            cmbLinhVuc.SelectedIndex = 0;
            cmbKhoaHoc.SelectedIndex = 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (isUpdate)
            {
                MessageBox.Show("Đang ở chế độ cập nhật. Vui lòng hoàn tất hoặc hủy bỏ trước khi thêm mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!isAdd)
            {
                position = bds_dstu.Position;
                txtNoiDung.Clear();
                txtGhiChu.Clear();
                cmbTuVietTat.Focus();
                cmbLinhVuc1.SelectedIndex = -1;
                txtTuDayDu.Clear();
                txtTuVietTat.Clear();
                cmbKhoaHoc1.SelectedIndex = -1;
                txtBuoiHoc.Clear();
            }
            isAdd = true;
            panelLoc.Visible = dgvDSTU.Enabled = btnTraCuu.Enabled = btnCapNhat.Enabled = btnTaiLai.Enabled = btnXoa.Enabled = btnThoat.Enabled = false;
            txtGhiChu.ReadOnly = false;
            txtNoiDung.ReadOnly = false;
            lbKhoaHoc.Visible = cmbKhoaHoc1.Visible = lbBuoiHoc.Visible = txtBuoiHoc.Visible = panelFormatText.Visible = lbLinhVuc.Visible = cmbLinhVuc1.Visible = lbTuDayDu.Visible = txtTuDayDu.Visible = lbTuVietTat.Visible = txtTuVietTat.Visible = true;
            txtNoiDung.BackColor = txtGhiChu.BackColor = Color.Thistle;
            txtTuVietTat.Focus();
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (isAdd)
            {
                MessageBox.Show("Đang ở chế độ thêm. Vui lòng hoàn tất hoặc hủy bỏ trước khi cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (isSearching && (cmbTuVietTat.SelectedIndex == -1 || cmbTuDayDu.SelectedIndex == -1))
            {
                MessageBox.Show("Vui lòng chọn từ cần cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTuVietTat.Focus();
                return;
            }
            if (isSearching)
            {
                btnLuu.Enabled = true;
                cmbTuDayDu.Visible = cmbTuVietTat.Visible = false;
                DataRowView row = bds_dscmb[bds_dscmb.Position] as DataRowView;
                tuviettat = txtTuVietTat.Text = row["TUVIETTAT"].ToString().Trim();
                tudaydu = txtTuDayDu.Text = row["TUDAYDU"].ToString().Trim();
                cmbLinhVuc1.SelectedValue = row["LINHVUC"];
                txtBuoiHoc.Text = (row["BUOIHOC"] == null || row["BUOIHOC"] == DBNull.Value) ? "" : row["BUOIHOC"].ToString().Trim();
                cmbKhoaHoc1.SelectedValue = (row["KHOAHOC"] == null || row["KHOAHOC"] == DBNull.Value) ? null : row["KHOAHOC"].ToString().Trim();
            }
            else
            {
                DataRowView row = bds_dstu[bds_dstu.Position] as DataRowView;
                tuviettat = txtTuVietTat.Text = row["TUVIETTAT"].ToString().Trim();
                tudaydu = txtTuDayDu.Text = row["TUDAYDU"].ToString().Trim();
                cmbLinhVuc1.SelectedValue = row["LINHVUC"];
                txtBuoiHoc.Text = (row["BUOIHOC"] == null || row["BUOIHOC"] == DBNull.Value) ? "" : row["BUOIHOC"].ToString().Trim();
                cmbKhoaHoc1.SelectedValue = (row["KHOAHOC"] == null || row["KHOAHOC"] == DBNull.Value) ? null : row["KHOAHOC"].ToString().Trim();
            }
            isUpdate = true;
            panelLoc.Visible = dgvDSTU.Enabled = btnTraCuu.Enabled = btnThem.Enabled = btnTaiLai.Enabled = btnXoa.Enabled = btnThoat.Enabled = false;
            txtGhiChu.ReadOnly = false;
            txtNoiDung.ReadOnly = false;
            lbKhoaHoc.Visible = cmbKhoaHoc1.Visible = lbBuoiHoc.Visible = txtBuoiHoc.Visible = panelFormatText.Visible = lbLinhVuc.Visible = cmbLinhVuc1.Visible = lbTuDayDu.Visible = txtTuDayDu.Visible = lbTuVietTat.Visible = txtTuVietTat.Visible = true;
            txtTuVietTat.Focus();
            txtNoiDung.BackColor = txtGhiChu.BackColor = Color.Thistle;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (isAdd)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(txtTuDayDu.Text.Trim()) || string.IsNullOrWhiteSpace(txtTuVietTat.Text.Trim()))
                    {
                        MessageBox.Show("Ô từ đầy đủ và từ viết tắt không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(cmbLinhVuc1.Text.Trim()))
                    {
                        MessageBox.Show("Ô lĩnh vực không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (Program.ComboBoxCoGiaTri2(cmbTuVietTat, "TuVietTat", "TuDayDu", txtTuVietTat.Text, txtTuDayDu.Text))
                    {
                        MessageBox.Show("Từ này đã tồn tại trong cầm nang.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    using (var connection = new SQLiteConnection(Program.connectionString))
                    {
                        string query = "INSERT INTO TUDIEN (TUVIETTAT, TUDAYDU, NOIDUNG, GHICHU, LINHVUC, KHOAHOC, BUOIHOC) VALUES (@TUVIETTAT, @TUDAYDU, @NOIDUNG, @GHICHU, @LINHVUC, @KHOAHOC, @BUOIHOC)";
                        connection.Open();
                        using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@TUVIETTAT", txtTuVietTat.Text.Trim());
                            cmd.Parameters.AddWithValue("@TUDAYDU", txtTuDayDu.Text.Trim());
                            if (Program.KiemTraCoDinhDang(txtNoiDung))
                            {
                                cmd.Parameters.AddWithValue("@NOIDUNG", txtNoiDung.Rtf);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@NOIDUNG", txtNoiDung.Text.Trim());
                            }
                            if (Program.KiemTraCoDinhDang(txtGhiChu))
                            {
                                cmd.Parameters.AddWithValue("@GHICHU", txtGhiChu.Rtf);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@GHICHU", txtGhiChu.Text.Trim());
                            }
                            cmd.Parameters.AddWithValue("@LINHVUC", cmbLinhVuc1.Text.Trim());
                            cmd.Parameters.AddWithValue("@KHOAHOC", string.IsNullOrWhiteSpace(cmbKhoaHoc1.Text) ? DBNull.Value : cmbKhoaHoc1.Text.Trim());
                            cmd.Parameters.AddWithValue("@BUOIHOC", string.IsNullOrWhiteSpace(txtBuoiHoc.Text) ? DBNull.Value : Convert.ToInt32(txtBuoiHoc.Text.Trim()));
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Thêm từ mới thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reload();
                    isAdd = false;
                    txtGhiChu.ReadOnly = true;
                    txtNoiDung.ReadOnly = true;
                    panelLoc.Visible = dgvDSTU.Enabled = btnTraCuu.Enabled = btnCapNhat.Enabled = btnTaiLai.Enabled = btnXoa.Enabled = btnThoat.Enabled = true;
                    txtNoiDung.BackColor = txtGhiChu.BackColor = SystemColors.GradientInactiveCaption;
                    lbKhoaHoc.Visible = cmbKhoaHoc1.Visible = lbBuoiHoc.Visible = txtBuoiHoc.Visible = panelFormatText.Visible = lbLinhVuc.Visible = cmbLinhVuc1.Visible = lbTuDayDu.Visible = txtTuDayDu.Visible = lbTuVietTat.Visible = txtTuVietTat.Visible = false;
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("Lỗi " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (isUpdate)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(txtTuDayDu.Text) || string.IsNullOrWhiteSpace(txtTuVietTat.Text))
                    {
                        MessageBox.Show("Ô từ đầy đủ và từ viết tắt không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(cmbLinhVuc1.Text))
                    {
                        MessageBox.Show("Ô lĩnh vực không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (tuviettat != txtTuVietTat.Text.Trim() || tudaydu != txtTuDayDu.Text.Trim())
                    {
                        if (Program.ComboBoxCoGiaTri2(cmbTuVietTat, "TuVietTat", "TuDayDu", txtTuVietTat.Text.Trim(), txtTuDayDu.Text.Trim()))
                        {
                            MessageBox.Show("Từ đã tồn tại trong cẩm nang", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    using (var connection = new SQLiteConnection(Program.connectionString))
                    {
                        string query = "UPDATE TUDIEN SET TUVIETTAT = @TUVIETTAT, TUDAYDU = @TUDAYDU, NOIDUNG = @NOIDUNG, GHICHU = @GHICHU, LINHVUC = @LINHVUC, KHOAHOC = @KHOAHOC, BUOIHOC = @BUOIHOC WHERE ID = @ID";
                        connection.Open();
                        if (isSearching)
                        {
                            using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                            {
                                DataRowView row = bds_dscmb[bds_dscmb.Position] as DataRowView;
                                cmd.Parameters.AddWithValue("@ID", row["ID"]);
                                cmd.Parameters.AddWithValue("@TUVIETTAT", txtTuVietTat.Text.Trim());
                                cmd.Parameters.AddWithValue("@TUDAYDU", txtTuDayDu.Text.Trim());
                                if (Program.KiemTraCoDinhDang(txtNoiDung))
                                {
                                    cmd.Parameters.AddWithValue("@NOIDUNG", txtNoiDung.Rtf);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@NOIDUNG", txtNoiDung.Text.Trim());
                                }
                                if (Program.KiemTraCoDinhDang(txtGhiChu))
                                {
                                    cmd.Parameters.AddWithValue("@GHICHU", txtGhiChu.Rtf);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@GHICHU", txtGhiChu.Text.Trim());
                                }
                                cmd.Parameters.AddWithValue("@LINHVUC", cmbLinhVuc1.Text.Trim());
                                cmd.Parameters.AddWithValue("@KHOAHOC", string.IsNullOrWhiteSpace(cmbKhoaHoc1.Text) ? DBNull.Value : cmbKhoaHoc1.Text.Trim());
                                cmd.Parameters.AddWithValue("@BUOIHOC", string.IsNullOrWhiteSpace(txtBuoiHoc.Text) ? DBNull.Value : Convert.ToInt32(txtBuoiHoc.Text.Trim()));
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                            {
                                DataRowView row = bds_dstu[bds_dstu.Position] as DataRowView;
                                cmd.Parameters.AddWithValue("@ID", row["ID"]);
                                cmd.Parameters.AddWithValue("@TUVIETTAT", txtTuVietTat.Text.Trim());
                                cmd.Parameters.AddWithValue("@TUDAYDU", txtTuDayDu.Text.Trim());
                                if (Program.KiemTraCoDinhDang(txtNoiDung))
                                {
                                    cmd.Parameters.AddWithValue("@NOIDUNG", txtNoiDung.Rtf);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@NOIDUNG", txtNoiDung.Text.Trim());
                                }
                                if (Program.KiemTraCoDinhDang(txtGhiChu))
                                {
                                    cmd.Parameters.AddWithValue("@GHICHU", txtGhiChu.Rtf);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@GHICHU", txtGhiChu.Text.Trim());
                                }
                                cmd.Parameters.AddWithValue("@LINHVUC", cmbLinhVuc1.Text.Trim());
                                cmd.Parameters.AddWithValue("@KHOAHOC", string.IsNullOrWhiteSpace(cmbKhoaHoc1.Text) ? DBNull.Value : cmbKhoaHoc1.Text.Trim());
                                cmd.Parameters.AddWithValue("@BUOIHOC", string.IsNullOrWhiteSpace(txtBuoiHoc.Text) ? DBNull.Value : Convert.ToInt32(txtBuoiHoc.Text.Trim()));
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    MessageBox.Show("Cập nhật từ thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reload();
                    isUpdate = false;
                    txtGhiChu.ReadOnly = true;
                    txtNoiDung.ReadOnly = true;
                    panelLoc.Visible = dgvDSTU.Enabled = btnTraCuu.Enabled = btnThem.Enabled = btnTaiLai.Enabled = btnXoa.Enabled = btnThoat.Enabled = true;
                    txtNoiDung.BackColor = txtGhiChu.BackColor = SystemColors.GradientInactiveCaption;
                    lbKhoaHoc.Visible = cmbKhoaHoc1.Visible = lbBuoiHoc.Visible = txtBuoiHoc.Visible = panelFormatText.Visible = lbLinhVuc.Visible = cmbLinhVuc1.Visible = lbTuDayDu.Visible = txtTuDayDu.Visible = lbTuVietTat.Visible = txtTuVietTat.Visible = false;
                    if (isSearching)
                    {
                        panelLoc.Visible = false;
                        btnXoa.Enabled = btnThem.Enabled = btnLuu.Enabled = false;
                        lbTuDayDu.Visible = lbTuVietTat.Visible = cmbTuDayDu.Visible = cmbTuVietTat.Visible = true;
                        dgvDSTU.Enabled = false;
                    }
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("Lỗi " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (isAdd)
            {
                MessageBox.Show("Đang ở chế độ thêm. Vui lòng hoàn tất hoặc hủy bỏ trước khi xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (isUpdate)
            {
                MessageBox.Show("Đang ở chế độ cập nhật. Vui lòng hoàn tất hoặc hủy bỏ trước khi xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa từ này không? Hành động này không thể hoàn tác!", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var connection = new SQLiteConnection(Program.connectionString))
                    {
                        string query = "DELETE FROM TUDIEN WHERE ID = @ID";
                        using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                        {
                            DataRowView row = bds_dstu[bds_dstu.Position] as DataRowView;
                            cmd.Parameters.AddWithValue("@ID", row["ID"]);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Xóa từ thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reload();
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("Lỗi " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtNoiDung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true; // Chặn lệnh paste mặc định

                if (Clipboard.ContainsText())
                {
                    string clipboardText = Clipboard.GetText();

                    // Đã cập nhật: Cấu hình font Times New Roman, Size 12, FontStyle.Regular cho đoạn sắp dán
                    txtNoiDung.SelectionFont = new Font("Times New Roman", 13, FontStyle.Regular);

                    // Chèn đoạn text vào
                    txtNoiDung.SelectedText = clipboardText;
                }
            }
            if (e.Control && e.KeyCode == Keys.B)
            {
                e.SuppressKeyPress = true; // Chặn tiếng "bíp" của hệ thống Windows

                btnBold.PerformClick();    // Gọi lại sự kiện Click của nút bấm
            }
            if (e.Control && e.KeyCode == Keys.U)
            {
                e.SuppressKeyPress = true; // Chặn tiếng "bíp" của hệ thống Windows

                btnUnderline.PerformClick();    // Gọi lại sự kiện Click của nút bấm
            }
            if (e.Control && e.KeyCode == Keys.I)
            {
                e.SuppressKeyPress = true; // Chặn tiếng "bíp" của hệ thống Windows

                btnItalic.PerformClick();    // Gọi lại sự kiện Click của nút bấm
            }
            if ((e.Alt && e.KeyCode == Keys.Right) || (e.Alt && e.KeyCode == Keys.Down) || (e.Control && e.KeyCode == Keys.Enter))
            {
                e.SuppressKeyPress = true; // Chặn tiếng "bíp" của hệ thống Windows
                txtGhiChu.Focus();
                e.Handled = true;
            }
            if ((e.Alt && e.KeyCode == Keys.Left) || (e.Alt && e.KeyCode == Keys.Up))
            {
                e.SuppressKeyPress = true; // Chặn tiếng "bíp" của hệ thống Windows
                txtBuoiHoc.Focus();
                e.Handled = true;
            }
        }

        private void txtGhiChu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true; // Chặn lệnh paste mặc định

                if (Clipboard.ContainsText())
                {
                    string clipboardText = Clipboard.GetText();

                    // Đã cập nhật: Cấu hình font Times New Roman, Size 13, FontStyle.Regular cho đoạn sắp dán
                    txtGhiChu.SelectionFont = new Font("Times New Roman", 13, FontStyle.Regular);

                    // Chèn đoạn text vào
                    txtGhiChu.SelectedText = clipboardText;
                }
            }
            if (e.Control && e.KeyCode == Keys.B)
            {
                e.SuppressKeyPress = true; // Chặn tiếng "bíp" của hệ thống Windows

                btnBold.PerformClick();    // Gọi lại sự kiện Click của nút bấm
            }
            if (e.Control && e.KeyCode == Keys.U)
            {
                e.SuppressKeyPress = true; // Chặn tiếng "bíp" của hệ thống Windows

                btnUnderline.PerformClick();    // Gọi lại sự kiện Click của nút bấm
            }
            if (e.Control && e.KeyCode == Keys.I)
            {
                e.SuppressKeyPress = true; // Chặn tiếng "bíp" của hệ thống Windows

                btnItalic.PerformClick();    // Gọi lại sự kiện Click của nút bấm
            }
            if ((e.Alt && e.KeyCode == Keys.Right) || (e.Alt && e.KeyCode == Keys.Down))
            {
                e.SuppressKeyPress = true; // Chặn tiếng "bíp" của hệ thống Windows
                txtTuVietTat.Focus();
                e.Handled = true;
            }
            if ((e.Alt && e.KeyCode == Keys.Left) || (e.Alt && e.KeyCode == Keys.Up))
            {
                e.SuppressKeyPress = true; // Chặn tiếng "bíp" của hệ thống Windows
                txtNoiDung.Focus();
                e.Handled = true;
            }
        }

        private void dgvDSTU_SelectionChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            if (bds_dstu.Count > 0)
            {
                position = bds_dstu.Position;
                DataRowView row = bds_dstu[bds_dstu.Position] as DataRowView;
                GanNoiDungRichTextBox(txtNoiDung, row["NoiDung"]);
                GanNoiDungRichTextBox(txtGhiChu, row["GhiChu"]);
            }
        }

        private void cmbLinhVuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            isLoading = true;
            if (cmbLinhVuc.SelectedIndex != -1 && Program.ComboBoxCoGiaTri(cmbLinhVuc, "LINHVUC", cmbLinhVuc.Text.Trim()))
            {
                linhvuc = cmbLinhVuc.SelectedValue == null ? "Tất cả" : cmbLinhVuc.SelectedValue.ToString(); 
                cmbKhoaHoc.SelectedValue = "Tất cả";
                cmbKhoaHoc.BackColor = Color.White;
                dgvDSTU.Columns["BuoiHoc"].Visible = dgvDSTU.Columns["KhoaHoc"].Visible = false;
                dgvDSTU.Columns["Linhvuc"].Visible = true;
                lbFrom.Visible = lbTo.Visible = cmbFrom.Visible = cmbTo.Visible = btnLoc.Visible = false;
                DisplayPage(1);
            }
            isLoading = false;
        }

        private void cmbNgaySua_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbNgaySua.SelectedIndex == 0)
            {
                kieuSapXep = "";
                dgvDSTU.Columns["ModifiedDate"].Visible = false;
            }
            else if (cmbNgaySua.SelectedIndex == 1)
            {
                kieuSapXep = "ModifiedDate ASC";
                dgvDSTU.Columns["ModifiedDate"].Visible = true;
            }
            else
            {
                kieuSapXep = "ModifiedDate DESC";
                dgvDSTU.Columns["ModifiedDate"].Visible = true;
            }
            cmbNgayTao.SelectedIndex = 0;
            dgvDSTU.Columns["CreatedDate"].Visible = false;
            DisplayPage(1);
        }

        private void cmbNgayTao_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbNgayTao.SelectedIndex == 0)
            {
                kieuSapXep = "";
                dgvDSTU.Columns["CreatedDate"].Visible = false;
            }
            else if (cmbNgayTao.SelectedIndex == 1)
            {
                kieuSapXep = "CreatedDate ASC";
                dgvDSTU.Columns["CreatedDate"].Visible = true;
            }
            else
            {
                kieuSapXep = "CreatedDate DESC";
                dgvDSTU.Columns["CreatedDate"].Visible = true;
            }
            cmbNgaySua.SelectedIndex = 0;
            dgvDSTU.Columns["ModifiedDate"].Visible = false;
            DisplayPage(1);
        }

        private void btnColorMenu_Click(object sender, EventArgs e)
        {
            colorMenu.Show(btnColorMenu, new Point(0, btnColorMenu.Height));
        }



        private void btnMoreColors_Click(object sender, EventArgs e)
        {
            using (ColorDialog dlg = new ColorDialog())
            {
                if (dlg.ShowDialog() != DialogResult.Cancel)
                {
                    ChangeColor(dlg.Color);
                }
            }
        }

        private void ChangeColor(Color selectedColor)
        {
            // Đổi màu chữ của chính nút bấm để báo hiệu màu đang chọn
            btnShowColor.BackColor = selectedColor;
            if (txtGhiChu.SelectionLength > 0)
            {
                // Chỉ đổi màu đoạn văn bản đang được chọn
                txtGhiChu.SelectionColor = selectedColor;
            }
            else if (txtNoiDung.SelectionLength > 0)
            {

                txtNoiDung.SelectionColor = selectedColor;
            }
            else
            {
                // Nếu không bôi đen đoạn nào, màu này sẽ áp dụng cho các chữ gõ tiếp theo
                txtNoiDung.SelectionColor = txtGhiChu.SelectionColor = selectedColor;
            }
        }

        private void btnShowColor_Click(object sender, EventArgs e)
        {
            if (txtGhiChu.SelectionLength > 0)
            {
                // Chỉ đổi màu đoạn văn bản đang được chọn
                txtGhiChu.SelectionColor = btnShowColor.BackColor;
            }
            if (txtNoiDung.SelectionLength > 0)
            {
                txtNoiDung.SelectionColor = btnShowColor.BackColor;
            }
        }

        private void btnBold_Click(object sender, EventArgs e)
        {
            if (txtGhiChu.Focused)
            {
                Font currentFont = txtGhiChu.SelectionFont ?? txtGhiChu.Font;
                txtGhiChu.SelectionFont = new Font(currentFont, currentFont.Style ^ FontStyle.Bold);
            }
            else if (txtNoiDung.Focused)
            {
                Font currentFont = txtNoiDung.SelectionFont ?? txtNoiDung.Font;
                txtNoiDung.SelectionFont = new Font(currentFont, currentFont.Style ^ FontStyle.Bold);
            }
        }

        private void btnUnderline_Click(object sender, EventArgs e)
        {

            if (txtGhiChu.Focused)
            {
                Font currentFont = txtGhiChu.SelectionFont ?? txtGhiChu.Font;
                txtGhiChu.SelectionFont = new Font(currentFont, currentFont.Style ^ FontStyle.Underline);
            }
            else if (txtNoiDung.Focused)
            {
                Font currentFont = txtNoiDung.SelectionFont ?? txtNoiDung.Font;
                txtNoiDung.SelectionFont = new Font(currentFont, currentFont.Style ^ FontStyle.Underline);
            }

        }

        private void btnItalic_Click(object sender, EventArgs e)
        {

            if (txtGhiChu.Focused)
            {
                Font currentFont = txtGhiChu.SelectionFont ?? txtGhiChu.Font;
                txtGhiChu.SelectionFont = new Font(currentFont, currentFont.Style ^ FontStyle.Italic);
            }
            else if (txtNoiDung.Focused)
            {
                Font currentFont = txtNoiDung.SelectionFont ?? txtNoiDung.Font;
                txtNoiDung.SelectionFont = new Font(currentFont, currentFont.Style ^ FontStyle.Italic);
            }

        }

        private void DisplayPage(int page)
        {
            if (dtOriginal == null || dtOriginal.Rows.Count == 0) return;

            //Khởi tạo DataView từ DataTable gốc để Lọc và Sắp xếp
            DataView dataView = new DataView(dtOriginal);
            // Trích xuất giá trị an toàn (tránh NullReferenceException)
            string linhVucVal = cmbLinhVuc.SelectedValue?.ToString();
            string khoaHocVal = cmbKhoaHoc.SelectedValue?.ToString();
            string khoaHocText = cmbKhoaHoc.Text; // .Text luôn trả về chuỗi (rỗng hoặc có chữ), không bị null
            //Xử lý chức năng LỌC (Filter) theo cột Lĩnh Vực
            if (linhVucVal !=null && linhVucVal != "Tất cả")
            {
                dataView.RowFilter = $"LinhVuc = '{linhVucVal.Replace("'", "''")}'";
            }
            //Lọc các từ không có Khóa học
            else if (khoaHocText == "--blank--")
            {
                dataView.RowFilter = $"KhoaHoc = '{khoaHocText.Replace("'", "''")}'";
            }
            //Lọc theo khóa học cụ thể và theo buổi học
            else if (cmbKhoaHoc.SelectedIndex != -1 && khoaHocVal != "--blank--" && khoaHocVal != "Tất cả" &&
                     int.TryParse(cmbFrom.SelectedValue?.ToString(), out int fromVal) &&
                     int.TryParse(cmbTo.SelectedValue?.ToString(), out int toVal))
            {
                dataView.RowFilter = $"BuoiHoc >= {fromVal} AND BuoiHoc <= {toVal}";
            }
            // Không lọc nếu cả lĩnh vực và khóa học đều chọn "Tất cả"
            else
            {
                dataView.RowFilter = string.Empty; 
            }

            dataView.Sort = kieuSapXep;

            DataTable dtAfterFilterAndSort = dataView.ToTable();





            // 3. Dùng LINQ lấy dữ liệu của trang hiện tại
            var pageRows = dtAfterFilterAndSort.AsEnumerable()
                                     .Skip((currentPage - 1) * pageSize)
                                     .Take(pageSize);

            // 4. Tạo DataTable mới cho trang này và gán vào BindingSource
            if (pageRows.Any())
            {
                DataTable dtPage = pageRows.CopyToDataTable();
                bds_dstu.DataSource = dtPage;
            }
            else
            {
                bds_dstu.DataSource = dtOriginal.Clone(); // Trả về bảng trống nếu không có dữ liệu
            }
            // Tính tổng số trang
            totalPages = (int)Math.Ceiling((double)dtAfterFilterAndSort.Rows.Count / pageSize);
            // Kiểm tra giới hạn trang
            if (page < 1) page = 1;
            if (page > totalPages) page = totalPages;
            currentPage = page;
            // Cập nhật giao diện (Ví dụ: "Trang 1 / 10")
            txtPage.Text = $"{currentPage}/{totalPages}";
        }

        private void btnPrePage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1) DisplayPage(currentPage - 1);
        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            DisplayPage(1);
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages) DisplayPage(currentPage + 1);
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            DisplayPage(totalPages);
        }

        private void txtPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Tắt tiếng bíp
                this.ActiveControl = null; // Ép Form bỏ chọn TextBox -> Kích hoạt sự kiện Leave bên dưới
            }
        }

        private void txtPage_Leave(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPage.Text, out int targetPage))
            {
                txtPage.Text = $"{currentPage}/{totalPages}";
                return;
            }
            if (targetPage < 1 || targetPage > totalPages)
            {
                txtPage.Text = $"{currentPage}/{totalPages}";
                return;
            }
            if (targetPage != currentPage)
            {
                DisplayPage(targetPage);
            }
        }

        private void cmbTuVietTat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Tắt tiếng bíp
                this.ActiveControl = null; // Ép Form bỏ chọn Box -> Kích hoạt sự kiện Leave bên dưới
            }
        }

        private void cmbTuDayDu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Tắt tiếng bíp
                this.ActiveControl = null; // Ép Form bỏ chọn Box -> Kích hoạt sự kiện Leave bên dưới
            }
        }

        private void btnSymbolMenu_Click_1(object sender, EventArgs e)
        {
            symbolMenu.Show(btnSymbolMenu, new Point(0, btnSymbolMenu.Height));
        }

        private void txtNoiDung_Leave(object sender, EventArgs e)
        {
            targetRtb = txtNoiDung;
            selectionStart = targetRtb.SelectionStart;
            selectionLength = targetRtb.SelectionLength;

        }

        private void txtGhiChu_Leave(object sender, EventArgs e)
        {
            targetRtb = txtGhiChu;
            selectionStart = targetRtb.SelectionStart;
            selectionLength = targetRtb.SelectionLength;
        }

        private void btnShowSymbol_Click(object sender, EventArgs e)
        {
            if (btnShowSymbol.Text.Trim() != "")
            {
                InsertSymbol(btnShowSymbol.Text);
            }
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Control && e.KeyCode == Keys.S)
            {
                if (isAdd || isUpdate)
                {
                    // Ngăn chặn tiếng "ting" mặc định của hệ thống khi nhấn phím tắt
                    e.SuppressKeyPress = true;

                    // Gọi hàm lưu của bạn (truyền sender và e hợp lệ)
                    btnLuu_Click(sender, e);
                    this.ActiveControl = null;
                }
            }

            if (e.Control && e.KeyCode == Keys.N) //them tu
            {
                if (!isUpdate && !isSearching && !isAdd)
                {
                    e.SuppressKeyPress = true;
                    btnThem_Click(sender, e);
                    e.Handled = true;
                }
            }

            if (e.Control && e.KeyCode == Keys.M) //chinh sua tu
            {
                if (!isAdd && !isUpdate)
                {
                    e.SuppressKeyPress = true;
                    btnCapNhat_Click(sender, e);
                    e.Handled = true;
                }
            }

            if (e.Control && e.KeyCode == Keys.F) //tra cuu tu
            {
                if (!isAdd && !isUpdate && !isSearching)
                {
                    e.SuppressKeyPress = true;
                    btnTraCuu_Click(sender, e);
                    e.Handled = true;
                }
            }

            if (e.KeyCode == Keys.Escape) //Thoat khi dang tra cuu/them/sua
            {
                if (isAdd || isUpdate || isSearching)
                {
                    e.SuppressKeyPress = true;
                    btnPhucHoi_Click(sender, e);
                    e.Handled = true;
                }
            }

            if (e.KeyCode == Keys.Delete)
            {
                e.SuppressKeyPress = true;
                btnXoa_Click(sender, e);
                e.Handled = true;
            }

            if (e.Alt && e.KeyCode == Keys.C)
            {
                e.SuppressKeyPress = true;
                ChangeColor(btnShowColor.BackColor);
                e.Handled = true;
            }

            if (e.Alt && e.KeyCode == Keys.S)
            {
                e.SuppressKeyPress = true;
                btnShowSymbol_Click(sender, e);
                e.Handled = true;
            }
        }

        private void cmbLinhVuc1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab || (e.Alt && e.KeyCode == Keys.Right))
            {
                e.SuppressKeyPress = true; // Tắt tiếng bíp
                cmbKhoaHoc1.Focus(); // Chuyển focus sang cmbKhoaHoc
                e.Handled = true;
            }
            else if (e.Alt && e.KeyCode == Keys.Left)
            {
                e.SuppressKeyPress = true; // Tắt tiếng bíp
                txtTuDayDu.Focus(); // Chuyển focus sang TextBox txtTuDayDu
                e.Handled = true; // Ngăn chặn sự kiện mặc định của phím Alt + Left Arrow
            }
        }

        private void cmbLinhVuc1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            // Báo cho hệ thống biết phím Enter sẽ được xử lý như một phím bấm thông thường
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.IsInputKey = true;
            }
        }

        private void txtTuVietTat_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Alt && e.KeyCode == Keys.Left) || (e.Alt && e.KeyCode == Keys.Down))
            {
                e.SuppressKeyPress = true; // Tắt tiếng bíp
                txtGhiChu.Focus();
                e.Handled = true; // Ngăn chặn sự kiện mặc định của phím Alt + Left Arrow
            }
            else if ((e.Alt && e.KeyCode == Keys.Right) || (e.Alt && e.KeyCode == Keys.Up))
            {
                e.SuppressKeyPress = true; // Tắt tiếng bíp
                txtTuDayDu.Focus();
                e.Handled = true; // Ngăn chặn sự kiện mặc định của phím Alt + Right Arrow
            }
        }

        private void txtTuDayDu_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Alt && e.KeyCode == Keys.Left) || (e.Alt && e.KeyCode == Keys.Down))
            {
                e.SuppressKeyPress = true; // Tắt tiếng bíp
                txtTuVietTat.Focus();
                e.Handled = true; // Ngăn chặn sự kiện mặc định của phím Alt + Left Arrow
            }
            else if ((e.Alt && e.KeyCode == Keys.Right) || (e.Alt && e.KeyCode == Keys.Up))
            {
                e.SuppressKeyPress = true; // Tắt tiếng bíp
                cmbLinhVuc1.Focus();
                e.Handled = true; // Ngăn chặn sự kiện mặc định của phím Alt + Right Arrow
            }
        }

        private void txtBuoiHoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.Left)
            {
                e.SuppressKeyPress = true; // Tắt tiếng bíp
                cmbKhoaHoc1.Focus();
                e.Handled = true; // Ngăn chặn sự kiện mặc định của phím Alt + Left Arrow
            }
            else if (e.KeyCode == Keys.Tab || (e.Alt && e.KeyCode == Keys.Right) || (e.Alt && e.KeyCode == Keys.Down) || e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Tắt tiếng bíp
                txtNoiDung.Focus();
                e.Handled = true; // Ngăn chặn sự kiện mặc định của phím Alt + Left Arrow
            }
        }


        private void cmbKhoaHoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.Left)
            {
                e.SuppressKeyPress = true; // Tắt tiếng bíp
                cmbLinhVuc1.Focus();
                e.Handled = true; // Ngăn chặn sự kiện mặc định của phím Alt + Left Arrow
            }
            else if (e.KeyCode == Keys.Tab || (e.Alt && e.KeyCode == Keys.Right) || (e.KeyCode == Keys.Enter))
            {
                e.SuppressKeyPress = true; // Tắt tiếng bíp
                txtBuoiHoc.Focus();
                e.Handled = true; // Ngăn chặn sự kiện mặc định của phím Alt + Left Arrow
            }
        }

        private void cmbKhoaHoc_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.IsInputKey = true;
            }
        }

        private void cmbKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            isLoading = true;
            if (cmbKhoaHoc.SelectedIndex !=-1 && cmbKhoaHoc.SelectedValue != null)
            {
                lastCourse = cmbKhoaHoc.SelectedValue.ToString();
            }
            if (cmbKhoaHoc.SelectedIndex > 0 && cmbKhoaHoc.SelectedValue.ToString() != "--blank--" && Program.ComboBoxCoGiaTri(cmbKhoaHoc, "KhoaHoc", cmbKhoaHoc.Text.Trim()))
            {
                cmbLinhVuc.SelectedIndex = 0; 
                cmbKhoaHoc.BackColor = Color.PapayaWhip;
                string query = "SELECT BUOIHOC FROM TUDIEN WHERE KHOAHOC = @KHOAHOC GROUP BY BUOIHOC";
                using (var connection = new SQLiteConnection(Program.connectionString))
                {
                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@KHOAHOC", cmbKhoaHoc.Text.Trim());
                        DataTable dt = new DataTable();
                        SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                        da.Fill(dt);
                        bds_dsbuoihocfrom.DataSource = dt;
                        cmbFrom.DataSource = bds_dsbuoihocfrom;
                        cmbFrom.DisplayMember = "BUOIHOC";
                        cmbFrom.ValueMember = "BUOIHOC";
                        cmbFrom.SelectedIndex = 0;
                        bds_dsbuoihocto.DataSource = dt;
                        cmbTo.DataSource = bds_dsbuoihocto;
                        cmbTo.DisplayMember = "BUOIHOC";
                        cmbTo.ValueMember = "BUOIHOC";
                        cmbTo.SelectedIndex = 0;
                    }
                }
                if (cmbTo.Items.Count > 0)
                {
                    buoiHocMax = cmbTo.Items.Cast<System.Data.DataRowView>()
                                            .Select(x => Convert.ToInt32(x["BUOIHOC"]))
                                            .Max();
                }
                else
                {
                    buoiHocMax = 0;
                }
                lbFrom.Visible = lbTo.Visible = cmbFrom.Visible = cmbTo.Visible = btnLoc.Visible = true;
                cmbFrom.Focus();
            }
            else
            {
                if(cmbKhoaHoc.Text == "--blank--")
                {
                    cmbLinhVuc.SelectedIndex = 0;
                }
                cmbKhoaHoc.BackColor = Color.White;
                lbFrom.Visible = lbTo.Visible = cmbFrom.Visible = cmbTo.Visible = btnLoc.Visible = false;
                dgvDSTU.Columns["BuoiHoc"].Visible = dgvDSTU.Columns["KhoaHoc"].Visible = false;
                dgvDSTU.Columns["Linhvuc"].Visible = true;
                DisplayPage(1);
            }
            isLoading = false;
        }

        private void txtBuoiHoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (int.TryParse(txtBuoiHoc.Text + e.KeyChar, out int result) && result > 9999)
            {
                e.Handled = true;
                txtBuoiHoc.Text = "9999";
                txtBuoiHoc.SelectionStart = txtBuoiHoc.Text.Length; // Đặt con trỏ ở cuối
            }
        }

        private void txtBuoiHoc_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true;
            }
        }

        private void cmbKhoaHoc_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.Right)
            {
                e.SuppressKeyPress = true; // Tắt tiếng bíp
                cmbFrom.Focus();
                e.Handled = true; // Ngăn chặn sự kiện mặc định của phím Alt + Left Arrow
            }
        }

        private void cmbFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.Left)
            {
                e.SuppressKeyPress = true; // Tắt tiếng bíp
                cmbKhoaHoc.Focus();
                e.Handled = true; // Ngăn chặn sự kiện mặc định của phím Alt + Left Arrow
            }
            if (e.Alt && e.KeyCode == Keys.Right)
            {
                e.SuppressKeyPress = true; // Tắt tiếng bíp
                cmbTo.Focus();
                e.Handled = true; // Ngăn chặn sự kiện mặc định của phím Alt + Left Arrow
            }
        }

        private void cmbTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.Left)
            {
                e.SuppressKeyPress = true; // Tắt tiếng bíp
                cmbFrom.Focus();
                e.Handled = true; // Ngăn chặn sự kiện mặc định của phím Alt + Left Arrow
            }
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Tắt tiếng bíp
                btnLoc_Click(sender, e);
                e.Handled = true; // Ngăn chặn sự kiện mặc định của phím Alt + Left Arrow
            }

        }



        private void cmbKhoaHoc_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.IsInputKey = true;
            }
        }

        private void cmbFrom_Leave(object sender, EventArgs e)
        {
            if (!Program.ComboBoxCoGiaTri(cmbFrom, "BuoiHoc", cmbFrom.Text.Trim()))
            {
                cmbFrom.SelectedIndex = 0;
                cmbFrom.Focus();
                MessageBox.Show("Giá trị không hợp lệ. Vui lòng chọn từ danh sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            if (isLoading) return;
            if(cmbFrom.SelectedIndex !=-1 && cmbFrom.SelectedValue != null)
            {
                lastFrom = cmbFrom.SelectedValue.ToString();
            }
            if (cmbTo.SelectedIndex != -1 && cmbTo.SelectedValue != null)
            {
                lastTo = cmbTo.SelectedValue.ToString();
            }
            int fromValue = int.Parse(cmbFrom.SelectedValue.ToString());
            int toValue = int.Parse(cmbTo.SelectedValue.ToString());
            if (fromValue > toValue)
            {
                MessageBox.Show("Giá trị 'Từ buổi học' phải nhỏ hơn hoặc bằng 'Đến buổi học'. Vui lòng chọn lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTo.SelectedValue = cmbFrom.SelectedValue;
                cmbTo.Focus();
                return;
            }
            dgvDSTU.Columns["BuoiHoc"].Visible = dgvDSTU.Columns["KhoaHoc"].Visible = true;
            dgvDSTU.Columns["Linhvuc"].Visible = false;
            //MessageBox.Show("Chức năng lọc theo buổi học đang được phát triển. Vui lòng sử dụng chức năng lọc theo lĩnh vực hoặc khóa học.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DisplayPage(1);
        }


        private void cmbTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (int.TryParse(cmbTo.Text + e.KeyChar, out int result) && result > buoiHocMax)
            {
                e.Handled = true;
                cmbTo.SelectedValue = buoiHocMax.ToString();
                cmbTo.SelectionStart = cmbTo.Text.Length; // Đặt con trỏ ở cuối
            }
        }

        private void cmbFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (int.TryParse(cmbTo.Text + e.KeyChar, out int result) && result > buoiHocMax)
            {
                e.Handled = true;
                cmbFrom.SelectedValue = buoiHocMax.ToString();
                cmbFrom.SelectionStart = cmbFrom.Text.Length; // Đặt con trỏ ở cuối
            }
        }
    }
}
