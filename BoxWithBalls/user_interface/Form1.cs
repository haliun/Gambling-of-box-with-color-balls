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
using BoxWithBalls;
using static BoxWithBalls.Form1;

namespace user_interface
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
        public void getData(string strValue)
        {
            label10.Text = strValue;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var moneyForm = new BuyMoney(this);
            moneyForm.Show();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var tableForm = new TableForm(this);
            tableForm.Show();

        }
        class box1
        {
            public string black { get; set; }
            public string white { get; set; }
            public string red { get; set; }
        }
        class box2
        {
            public string black { get; set; }
            public string white { get; set; }
            public string red { get; set; }
        }
        class box3
        {
            public string black { get; set; }
            public string white { get; set; }
            public string red { get; set; }
        }
  
        public void Play()
        {

            XDocument xdoc = XDocument.Load("C:\\Users\\Khaliun\\Documents\\Visual Studio 2015\\Projects\\BoxWithBalls\\BoxWithBalls\\bin\\Debug\\boxes1.xml");

            XElement root = xdoc.Element("boxes");
            var colors1 = from xe in root.Elements("содержимое_ВОХ-ов").Elements("box")
                        where (string)xe.Attribute("id") == "1"
                        select new box1
                        {
                            black = xe.Element("black").Value,
                            red = xe.Element("red").Value,
                            white = xe.Element("white").Value
           
                        };
            var colors2 = from xe in root.Elements("содержимое_ВОХ-ов").Elements("box")
                          where (string)xe.Attribute("id") == "2"
                          select new box2
                          {
                              black = xe.Element("black").Value,
                              red = xe.Element("red").Value,
                              white = xe.Element("white").Value

                          };
            var colors3 = from xe in root.Elements("содержимое_ВОХ-ов").Elements("box")
                          where (string)xe.Attribute("id") == "3"
                          select new box3
                          {
                              black = xe.Element("black").Value,
                              red = xe.Element("red").Value,
                              white = xe.Element("white").Value

                          };
            //контейнеры
    
            
            //добавим шарики в 1-ую коробку 
            Box box_1 = new Box();
            foreach (var color1 in colors1)
            {
                List<string> n_balls1 = new List<string>();

                for (int i = 0; i < Convert.ToInt32(color1.black); i++)
                {
                    n_balls1.AddRange(new string[] { "black" });
                }
                for (int i = 0; i < Convert.ToInt32(color1.white); i++)
                {
                    n_balls1.AddRange(new string[] { "white" });
                }
                for (int i = 0; i < Convert.ToInt32(color1.red); i++)
                {
                    n_balls1.AddRange(new string[] { "red" });
                }
                box_1.add(n_balls1);

            }

            //добавим шарики в 2-ую коробку 
            Box box_2 = new Box();
            foreach (var color2 in colors2)
            {
                List<string> n_balls2 = new List<string>();

                for (int i = 0; i < Convert.ToInt32(color2.black); i++)
                {
                    n_balls2.AddRange(new string[] { "black" });
                }
                for (int i = 0; i < Convert.ToInt32(color2.white); i++)
                {
                    n_balls2.AddRange(new string[] { "white" });
                }
                for (int i = 0; i < Convert.ToInt32(color2.red); i++)
                {
                    n_balls2.AddRange(new string[] { "red" });
                }
                box_2.add(n_balls2);

            }
            //добавим шарики в 3-ую коробку 
            Box box_3 = new Box();
            foreach (var color3 in colors3)
            {
                List<string> n_balls3 = new List<string>();

                for (int i = 0; i < Convert.ToInt32(color3.black); i++)
                {
                    n_balls3.AddRange(new string[] { "black" });
                }
                for (int i = 0; i < Convert.ToInt32(color3.white); i++)
                {
                    n_balls3.AddRange(new string[] { "white" });
                }
                for (int i = 0; i < Convert.ToInt32(color3.red); i++)
                {
                    n_balls3.AddRange(new string[] { "red" });
                }
                box_3.add(n_balls3);

            }
            //Добавить из одного в другой контейнер 
            String b1 = "0", b2 = "0", b3 = "0";
      
            foreach(XElement e in root.Elements("придаваемые_шары").Elements("от_box1")){ b1 = e.Value; }
            foreach (XElement e in root.Elements("придаваемые_шары").Elements("от_box2")) { b2 = e.Value; }
            foreach (XElement e in root.Elements("придаваемые_шары").Elements("от_box3")) { b3= e.Value; }
            
            
            Box box1_copy, box2_copy, box3_copy, temp_box1, temp_box2, res_box;
       
                box1_copy = new Box(box_1);
                box2_copy = new Box(box_2);
                box3_copy = new Box(box_3);
            int take1 =0, take2 =0, take3 =0;
            
                take1 = (Convert.ToInt32(b1));
                take2 = (Convert.ToInt32(b2));
                take3 = (Convert.ToInt32(b3));
            
            
            temp_box1 = box1_copy.take(Convert.ToInt32(2));
            box2_copy = box2_copy + temp_box1;
            temp_box2 = box2_copy.take(Convert.ToInt32(2));
            box3_copy = box3_copy + temp_box2;
            res_box = box3_copy.take(Convert.ToInt32(2));

            //смотрим случаи выигриша 
            String b_b = "0", w_w = "0", r_r = "0", w_r = "0", b_r = "0", b_w = "0";
            foreach (XElement ballElement in root.Elements("события").Elements("событие"))
            {
                XAttribute nameAttribute = ballElement.Attribute("colors");
                XElement colorElement = ballElement.Element("выигрыш");

                if (nameAttribute.Value=="black_black")
                {
                    b_b = colorElement.Value;
                }
                if (nameAttribute.Value == "black_red")
                {
                    b_r = colorElement.Value;
                }
                if (nameAttribute.Value == "red_red")
                {
                    r_r = colorElement.Value;
                }
                if (nameAttribute.Value == "white_white")
                {
                    w_w = colorElement.Value;
                }
                if (nameAttribute.Value == "white_red")
                {
                    w_r = colorElement.Value;
                }
            }
            //проверка 
                if (res_box.contain(new List<string> { "black", "black" }))
                {
                    label20.Text =b_b;
                }
                if (res_box.contain(new List<string> { "black", "red" }))
                {
                    label20.Text = b_r;
                }
                if (res_box.contain(new List<string> { "red", "white" }))
                {
                    label20.Text = w_r;
                }
                if (res_box.contain(new List<string> { "white", "white" }))
                {
                    label20.Text = w_w;
                }
                if (res_box.contain(new List<string> { "red", "red" }))
                {
                    label20.Text = r_r;
                }
            
            

        }
            
            
        
        private void button2_Click(object sender, EventArgs e)
        {
            int rest = 0;
            string r = label10.Text;
            rest = Convert.ToInt32(r);
            if (rest<10)
            {
                MessageBox.Show("Вам надо пополнить баланс! Не хватает остатка.","Внимание!");

            }
            else
            {
                rest =rest - 50;
                label10.Text = rest.ToString();
                Play();
            }
            label10.Text = (Convert.ToInt32(rest) + Convert.ToInt32(label20.Text)).ToString();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int rest = 0;
            if (Convert.ToInt32(label10.Text) < 10)
            {
                MessageBox.Show("Вам надо пополнить баланс! Не хватает остатка.", "Внимание!");
            }
            else
            {
                rest = Convert.ToInt32(label10.Text) - 50;
                label10.Text = rest.ToString();
                Play();
            }
            label10.Text = (Convert.ToInt32(rest) + Convert.ToInt32(label20.Text)).ToString();

        }
    }
}
