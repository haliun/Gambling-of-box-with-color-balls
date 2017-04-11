using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace user_interface
{
    public partial class BuyMoney : Form
    {
        Form1 ownerForm = null;
        public BuyMoney(Form1 ownerForm)
        {
            InitializeComponent();
            this.ownerForm = ownerForm;
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.ownerForm.getData(textBox1.Text);
            this.Close();
        }
    }
}
