using System.Data;
using System.Data.SQLite;
namespace TuDienChuyenNganhCyberSecurity
{
    public partial class frmMain : Form
    {
        DataTable dtOriginal = new DataTable(); // Chứa toàn bộ dữ liệu gốc
        int currentPage = 1;  // Trang hiện tại
        readonly int pageSize = 30;    // Số dòng trên một trang
        int totalPages = 1;   // Tổng số trang
        string kieuSapXep = "";
        public static BindingSource bds_dscmb = new BindingSource();
        public static BindingSource bds_dstu = new BindingSource();
        public static BindingSource bds_dslinhvuc = new BindingSource();
        public static BindingSource bds_dslinhvuc1 = new BindingSource();
        int position = 0;
        bool isAdd = false;
        bool isUpdate = false;
        bool isLoading = false;
        bool isSearching = false;
        string linhvuc = "Tất cả";
        string tuviettat = "";
        string tudaydu = "";
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
                        cmbLinhVuc.SelectedIndex = -1;
                        cmbLinhVuc.SelectedIndex = 0;
                    }
                }
                cmbNgaySua.SelectedIndex = cmbNgayTao.SelectedIndex = 0;
                if (bds_dstu.Count > 0)
                {
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
                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                        dtOriginal.Clear();
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
                        if (position != -1)
                        {
                            DataRowView row = bds_dstu[position] as DataRowView;
                            GanNoiDungRichTextBox(txtNoiDung, row["NoiDung"]);
                            GanNoiDungRichTextBox(txtGhiChu, row["GhiChu"]);
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
                            cmbLinhVuc.SelectedValue = linhvuc;
                        }

                    }
                }
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
            lbLinhVuc.Visible = cmbLinhVuc1.Visible = lbTuDayDu.Visible = txtTuDayDu.Visible = lbTuVietTat.Visible = txtTuVietTat.Visible = false;
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
            isAdd = false;
            isUpdate = false;
            isSearching = false;
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
            }
            isAdd = true;
            panelLoc.Visible = dgvDSTU.Enabled = btnTraCuu.Enabled = btnCapNhat.Enabled = btnTaiLai.Enabled = btnXoa.Enabled = btnThoat.Enabled = false;
            txtGhiChu.ReadOnly = false;
            txtNoiDung.ReadOnly = false;
            panelFormatText.Visible = lbLinhVuc.Visible = cmbLinhVuc1.Visible = lbTuDayDu.Visible = txtTuDayDu.Visible = lbTuVietTat.Visible = txtTuVietTat.Visible = true;
            txtNoiDung.BackColor = txtGhiChu.BackColor = Color.Thistle;
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
            }
            else
            {
                DataRowView row = bds_dstu[bds_dstu.Position] as DataRowView;
                tuviettat = txtTuVietTat.Text = row["TUVIETTAT"].ToString().Trim();
                tudaydu = txtTuDayDu.Text = row["TUDAYDU"].ToString().Trim();
                cmbLinhVuc1.SelectedValue = row["LINHVUC"];
            }
            isUpdate = true;
            panelLoc.Visible = dgvDSTU.Enabled = btnTraCuu.Enabled = btnThem.Enabled = btnTaiLai.Enabled = btnXoa.Enabled = btnThoat.Enabled = false;
            txtGhiChu.ReadOnly = false;
            txtNoiDung.ReadOnly = false;
            panelFormatText.Visible = lbLinhVuc.Visible = cmbLinhVuc1.Visible = lbTuDayDu.Visible = txtTuDayDu.Visible = lbTuVietTat.Visible = txtTuVietTat.Visible = true;
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
                        string query = "INSERT INTO TUDIEN (TUVIETTAT, TUDAYDU, NOIDUNG, GHICHU, LINHVUC) VALUES (@TUVIETTAT, @TUDAYDU, @NOIDUNG, @GHICHU, @LINHVUC)";
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
                    panelFormatText.Visible = lbLinhVuc.Visible = cmbLinhVuc1.Visible = lbTuDayDu.Visible = txtTuDayDu.Visible = lbTuVietTat.Visible = txtTuVietTat.Visible = false;
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
                        string query = "UPDATE TUDIEN SET TUVIETTAT = @TUVIETTAT, TUDAYDU = @TUDAYDU, NOIDUNG = @NOIDUNG, GHICHU = @GHICHU, LINHVUC = @LINHVUC WHERE ID = @ID";
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
                    panelFormatText.Visible = lbLinhVuc.Visible = cmbLinhVuc1.Visible = lbTuDayDu.Visible = txtTuDayDu.Visible = lbTuVietTat.Visible = txtTuVietTat.Visible = false;
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
            if (cmbLinhVuc.SelectedIndex != -1 && Program.ComboBoxCoGiaTri(cmbLinhVuc, "LINHVUC", cmbLinhVuc.Text.Trim()))
            {
                DisplayPage(1);
            }
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
            else if (txtNoiDung.SelectionLength > 0)
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
            //Xử lý chức năng LỌC (Filter) theo cột Lĩnh Vực
            if (cmbLinhVuc.SelectedIndex != -1 && cmbLinhVuc.SelectedValue.ToString() != "Tất cả")
            {
                dataView.RowFilter = $"LinhVuc = '{cmbLinhVuc.SelectedValue}'";
            }
            else
            {
                dataView.RowFilter = string.Empty; // Không lọc nếu chọn "Tất cả"
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
            if (isAdd || isUpdate)
            {
                if (e.Control && e.KeyCode == Keys.S)
                {
                    // Ngăn chặn tiếng "ting" mặc định của hệ thống khi nhấn phím tắt
                    e.SuppressKeyPress = true;

                    // Gọi hàm lưu của bạn (truyền sender và e hợp lệ)
                    btnLuu_Click(sender, e);
                    this.ActiveControl = null;
                }
            }
        }
    }
}
