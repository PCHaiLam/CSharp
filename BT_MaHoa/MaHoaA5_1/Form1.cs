namespace MaHoaA5_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tbX.TextChanged += new EventHandler(tbX_TextChanged);
        }
        private void tbX_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem nội dung trong tbX có phải là số nguyên hay không
            if (int.TryParse(tbX.Text, out int number) && number >= 0)
            {
                // Chuyển đổi số nguyên dương thành chuỗi nhị phân
                tbBitX.Text = Convert.ToString(number, 2).PadLeft(19,'0');
            }
            else
            {
                // Nếu nhập không phải là số nguyên dương, thì hiển thị chuỗi rỗng
                tbBitX.Text = string.Empty;
            }
        }

        private void btnMaHoa_Click(object sender, EventArgs e)
        {

        }
    }
}
