using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaBang
{
    public partial class Form1 : Form
    {
        DaBangHelper cc = new DaBangHelper();
        public Form1()
        {
            InitializeComponent();
        }

        private void btMaHoa_Click(object sender, EventArgs e)
        {
            if (tbDuLieuCanMaHoa.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập dữ liệu cẫn mã hóa!");
                tbDuLieuCanMaHoa.Focus();
                return;
            }
            else
            {
                tbDuLieuDaMaHoa.Text = cc.MaHoa(tbDuLieuCanMaHoa.Text);
            }
        }

        private void btGiaiMa_Click(object sender, EventArgs e)
           
        {
            string key = cc.khoa;
            if (tbDuLieuDaMaHoa.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập dữ liệu cần giải mã!");
                tbDuLieuDaMaHoa.Focus();
                return;
            }
            else
            {
                tbDuLieuDaGiaiMa.Text = cc.GiaiMa(tbDuLieuDaMaHoa.Text,key);
            }
        }
    }
}
