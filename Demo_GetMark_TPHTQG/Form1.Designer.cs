namespace Demo_GetMark_TPHTQG
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
            this.btn_GetDataWithSele = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.btn_GetDataWithHttpRequest = new System.Windows.Forms.Button();
            this.btn_GetDataWithHttpClient = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_GetDataWithSele
            // 
            this.btn_GetDataWithSele.Enabled = false;
            this.btn_GetDataWithSele.Location = new System.Drawing.Point(12, 12);
            this.btn_GetDataWithSele.Name = "btn_GetDataWithSele";
            this.btn_GetDataWithSele.Size = new System.Drawing.Size(93, 153);
            this.btn_GetDataWithSele.TabIndex = 0;
            this.btn_GetDataWithSele.Text = "Lấy điểm dùng selenium";
            this.btn_GetDataWithSele.UseVisualStyleBackColor = true;
            this.btn_GetDataWithSele.Click += new System.EventHandler(this.btn_Get_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 171);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(776, 435);
            this.dataGridView1.TabIndex = 1;
            // 
            // btn_Stop
            // 
            this.btn_Stop.Location = new System.Drawing.Point(410, 12);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(93, 153);
            this.btn_Stop.TabIndex = 2;
            this.btn_Stop.Text = "Dừng";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // btn_GetDataWithHttpRequest
            // 
            this.btn_GetDataWithHttpRequest.Location = new System.Drawing.Point(138, 12);
            this.btn_GetDataWithHttpRequest.Name = "btn_GetDataWithHttpRequest";
            this.btn_GetDataWithHttpRequest.Size = new System.Drawing.Size(93, 153);
            this.btn_GetDataWithHttpRequest.TabIndex = 3;
            this.btn_GetDataWithHttpRequest.Text = "Lấy điểm dùng http request";
            this.btn_GetDataWithHttpRequest.UseVisualStyleBackColor = true;
            this.btn_GetDataWithHttpRequest.Click += new System.EventHandler(this.btn_GetDataWithHTTPRE_Click);
            // 
            // btn_GetDataWithHttpClient
            // 
            this.btn_GetDataWithHttpClient.Location = new System.Drawing.Point(275, 12);
            this.btn_GetDataWithHttpClient.Name = "btn_GetDataWithHttpClient";
            this.btn_GetDataWithHttpClient.Size = new System.Drawing.Size(93, 153);
            this.btn_GetDataWithHttpClient.TabIndex = 4;
            this.btn_GetDataWithHttpClient.Text = "Lấy điểm dùng http client";
            this.btn_GetDataWithHttpClient.UseVisualStyleBackColor = true;
            this.btn_GetDataWithHttpClient.Click += new System.EventHandler(this.btn_GetDataWithHttpClient_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 618);
            this.Controls.Add(this.btn_GetDataWithHttpClient);
            this.Controls.Add(this.btn_GetDataWithHttpRequest);
            this.Controls.Add(this.btn_Stop);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_GetDataWithSele);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_GetDataWithSele;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Button btn_GetDataWithHttpRequest;
        private System.Windows.Forms.Button btn_GetDataWithHttpClient;
    }
}

