namespace QuanLiSinhVien
{
    partial class frmThongKe
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
            this.dataGridView_TT = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_tt = new System.Windows.Forms.ComboBox();
            this.panel_contrl = new System.Windows.Forms.Panel();
            this.tong_lbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TT)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel_contrl.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_TT
            // 
            this.dataGridView_TT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_TT.Location = new System.Drawing.Point(24, 215);
            this.dataGridView_TT.Name = "dataGridView_TT";
            this.dataGridView_TT.Size = new System.Drawing.Size(776, 223);
            this.dataGridView_TT.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 38);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(318, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thống kê";
            // 
            // comboBox_tt
            // 
            this.comboBox_tt.FormattingEnabled = true;
            this.comboBox_tt.Location = new System.Drawing.Point(12, 145);
            this.comboBox_tt.Name = "comboBox_tt";
            this.comboBox_tt.Size = new System.Drawing.Size(121, 21);
            this.comboBox_tt.TabIndex = 5;
            this.comboBox_tt.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // panel_contrl
            // 
            this.panel_contrl.Controls.Add(this.tong_lbl);
            this.panel_contrl.Location = new System.Drawing.Point(166, 45);
            this.panel_contrl.Name = "panel_contrl";
            this.panel_contrl.Size = new System.Drawing.Size(622, 135);
            this.panel_contrl.TabIndex = 4;
            this.panel_contrl.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_contrl_Paint);
            // 
            // tong_lbl
            // 
            this.tong_lbl.AutoSize = true;
            this.tong_lbl.Location = new System.Drawing.Point(505, 109);
            this.tong_lbl.Name = "tong_lbl";
            this.tong_lbl.Size = new System.Drawing.Size(38, 13);
            this.tong_lbl.TabIndex = 3;
            this.tong_lbl.Text = "Tổng: ";
            this.tong_lbl.Click += new System.EventHandler(this.tong_lbl_Click);
            // 
            // frmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBox_tt);
            this.Controls.Add(this.panel_contrl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView_TT);
            this.Name = "frmThongKe";
            this.Text = "frmThongKe";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TT)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_contrl.ResumeLayout(false);
            this.panel_contrl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_TT;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_tt;
        private System.Windows.Forms.Panel panel_contrl;
        private System.Windows.Forms.Label tong_lbl;
    }
}