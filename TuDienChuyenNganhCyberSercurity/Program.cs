using System.Windows.Forms;
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Data.SQLite;
namespace TuDienChuyenNganhCyberSecurity
{
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