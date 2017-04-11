using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace user_interface
{
    public partial class TableForm : Form
    {
        Form1 ownerForm = null;
        public TableForm(Form1 ownerForm)
        {
            InitializeComponent();
            this.ownerForm = ownerForm;
            TableCells();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        public void TableCells()
        {

            XDocument xdoc = XDocument.Load("C:\\Users\\Khaliun\\documents\\visual studio 2015\\Projects\\BoxWithBalls\\BoxWithBalls\\bin\\Debug\\boxes1.xml");
            XElement root = xdoc.Element("boxes");
            foreach (XElement xe in root.Elements("события").Elements("событие").ToList())
            {
                if (xe.Attribute("colors").Value == "black_black")
                {
                    label18.Text = xe.Element("вероятность").Value;
                    label11.Text = xe.Element("выигрыш").Value;
                }
                if (xe.Attribute("colors").Value == "red_red")
                {
                    label19.Text = xe.Element("вероятность").Value;
                    label12.Text = xe.Element("выигрыш").Value;
                }
                if (xe.Attribute("colors").Value == "white_white")
                {
                    label20.Text = xe.Element("вероятность").Value;
                    label13.Text = xe.Element("выигрыш").Value;
                }
                if (xe.Attribute("colors").Value == "black_white")
                {
                    label21.Text = xe.Element("вероятность").Value;
                    label14.Text = xe.Element("выигрыш").Value;
                }
                if (xe.Attribute("colors").Value == "black_red")
                {
                    label22.Text = xe.Element("вероятность").Value;
                    label15.Text = xe.Element("выигрыш").Value;
                }
                if (xe.Attribute("colors").Value == "white_red")
                {
                    label23.Text = xe.Element("вероятность").Value;
                    label16.Text = xe.Element("выигрыш").Value;
                }

            }
            double all_money = Convert.ToDouble(label11.Text) + Convert.ToDouble(label12.Text) + Convert.ToDouble(label13.Text)
                    + Convert.ToDouble(label14.Text) + Convert.ToDouble(label15.Text) + Convert.ToDouble(label16.Text);

            double all_p = Convert.ToDouble(label18.Text) + Convert.ToDouble(label19.Text) + Convert.ToDouble(label20.Text) + Convert.ToDouble(label21.Text)
                + Convert.ToDouble(label22.Text) + Convert.ToDouble(label23.Text);
            label17.Text = all_money.ToString("F");
            label24.Text = all_p.ToString("F");










        }
    }
}
