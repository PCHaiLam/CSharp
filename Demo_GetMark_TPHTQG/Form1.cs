using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;

namespace Demo_GetMark_TPHTQG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string GetIdFromFile(string file)
        {
            string currentId;

            if (!File.Exists(file))
            {
                currentId = "01000001";
                File.WriteAllText(file, currentId);
            }
            else
            {
                currentId = File.ReadAllText(file).Trim();
            }

            int idNumber = int.Parse(currentId);
            return idNumber.ToString();
        }
        private void SaveIdToFile(string filePath, int id)
        {
            using (var writer = new StreamWriter(filePath))
            {
                writer.WriteLine(id.ToString("D8"));
            }
        }

        private void SaveDataToCsv(List<string> row, string csvFilePath)
        {
            using (var writer = new StreamWriter(csvFilePath, true))
            {
                writer.WriteLine(string.Join(",", row));
            }
        }

        private List<string> GetDataFromWeb(IWebDriver driver)
        {
            var row = new List<string>();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2000));

            // Lấy cụm thi
            var cumThiElement = wait.Until(drv => drv.FindElement(By.CssSelector(".o-detail-thisinh__cumthi")));
            string cumThiText = cumThiElement.Text.Trim();
            string[] cumThiParts = cumThiText.Split(':');

            if (cumThiParts.Length > 1)
            {
                row.Add(cumThiParts[1].Trim());
            }
            else
            {
                row.Add("");
            }

            // Khởi tạo mảng điểm
            var scores = new string[9];

            // Lấy điểm từ bảng
            var table = driver.FindElement(By.ClassName("e-table"));
            var tableRows = table.FindElements(By.TagName("tr"));

            foreach (var r in tableRows)
            {
                var columns = r.FindElements(By.TagName("td"));
                if (columns.Count == 2)
                {
                    var subject = columns[0].Text.Trim();
                    var score = columns[1].Text.Trim();

                    // Cập nhật điểm vào mảng đúng vị trí môn học
                    switch (subject)
                    {
                        case "Toán":
                            scores[0] = score;
                            break;
                        case "Ngữ văn":
                            scores[1] = score;
                            break;
                        case "Ngoại ngữ":
                            scores[2] = score;
                            break;
                        case "Vật lý":
                            scores[3] = score;
                            break;
                        case "Hóa học":
                            scores[4] = score;
                            break;
                        case "Sinh học":
                            scores[5] = score;
                            break;
                        case "Lịch sử":
                            scores[6] = score;
                            break;
                        case "Địa lý":
                            scores[7] = score;
                            break;
                        case "Giáo dục công dân":
                            scores[8] = score;
                            break;
                    }
                }
            }

            row.AddRange(scores);

            // Đảm bảo rằng tất cả các trường đều có mặt
            while (row.Count < 10)
            {
                row.Add(""); // Thêm ô trống nếu thiếu
            }

            return row;
        }
        private void btn_Get_Click(object sender, EventArgs e)
        {
            var edgeDriverService = EdgeDriverService.CreateDefaultService();
            var edgeOptions = new EdgeOptions();
            using (var driver = new EdgeDriver(edgeDriverService, edgeOptions))
            {
                driver.Navigate().GoToUrl("https://diemthi.vnexpress.net/");

                while (true)
                {
                    int id = int.Parse(GetIdFromFile("id.txt"));

                    var textbox = driver.FindElement(By.Id("keyword"));
                    textbox.SendKeys(id.ToString("D8"));

                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                    var button = wait.Until(drv => drv.FindElement(By.ClassName("btn--search")));
                    button.Click();

                    System.Threading.Thread.Sleep(2000);

                    // Tạo một dòng dữ liệu với các trường
                    var row = new List<string> { id.ToString("D8") };
                    row.AddRange(GetDataFromWeb(driver));

                    // Ghi dữ liệu vào file CSV
                    var csvFilePath = "data.csv";
                    SaveDataToCsv(row, csvFilePath);

                    id++;
                    SaveIdToFile("id.txt", id);

                }
            }
        }
        int CheckValidId(IWebDriver driver, int id)
        {
            int count = 1;
            while (true)
            {
                string url = $"https://diemthi.vnexpress.net/index/detail/sbd/{id:D8}/year/2024";
                driver.Navigate().GoToUrl(url);

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));

                try
                {
                    IWebElement element = wait.Until(drv => drv.FindElement(By.CssSelector(".o-detail-thisinh__sbd")));
                    if (element != null && element.Displayed)
                    {
                        return id;
                    }
                }
                catch (WebDriverTimeoutException)
                {
                    if (count >= 3)
                    {
                        int newId = NextAreaId();
                        if (newId == -1)
                        {
                            return -1; // Không còn mã vùng hợp lệ
                        }
                        SaveIdToFile("id.txt", newId); // Cập nhật giá trị id mới vào file
                        count = 1; // Đặt lại đếm số lần thử
                        continue;
                    }
                }

                count++;
            }
        }


        int NextAreaId()
        {
            string id = GetIdFromFile("id.txt");

            string sub1_IdString = id.Substring(0, 2);
            int sub1_id = int.Parse(sub1_IdString)+1;

            if (sub1_id == 64)
            {
                return -1;
            }

            int newId = int.Parse(sub1_id.ToString("D1") + "000001");

            return newId;
        }

        private void btn_GetDataWithHTTPRE_Click(object sender, EventArgs e)
        {
            var edgeDriverService = EdgeDriverService.CreateDefaultService();
            var edgeOptions = new EdgeOptions();
            using (var driver = new EdgeDriver(edgeDriverService, edgeOptions))
            {
                bool continueLoop = true;
                while (continueLoop)
                {
                    int id = int.Parse(GetIdFromFile("id.txt"));

                    int valid = CheckValidId(driver, id);

                    if (valid == -1)
                    {
                        System.Threading.Thread.Sleep(1000);

                        continueLoop = false;
                        driver.Quit();
                        driver.Dispose();
                    }

                    var row = new List<string> { valid.ToString("D8") };
                    row.AddRange(GetDataFromWeb(driver));

                    // Ghi dữ liệu vào file CSV
                    var csvFilePath = "test.csv";
                    SaveDataToCsv(row, csvFilePath);

                    id++;
                    SaveIdToFile("id.txt", id);
                }
            }
        }

        private void btn_GetDataWithHttpClient_Click(object sender, EventArgs e)
        {
            // Implement HttpClient method here if needed
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
