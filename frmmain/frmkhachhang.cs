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
    
    public partial class frmkhachhang : Form
    {
        public static string QUYEN;
        public bool makh = false;
        public bool tenkh = false;
        public bool diachi = false;
        public bool email = false;
        public bool phone = false;
        dbDataContext db = new dbDataContext();                
        public frmkhachhang()
        {
            InitializeComponent();
        }       
        private void frmkhachhang_Load(object sender, EventArgs e)
        {
             dgv.DataSource =db.KHACHHANGs.ToList();              
            if (QUYEN == "NV")
            {
                btnsua.Enabled = false;
                btnxoa.Enabled = false;
            }
            else
            {

            }
        }
      
        private bool add(object sender, EventArgs e)
        {
            KHACHHANG tb = new KHACHHANG();
            tb.MAKH = txtmakh.Text;           
            tb.TENKH = txttenkh.Text;
            tb.DIACHI = txtdiachi.Text;
            tb.EMAIL = txtemail.Text;
            tb.PHONE = txtphone.Text;
            db.KHACHHANGs.InsertOnSubmit(tb);
            db.SubmitChanges();
            frmkhachhang_Load(sender, e);
            return true;
        }
         
        private void btnthem_Click(object sender, EventArgs e)
        {
            KHACHHANG tb = db.KHACHHANGs.Where(a => a.MAKH == txtmakh.Text || a.PHONE == txtphone.Text).FirstOrDefault();     
            if (txttenkh.Text.Length ==0 || txtdiachi.Text.Length == 0 || txtemail.Text.Length == 0 || txtphone.Text.Length == 0)            
              MessageBox.Show("Bạn chưa đủ nhập thông tin!", "Thông báo");
            else
            {
                if (tb != null)
                    MessageBox.Show("Không được trùng mã khách hàng và SDT", "Thông báo");
                else
                { 
                    add(sender, e);
                    MessageBox.Show("Thêm thành công", "Thành công");
                }
            }                                                                           
        }
        private void btnthoat_Click(object sender, EventArgs e)
        {
            DialogResult h = new DialogResult();
            h = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (h == DialogResult.Yes)
                Close();
        }
        private bool edit(object sender,EventArgs e)
        {
            string makh = dgv.SelectedCells[0].OwningRow.Cells["MAKH"].Value.ToString();
            KHACHHANG tb = db.KHACHHANGs.Where(a => a.MAKH.Equals(makh)).FirstOrDefault();            
            tb.TENKH = txttenkh.Text;
            tb.DIACHI = txtdiachi.Text;
            tb.EMAIL = txtemail.Text;
            tb.PHONE = txtphone.Text;
            db.SubmitChanges();
            frmkhachhang_Load(sender, e);
            return true;
        }
        private void btnsua_Click(object sender, EventArgs e)
        {
            DialogResult h = new DialogResult();
            h = MessageBox.Show("Bạn có muốn sửa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (h == DialogResult.Yes)
            {
                string makh = dgv.SelectedCells[0].OwningRow.Cells["MAKH"].Value.ToString();
                if (makh != txtmakh.Text)
                    MessageBox.Show("Không được thay đổi mã khách hàng", "Thông báo");
                else
                {
                    edit(sender, e);
                    MessageBox.Show("Sửa thành công", "Thành công");
                }
            }
        }
        private bool del(object sender,EventArgs e)
        {
            string makh = dgv.SelectedCells[0].OwningRow.Cells["MAKH"].Value.ToString();
            KHACHHANG tb = db.KHACHHANGs.Where(a => a.MAKH.Equals(makh)).FirstOrDefault();
            db.KHACHHANGs.DeleteOnSubmit(tb);
            db.SubmitChanges();
            frmkhachhang_Load(sender, e);
            return true;
        }
        private void btnxoa_Click(object sender, EventArgs e)
        {
            DialogResult h = new DialogResult();
            h = MessageBox.Show("Bạn có muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(h == DialogResult.Yes)
            { 
                del(sender, e);
                MessageBox.Show("Xóa thành công", "Thành công");
            }
        }
        private void clear(object sender,EventArgs e)
        {
            txtmakh.Text = "";
            txttenkh.Text = "";
            txtdiachi.Text = "";
            txtemail.Text = "";
            txtphone.Text = "";
        }       
        private void btnclear_Click(object sender, EventArgs e)
        {
            clear(sender, e);
            frmkhachhang_Load(sender, e);
        }
        private bool search(object sender,EventArgs e)
        {
            var tim = from kh in db.KHACHHANGs
                      where kh.TENKH.Contains(txttimkiem.Text)
                      select kh;
            dgv.DataSource = tim;
            dgv.Refresh();
            return true;
        }
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmakh.Text = dgv.SelectedCells[0].OwningRow.Cells["MAKH"].Value.ToString();
            txttenkh.Text = dgv.SelectedCells[0].OwningRow.Cells["TENKH"].Value.ToString();
            txtdiachi.Text = dgv.SelectedCells[0].OwningRow.Cells["DIACHI"].Value.ToString();
            txtemail.Text = dgv.SelectedCells[0].OwningRow.Cells["EMAIL"].Value.ToString();
            txtphone.Text = dgv.SelectedCells[0].OwningRow.Cells["PHONE"].Value.ToString();
        }
        private void txtphone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        private void txttenkh_TextChanged(object sender, EventArgs e)
        {
            if (txttenkh.Text.Length == 0)
                eptenkh.SetError(txttenkh, "Chưa nhập tên khách hàng");
            else
            {
                eptenkh.Clear();
                tenkh = false;
            }
        }
        private void txtdiachi_TextChanged(object sender, EventArgs e)
        {
            if (txtdiachi.Text.Length == 0)
                epdiachi.SetError(txtdiachi, "Chưa nhập địa chỉ");
            else
            {
                epdiachi.Clear();
                diachi = false;
            }
        }
        private void txtemail_TextChanged(object sender, EventArgs e)
        {
            if (txtemail.Text.Length == 0)
                epemail.SetError(txtemail, "Chưa nhập email");
            else
            {
                epemail.Clear();
                email = false;
            }
        }
        private void txtphone_TextChanged(object sender, EventArgs e)
        {
            if (txtphone.Text.Length == 0)
                epphone.SetError(txtphone, "Chưa nhập số điện thoại");
            else
            {
                epphone.Clear();
                phone = false;
            }
        }
        private void btntimkiem_Click(object sender, EventArgs e)
        {            
            if (txttimkiem.Text.Length != 0)
                search(sender, e);
            else
                frmkhachhang_Load(sender, e);                        
        }

        private void txtmakh_TextChanged(object sender, EventArgs e)
        {
            if (txtmakh.Text.Length == 0)
                epmakh.SetError(txtmakh, "Chưa nhập mã khách hàng");
            else
            {
                epmakh.Clear();
                makh = false;
            }
        }

        private void btndv_Click(object sender, EventArgs e)
        {
            frmdichvu f = new frmdichvu();
            f.Show();
            frmctdv g = new frmctdv();
            g.Show();
        }
    }

}
