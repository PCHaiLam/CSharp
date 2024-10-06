using System.Net.Http.Headers;

namespace MaHoaA5_1
{
    public partial class Form1 : Form
    {
        int[] arrayBitX = new int[19];
        int[] arrayBitY = new int[22];
        int[] arrayBitZ = new int[23];

        public Form1()
        {
            InitializeComponent();

            tbKhoa.TextChanged += new EventHandler(tbKhoa_TextChanged);
            tbX.TextChanged += new EventHandler(tbXYZ_TextChanged);
            tbY.TextChanged += new EventHandler(tbXYZ_TextChanged);
            tbZ.TextChanged += new EventHandler(tbXYZ_TextChanged);
            tbX.TextChanged += new EventHandler(tbX_TextChanged);
            tbY.TextChanged += new EventHandler(tbY_TextChanged);
            tbZ.TextChanged += new EventHandler(tbZ_TextChanged);
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
        private void tbY_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem nội dung trong tbX có phải là số nguyên hay không
            if (int.TryParse(tbY.Text, out int number) && number >= 0)
            {
                // Chuyển đổi số nguyên dương thành chuỗi nhị phân
                tbBitY.Text = Convert.ToString(number, 2).PadLeft(22, '0');
            }
            else
            {
                // Nếu nhập không phải là số nguyên dương, thì hiển thị chuỗi rỗng
                tbBitY.Text = string.Empty;
            }
        }
        private void tbZ_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem nội dung trong tbX có phải là số nguyên hay không
            if (int.TryParse(tbZ.Text, out int number) && number >= 0)
            {
                // Chuyển đổi số nguyên dương thành chuỗi nhị phân
                tbBitZ.Text = Convert.ToString(number, 2).PadLeft(23, '0');
            }
            else
            {
                // Nếu nhập không phải là số nguyên dương, thì hiển thị chuỗi rỗng
                tbBitZ.Text = string.Empty;
            }
        }
        public int XORArray(int[] array)
        {
            int result = array[0];
            
            for(int i = 0; i<array.Length; i++)
            {
                result ^= array[i];
            }
            return result;
        }
        public int[] LayMangBit(TextBox tb)
        {
            string bitString = tb.Text;
            int[] array = new int[bitString.Length];

            // Duyệt qua từng ký tự trong chuỗi nhị phân và chuyển thành số nguyên (0 hoặc 1)
            for(int i = 0; i < bitString.Length; i++)
            {
                array[i] = bitString[i] == '1' ? 1 : 0;
            }
            return array;
        }
        public List<int[]> maj(int[] X, int[] Y, int[] Z)
        {
            List<int[]> arrayList = new List<int[]>();

            // Kiểm tra xem có ít nhất 2 bit giống nhau không
            if (X[8] == Y[10] && Y[10] == Z[10])
            {
                // Xoay cả 3
                arrayList.Add(Rotate(X, 'X'));
                arrayList.Add(Rotate(Y, 'Y'));
                arrayList.Add(Rotate(Z, 'Z'));
            }
            else if (X[8] == Y[10])
            {
                // Xoay x và y
                arrayList.Add(Rotate(X, 'X'));
                arrayList.Add(Rotate(Y, 'Y'));
                arrayList.Add(Z);
            }
            else if (Y[10] == Z[10])
            {
                // Xoay y và z
                arrayList.Add(X);
                arrayList.Add(Rotate(Y, 'Y'));
                arrayList.Add(Rotate(Z, 'Z'));
            }
            else
            {
                // Xoay x và z
                arrayList.Add(Rotate(X, 'X'));
                arrayList.Add(Y);
                arrayList.Add(Rotate(Z, 'Z'));
            }

            return arrayList;
        }
        public int[] Rotate(int[] array, char ss)
        {
            int[] arrayBit = new int[4];
            int resultXOR = -1;

            if (ss == 'X')
            {
                // Lấy các bit 13, 16, 17, 18 từ mảng array
                arrayBit[0] = array[13];  // Bit thứ 13
                arrayBit[1] = array[16];  // Bit thứ 16
                arrayBit[2] = array[17];  // Bit thứ 17
                arrayBit[3] = array[18];  // Bit thứ 18
                resultXOR = XORArray(arrayBit);
            }
            else if (ss == 'Y')
            {
                arrayBit[0] = array[20];
                arrayBit[1] = array[21];
                resultXOR = XORArray(arrayBit);
            }
            else if (ss == 'Z')
            {
                arrayBit[0] = array[7];
                arrayBit[1] = array[20];
                arrayBit[2] = array[21];
                arrayBit[3] = array[22];
                resultXOR = XORArray(arrayBit);
            }

            // Dịch chuyển các phần tử sang phải
            for (int i = array.Length - 1; i > 0; i--)
            {
                array[i] = array[i - 1];
            }

            array[0] = resultXOR;

            return array;
        }
        public int LastElement(int[] X, int[] Y, int[] Z)
        {
            int[] array = new int[3];
            array[0] = X[X.Length -1];
            array[1] = Y[Y.Length -1];
            array[2] = Z[Z.Length -1];

            return XORArray(array);
        }
        public int[] BanMaArray(int[] array1, int[] array2)
        {
            // Giả sử array1 và array2 có cùng độ dài
            int[] resultArray = new int[array1.Length];

            // Thực hiện phép XOR từng phần tử giữa hai mảng
            for (int i = 0; i < array1.Length; i++)
            {
                resultArray[i] = array1[i] ^ array2[i]; // Phép XOR giữa array1[i] và array2[i]
            }

            return resultArray;
        }

        private void btnMaHoa_Click(object sender, EventArgs e)
        {
            // Giả định rằng bạn đã lấy được các mảng bit từ các TextBox
            int[] arrayBitX = LayMangBit(tbBitX);
            int[] arrayBitY = LayMangBit(tbBitY);
            int[] arrayBitZ = LayMangBit(tbBitZ);

            int[] P = LayMangBit(tbBanRo);


            int[] array = new int[P.Length];

            for (int i = 0; i < P.Length; i++)
            {
                array[i] = LastElement(arrayBitX, arrayBitY, arrayBitZ);
            }
            int[] BanMa = BanMaArray(P,array);
            tbBanMa.Text = string.Join("", BanMa);
        }
        private void tbKhoa_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbKhoa.Text))
            {
                // Nếu tbKhoa có giá trị, vô hiệu hóa tbX, tbY, tbZ
                tbX.Enabled = false;
                tbY.Enabled = false;
                tbZ.Enabled = false;
            }
            else
            {
                // Nếu tbKhoa rỗng, kích hoạt lại tbX, tbY, tbZ
                tbX.Enabled = true;
                tbY.Enabled = true;
                tbZ.Enabled = true;
            }
        }

        private void tbXYZ_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbX.Text) || !string.IsNullOrEmpty(tbY.Text) || !string.IsNullOrEmpty(tbZ.Text))
            {
                // Nếu bất kỳ tbX, tbY hoặc tbZ có giá trị, vô hiệu hóa tbKhoa
                tbKhoa.Enabled = false;
            }
            else
            {
                // Nếu cả 3 tbX, tbY, tbZ đều rỗng, kích hoạt lại tbKhoa
                tbKhoa.Enabled = true;
            }
        }
    }
}
