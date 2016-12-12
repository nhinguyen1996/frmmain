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
    public partial class frmctdv : Form
    {
        private bool madv = false;
        private bool makh = false;
        public static string QUYEN;
        public frmctdv()
        {
            InitializeComponent();
            txtmadv.Focus();
        }
        dbDataContext db = new dbDataContext();
        CHITIETDV tb = new CHITIETDV();
        private void frmctdv_Load(object sender, EventArgs e)
        {
            dgv.DataSource = from c in db.CHITIETDVs
                            
                             select new
                             {                                  
                                 MADV = c.MADV,
                                 MAKH = c.MAKH,
                                 NGAYNHAP = c.NGAYNHAP
                             };           
            if(QUYEN == "NV")
            {
                btnsua.Enabled = false;
                btnxoa.Enabled = false;
            }
            else
            {

            }            
        }
        private bool add(object sender,EventArgs e)
        {
            CHITIETDV add = new CHITIETDV();
            add.MADV = txtmadv.Text;
            add.MAKH = txtmakh.Text;
            add.NGAYNHAP = DateTime.Parse(dtpnn.Text);
            db.CHITIETDVs.InsertOnSubmit(add);
            db.SubmitChanges();
            frmctdv_Load(sender, e);
            return true;
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            KHACHHANG kh = db.KHACHHANGs.Where(a => a.MAKH == txtmakh.Text).FirstOrDefault();
            DICHVU dv = db.DICHVUs.Where(a => a.MADV == txtmadv.Text).FirstOrDefault();
            CHITIETDV ct = db.CHITIETDVs.Where(a => a.MADV == txtmadv.Text && a.MAKH == txtmakh.Text).FirstOrDefault();            
            if (txtmadv.Text.Length == 0 || txtmakh.Text.Length == 0)
                MessageBox.Show("Chưa nhập thông tin", "Thông báo");
            else
            {
                if (kh == null)
                    MessageBox.Show("Chưa có khách hàng này", "Thông báo");
                else
                {
                    if (dv == null)
                        MessageBox.Show("Chưa có dịch vụ này", "Thông báo");
                    else
                    {
                        if (ct != null)
                            MessageBox.Show("Đã có chi tiết dịch vụ này", "Thông báo");
                        else
                        {                            
                            add(sender, e);
                            MessageBox.Show("Thêm thành công", "Thành công");
                        }
                    }
                }                                   
            }                      
        }
        private bool edit(object sender,EventArgs e)
        {
            string madv = dgv.SelectedCells[0].OwningRow.Cells["MADV"].Value.ToString();
            tb = db.CHITIETDVs.Where(a => a.MADV.Equals(madv)).FirstOrDefault();
            tb.MADV = txtmadv.Text;
            tb.MAKH = txtmakh.Text;
            tb.NGAYNHAP = DateTime.Parse(dtpnn.Text);
            db.SubmitChanges();
            frmctdv_Load(sender, e);
            return true;
        }
        private void btnsua_Click(object sender, EventArgs e)
        {
            KHACHHANG kh = db.KHACHHANGs.Where(a => a.MAKH == txtmakh.Text).FirstOrDefault();
            DICHVU dv = db.DICHVUs.Where(a => a.MADV == txtmadv.Text).FirstOrDefault();
            CHITIETDV ct = db.CHITIETDVs.Where(a => a.MADV == txtmadv.Text && a.MAKH == txtmakh.Text).FirstOrDefault();
            if (txtmadv.Text.Length == 0 || txtmakh.Text.Length == 0)
                MessageBox.Show("Chưa nhập thông tin", "Thông báo");
            else
            {
                if (kh == null)
                    MessageBox.Show("Chưa có khách hàng này", "Thông báo");
                else
                {
                    if (dv == null)
                        MessageBox.Show("Chưa có dịch vụ này", "Thông báo");
                    else
                    {
                        if (ct != null)
                            MessageBox.Show("Đã có chi tiết dịch vụ này", "Thông báo");
                        else
                        {
                            edit(sender, e);
                            MessageBox.Show("Sửa thành công", "Thành công");
                        }
                    }
                }
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtmadv.Text = "";
            txtmakh.Text = "";
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            DialogResult h = new DialogResult();
            h = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (h == DialogResult.Yes)
                Close();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string madv = dgv.SelectedCells[0].OwningRow.Cells["MADV"].Value.ToString();
            string makh = dgv.SelectedCells[0].OwningRow.Cells["MAKH"].Value.ToString();
            txtmadv.Text = madv;
            txtmakh.Text = makh;
        }
        private bool del(object sender, EventArgs e)
        {
            string madv = dgv.SelectedCells[0].OwningRow.Cells["MADV"].Value.ToString();
            tb = db.CHITIETDVs.Where(a => a.MADV.Equals(madv)).FirstOrDefault();
            db.CHITIETDVs.DeleteOnSubmit(tb);
            db.SubmitChanges();
            frmctdv_Load(sender, e);
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

        private void txtmakh_TextChanged(object sender, EventArgs e)
        {
            if(txtmakh.Text.Length == 0)
            {
                epmakh.SetError(txtmakh, "Chưa nhập mã khách hàng");
            }
            else
            {
                epmakh.Clear();
                makh = false;
            }
        }
    }
}
