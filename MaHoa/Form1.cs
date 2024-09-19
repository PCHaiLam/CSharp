using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MaHoa
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);

        private int selectionStart;
        private int selectionLength;

        public Form1()
        {
            InitializeComponent();

            // Gán sự kiện cho các RichTextBox
            richTextBox2.MouseUp += RichTextBox2_MouseUp;
            richTextBox2.SelectionChanged += RichTextBox2_SelectionChanged;

            this.Load += new EventHandler(DgvThongKe_Load);
            this.Load += new EventHandler(DgvDiagram_Load);
            this.Load += new EventHandler(DgvTriagram_Load);
            this.Load += new EventHandler(DgvCeasar_Load);
        }
        //**************************************************************************************************************************
        private void RichTextBox2_MouseUp(object? sender, MouseEventArgs e)
        {
            // Lấy vị trí bắt đầu và độ dài của đoạn văn bản được chọn trong RichTextBox2
            selectionStart = richTextBox2.SelectionStart;
            selectionLength = richTextBox2.SelectionLength;

            // Ẩn trỏ chuột
            HideCaret(richTextBox2.Handle);

            // Xóa lựa chọn hiện tại trong richTbox1
            richTextBox1.Select(0, richTextBox1.Text.Length);
            richTextBox1.SelectionBackColor = richTextBox1.BackColor;

            // Nếu có đoạn văn bản được chọn trong richTbox2
            if (selectionLength > 0)
            {
                // Chọn đoạn văn bản tương ứng trong richTbox1
                richTextBox1.Select(selectionStart, selectionLength);
                richTextBox1.SelectionBackColor = Color.Yellow;
            }
        }

        private void RichTextBox2_SelectionChanged(object? sender, EventArgs e)
        {
            // Ẩn trỏ chuột
            HideCaret(richTextBox2.Handle);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (richTextBox1 == null || dgvThongKe == null) return;

            string input = richTextBox1.Text.ToUpper();

            Dictionary<char, int> charFrequency = new Dictionary<char, int>();

            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    if (charFrequency.ContainsKey(c))
                    {
                        charFrequency[c]++;
                    }
                    else
                    {
                        charFrequency[c] = 1;
                    }
                }
            }

            foreach (DataGridViewRow row in dgvThongKe.Rows)
            {
                if (row.Cells["Chu"].Value == null) continue;

                string? cellValue = row.Cells["Chu"].Value.ToString();
                if (string.IsNullOrEmpty(cellValue)) continue;

                char c = cellValue[0];
                if (charFrequency.ContainsKey(c))
                {
                    row.Cells["TanSo"].Value = charFrequency[c];
                }
                else
                {
                    row.Cells["TanSo"].Value = 0;
                }
            }
        }
        private void btnMaHoa_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = ThayTheBangDauGachNgang(richTextBox1.Text);
            ThayDoiKiTu();
        }
        private void ThayDoiKiTu()
        {
            string text = richTextBox1.Text.ToUpper();
            char[] result = new char[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                char originalChar = text[i];
                bool replaced = false;

                foreach (DataGridViewRow row in dgvThongKe.Rows)
                {
                    if (row.Cells["Chu"].Value != null && row.Cells["Thay"].Value != null)
                    {
                        char? chu = row.Cells["Chu"].Value.ToString()[0];
                        string? replacement = row.Cells["Thay"].Value.ToString();

                        if (originalChar == chu)
                        {
                            if (!string.IsNullOrEmpty(replacement) && replacement != "-")
                            {
                                result[i] = replacement[0];
                            }
                            else
                            {
                                result[i] = '-';
                            }
                            replaced = true;
                            break;
                        }
                    }
                }

                if (!replaced)
                {
                    result[i] = '-';
                }
            }

            richTextBox2.Text = new string(result);
        }

        private string ThayTheBangDauGachNgang(string input)
        {
            char[] chars = input.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] != ' ')
                {
                    chars[i] = '-';
                }
            }
            return new string(chars);
        }
        private void btnSaoChep_Click(object sender, EventArgs e)
        {

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {

        }
        private void DgvThongKe_Load(object sender, EventArgs e)
        {
            ThongKe_Load();
        }
        private void DgvDiagram_Load(object sender, EventArgs e)
        {
            Diagram_Load();
        }
        private void DgvTriagram_Load(object sender, EventArgs e)
        {
            Triagram_Load();
        }
        private void ThongKe_Load()
        {
            // Tạo các cột cho DataGridView
            dgvThongKe.Columns.Add("Chu", "Chữ");
            dgvThongKe.Columns.Add("TanSo", "Tần số");
            dgvThongKe.Columns.Add("Thay", "Thay");

            // Thêm các hàng với mỗi chữ cái trong bảng chữ cái
            for (char c = 'A'; c <= 'Z'; c++)
            {
                dgvThongKe.Rows.Add(c.ToString(), 0, "-");
            }
        }
        private void Diagram_Load()
        {
            // Tạo các cột cho DataGridView
            dgvDiagram.Columns.Add("Diagram", "Diagram");
            dgvDiagram.Columns.Add("TanSo", "Tần số");

        }
        private void Triagram_Load()
        {
            // Tạo các cột cho DataGridView
            dgvTriagram.Columns.Add("Triagram", "Triagram");
            dgvTriagram.Columns.Add("TanSo", "Tần số");


        }
        //**********************************************************************************************************************

        private void btnCeasar_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ richTextBoxCeasar
            string input = richTBCeasar.Text;
            dgvCeasar.Columns[1].HeaderText = "";

            // Mã hóa Caesar với các khóa từ 1 đến 26 và hiển thị trong dgvCeasar
            for (int k = 26; k >= 1; k--)
            {
                string encryptedText = MaHoaCaesar(input, k);
                dgvCeasar.Rows[26-k].Cells[1].Value = encryptedText;
            }

        }

        private string MaHoaCaesar(string input, int key)
        {
            char[] inp = input.ToUpper().ToCharArray();
            for (int i = 0; i < inp.Length; i++)
            {
                char letter = inp[i];
                if (char.IsLetter(letter))
                {
                    letter = (char)(letter + key);
                    if (letter > 'Z')
                    {
                        letter = (char)(letter - 26);
                    }
                    inp[i] = letter;
                }
            }
            return new string(inp);
        }

        private void DgvCeasar_Load(object sender, EventArgs e)
        {
            Ceasar_Load();
        }
        private void Ceasar_Load()
        {
            // Tạo cột cho DataGridView Ceasar
            dgvCeasar.Columns.Add("Key", "Key");
            dgvCeasar.Columns.Add("VanBan", "Văn bản");
            // Thêm các số từ 1 đến 26 vào cột "Key"
            for (int i = 0; i <= 25; i++)
            {
                dgvCeasar.Rows.Add(i, ""); // Thêm một hàng mới với giá trị Key và cột Văn bản trống
            }
        }

    }
}
