using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxWithBalls
{
    /// <summary>
    /// Class Box
    /// </summary>
    #region Class Box
    public class Box
    {

        //Список, содержащий количество шаров определенного цвета.
        public List<string> balls = new List<string>();

        #region Конструкторы
        //Конструктор по умолчанию
        public Box()
        { }
        //Конструкторы инициализации
        public Box(string[] new_balls)
        {
            balls = new List<string>();

            foreach (string ball in new_balls)
            {
                balls.Add(ball);
            }
        }
        public Box(List<string> new_balls)
        {
            balls = new_balls;
        }
        //Конструктор копии
        public Box(Box box)
        {
            balls = new List<string>(box.balls);
        }
        #endregion

        //Деструктор
        ~Box()
        {
            this.clear();
        }


        #region Перегруженные операции
        //сумма двух контейнеров
        public static Box operator +(Box box1, Box box2)
        {
            List<string> new_balls = box1.balls;
            new_balls.AddRange(box2.balls);
            return new Box(new_balls);
        }
        //разность двух контейнеров
        public static Box operator -(Box box1, Box box2)
        {
            List<string> new_balls = box1.balls;
            foreach (string ball in box2.balls)
            {
                try
                {
                    new_balls.Remove(ball);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return new Box(new_balls);
        }
        //операции присваивания 
        public static bool operator ==(Box box1, Box box2)
        {

            int a_count;
            foreach (string ball_color in box1.balls.Select(item => item).Distinct().ToArray())
            {
                a_count = (from ball in box1.balls
                           where ball == ball_color
                           select ball).Count();
                if (a_count != box2.count(ball_color))
                {
                    return false;
                }
            }


            return true;
        }

        public static bool operator !=(Box box1, Box box2)
        {

            int a_count;
            foreach (string ball_color in box1.balls.Select(item => item).Distinct().ToArray())
            {
                a_count = (from ball in box1.balls
                           where ball == ball_color
                           select ball).Count();
                if (a_count != box2.count(ball_color))
                {
                    return true;
                }
            }


            return false;
        }
        //операции сравнения 
        public static bool operator >(Box box1, Box box2)
        {
            return box1.balls.Count() > box2.balls.Count();
        }
        public static bool operator >=(Box box1, Box box2)
        {
            return box1.balls.Count() >= box2.balls.Count();
        }
        public static bool operator <=(Box box1, Box box2)
        {
            return box1.balls.Count() <= box2.balls.Count();
        }

        public static bool operator <(Box box1, Box box2)
        {
            return box1.balls.Count() < box2.balls.Count();
        }
        #endregion

        #region Методы


        // Проверка на включение одного контейнера в другой.

        public bool contain(Box b)
        {
            int b_count;
            foreach (string ball_color in b.balls.Select(item => item).Distinct().ToArray())
            {
                b_count = (from ball in b.balls
                           where ball == ball_color
                           select ball).Count();

                if (b_count > this.count(ball_color) || this.count(ball_color) == 0)
                {
                    Console.WriteLine("Попытка изъятия несуществующего количества шаров, или шаров несуществующего цвета.");
                    return false;
                }
            }
            return true;
        }
        // Очистка контейнера
        public void clear()
        {
            balls.Clear();
        }
        //метод, который считает количество шаров 
        public int count(string color)
        {
            return (from ball in balls
                    where ball == color
                    select ball).Count();
        }

        // метод добавления шаров  в список 
        public void add(List<string> n_balls)
        {
            foreach (string ball_color in n_balls)
            {
                balls.Add(ball_color);
            }
        }
        
        #region public Box take()
        //метод изъятия  случайное количество шаров  
        public Box take()
        {
            Box new_box;
            List<string> n_balls = new List<string>();
            Random rand = new Random();
            foreach (string ball_color in this.balls.Distinct().ToArray())
            {
                for (int i = 0; i < rand.Next(1, this.count(ball_color) + 1); i++)
                {
                    this.balls.Remove(ball_color);
                    n_balls.Add(ball_color);
                }
            }

            new_box = new Box(n_balls);
            return new_box;
        }



        /// метод изъятия определенное количество шаров случайных цветов
        public Box take(int count)
        {
            Box new_box;
            string current_ball;
            List<string> n_balls = new List<string>();
            Random rand = new Random();

            for (int i = 0; i < count; i++)
            {
                current_ball = this.balls.ElementAt(rand.Next(this.balls.Count()));
                this.balls.Remove(current_ball);
                n_balls.Add(current_ball);
            }

            new_box = new Box(n_balls);
            return new_box;
        }



        /// метод изъятия случайное количество шаров определенного цвета  
        public Box take(string color)
        {
            Box new_box = new Box();
            if (this.count(color) == 0) return new_box;

            List<string> n_balls = new List<string>();
            Random rand = new Random();

            for (int i = 0; i < rand.Next(1, this.count(color) + 1); i++)
            {
                this.balls.Remove(color);
                n_balls.Add(color);
            }

            new_box = new Box(n_balls);
            return new_box;
        }



        #endregion



        // Проверка содержания контейнером определенного количества шаров.

        public bool contain(List<string> balls)
        {
            int count;
            foreach (string ball_color in balls.Select(item => item).Distinct().ToArray())
            {
                count = (from ball in balls
                         where ball == ball_color
                         select ball).Count();

                if (count > this.count(ball_color) || this.count(ball_color) == 0)
                {
                    Console.WriteLine("Попытка изъятия несуществующего количества шаров!");
                    return false;
                }
            }
            return true;
        }


        // Проверка содержания контейнером шаров определенного цвета.

        public bool contain(string color)
        {
            int count = (from ball in this.balls
                         where ball == color
                         select ball).Count();

            if (count == 0)
            {
                Console.WriteLine("Попытка изъятия несуществующего количества шаров!");
                return false;
            }

            return true;
        }
        #endregion


    }
    #endregion
}
