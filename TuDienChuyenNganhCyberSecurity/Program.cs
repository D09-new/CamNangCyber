using System.Windows.Forms;
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
namespace TuDienChuyenNganhCyberSecurity
{
    public static class ButtonExtensions
    {
        public static async void Cooldown(this Control control, int milliseconds)
        {
            control.Enabled = false;
            await Task.Delay(milliseconds);
            control.Enabled = true;
        }
    }
    internal static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        static public readonly string appPath = AppDomain.CurrentDomain.BaseDirectory;
        static public readonly string dbPath = Path.Combine(appPath, "CamNangCS.db");
        static public readonly string connectionString = $"Data Source={dbPath};Version=3;";
        //public static int KetNoi()
        //{
        //    if (Program.conn != null && Program.conn.State == System.Data.ConnectionState.Open)
        //        Program.conn.Close();
        //    try
        //    {
        //        Program.conn.ConnectionString = Program.connstr;
        //        Program.conn.Open();
        //        return 1;
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show("Lỗi kết nối cơ sở dữ liệu.\nBạn xem lại username và password.\n " + e.Message, "", MessageBoxButtons.OK);
        //        return 0;
        //    }
        //}
        
        public static bool ComboBoxCoGiaTri(ComboBox cmb, string tenCot, string giaTriCanTim)
        {
            foreach (object item in cmb.Items)
            {
                string target = giaTriCanTim?.Trim() ?? "";
                if (item is DataRowView row)
                {
                    string value = (row[tenCot] == DBNull.Value || row[tenCot] == null) ? "" : row[tenCot].ToString().Trim();

                    if (value == target.Trim())
                        return true;
                }
            }

            return false;
        }

        public static bool ComboBoxCoGiaTri2(ComboBox cmb, string tenCot1, string tenCot2, string giaTriCanTim1, string giaTriCanTim2)
        {
            string target1 = giaTriCanTim1?.Trim() ?? "";
            string target2 = giaTriCanTim2?.Trim() ?? "";
            foreach (object item in cmb.Items)
            {
                if (item is DataRowView row)
                {
                    string value1 = (row[tenCot1] == DBNull.Value || row[tenCot1] == null) ? "" : row[tenCot1].ToString().Trim();
                    string value2 = (row[tenCot2] == DBNull.Value || row[tenCot2] == null) ? "" : row[tenCot2].ToString().Trim();

                    if (value1 == target1.Trim() && value2 == target2.Trim())
                        return true;
                }
            }

            return false;
        }

        public static bool KiemTraCoDinhDang(RichTextBox rtb)
        {
            // Nếu ô trống thì coi như không có định dạng
            if (string.IsNullOrEmpty(rtb.Text)) return false;

            string rtf = rtb.Rtf;

            // Tìm vị trí bắt đầu của văn bản thực tế sau phần khai báo header của RTF
            // Thông thường nội dung text thực tế sẽ nằm sau thẻ điều khiển định dạng cuối cùng
            int lastControlWord = rtf.LastIndexOf('\\');
            if (lastControlWord == -1) return false;

            // Cắt bỏ phần text thuần ở cuối chuỗi RTF để chỉ kiểm tra phần mã định dạng
            string rtfHeaderAndTags = rtf.Substring(0, lastControlWord);

            // Kiểm tra xem trong phần mã có chứa các thẻ định dạng phổ biến hay không
            bool coInDam = rtfHeaderAndTags.Contains(@"\b ") || rtfHeaderAndTags.Contains(@"\b1");
            bool coInNghieng = rtfHeaderAndTags.Contains(@"\i ") || rtfHeaderAndTags.Contains(@"\i1");
            bool coGachChan = rtfHeaderAndTags.Contains(@"\ul ") || rtfHeaderAndTags.Contains(@"\ul1");
            bool coMauSac = rtfHeaderAndTags.Contains(@"\cf") && !rtfHeaderAndTags.Contains(@"\cf0"); // cf0 là màu mặc định
            bool coDoiFont = rtfHeaderAndTags.Contains(@"\f1"); // f0 là font mặc định, từ f1 trở đi là có đổi font khác

            return coInDam || coInNghieng || coGachChan || coMauSac || coDoiFont;
        }

        public static bool PushDatabaseToGitHub()
        {
            try
            {
                // 1. Thư mục chứa file .git (Thư mục gốc của project)
                string repoPath = @"D:\MyData\Thông tin khóa học\Thông tin khóa học\Tài liệu học\CSharp\TuDienChuyenNganhCyberSecurity";

                // 2. Tên file database thực tế của bạn (Thay "TuDien.db" bằng tên file thật của bạn)
                string dbName = "CamNangCS.db";

                // Tự động lấy đường dẫn tuyệt đối của file db đang chạy thực tế
                string appPath = AppDomain.CurrentDomain.BaseDirectory;
                string fullDbPath = Path.Combine(appPath, dbName);

                if (!File.Exists(fullDbPath))
                {
                    MessageBox.Show($"Không tìm thấy file database tại:\n{fullDbPath}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // 3. Tính toán đường dẫn tương đối từ repoPath đến file DB để truyền vào lệnh Git
                Uri repoUri = new Uri(repoPath + Path.DirectorySeparatorChar);
                Uri dbUri = new Uri(fullDbPath);
                string relativeDbPath = repoUri.MakeRelativeUri(dbUri).ToString().Replace("/", "\\");
                relativeDbPath = Uri.UnescapeDataString(relativeDbPath); // Giải mã khoảng trắng (%20 -> khoảng trắng)

                // 4. Thực thi lệnh Git qua CMD ngầm
                string commitMessage = $"Auto-backup database: {DateTime.Now:yyyy-MM-dd HH:mm:ss}";

                // Chỉ add duy nhất file database ở thư mục đang chạy
                string arguments = $"/c cd /d \"{repoPath}\" && git add \"{relativeDbPath}\" && git commit -m \"{commitMessage}\" && git push origin main";

                ProcessStartInfo processInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = arguments,
                    CreateNoWindow = true,       // Chạy ngầm hoàn toàn
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true
                };

                using (Process process = Process.Start(processInfo))
                {
                    process.WaitForExit(); // Chờ Git xử lý xong
                    return process.ExitCode == 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống khi backup: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            frmMain mainForm = new frmMain();
            mainForm.WindowState = FormWindowState.Maximized;
            Application.Run(mainForm);
        }
    }
}