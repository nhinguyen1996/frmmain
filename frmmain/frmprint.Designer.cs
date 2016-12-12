namespace frmmain
{
    partial class frmprint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmprint));
            this.dgv = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnthoat = new System.Windows.Forms.Button();
            this.btninexcel = new System.Windows.Forms.Button();
            this.btninpdf = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(0, 66);
            this.dgv.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.Size = new System.Drawing.Size(748, 314);
            this.dgv.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnthoat);
            this.panel1.Controls.Add(this.btninexcel);
            this.panel1.Controls.Add(this.btninpdf);
            this.panel1.Location = new System.Drawing.Point(0, 385);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(747, 68);
            this.panel1.TabIndex = 1;
            // 
            // btnthoat
            // 
            this.btnthoat.BackColor = System.Drawing.SystemColors.Menu;
            this.btnthoat.Image = global::frmmain.Properties.Resources._1481229250_common_logout_signout_exit_glyph;
            this.btnthoat.Location = new System.Drawing.Point(481, 5);
            this.btnthoat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(112, 58);
            this.btnthoat.TabIndex = 2;
            this.btnthoat.UseVisualStyleBackColor = false;
            this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // btninexcel
            // 
            this.btninexcel.BackColor = System.Drawing.SystemColors.Menu;
            this.btninexcel.Image = global::frmmain.Properties.Resources._1481229703_excel;
            this.btninexcel.Location = new System.Drawing.Point(315, 5);
            this.btninexcel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btninexcel.Name = "btninexcel";
            this.btninexcel.Size = new System.Drawing.Size(112, 58);
            this.btninexcel.TabIndex = 1;
            this.btninexcel.UseVisualStyleBackColor = false;
            this.btninexcel.Click += new System.EventHandler(this.btninexcel_Click);
            // 
            // btninpdf
            // 
            this.btninpdf.BackColor = System.Drawing.SystemColors.Menu;
            this.btninpdf.Image = global::frmmain.Properties.Resources._1481229823_pdf;
            this.btninpdf.Location = new System.Drawing.Point(153, 5);
            this.btninpdf.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btninpdf.Name = "btninpdf";
            this.btninpdf.Size = new System.Drawing.Size(112, 58);
            this.btninpdf.TabIndex = 0;
            this.btninpdf.UseVisualStyleBackColor = false;
            this.btninpdf.Click += new System.EventHandler(this.btninpdf_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(102, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(525, 46);
            this.label1.TabIndex = 2;
            this.label1.Text = "THỐNG KÊ KHÁCH HÀNG";
            // 
            // frmprint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(748, 454);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgv);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmprint";
            this.Text = "XEM THÔNG TIN KHÁCH HÀNG";
            this.Load += new System.EventHandler(this.frmprint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.Button btninexcel;
        private System.Windows.Forms.Button btninpdf;
        private System.Windows.Forms.Label label1;
    }
}