using System;

namespace Chapter14_Defining_Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            //StudentTest.student1.DisplayStudentInfos();
            //StudentTest.TestStudent();
            //MobilePhone.ShowNokia();
            //MobilePhone phone = new MobilePhone("Samsung Galaxy Ace OVER 9000", "Samsung", 120515, "Benji", new Battery("Li", Battery.BatteryTypes.Li_ION), new Screen(300, 800));
            //Console.WriteLine(phone.PhoneInformations());
            //MobilePhoneTest.Execute();

        }
    }

    public class Student
    {
        #region Fields & Properties
        public static int studentsCreated = 0;

        private string fullName = null;
        public string FullName { get { return this.fullName; } }

        private string course = null;
        public string Course { get { return this.course; } set { this.course = value; } }

        private string subject = null;
        public string Subject { get { return this.subject; } set { this.subject = value; } }

        private string university = null;
        public string University { get { return this.university; } set { this.university = value; } }

        private string email = null;
        public string Email { get { return this.email; } set { this.email = value; } }

        private string phoneNumber = null;
        public string PhoneNumber { get { return this.phoneNumber; } set { this.phoneNumber = value; } }

        #endregion

        #region Constructors
        public Student() : this("Noname")
        {

        }
        public Student(string fullName) : this(fullName,"Maths")
        {

        }
        public Student(string fullName, string course) : this(fullName,course,"Data")
        {

        }
        public Student(string fullName, string course, string subject) : this(fullName,course,subject,"Cambridge")
        {

        }
        public Student(string fullName, string course,string subject, string university) : this(fullName, course, subject, university,"nobody@hotmail.com")
        {

        }
        public Student(string fullName, string course, string subject, string university, string email) : this(fullName, course, subject, university, email, "0612345678")
        {

        }
        public Student(string fullName, string course, string subject, string university, string email, string phoneNumber)
        {
            this.fullName = fullName;
            this.course = course;
            this.subject = subject;
            this.university = university;
            this.email = email;
            this.phoneNumber = phoneNumber;
            studentsCreated++;
        }
        #endregion

        #region Methods
        public void DisplayStudentInfos()
        {
            Console.WriteLine("The student " + this.fullName + " is the course : " + this.course + " learning about " + this.subject + " in the university " + this.university + ".\n" +
                "His email is : " + email + ", and is phone number is " + this.phoneNumber + ".");
        }
        #endregion
    }

    public static class StudentTest
    {
        public static Student student1 = null;
        public static Student student2 = null;
        public static Student student3 = null;
        public static Student student4 = null;

        public static void TestStudent()
        {
            Student student1 = new Student();
            Student student2 = new Student("Paprika");
            Student student3 = new Student("Guillaume","Biology");
            Student student4 = new Student("Zyzouf","Game Design","Documentation");
            Student student5 = new Student("Flavion","Maths","High level skills","ENS");
            Student student6 = new Student("Martin", "Java", "Some Shenaningans", "Somewhere","Martin.Thug@wtf.life");
            Student student7 = new Student("Benjamin PETER", "Game Design", "Mecanics", "ICAN", "b****.p****@hotmail.fr", "06********");

            student1.DisplayStudentInfos();
            student2.DisplayStudentInfos();
            student3.DisplayStudentInfos();
            student4.DisplayStudentInfos();
            student5.DisplayStudentInfos();
            student6.DisplayStudentInfos();
            student7.DisplayStudentInfos();
        }

        static StudentTest()
        {
            student1 = new Student("Zyzouf", "Game Design", "Documentation");
            student2 = new Student("Flavion", "Maths", "High level skills", "ENS");
            student3 = new Student("Martin", "Java", "Some Shenaningans", "Somewhere", "Martin.Thug@wtf.life");
            student4 = new Student("Benjamin PETER", "Game Design", "Mecanics", "ICAN", "b****.p****@hotmail.fr", "06********");
        }
    }

    public class MobilePhone
    {
        #region Fields & Properties
        public static MobilePhone nokiaN95 = new MobilePhone("NokiaN95", "Nokia", 1000, "Me", new Battery("Nokia", Battery.BatteryTypes.NiCd), new Screen(300, 800, new Color(255, 0, 0)));

        private string model = null;
        public string Model { get { return this.model; } }
        private string manufacturer = null;
        public string Manufacturer { get { return this.manufacturer; } }
        private float price = 0;
        public float Price { get { return this.price; } }
        private string owner = null;
        public string Owner { get { return this.owner; } set { this.owner = value; } }
        private Battery battery = null;
        public Battery Battery { get { return this.battery; }  set { this.battery = value; } }
        private Screen screen = null;
        public Screen Screen { get { return this.screen; } }
        #endregion

        #region Constructors
        public MobilePhone() : this("Nokia")
        {

        }
        public MobilePhone(string model) : this(model,"Black Market")
        {

        }
        public MobilePhone(string model, string manufacturer) : this(model, manufacturer, 0)
        {

        }
        public MobilePhone(string model, string manufacturer, float price) : this(model, manufacturer, price, "Me")
        {

        }
        public MobilePhone(string model, string manufacturer, float price, string owner) : this(model, manufacturer, price, owner,new Battery())
        {

        }
        public MobilePhone(string model, string manufacturer, float price, string owner, Battery battery) : this(model, manufacturer, price, owner, battery,new Screen())
        {

        }
        public MobilePhone(string model, string manufacturer, float price, string owner, Battery battery, Screen screen)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
            this.owner = owner;
            this.battery = battery;
            this.screen = screen;
        }
        #endregion

        #region Methods

        public string PhoneInformations()
        {
            string informations =
                "Phone :\n" +
                "\tModel : " + this.model + "\n" +
                "\tManufacturer : " + this.manufacturer + "\n" +
                "\tOwner : " + this.owner + "\n" +
                "\tPrice : " + this.price + "\n" +
                "Battery :\n" +
                "\tModel : " + this.battery.Model + "\n" +
                "\tBattery Type : " + this.battery.BatteryType + "\n" +
                "\tIdle Time : " + this.battery.IdleTime + "\n" +
                "\tHours Talk : " + this.battery.HoursTalk + "\n" +
                "Screen :\n" +
                "\tWidht : " + this.screen.Width + "\n" +
                "\tHeight : " + this.screen.Height + "\n";
            return informations;
        }

        public static void ShowNokia()
        {
            Console.WriteLine("The mobile " + nokiaN95.Model + "from" + nokiaN95.Manufacturer + "which belong to " + nokiaN95.Owner + " has a price of " + nokiaN95.Price + ".\n" +
                "It has a " + nokiaN95.Battery.Model + " Battery which is a "+nokiaN95.Battery.BatteryType +" which has " + nokiaN95.Battery.IdleTime + " idle time and " + nokiaN95.Battery.HoursTalk + " of hours talk.\n" +
                "It also have a Screen with a width of " + nokiaN95.Screen.Width + "and a height of " + nokiaN95.Screen.Height + ".");
        }
        #endregion
    }

    public static class MobilePhoneTest
    {
        public static void Execute()
        {
            MobilePhone[] mobiles = new MobilePhone[]
            {
                new MobilePhone(),
                new MobilePhone("Samsung Galaxy Ace OVER 9000"),
                new MobilePhone("Samsung Ace Set et Match", "Samsung"),
                new MobilePhone("Samsung Galaxy Intergalactic", "Samsung", 120515),
                new MobilePhone("IPigeon 12000", "Apple", 1215, "Benji"),
                new MobilePhone("Nokia invincible", "Nokia", 12015, "Flavion", new Battery("Li", Battery.BatteryTypes.Li_ION)),
                new MobilePhone("ITarteenfion 12", "Apple", 0515, "Martin", new Battery("Li", Battery.BatteryTypes.NiCd), new Screen(150, 700)),
                new MobilePhone("Samsung Mario Galaxy", "Samsung", 1515, "Zyzouf", new Battery("Li", Battery.BatteryTypes.NiMH), new Screen(124, 600)),
                new MobilePhone("Nokia c'est plus fort que toi", "Nokia", 1515, "Gui", new Battery("Li", Battery.BatteryTypes.Li_ION), new Screen(500, 1500))
            };
            for(int i = 0; i < mobiles.Length;i++)
            {
                Console.WriteLine("Mobile number " + i + " : " + mobiles[i].PhoneInformations());
            }
            Console.WriteLine("Nokia : " + MobilePhone.nokiaN95.PhoneInformations());
        }
    }

    public class Battery
    {
        #region Fields & Properties
        private string model = null;
        public string Model { get { return this.model; } }
        private int idleTime = 0;
        public int IdleTime { get { return this.idleTime; } set { this.idleTime = value; } }
        private int hoursTalk = 0;
        public int HoursTalk { get { return this.hoursTalk; } set { this.hoursTalk = value; } }

        public enum BatteryTypes
        {
            Li_ION,
            NiMH,
            NiCd
        }
        private BatteryTypes batteryType = BatteryTypes.Li_ION;
        public BatteryTypes BatteryType { get { return this.batteryType; } }
        #endregion

        #region Constructors
        public Battery() : this("Intel")
        {

        }
        public Battery(string model) : this(model, BatteryTypes.Li_ION)
        {

        }
        public Battery(string model, BatteryTypes batteryType)
        {
            this.model = model;
            this.batteryType = batteryType;
            this.idleTime = 0;
            this.hoursTalk = 0;
        }
        #endregion
    }

    public class Screen
    {
        #region Fields & Properties
        private int width = 0;
        public int Width { get { return this.width; }}
        private int height = 0;
        public int Height { get { return this.height; }}
        private Color color = null;
        public Color Color { get { return this.color; } set { this.color = value; } }
        #endregion

        #region Constructors
        public Screen() : this(0,0)
        {

        }
        public Screen(int width, int height) : this(width,height,new Color())
        {

        }
        public Screen(int width, int height, Color color)
        {
            this.width = width;
            this.height = height;
            this.color = color;
        }
        #endregion
    }

    public class Color
    {
        #region Fields & Properties
        private int r = 0;
        public int R { get { return this.r; } }
        private int g = 0;
        public int G { get { return this.g; } }
        private int b = 0;
        public int B { get { return this.b; } }
        #endregion

        #region Constructors
        public Color(): this(0,0,0)
        {

        }
        public Color(int r,int g,int b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }
        #endregion
    }

    public class Call
    {
        #region Fields & Properties
        private DateTime date = default(DateTime);
        private DateTime startTime = default(DateTime);
        private int callDuration = 0; //Call duration in seconds;
        #endregion

        #region Constructors
        public Call()
        {

        }
        #endregion

        public void StartCall()
        {
            date = DateTime.Today;
            startTime = DateTime.Now;
        }

        public void EndCall()
        {
            DateTime endTime = DateTime.Now;
            callDuration = DateTime.Compare(startTime, endTime);
        }
    }

    /// <summary>
    /// Define a class Student, which contains the following information about students: 
    /// full name, course, subject, university, e-mail and phone number.
    /// </summary>
    public static class Exo1
    {
        public static void Execute()
        {

        }
    }

    /// <summary>
    /// Declare several constructors for the class Student, which have different lists of parameters (for complete information about a student or part of it). 
    /// Data, which has no initial value to be initialized with null. 
    /// Use nullable types for all non-mandatory data.
    /// </summary>
    public static class Exo2
    {
        public static void Execute()
        {

        }
    }

    /// <summary>
    /// Add a static field for the class Student, which holds the number of created objects of this class.
    /// </summary>
    public static class Exo3
    {
        public static void Execute()
        {

        }
    }

    /// <summary>
    /// Add a method in the class Student, which displays complete information about the student.
    /// </summary>
    public static class Exo4
    {
        public static void Execute()
        {

        }
    }

    /// <summary>
    /// Modify the current source code of Student class so as to encapsulate the data in the class using properties.
    /// </summary>
    public static class Exo5
    {
        public static void Execute()
        {

        }
    }

    /// <summary>
    /// Write a class StudentTest, which has to test the functionality of the class Student.
    /// </summary>
    public static class Exo6
    {
        public static void Execute()
        {

        }
    }

    /// <summary>
    /// Add a static method in class StudentTest, which creates several objects of type Student and store them in static fields. 
    /// Create a static property of the class to access them.
    /// Write a test program, which displays the information about them in the console.
    /// </summary>
    public static class Exo7
    {
        public static void Execute()
        {

        }
    }

    /// <summary>
    /// Define a class, which contains information about a mobile phone: 
    /// model, manufacturer, price, owner, features of the battery (model, idle time and hours talk) and features of the screen (size and colors).
    /// </summary>
    public static class Exo8
    {
        public static void Execute()
        {

        }
    }

    /// <summary>
    /// Declare several constructors for each of the classes created by the previous task, 
    /// which have different lists of parameters (for complete information about a student or part of it). 
    /// Data fields that are unknown have to be initialized respectively with null or 0.
    /// </summary>
    public static class Exo9
    {
        public static void Execute()
        {

        }
    }

    /// <summary>
    /// To the class of mobile phone in the previous two tasks, add a static field nokiaN95, which stores information about mobile phone model Nokia N95. 
    /// Add a method to the same class, which displays information about this static field.
    /// </summary>
    public static class Exo10
    {
        public static void Execute()
        {

        }
    }

    /// <summary>
    /// Add an enumeration BatteryType, which contains the values for type of the battery (Li-Ion, NiMH, NiCd, …) and use it as a new field for the class Battery.
    /// </summary>
    public static class Exo11
    {
        public static void Execute()
        {

        }
    }

    /// <summary>
    /// Add a method to the class GSM, which returns information about the object as a string.
    /// </summary>
    public static class Exo12
    {
        public static void Execute()
        {

        }
    }

    /// <summary>
    /// Define properties to encapsulate the data in classes GSM, Battery and Display.
    /// </summary>
    public static class Exo13
    {
        public static void Execute()
        {

        }
    }

    /// <summary>
    /// Write a class GSMTest, which has to test the functionality of class GSM. 
    /// Create few objects of the class and store them into an array. 
    /// Display information about the created objects. 
    /// Display information about the static field nokiaN95.
    /// </summary>
    public static class Exo14
    {
        public static void Execute()
        {

        }
    }

    /// <summary>
    /// Create a class Call, which contains information about a call made via mobile phone. 
    /// It should contain information about date, time of start and duration of the call.
    /// </summary>
    public static class Exo15
    {
        public static void Execute()
        {

        }
    }

    public static class Exo16
    {
        public static void Execute()
        {

        }
    }

    public static class Exo17
    {
        public static void Execute()
        {

        }
    }

    public static class Exo18
    {
        public static void Execute()
        {

        }
    }

    public static class Exo19
    {
        public static void Execute()
        {

        }
    }

    public static class Exo20
    {
        public static void Execute()
        {

        }
    }

    public static class Exo21
    {
        public static void Execute()
        {

        }
    }

    public static class Exo22
    {
        public static void Execute()
        {

        }
    }

    public static class Exo23
    {
        public static void Execute()
        {

        }
    }

    public static class Exo24
    {
        public static void Execute()
        {

        }
    }

    public static class Exo25
    {
        public static void Execute()
        {

        }
    }

    public static class Exo26
    {
        public static void Execute()
        {

        }
    }

    public static class Exo27
    {
        public static void Execute()
        {

        }
    }
}
