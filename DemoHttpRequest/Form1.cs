using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xNet;

namespace DemoHttpRequest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGetDataNoCookie_Click(object sender, EventArgs e)
        {
            string html = GetData("https://howkteam.vn/learn");
            TestData(html);
        }

        void TestData(string html)
        {
            File.WriteAllText("res.html", html);
            Process.Start("res.html");
        }

        string GetData(string url, string cookie = null)
        {
            HttpRequest http = new HttpRequest();
            http.Cookies = new CookieDictionary();

            if(!string.IsNullOrEmpty(cookie))
            {
                AddCookie(http, cookie);
            }

            http.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/126.0.0.0 Safari/537.36 Edg/126.0.0.0";
            string html = http.Get(url).ToString();
            return html;
        }
        private void GetDataWithCookie_Click(object sender, EventArgs e)
        {
            string cookie = "_ga=GA1.2.1773502772.1719799166; _gid=GA1.2.841604354.1721705432; __RequestVerificationToken=YnEZybqXtw4XI7ZruWrGlHqZBTPlTQ40GMZl2LxObpf-nTeVsC2WSwHTYhnq6UaxdDoVpPTugLLx2r3NFvNad44HkEVhKTOnWzPzqWSk_t41; .AspNet.ApplicationCookie=n9Oterhy2CvFtkD0q0tR1EKORfp6vUiznd2y6lLrtFLPlP3oRGjqE6MaEtEZTCGh4xxdPDOCeHNaVl6aDOaeoX2N6ADtrzAf216rEsC0oAUWkSvWeij3MPl3j9_tVQaMGIA0lT3qS2hzBaGhhCRS5VDdOeHnAq_kDSxPSHv_KAi2GXvR2HSnxO29RJPuxw6nULcxwEHWu8HusvX7Eo5V9kYYPu3ZxEMZCCCmKKjUccw1g--qS-SxjXKiSY8vqkW55Fo6zYEDzpgDl4_mdIYetHzLTlT0gsb5J4VC9Q1ZJ1O7Zw3vUhkLWWtUMTy6KZki9TrRSlJqf8GPGX-CkSg0YGEj3toMQVUJLSR-tLO4UByqsTpeWRKviDYIHMnvappZkvRuUGeaU4r2cXpHvqdYwNDy7Hsm-ET2eVU7SGFaXjZxgWNI0FRR-_qOa_Dxb2hsAIraRWuTbjkOQtgE9CMO0Cbl22tQ--03XDM1gAepSvQ5liYYXJRDUU5f7egdPML_; _gat=1";

            string html = GetData("https://howkteam.vn/learn", cookie);
            TestData(html);
        }

        void AddCookie(HttpRequest http, string cookie)
        {
            var temp_string = cookie.Split(';');
            foreach (var item in temp_string)
            {
                var temp = item.Split('='); //temp[0] = name, temp[1] = value
                if (temp.Count() > 0)
                {
                    http.Cookies.Add(temp[0], temp[1]);
                }
            }
        }

    }
}
