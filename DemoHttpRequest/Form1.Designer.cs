namespace DemoHttpRequest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_GetdataNoCookie = new System.Windows.Forms.Button();
            this.btn_GetDataWithCookie = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_GetdataNoCookie
            // 
            this.btn_GetdataNoCookie.Location = new System.Drawing.Point(110, 96);
            this.btn_GetdataNoCookie.Name = "btn_GetdataNoCookie";
            this.btn_GetdataNoCookie.Size = new System.Drawing.Size(95, 59);
            this.btn_GetdataNoCookie.TabIndex = 0;
            this.btn_GetdataNoCookie.Text = "Get Data";
            this.btn_GetdataNoCookie.UseVisualStyleBackColor = true;
            this.btn_GetdataNoCookie.Click += new System.EventHandler(this.btnGetDataNoCookie_Click);
            // 
            // btn_GetDataWithCookie
            // 
            this.btn_GetDataWithCookie.Location = new System.Drawing.Point(247, 96);
            this.btn_GetDataWithCookie.Name = "btn_GetDataWithCookie";
            this.btn_GetDataWithCookie.Size = new System.Drawing.Size(95, 59);
            this.btn_GetDataWithCookie.TabIndex = 1;
            this.btn_GetDataWithCookie.Text = "Get Data With Cookie";
            this.btn_GetDataWithCookie.UseVisualStyleBackColor = true;
            this.btn_GetDataWithCookie.Click += new System.EventHandler(this.GetDataWithCookie_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_GetDataWithCookie);
            this.Controls.Add(this.btn_GetdataNoCookie);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_GetdataNoCookie;
        private System.Windows.Forms.Button btn_GetDataWithCookie;
    }
}

