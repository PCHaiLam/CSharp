namespace MaHoaA5_1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tbBanRo = new TextBox();
            tbZ = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tbKhoa = new TextBox();
            label4 = new Label();
            tbX = new TextBox();
            label5 = new Label();
            tbY = new TextBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            tbBitX = new TextBox();
            tbBitY = new TextBox();
            tbBitZ = new TextBox();
            btnMaHoa = new Button();
            label9 = new Label();
            tbBanMa = new TextBox();
            SuspendLayout();
            // 
            // tbBanRo
            // 
            tbBanRo.Location = new Point(95, 64);
            tbBanRo.Name = "tbBanRo";
            tbBanRo.Size = new Size(126, 27);
            tbBanRo.TabIndex = 0;
            // 
            // tbZ
            // 
            tbZ.Location = new Point(96, 372);
            tbZ.Name = "tbZ";
            tbZ.Size = new Size(125, 27);
            tbZ.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(72, 67);
            label1.Name = "label1";
            label1.Size = new Size(17, 20);
            label1.TabIndex = 2;
            label1.Text = "P";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(72, 373);
            label2.Name = "label2";
            label2.Size = new Size(18, 20);
            label2.TabIndex = 2;
            label2.Text = "Z";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(272, 67);
            label3.Name = "label3";
            label3.Size = new Size(18, 20);
            label3.TabIndex = 4;
            label3.Text = "K";
            // 
            // tbKhoa
            // 
            tbKhoa.Location = new Point(308, 64);
            tbKhoa.Name = "tbKhoa";
            tbKhoa.Size = new Size(205, 27);
            tbKhoa.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(72, 172);
            label4.Name = "label4";
            label4.Size = new Size(18, 20);
            label4.TabIndex = 6;
            label4.Text = "X";
            // 
            // tbX
            // 
            tbX.Location = new Point(95, 169);
            tbX.Name = "tbX";
            tbX.Size = new Size(126, 27);
            tbX.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(72, 270);
            label5.Name = "label5";
            label5.Size = new Size(17, 20);
            label5.TabIndex = 8;
            label5.Text = "Y";
            // 
            // tbY
            // 
            tbY.Location = new Point(95, 267);
            tbY.Name = "tbY";
            tbY.Size = new Size(126, 27);
            tbY.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(250, 169);
            label6.Name = "label6";
            label6.Size = new Size(39, 20);
            label6.TabIndex = 9;
            label6.Text = "==>";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(250, 267);
            label7.Name = "label7";
            label7.Size = new Size(39, 20);
            label7.TabIndex = 10;
            label7.Text = "==>";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(250, 372);
            label8.Name = "label8";
            label8.Size = new Size(39, 20);
            label8.TabIndex = 11;
            label8.Text = "==>";
            // 
            // tbBitX
            // 
            tbBitX.Location = new Point(308, 169);
            tbBitX.Name = "tbBitX";
            tbBitX.ReadOnly = true;
            tbBitX.Size = new Size(205, 27);
            tbBitX.TabIndex = 12;
            // 
            // tbBitY
            // 
            tbBitY.Location = new Point(308, 267);
            tbBitY.Name = "tbBitY";
            tbBitY.ReadOnly = true;
            tbBitY.Size = new Size(205, 27);
            tbBitY.TabIndex = 13;
            // 
            // tbBitZ
            // 
            tbBitZ.Location = new Point(308, 372);
            tbBitZ.Name = "tbBitZ";
            tbBitZ.ReadOnly = true;
            tbBitZ.Size = new Size(205, 27);
            tbBitZ.TabIndex = 14;
            // 
            // btnMaHoa
            // 
            btnMaHoa.Location = new Point(573, 217);
            btnMaHoa.Name = "btnMaHoa";
            btnMaHoa.Size = new Size(94, 29);
            btnMaHoa.TabIndex = 15;
            btnMaHoa.Text = "Mã Hóa";
            btnMaHoa.UseVisualStyleBackColor = true;
            btnMaHoa.Click += btnMaHoa_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(787, 171);
            label9.Name = "label9";
            label9.Size = new Size(77, 25);
            label9.TabIndex = 16;
            label9.Text = "Bản Mã";
            // 
            // tbBanMa
            // 
            tbBanMa.Location = new Point(725, 219);
            tbBanMa.Name = "tbBanMa";
            tbBanMa.ReadOnly = true;
            tbBanMa.Size = new Size(202, 27);
            tbBanMa.TabIndex = 17;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(988, 486);
            Controls.Add(tbBanMa);
            Controls.Add(label9);
            Controls.Add(btnMaHoa);
            Controls.Add(tbBitZ);
            Controls.Add(tbBitY);
            Controls.Add(tbBitX);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(tbY);
            Controls.Add(label4);
            Controls.Add(tbX);
            Controls.Add(label3);
            Controls.Add(tbKhoa);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbZ);
            Controls.Add(tbBanRo);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbBanRo;
        private TextBox tbZ;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox tbKhoa;
        private Label label4;
        private TextBox tbX;
        private Label label5;
        private TextBox tbY;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox tbBitX;
        private TextBox tbBitY;
        private TextBox tbBitZ;
        private Button btnMaHoa;
        private Label label9;
        private TextBox tbBanMa;
    }
}
