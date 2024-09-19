namespace MaHoa
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
            btnThongKe = new Button();
            tabPage2 = new TabPage();
            dgvCeasar = new DataGridView();
            btnCeasar = new Button();
            richTBCeasar = new RichTextBox();
            tabPage1 = new TabPage();
            btnLamMoi = new Button();
            btnSaoChep = new Button();
            btnMaHoa = new Button();
            dgvTriagram = new DataGridView();
            dgvDiagram = new DataGridView();
            dgvThongKe = new DataGridView();
            richTextBox2 = new RichTextBox();
            richTextBox1 = new RichTextBox();
            tabControl1 = new TabControl();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCeasar).BeginInit();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTriagram).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDiagram).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvThongKe).BeginInit();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // btnThongKe
            // 
            btnThongKe.Location = new Point(73, 324);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(94, 29);
            btnThongKe.TabIndex = 16;
            btnThongKe.Text = "Thống kê";
            btnThongKe.UseVisualStyleBackColor = true;
            btnThongKe.Click += btnThongKe_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgvCeasar);
            tabPage2.Controls.Add(btnCeasar);
            tabPage2.Controls.Add(richTBCeasar);
            tabPage2.Location = new Point(4, 32);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1228, 710);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Mã hóa Ceasar";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvCeasar
            // 
            dgvCeasar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCeasar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCeasar.Location = new Point(505, 17);
            dgvCeasar.Name = "dgvCeasar";
            dgvCeasar.RowHeadersVisible = false;
            dgvCeasar.RowHeadersWidth = 51;
            dgvCeasar.Size = new Size(717, 687);
            dgvCeasar.TabIndex = 2;
            // 
            // btnCeasar
            // 
            btnCeasar.Location = new Point(372, 202);
            btnCeasar.Name = "btnCeasar";
            btnCeasar.Size = new Size(94, 29);
            btnCeasar.TabIndex = 1;
            btnCeasar.Text = "Mã Hóa";
            btnCeasar.UseVisualStyleBackColor = true;
            btnCeasar.Click += btnCeasar_Click;
            // 
            // richTBCeasar
            // 
            richTBCeasar.Location = new Point(16, 184);
            richTBCeasar.Name = "richTBCeasar";
            richTBCeasar.Size = new Size(323, 68);
            richTBCeasar.TabIndex = 0;
            richTBCeasar.Text = "";
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnLamMoi);
            tabPage1.Controls.Add(btnSaoChep);
            tabPage1.Controls.Add(btnMaHoa);
            tabPage1.Controls.Add(btnThongKe);
            tabPage1.Controls.Add(dgvTriagram);
            tabPage1.Controls.Add(dgvDiagram);
            tabPage1.Controls.Add(dgvThongKe);
            tabPage1.Controls.Add(richTextBox2);
            tabPage1.Controls.Add(richTextBox1);
            tabPage1.Location = new Point(4, 32);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1228, 710);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Phân tích tần số";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(225, 325);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(94, 29);
            btnLamMoi.TabIndex = 19;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // btnSaoChep
            // 
            btnSaoChep.Location = new Point(225, 678);
            btnSaoChep.Name = "btnSaoChep";
            btnSaoChep.Size = new Size(94, 29);
            btnSaoChep.TabIndex = 18;
            btnSaoChep.Text = "Sao Chép";
            btnSaoChep.UseVisualStyleBackColor = true;
            // 
            // btnMaHoa
            // 
            btnMaHoa.Location = new Point(401, 326);
            btnMaHoa.Name = "btnMaHoa";
            btnMaHoa.Size = new Size(94, 29);
            btnMaHoa.TabIndex = 17;
            btnMaHoa.Text = "Mã Hóa";
            btnMaHoa.UseVisualStyleBackColor = true;
            btnMaHoa.Click += btnMaHoa_Click;
            // 
            // dgvTriagram
            // 
            dgvTriagram.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTriagram.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTriagram.Location = new Point(1015, 16);
            dgvTriagram.Name = "dgvTriagram";
            dgvTriagram.RowHeadersVisible = false;
            dgvTriagram.RowHeadersWidth = 51;
            dgvTriagram.Size = new Size(208, 647);
            dgvTriagram.TabIndex = 15;
            // 
            // dgvDiagram
            // 
            dgvDiagram.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDiagram.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDiagram.Location = new Point(792, 16);
            dgvDiagram.Name = "dgvDiagram";
            dgvDiagram.RowHeadersVisible = false;
            dgvDiagram.RowHeadersWidth = 51;
            dgvDiagram.Size = new Size(208, 647);
            dgvDiagram.TabIndex = 14;
            // 
            // dgvThongKe
            // 
            dgvThongKe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThongKe.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dgvThongKe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvThongKe.Location = new Point(569, 16);
            dgvThongKe.Name = "dgvThongKe";
            dgvThongKe.RowHeadersVisible = false;
            dgvThongKe.RowHeadersWidth = 51;
            dgvThongKe.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvThongKe.Size = new Size(208, 647);
            dgvThongKe.TabIndex = 13;
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(5, 363);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.ReadOnly = true;
            richTextBox2.Size = new Size(550, 300);
            richTextBox2.TabIndex = 12;
            richTextBox2.Text = "";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(3, 16);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(550, 300);
            richTextBox1.TabIndex = 11;
            richTextBox1.Text = "";
            // 
            // tabControl1
            // 
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1236, 746);
            tabControl1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1260, 770);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Form1";
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCeasar).EndInit();
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTriagram).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDiagram).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvThongKe).EndInit();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabPage tabPage2;
        private DataGridView dgvCeasar;
        private Button btnCeasar;
        private RichTextBox richTBCeasar;
        private TabPage tabPage1;
        private Button btnLamMoi;
        private Button btnSaoChep;
        private Button btnMaHoa;
        private DataGridView dgvTriagram;
        private DataGridView dgvDiagram;
        private DataGridView dgvThongKe;
        private RichTextBox richTextBox2;
        private TabControl tabControl1;
        public RichTextBox richTextBox1;
        private Button btnThongKe;
    }
}
