using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DUAN_
{
    public partial class GIAODIEN : Form
    {
        public GIAODIEN()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TRANGCHU f = new TRANGCHU();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            THANHTOAN f = new THANHTOAN();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
