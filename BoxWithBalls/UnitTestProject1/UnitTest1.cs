using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoxWithBalls;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod()]
        //тест очишения контейнера 
        public void clearTest()
        {
            Box box = new Box(new string[] { "white", "black", "blue" });
            box.clear();
            Assert.AreEqual(0, box.balls.Count);
        }

        [TestMethod()]
        //тест считывания количество шариков определенного каждого цвета 
        public void countTest()
        {
            Box box = new Box(new string[] { "white", "white", "black", "black", "blue" });
            Assert.AreEqual(2, box.count("white"));
            Assert.AreEqual(2, box.count("black"));
            Assert.AreEqual(1, box.count("blue"));
        }


        [TestMethod()]
        //тест добавления шарика в новой  контейнер 
        public void addTest()
        {
            Box box = new Box();
            List<string> n_balls = new List<string>();
            n_balls.AddRange(new string[] { "white", "white", "black", "blue" });
            box.add(n_balls);
            CollectionAssert.AreEqual(new List<string> { "white", "white", "black", "blue" }, box.balls);
        }

        [TestMethod()]
        //тест для изъятия шариков сушествуюшего количества 
        public void takeTest()
        {
            Box box = new Box(new string[] { "white", "black", "black", "blue", "blue" });
            Box new_box = box.take();

            Assert.IsTrue(box.balls.Count <= 5);
            Assert.IsTrue(new_box.balls.Count > 0);
        }

        [TestMethod()]
        //тест для проверки количество шариков в контейнерах после изъятия 
        public void takeTest1()
        {
            Box box = new Box(new string[] { "white", "black", "black", "blue", "blue" });
            Box new_box = box.take(2);

            Assert.AreEqual(3, box.balls.Count);
            Assert.AreEqual(2, new_box.balls.Count);
        }

        [TestMethod()]
        //тест для проверки шариков определенного цвета в контейнерах после  изъятия 
        public void takeTest2()
        {
            Box box = new Box(new string[] { "white", "black", "black", "blue" });
            Box new_box = new Box(new string[] { "white" });
            new_box=box.take("blue");

            CollectionAssert.AreEqual(new List<string> { "white", "black", "black" }, box.balls);
            CollectionAssert.AreEqual(new List<string> { "blue" }, new_box.balls);
        }



        [TestMethod()]
        //Тест проверки на включения одного на другой контейнер 
        public void containsTest1()
        {
            Box box = new Box(new string[] { "white", "black", "black" });
            Box new_box = new Box(new string[] { "white" });
            Box blue_box = new Box(new string[] { "blue" });

            Assert.IsTrue(box.contain(new_box));
            Assert.IsFalse(box.contain(blue_box));
        }
        //тест проверки  содержания контейнером определенного количества шаров определенного цвета.
        [TestMethod()]
        public void containsTest2()
        {
            Box box = new Box(new string[] { "white", "black", "black" });
            Assert.IsTrue(box.contain("white"));
            Assert.IsFalse(box.contain("blue"));
        }
        [TestMethod()]
        //тесты для проверки содержания определенного цвета шариков 
        public void containsTest()
        {
            Box box = new Box(new string[] { "red","black","red","white", "black", "black" });

            Assert.IsTrue(box.contain(new List<string> { "black","white" }));
            Assert.IsTrue(box.contain(new List<string> { "red", "white" }));
            Assert.IsTrue(box.contain(new List<string> { "red", "red" }));
            Assert.IsFalse(box.contain(new List<string> { "blue" }));
        }

        [TestMethod()]
        //тест для суммирования шариков контейноров 
        public void TestBoxAddition()
        {
            Box box = new Box(new string[] { "white", "blue" });
            Box new_box = new Box(new string[] { "black", "black" });

            new_box = box + new_box;
            CollectionAssert.AreEqual(new List<string> { "white", "blue", "black", "black" }, new_box.balls);
        }

        [TestMethod()]
        //тест для вычитания шариков контейноров
        public void TestBoxSubstraction()
        {
            Box box = new Box(new string[] { "white", "blue", "black", "black" });
            Box new_box = new Box(new string[] { "black", "black" });

            box = box - new_box;
            CollectionAssert.AreEqual(new List<string> { "white", "blue" }, box.balls);
        }

        [TestMethod()]
        //тест для приравнения шариков контейноров
        public void TestBoxesAreEqual()
        {
            Box box = new Box(new string[] { "black", "blue" });
            Box new_box = new Box(new string[] { "black", "blue" });

            bool result = box == new_box;
            Assert.IsTrue(result);
        }

        [TestMethod()]
        //тест для сравниения шариков контейноров
        public void TestBoxesAreNotEqual()
        {
            Box box = new Box(new string[] { "black", "black", "black", "blue" });
            Box new_box = new Box(new string[] { "black", "black" });

            bool result = box != new_box;
            Assert.IsTrue(result);
        }
        [TestMethod()]
        //тест для сравниения шариков контейноров
        public void TestBoxesComparisons()
        {
            Box box = new Box(new string[] { "black", "black", "black", "blue" });
            Box new_box = new Box(new string[] { "black", "black" });

            bool result = box > new_box;
            Assert.IsTrue(result);
        }
    }
}

