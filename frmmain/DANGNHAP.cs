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
    public partial class LOGIN : Form
    {
        dbDataContext db = new dbDataContext();
        public LOGIN()
        {
            InitializeComponent();
        }

        private void LOGIN_Load(object sender, EventArgs e)
        {
            txtuser.Focus();            
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            DialogResult h = new DialogResult();
            h = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (h == DialogResult.Yes)
                Application.Exit();
        }
        
        private bool ktlogin(string user,string password)
        {
            return db.LOG_INs.Where(a=>a.USENAME== user && a.PASS== password).FirstOrDefault() !=null ? true:false;
        }
        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtuser.Text.Length == 0 || txtpassword.Text.Length == 0)
                MessageBox.Show("Vui lòng nhập!", "Thông báo");
            else
            {
                bool ok = ktlogin(txtuser.Text, txtpassword.Text);
                if (ok == true)
                {
                    MessageBox.Show("Đăng nhập thành công", "Thành Công");
                    this.Hide();
                    if (txtuser.Text == "admin")
                    {
                        MDIParent1.QUYEN = "GD";
                        frmctdv.QUYEN = "GD";
                        frmdichvu.QUYEN = "GD";
                        frmkhachhang.QUYEN = "GD";
                    }
                    else
                    {
                        MDIParent1.QUYEN = "NV";
                        frmctdv.QUYEN = "NV";
                        frmdichvu.QUYEN = "NV";
                        frmkhachhang.QUYEN = "NV";
                    }
                    MDIParent1 f = new MDIParent1();
                    f.Show();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại", "Thất bại");
                }
            }
        }

        private void LOGIN_Enter(object sender, EventArgs e)
        {
            btnlogin_Click(sender, e);
        }
    }
}
