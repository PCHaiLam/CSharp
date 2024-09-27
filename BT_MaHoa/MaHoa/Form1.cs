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
            // Phân tích các cặp ký tự (diagram) sau khi thay đổi ký tự trong richTextBox2
            PhanTichDiagram();
            // Phân tích các chuỗi ba ký tự (trigram) sau khi thay đổi ký tự trong richTextBox2
            PhanTichTrigram();
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

                // Kiểm tra nếu là dấu cách thì giữ nguyên
                if (originalChar == ' ')
                {
                    result[i] = ' ';
                    continue; // Bỏ qua việc thay thế cho dấu cách
                }

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

        private void PhanTichDiagram()
        {
            // Lấy văn bản từ richTextBox2
            string text = richTextBox1.Text.ToUpper().Replace(" ", ""); // Bỏ khoảng trắng

            // Xóa dữ liệu cũ trong dgvDiagram
            dgvDiagram.Rows.Clear();

            // Tạo Dictionary để lưu trữ các cặp ký tự và tần suất của chúng
            Dictionary<string, int> diagramFrequency = new Dictionary<string, int>();

            // Duyệt qua văn bản và đếm tần suất các cặp ký tự
            for (int i = 0; i < text.Length - 1; i++)
            {
                // Lấy cặp ký tự liên tiếp
                string pair = text[i].ToString() + text[i + 1].ToString();

                // Kiểm tra và đếm tần suất xuất hiện của cặp ký tự
                if (diagramFrequency.ContainsKey(pair))
                {
                    diagramFrequency[pair]++;
                }
                else
                {
                    diagramFrequency[pair] = 1;
                }
            }

            // Hiển thị kết quả trong dgvDiagram
            foreach (var pair in diagramFrequency)
            {
                dgvDiagram.Rows.Add(pair.Key, pair.Value);
            }
        }

        // Hàm phân tích các chuỗi ba ký tự liên tiếp (trigram) và hiển thị trong dgvTriagram
        private void PhanTichTrigram()
        {
            // Lấy văn bản từ richTextBox2
            string text = richTextBox1.Text.ToUpper().Replace(" ", ""); // Bỏ khoảng trắng

            // Xóa dữ liệu cũ trong dgvTriagram
            dgvTriagram.Rows.Clear();

            // Tạo Dictionary để lưu trữ các chuỗi ba ký tự và tần suất của chúng
            Dictionary<string, int> trigramFrequency = new Dictionary<string, int>();

            // Duyệt qua văn bản và đếm tần suất các chuỗi ba ký tự
            for (int i = 0; i < text.Length - 2; i++)
            {
                // Lấy chuỗi ba ký tự liên tiếp
                string trigram = text[i].ToString() + text[i + 1].ToString() + text[i + 2].ToString();

                // Kiểm tra và đếm tần suất xuất hiện của chuỗi ba ký tự
                if (trigramFrequency.ContainsKey(trigram))
                {
                    trigramFrequency[trigram]++;
                }
                else
                {
                    trigramFrequency[trigram] = 1;
                }
            }

            // Hiển thị kết quả trong dgvTriagram
            foreach (var trigram in trigramFrequency)
            {
                dgvTriagram.Rows.Add(trigram.Key, trigram.Value);
            }
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
