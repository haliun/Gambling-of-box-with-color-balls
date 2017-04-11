using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoxWithBalls
{
    public partial class UserAttention : Form
    {
        Form1 ownerForm2 = null;
        public UserAttention(Form1 ownerForm2)
        {
            InitializeComponent();
            this.ownerForm2 = ownerForm2;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
