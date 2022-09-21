using System;
/*using Main1;*/
using Main2;

/*namespace Lab01
{
    class Program
    {
        static void Main(string[] args)
        {
            int nDOG = 3;
            int nCAT = 2;

            Dog cho;
            Cat meo;

            object[] obj = new object[nDOG + nCAT];

            for(int i = 0; i < nDOG; i++)
            {
                cho = new Dog();
                cho.InputInfo();
                obj[i] = (Dog)cho;
            }
            for(int i = 0; i < nCAT; i++)
            {
                meo = new Cat();
                meo.InputInfo();
                obj[i + nDOG] = (Cat)meo;
            }
            for (int i = 0; i < nDOG + nCAT; i++)
            {
                if (obj[i].GetType() == typeof(Dog))
                {
                    Console.WriteLine("Information of Dog:");
                    cho = (Dog)obj[i];
                    cho.DisplayInfo();
                    
                }
                else
                {
                    Console.WriteLine("Information of Cat:");
                    meo = (Cat)obj[i];
                    meo.DisplayInfo();
                }
            }
            Console.ReadLine();
        }

    }

}

namespace Main1
{
    public class NegativeNumException : Exception
    {
        public NegativeNumException() { }
        public NegativeNumException(string message) : base(message) { }
    }

    public class Dog
    {
        private string name;
        private int age = 0;
        private int height = 0;
        private int weight = 0;

        public Dog(string name = "", int age = 0, int height = 0, int weight = 0)
        {
            this.name = name;
            this.age = age;
            this.height = height;
            this.weight = weight;
        }

        public void InputAge()
        {
            bool isCompleted = false;

            Console.Write("Input Dog Age(1 - 20):");
            string str = Console.ReadLine();
            try
            {
                age = int.Parse(str);
                if (age <= 0 || age > 20)
                    throw new NegativeNumException();
                isCompleted = true;
            }
            catch (FormatException)
            {
                Console.Write("Not input a Number. Plz reinput a number!\n");

            }
            catch (NegativeNumException)
            {
                Console.Write("Negative age is not accepted. Plz reinput a number!\n");
            }
            finally
            {
                if (!isCompleted)
                {
                    InputAge();
                }
            }
        }

        public void InputHeight()
        {
            bool isCompleted = false;

            Console.Write("Input Dog Height (15 - 110 cm):");
            string h = Console.ReadLine();
            try
            {
                height = int.Parse(h);
                if (height < 15 || height > 110)
                    throw new NegativeNumException();
                isCompleted = true;
            }
            catch (FormatException)
            {
                Console.Write("Not input a Number. Plz reinput a number!\n");

            }
            catch (NegativeNumException)
            {
                Console.Write("Negative height is not accepted. Plz reinput a number!\n");
            }
            finally
            {
                if (!isCompleted)
                {
                    InputHeight();
                }
            }
        }

        public void InputWeight()
        {
            bool isCompleted = false;

            Console.Write("Input Dog Weight (7 - 200 pounds):");
            string w = Console.ReadLine();
            try
            {
                weight = int.Parse(w);
                if (weight < 7 || height > 200)
                    throw new NegativeNumException();
                isCompleted = true;
            }
            catch (FormatException)
            {
                Console.Write("Not input a Number. Plz reinput a number!\n");

            }
            catch (NegativeNumException)
            {
                Console.Write("Negative weight is not accepted. Plz reinput a number!\n");
            }
            finally
            {
                if (!isCompleted)
                {
                    InputWeight();
                }
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Name = {0}, Age = {1}, Height = {2}, Weight = {3}", name, age, height, weight);

        }

        public void InputInfo()
        {
            Console.Write("Input Dog Name:");
            name = Console.ReadLine();
            InputAge();
            InputHeight();
            InputWeight();
        }
    }

    public class Cat
    {
        private string name;
        private int age = 0;
        private int height = 0;
        private int weight = 0;

        public Cat(string name = "", int age = 0, int height = 0, int weight = 0)
        {
            this.name = name;
            this.age = age;
            this.height = height;
            this.weight = weight;
        }

        public void InputAge()
        {
            bool isCompleted = false;

            Console.Write("Input Cat Age(1 - 20):");
            string str = Console.ReadLine();
            try
            {
                age = int.Parse(str);
                if (age <= 0 || age > 20)
                    throw new NegativeNumException();
                isCompleted = true;
            }
            catch (FormatException)
            {
                Console.Write("Not input a Number. Plz reinput a number!\n");

            }
            catch (NegativeNumException)
            {
                Console.Write("Negative age is not accepted. Plz reinput a number!\n");
            }
            finally
            {
                if (!isCompleted)
                {
                    InputAge();
                }
            }
        }

        public void InputHeight()
        {
            bool isCompleted = false;

            Console.Write("Input Cat height(23 - 25cm):");
            string h = Console.ReadLine();
            try
            {
                height = int.Parse(h);
                if (height < 23 || height > 25)
                    throw new NegativeNumException();
                isCompleted = true;
            }
            catch (FormatException)
            {
                Console.Write("Not input a Number. Plz reinput a number!\n");

            }
            catch (NegativeNumException)
            {
                Console.Write("Negative height is not accepted. Plz reinput a number!\n");
            }
            finally
            {
                if (!isCompleted)
                {
                    InputHeight();
                }
            }
        }

        public void InputWeight()
        {
            bool isCompleted = false;

            Console.Write("Input Cat Weight (5 - 30 pounds):");
            string w = Console.ReadLine();
            try
            {
                weight = int.Parse(w);
                if (weight < 5 || height > 30)
                    throw new NegativeNumException();
                isCompleted = true;
            }
            catch (FormatException)
            {
                Console.Write("Not input a Number. Plz reinput a number!\n");

            }
            catch (NegativeNumException)
            {
                Console.Write("Negative weight is not accepted. Plz reinput a number!\n");
            }
            finally
            {
                if (!isCompleted)
                {
                    InputWeight();
                }
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Name = {0}, Age = {1}, Height = {2}, Weight = {3}", name, age, height, weight);

        }

    

        public void InputInfo()
        {
            Console.Write("Input Cat Name:");
            name = Console.ReadLine();
            InputAge();
            InputHeight();
            InputWeight();
        }
    }
}
*/


