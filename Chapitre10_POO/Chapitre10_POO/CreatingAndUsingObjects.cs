using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatingAndUsingObjects
{
    //Exo 7 :
    /*
        Define your own namespace CreatingAndUsingObjects and place in it two classes Cat and Sequence, 
        which we used in the examples of the current chapter. 
        Define one more namespace and make a class, which calls the classes Cat and Sequence, in it.
    */

    public class Cat
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string color;
        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public Cat()
        {
            name = "Unnamed";
            color = "gray";
        }
        public Cat(string name, string color)
        {
            this.name = name;
            this.color = color;
        }

        public void SayMiau()
        {
            Console.WriteLine("Cat {0} said : Miauuuuuu!", name);
        }
    }

    public class Sequence
    {
        private static int currentValue = 0;

        private Sequence()
        {

        }

        public static int NextValue()
        {
            currentValue++;
            return currentValue;
        }
    }

}
