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
using System.Diagnostics;
namespace BoxWithBalls
{
    public partial class Characters : Form
    {
        Form1 ownerForm = null;
        public Characters(Form1 ownerForm)
        {
            InitializeComponent();
            this.ownerForm = ownerForm;
            Character();
        }
         public void Character()
        {
            XDocument xdoc = XDocument.Load("C:\\Users\\Khaliun\\documents\\visual studio 2015\\Projects\\BoxWithBalls\\BoxWithBalls\\bin\\Debug\\boxes1.xml");
            XElement root = xdoc.Element("boxes");
            double[] p=new double[6];
            double[] x = new double[6];
            foreach (XElement xe in root.Elements("события").Elements("событие").ToList())
            {
                if (xe.Attribute("colors").Value == "black_black")
                {
                    p[0]=Convert.ToDouble(xe.Element("вероятность").Value);
                    x[0] = Convert.ToDouble(xe.Element("выигрыш").Value);
                }
                if (xe.Attribute("colors").Value == "red_red")
                {
                    p[1] = Convert.ToDouble(xe.Element("вероятность").Value);
                    x[1] = Convert.ToDouble(xe.Element("выигрыш").Value);
                }
                if (xe.Attribute("colors").Value == "white_white")
                {
                    p[2]= Convert.ToDouble(xe.Element("вероятность").Value);
                    x[2] = Convert.ToDouble(xe.Element("выигрыш").Value);
                }
                if (xe.Attribute("colors").Value == "black_white")
                {
                    p[3] = Convert.ToDouble(xe.Element("вероятность").Value);
                    x[3] = Convert.ToDouble(xe.Element("выигрыш").Value);
                }
                if (xe.Attribute("colors").Value == "black_red")
                {
                    p[4] = Convert.ToDouble(xe.Element("вероятность").Value);
                    x[4] = Convert.ToDouble(xe.Element("выигрыш").Value);
                }
                if (xe.Attribute("colors").Value == "white_red")
                {
                    p[5] = Convert.ToDouble(xe.Element("вероятность").Value);
                    x[5] = Convert.ToDouble(xe.Element("выигрыш").Value);
                }

            }
            double Avg_x, Math_x, Disp_x, SKO_x, Var_x;
            double[] M_x = new double[6];
            double[] D_x = new double[6];
            //, D_x, S_x, V_x;
            

            //Мат.ожидание //сред.размер выигрыша 
            for (int i = 0, j = 0; i < p.Length; i++,j++)
            {
                M_x[i]+= p[i] * x[j];
            }
            Math_x = M_x.Sum();
            label4.Text = Math_x.ToString("F");
            //Дисперсия 
            for (int i = 0, j = 0; i < p.Length; i++, j++)
            {
                D_x[i] = p[i] * Math.Pow((x[j]-M_x[j]),2);
            }
            Disp_x = D_x.Sum();
            label6.Text = Disp_x.ToString("F");
            //СКО 
            SKO_x = Math.Sqrt(Disp_x);
            label8.Text = SKO_x.ToString("F");
            //Коэф-вариации 
            Var_x = SKO_x/Math.Abs(Math_x);
            label10.Text = Var_x.ToString("F");
            XDocument doc = XDocument.Load("boxes1.xml");
            doc.Element("boxes").Add(
                new XElement(
                    "Statistics",
                    new XAttribute("size","рубль"),
                    new XElement("сред.размер_выигрыша", label4.Text),
                    new XElement("риск", label8.Text))
                    );
            doc.Save("boxes1.xml");
            if (Var_x >= 0.33)
            {
                label11.Text = "Игра высоко  рискована!";
            }else
            {
                label11.Text = "Игра  не рискована!";
            }
            Process.Start("notepad.exe", "C:\\Users\\Khaliun\\Documents\\Visual Studio 2015\\Projects\\BoxWithBalls\\BoxWithBalls\\bin\\Debug\\boxes1.xml");

        }
    }
}
