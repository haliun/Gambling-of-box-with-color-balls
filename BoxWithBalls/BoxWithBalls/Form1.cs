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
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        

        private void button4_Click(object sender, EventArgs e)
        {
           
            string n_boxes = comboBox1.SelectedItem.ToString();
            int int_boxes = Convert.ToInt16(n_boxes);
            switch(int_boxes)
            {
               
                case 2:
                    textBox1.Enabled = textBox2.Enabled =button5.Enabled= true;
                  
                    break;
                case 3:
                    textBox1.Enabled = textBox2.Enabled = textBox3.Enabled = button5.Enabled = true;
                   
                    break;
                

            }
    

        }
        //Рассмотрим  случай, где только 3 контейнера 
        public void button5_Click(object sender, EventArgs e)
        {
            
            
            //int n_box4 = Convert.ToInt32(textBox4.Text);
            //int n_box5 = Convert.ToInt32(textBox5.Text);
            textBox7.Enabled = textBox8.Enabled =
               comboBox2.Enabled = button6.Enabled = true;

            
           

        }
        public void AddtoBox()
        {

        }
        public void button6_Click(object sender, EventArgs e)
        {
            //контейнеры
            //вох 1
            int b_box1 = Convert.ToInt32(textBox1.Text);
            int w_box1= Convert.ToInt32(textBox5.Text);
            int r_box1= Convert.ToInt32(textBox4.Text);
            //вох2
            int b_box2 = Convert.ToInt32(textBox2.Text);
            int w_box2 = Convert.ToInt32(textBox6.Text);
            int r_box2 = Convert.ToInt32(textBox10.Text);
            //вох3
            int b_box3 = Convert.ToInt32(textBox3.Text);
            int w_box3 = Convert.ToInt32(textBox11.Text);
            int r_box3 = Convert.ToInt32(textBox12.Text);
            
            //Добавить из одного в другой контейнер 
            int take1 = Convert.ToInt32(textBox7.Text);
            int take2 = Convert.ToInt32(textBox8.Text);
            int take3 = Convert.ToInt32(comboBox2.Text);
            //количество вох-ов 
            string n_boxes = comboBox1.SelectedItem.ToString();
            int int_boxes = Convert.ToInt16(n_boxes);
            //добавим шарики в 1-ую коробку 
            Box box1 = new Box();
            List<string> n_balls = new List<string>();
            for (int i = 0; i < b_box1; i++)
            {
                n_balls.AddRange(new string[] {"black" });
            }
            for (int i = 0; i < w_box1; i++)
            {
                n_balls.AddRange(new string[] { "white" });
            }
            for (int i = 0; i < r_box1; i++)
            {
                n_balls.AddRange(new string[] { "red" });
            }
            box1.add(n_balls);
            //добавим шарики в 2-ую коробку 
            Box box2 = new Box();
            List<string> n_balls2 = new List<string>();
            for (int i = 0; i < b_box2; i++)
            {
                n_balls2.AddRange(new string[] { "black" });
            }
            for (int i = 0; i < w_box2; i++)
            {
                n_balls2.AddRange(new string[] { "white" });
            }
            for (int i = 0; i < r_box2; i++)
            {
                n_balls2.AddRange(new string[] { "red" });
            }
            box2.add(n_balls2);
            //добавим шарики в 3-ую коробку 
            Box box3 = new Box();
            List<string> n_balls3 = new List<string>();
            for (int i = 0; i < b_box3; i++)
            {
                n_balls3.AddRange(new string[] { "black" });
            }
            for (int i = 0; i < w_box3; i++)
            {
                n_balls3.AddRange(new string[] { "white" });
            }
            for (int i = 0; i < r_box3; i++)
            {
                n_balls3.AddRange(new string[] { "red" });
            }
            box3.add(n_balls3);
             int b_w=0, b_b=0, b_r=0, w_w=0, w_r=0, r_r=0;
             Box box1_copy, box2_copy, box3_copy, temp_box1, temp_box2, res_box;
            int n_exp=100;
            for (int i = 1; i < (n_exp+1); i++)
             {

                 box1_copy = new Box(box1);
                 box2_copy = new Box(box2);
                 box3_copy = new Box(box3);

                 temp_box1 = box1_copy.take(take1);
                 box2_copy = box2_copy + temp_box1;
                 temp_box2 = box2_copy.take(take2);
                 box3_copy = box3_copy + temp_box2;
                 res_box = box3_copy.take(take3);
                 if (res_box.contain(new List<string> { "black", "black" }))
                 {
                     b_b++;
                 }
                 if (res_box.contain(new List<string> { "black", "white" }))
                 {
                     b_w++;
                 }
                 if (res_box.contain(new List<string> { "black", "red" }))
                 {
                     b_r++;
                 }
                 if (res_box.contain(new List<string> { "red", "white" }))
                 {
                     w_r++;
                 }
                 if (res_box.contain(new List<string> { "white", "white" }))
                 {
                     w_w++;
                 }
                 if (res_box.contain(new List<string> { "red", "red" }))
                 {
                     r_r++;
                 }

             }
            //int b_b = 10359, w_w = 10390, b_w = 18062, b_r = 21943, w_r = 22671, r_r = 16575;
            string eventB_B = (Convert.ToDouble(b_b) / n_exp).ToString("F");
            string eventW_W = (Convert.ToDouble(w_w) / n_exp).ToString("F");
            string eventB_W = (Convert.ToDouble(b_w) / n_exp).ToString("F");
            string eventB_R = (Convert.ToDouble(b_r) / n_exp).ToString("F");
            string eventR_R = (Convert.ToDouble(r_r) / n_exp).ToString("F");
            string eventW_R = (Convert.ToDouble(w_r) / n_exp).ToString("F"); 
            //заполняем коробки шариками в xml документе  
            XDocument doc = new XDocument(new XElement("boxes",
                    new XElement("количество_ВОХ-ов",
                        new XElement("номер", int_boxes)),
                    new XElement("содержимое_ВОХ-ов",
                        new XElement("box",
                         new XAttribute("id", 1),
                                    new XElement("red", r_box1),
                                    new XElement("white", w_box1),
                                    new XElement("black", b_box1)

                            ),
                         new XElement("box",
                         new XAttribute("id", 2),
                                    new XElement("red", r_box2),
                                    new XElement("white", w_box2),
                                    new XElement("black", b_box2)

                            ),
                         new XElement("box",
                         new XAttribute("id", 3),
                                    new XElement("red", r_box3),
                                    new XElement("white", w_box3),
                                    new XElement("black", b_box3)

                            )),
                    new XElement("придаваемые_шары",
                        new XElement("от_box1", take1),
                        new XElement("от_box2", take2),
                        new XElement("от_box3", take3)),
                    new XElement("события",
                        new XElement("событие",
                            new XAttribute("colors","black_black"),
                            new XElement("вероятность", eventB_B),
                            new XElement("выигрыш",100)),
                        new XElement("событие",
                            new XAttribute("colors", "red_red"),
                            new XElement("вероятность", eventR_R),
                            new XElement("выигрыш", 150)),
                        new XElement("событие",
                            new XAttribute("colors", "white_white"),
                            new XElement("вероятность", eventW_W),
                            new XElement("выигрыш", 50)),
                        new XElement("событие",
                            new XAttribute("colors", "black_white"),
                            new XElement("вероятность", eventB_W),
                            new XElement("выигрыш", 0)),
                        new XElement("событие",
                            new XAttribute("colors", "black_red"),
                            new XElement("вероятность", eventB_R),
                            new XElement("выигрыш", 20)),
                        new XElement("событие",
                            new XAttribute("colors", "white_red"),
                            new XElement("вероятность", eventW_R),
                            new XElement("выигрыш", 10))),
                    new XElement("жетон",
                        new XAttribute("стоимость", "10 руб"))

                     ));
            doc.Save("boxes1.xml");
            Process.Start("notepad.exe", "C:\\Users\\Khaliun\\Documents\\Visual Studio 2015\\Projects\\BoxWithBalls\\BoxWithBalls\\bin\\Debug\\boxes1.xml");
            
        }

        private void label10_Click(object sender, EventArgs e)
        {
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe", "C:\\Users\\Khaliun\\Documents\\Visual Studio 2015\\Projects\\BoxWithBalls\\BoxWithBalls\\bin\\Debug\\boxes1.xml");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var userForm = new UserAttention(this);
            userForm.Show();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            var tableForm = new TableForm(this);
            tableForm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var charForm=new Characters(this);
            charForm.Show();
        }
    }

}
