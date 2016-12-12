using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmmain
{
    public partial class frmdichvu : Form
    {
        private bool madv = false;
        private bool tendv = false;
        private bool gia = false;
        public static string QUYEN;
        public frmdichvu()
        {
            InitializeComponent();
        }
        dbDataContext db = new dbDataContext();
    
        private bool add(object sender, EventArgs e)
        {
            DICHVU tb = new DICHVU();
            tb.MADV = txtmadv.Text;
            tb.TENDV = txttendv.Text;
            tb.GIA = float.Parse(cbbgia.Text);
            db.DICHVUs.InsertOnSubmit(tb);
            db.SubmitChanges();
            frmdichvu_Load(sender, e);
            return true;
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
           
            string madv = dgv.SelectedCells[0].OwningRow.Cells["MADV"].Value.ToString();
            DICHVU tb = db.DICHVUs.Where(a => a.MADV.Equals(madv)).FirstOrDefault();
            if (txtmadv.Text.Length == 0 || txttendv.Text.Length == 0)
                MessageBox.Show("Bạn chưa đủ nhập thông tin!", "Thông báo");
            else 
                if (madv == txtmadv.Text)
                    MessageBox.Show("Trùng mã dịch vụ! Vui lòng nhập lại", "Thông báo");
            else
            { 
                add(sender, e);
                MessageBox.Show("Thêm thành công", "Thành công");
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtmadv.Text = "";
            txttendv.Text = "";
            cbbgia.Text = "";
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            DialogResult h = new DialogResult();
            h = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (h == DialogResult.Yes)
                Close();
        }

        private void frmdichvu_Load(object sender, EventArgs e)
        {
            txtmadv.Focus();
            dgv.DataSource = db.DICHVUs.ToList();   
            if(QUYEN == "NV")
            {
                btnsua.Enabled = false;
                btnxoa.Enabled = false;
            }
            else { }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmadv.Text = dgv.SelectedCells[0].OwningRow.Cells["MADV"].Value.ToString();
            txttendv.Text = dgv.SelectedCells[0].OwningRow.Cells["TENDV"].Value.ToString();
            cbbgia.Text = dgv.SelectedCells[0].OwningRow.Cells["GIA"].Value.ToString();
        }
        private bool edit(object sender,EventArgs e)
        {
            string madv = dgv.SelectedCells[0].OwningRow.Cells["MADV"].Value.ToString();
            DICHVU tb = db.DICHVUs.Where(a => a.MADV.Equals(madv)).FirstOrDefault();
            tb.MADV = txtmadv.Text;
            tb.TENDV = txttendv.Text;
            tb.GIA = float.Parse(cbbgia.Text);
            db.SubmitChanges();
            frmdichvu_Load(sender, e);
            return true;
        }
        private void btnsua_Click(object sender, EventArgs e)
        {
            DialogResult h = new DialogResult();
            h = MessageBox.Show("Bạn có muốn sửa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (h == DialogResult.Yes)
            {
                string madv = dgv.SelectedCells[0].OwningRow.Cells["MADV"].Value.ToString();
                if(madv != txtmadv.Text)
                    MessageBox.Show("Không được thay đổi mã dịch vụ", "Thông báo");
                else
                { 
                    edit(sender, e);
                MessageBox.Show("Sửa thành công", "Thành công");
                }
            }
        }
        private bool del(object sender,EventArgs e)
        {
            string madv = dgv.SelectedCells[0].OwningRow.Cells["MADV"].Value.ToString();
            DICHVU tb = db.DICHVUs.Where(a => a.MADV.Equals(madv)).FirstOrDefault();
            db.DICHVUs.DeleteOnSubmit(tb);
            db.SubmitChanges();
            frmdichvu_Load(sender, e);
            return true;
        }
        private void btnxoa_Click(object sender, EventArgs e)
        {
            DialogResult h = new DialogResult();
            h = MessageBox.Show("Bạn có muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (h == DialogResult.Yes)
            {
                del(sender, e);
                MessageBox.Show("Xóa thành công", "Thành công");
            }
        }

        private void txtmadv_TextChanged(object sender, EventArgs e)
        {
            if(txtmadv.Text.Length == 0)
            {
                epmadv.SetError(txtmadv, "Chưa nhập mã dịch vụ");
            }
            else
            {
                epmadv.Clear();
                madv = false;
            }
        }

        private void txttendv_TextChanged(object sender, EventArgs e)
        {
            if(txttendv.Text.Length == 0)
            {
                eptendv.SetError(txttendv, "Chưa nhập tên dịch vụ");
            }
            else
            {
                eptendv.Clear();
                tendv = false;
            }
        }

        private void txtgia_TextChanged(object sender, EventArgs e)
        {
            if(cbbgia.Text.Length == 0)
            {
                epgia.SetError(cbbgia, "Chưa chọn giá");
            }
            else
            {
                epgia.Clear();
                gia = false;
            }
        }
        
        private void cbbgia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