namespace Main2
{
    class Progam
    {
        static void Main(string[] args)
        {
            Football f = new Football();
            Tenis t = new Tenis();
            Volleyball v = new Volleyball();
            f.InputInfo();
            t.InputInfo();
            v.InputInfo();
            f.DisplayInfo();
            t.DisplayInfo();
            v.DisplayInfo();
            
            Console.ReadKey();
        }
    }

    public class NegativeNumException : Exception
    {
        public NegativeNumException() { }
        public NegativeNumException(string message) : base(message) { }
    }

    public class Sport
    {
        protected string type;
        protected int playerSlary;
        protected string topTier;
        public Sport(string a = "", int b = 0, string c = "")
        {
            type = a;
            playerSlary = b;
            topTier = c;
           
        }

        public void InputPS() //#PS = player slary
        {
            bool isCompleted = false;

            Console.Write("Player Slary USD/Year:");
            string ps = Console.ReadLine();
            try
            {
                playerSlary = int.Parse(ps);
                if (playerSlary <=0 )
                    throw new NegativeNumException();
                isCompleted = true;
            }
            catch (FormatException)
            {
                Console.Write("Not input a Number. Plz reinput a number!\n");

            }
            catch (NegativeNumException)
            {
                Console.Write("Player slary must > 0. Plz reinput a number\n");
            }
            finally
            {
                if (!isCompleted)
                {
                    InputPS();
                }
            }
        }

        public virtual void InputInfo()
        {
            Console.Write("Type of sport (indoor - outdoor):");
            type = Console.ReadLine();
            InputPS();
            Console.Write("Top tier player:");
            topTier = Console.ReadLine();

        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine("Type of sport = {0}, Player salary = {1}, Top tier player = {2} ", type, playerSlary, topTier);
           
        }
    }

    public class Football: Sport
    {
        private int numberPlayer;
        private int time;
        private int ball;

        public Football(int numberPlayer = 0, int time = 0, int ball = 0, string a = "", int b = 0, string c = ""): base (a, b, c)
        {
            this.numberPlayer = numberPlayer;
            this.time = time;
            this.ball = ball;
            
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("                   FOOTBALL");
            base.DisplayInfo();
            Console.WriteLine("NumberPlayer = {0}, Time = {1}, Ball = {2}\n",numberPlayer ,time ,ball);
           

        }

        public override void InputInfo()
        {
            Console.Write("Input information for Football\n");
            base.InputInfo();
            Console.Write("Number of player:");
            string n = Console.ReadLine();
            numberPlayer = int.Parse(n);
            Console.Write("Time playing:");
            string t = Console.ReadLine();
            time = int.Parse(t);
            Console.Write("Type of ball(1-3):");
            string b = Console.ReadLine();
            ball = int.Parse(b);
        }

    }

    public class Tenis: Sport
    {
        private int numberPlayer;
        private int time;
        private int ball;

        public Tenis(int numberPlayer = 0, int time = 0, int ball = 0, string a = "", int b = 0, string c = "") : base(a, b, c)
        {
            this.numberPlayer = numberPlayer;
            this.time = time;
            this.ball = ball;

        }

        public override void DisplayInfo()
        {
            Console.WriteLine("                   TENIS");
            base.DisplayInfo();
            Console.WriteLine("NumberPlayer = {0}, Time = {1}, Ball = {2}\n", numberPlayer, time, ball);

        }

        public override void InputInfo()
        {
            Console.Write("Input information for Tenis\n");
            base.InputInfo();
            Console.Write("Number of player:");
            string n = Console.ReadLine();
            numberPlayer = int.Parse(n);
            Console.Write("Time playing:");
            string t = Console.ReadLine();
            time = int.Parse(t);
            Console.Write("Type of ball(1-3):");
            string b = Console.ReadLine();
            ball = int.Parse(b);
        }
    }

    public class Volleyball: Sport
    {
        private int numberPlayer;
        private int time;
        private int ball;

        public Volleyball(int numberPlayer = 0, int time = 0, int ball = 0, string a = "", int b = 0, string c = "") : base(a, b, c)
        {
            this.numberPlayer = numberPlayer;
            this.time = time;
            this.ball = ball;

        }

        public override void DisplayInfo()
        {
            Console.WriteLine("                   VOLLEYBALL");
            base.DisplayInfo();
            Console.WriteLine("NumberPlayer = {0}, Time = {1}, Ball = {2}\n", numberPlayer, time, ball);


        }

        public override void InputInfo()
        {
            Console.Write("Input information for Volleyball\n");
            base.InputInfo();
            Console.Write("Number of player:");
            string n = Console.ReadLine();
            numberPlayer = int.Parse(n);
            Console.Write("Time playing:");
            string t = Console.ReadLine();
            time = int.Parse(t);
            Console.Write("Type of ball(1-3):");
            string b = Console.ReadLine();
            ball = int.Parse(b);
        }
    }
}

