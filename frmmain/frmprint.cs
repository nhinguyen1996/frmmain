using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace frmmain
{
    public partial class frmprint : Form
    {
        dbDataContext db = new dbDataContext();
        public frmprint()
        {
            InitializeComponent();
        }
        private void btnthoat_Click(object sender, EventArgs e)
        {
            DialogResult h = new DialogResult();
            h = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (h == DialogResult.Yes)
                Close();
        }
        private void frmprint_Load(object sender, EventArgs e)
        {
            dgv.DataSource = from k in db.KHACHHANGs
                             from d in db.DICHVUs
                             from c in db.CHITIETDVs
                             where k.MAKH == c.MAKH && c.MADV == d.MADV
                             select new
                             {
                                 Tên = k.TENKH,
                                 Địa_chỉ = k.DIACHI,
                                 Email = k.EMAIL,
                                 Phone = k.PHONE,
                                 Tên_DV = d.TENDV,
                                 Ngày_nhập = c.NGAYNHAP
                             };
        }
        private void exporttoexcel(DataGridView g,string duongdan ,string tentap)
        {
            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 25;
            for(int i = 1; i<g.Columns.Count +1; i++)
            {
                obj.Cells[1, i] = g.Columns[i - 1].HeaderText;
            }
            for(int i =0; i < g.Rows.Count; i++)
            {
                for(int j =0; j < g.Columns.Count; j++)
                {
                    if(g.Rows[i].Cells[j].Value != null)
                    {
                        obj.Cells[i + 2, j + 1] = g.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            obj.ActiveWorkbook.SaveCopyAs(duongdan + tentap + ".xlsx");
            obj.ActiveWorkbook.Saved = true;
        }

        private void btninexcel_Click(object sender, EventArgs e)
        {
            exporttoexcel(dgv, @"E:\ ", "BaoCao");
        }

        private void btninpdf_Click(object sender, EventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER,10,10,42,35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(@"E:\test.pdf", FileMode.Create));
            doc.Open();            
            PdfPTable table = new PdfPTable(dgv.Columns.Count);
            for(int j = 0; j<dgv.Columns.Count; j++)
            {
                table.AddCell(new Phrase(dgv.Columns[j].HeaderText));
            }
            table.HeaderRows = 1;
            for (int i = 0; i<dgv.Rows.Count; i++)
            {
                for(int k = 0; k<dgv.Columns.Count; k++)
                {
                    if(dgv[k,i].Value != null)
                    {
                        table.AddCell(new Phrase(dgv[k, i].Value.ToString()));
                    }
                }
            }
            doc.Add(table);
            doc.Close();
        }

       
    }
}
