using System;
using System.Collections.Generic;

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
            //TestLibrary.Execute();
            FractionTest.Execute();
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
        public Student(string fullName) : this(fullName, "Maths")
        {

        }
        public Student(string fullName, string course) : this(fullName, course, "Data")
        {

        }
        public Student(string fullName, string course, string subject) : this(fullName, course, subject, "Cambridge")
        {

        }
        public Student(string fullName, string course, string subject, string university) : this(fullName, course, subject, university, "nobody@hotmail.com")
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
            Student student3 = new Student("Guillaume", "Biology");
            Student student4 = new Student("Zyzouf", "Game Design", "Documentation");
            Student student5 = new Student("Flavion", "Maths", "High level skills", "ENS");
            Student student6 = new Student("Martin", "Java", "Some Shenaningans", "Somewhere", "Martin.Thug@wtf.life");
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
        public Battery Battery { get { return this.battery; } set { this.battery = value; } }
        private Screen screen = null;
        public Screen Screen { get { return this.screen; } }

        //Phone data
        private List<Call> callHistory = null;
        public List<Call> CallHistory { get { return this.callHistory; } set { this.callHistory = value; } }
        #endregion

        #region Constructors
        public MobilePhone() : this("Nokia")
        {

        }
        public MobilePhone(string model) : this(model, "Black Market")
        {

        }
        public MobilePhone(string model, string manufacturer) : this(model, manufacturer, 0)
        {

        }
        public MobilePhone(string model, string manufacturer, float price) : this(model, manufacturer, price, "Me")
        {

        }
        public MobilePhone(string model, string manufacturer, float price, string owner) : this(model, manufacturer, price, owner, new Battery())
        {

        }
        public MobilePhone(string model, string manufacturer, float price, string owner, Battery battery) : this(model, manufacturer, price, owner, battery, new Screen())
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
                "It has a " + nokiaN95.Battery.Model + " Battery which is a " + nokiaN95.Battery.BatteryType + " which has " + nokiaN95.Battery.IdleTime + " idle time and " + nokiaN95.Battery.HoursTalk + " of hours talk.\n" +
                "It also have a Screen with a width of " + nokiaN95.Screen.Width + "and a height of " + nokiaN95.Screen.Height + ".");
        }

        /// <summary>
        /// Add a call to the call history list.
        /// </summary>
        /// <param name="call">The call that you want to add.</param>
        public void AddCall(Call call)
        {
            this.callHistory.Add(call);
        }

        /// <summary>
        /// Remove a specified call from the list.
        /// </summary>
        /// <param name="call">The call that you want to delete.</param>
        /// <returns>True if the call has been found and removed, else return false.</returns>
        public bool RemoveCall(Call call)
        {
            int index = this.callHistory.FindIndex((callToMatch) => { return callToMatch.ID == call.ID; });
            if (index >= 0)
            {
                this.callHistory.RemoveAt(index);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Remove all the calls from the list.
        /// </summary>
        public void RemoveAllCalls()
        {
            this.callHistory.Clear();
        }

        /// <summary>
        /// The number of call archived on the phone.
        /// </summary>
        /// <returns>The number of calls.</returns>
        public int NumberOfCallPassed()
        {
            return this.callHistory.Count;
        }

        /// <summary>
        /// Calculate the price of all the calls.
        /// </summary>
        /// <param name="amountOfACall">The amount of one call.</param>
        /// <returns>The total price.</returns>
        public float PriceOfAllCalls(float amountOfACall)
        {
            float price = 0;
            for (int i = 0; i < this.callHistory.Count; i++)
            {
                price += ((float)this.callHistory[i].CallDuration / 60.0f) * amountOfACall;
            }
            return price;
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
            for (int i = 0; i < mobiles.Length; i++)
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
        public int Width { get { return this.width; } }
        private int height = 0;
        public int Height { get { return this.height; } }
        private Color color = null;
        public Color Color { get { return this.color; } set { this.color = value; } }
        #endregion

        #region Constructors
        public Screen() : this(0, 0)
        {

        }
        public Screen(int width, int height) : this(width, height, new Color())
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
        public Color() : this(0, 0, 0)
        {

        }
        public Color(int r, int g, int b)
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
        private static uint callIDs = 0;
        private uint callID = 0;
        public uint ID { get { return this.callID; } }
        private DateTime date = default(DateTime);
        private DateTime startTime = default(DateTime);
        private int callDuration = 0; //Call duration in seconds;
        public int CallDuration { get { return this.callDuration; } }
        #endregion

        #region Constructors
        public Call()
        {
            this.callID = callIDs;
            callIDs++;
            if (callIDs == uint.MaxValue)
                callIDs = 0;
        }
        #endregion

        #region Methods
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
        #endregion
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

    /// <summary>
    /// Add a property for keeping a call history – CallHistory, which holds a list of call records.
    /// </summary>
    public static class Exo16
    {
        public static void Execute()
        {

        }
    }

    /// <summary>
    /// In GSM class add methods for adding and deleting calls (Call) in the archive of mobile phone calls. 
    /// Add method, which deletes all calls from the archive.
    /// </summary>
    public static class Exo17
    {
        public static void Execute()
        {

        }
    }

    /// <summary>
    /// In GSM class, add a method that calculates the total amount of calls (Call) from the archive of phone calls (CallHistory), as the price of a phone call is passed as a parameter to the method.
    /// </summary>
    public static class Exo18
    {
        public static void Execute()
        {

        }
    }

    /// <summary>
    /// Create a class GSMCallHistoryTest, with which to test the functionality of the class GSM, from task 12, as an object of type GSM. 
    /// Then add to it a few phone calls (Call). 
    /// Display information about each phone call. 
    /// Assuming that the price per minute is 0.37, calculate and display the total cost of all calls. 
    /// Remove the longest conversation from archive with phone calls and calculate the total price for all calls again. Finally, clear the archive.
    /// </summary>
    public static class Exo19
    {
        public static void Execute()
        {

        }
    } // Skip this one, fcts are working.

    public class Book
    {
        #region Fields & Properties
        private string title = "";
        public string Title { get { return this.title; } }
        private string author = "";
        public string Author { get { return this.author; } }
        private string publisher = "";
        public string Publisher { get { return this.publisher; } }
        private DateTime releaseDate = default(DateTime);
        public DateTime ReleaseDate { get { return this.releaseDate; } }
        private int isbnNumber = 0;
        public int ISBN_Number { get { return this.isbnNumber; } }
        #endregion

        #region Constructors
        public Book()
        {

        }
        public Book(string title, string author, string publisher, DateTime releaseDate, int isbnNumber)
        {
            this.title = title;
            this.author = author;
            this.publisher = publisher;
            this.releaseDate = releaseDate;
            this.isbnNumber = isbnNumber;
        }
        #endregion

        #region Methods

        #endregion
    }

    public class Library
    {
        #region Fields & Properties
        private string name = "";
        private List<Book> books = null;
        public List<Book> Books { get { return this.books; } }
        #endregion

        #region Constructors
        public Library() : this("")
        {

        }
        public Library(string name) : this(name, new List<Book>())
        {

        }
        public Library(string name, List<Book> books)
        {
            this.name = name;
            this.books = books;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Add a book in the library.
        /// </summary>
        /// <param name="book">The book to add.</param>
        public void AddBook(Book book)
        {
            this.books.Add(book);
        }

        /// <summary>
        /// Remove a book from the library.
        /// </summary>
        /// <param name="book">The book to remove.</param>
        /// <returns>True if the book has been found and removed, else return false.</returns>
        public bool DeleteBook(Book book)
        {
            int index = this.books.FindIndex((bookToMacth) => { return bookToMacth.ISBN_Number == book.ISBN_Number; });
            if (index >= 0)
            {
                this.books.RemoveAt(index);
                return true;
            }
            return false;
        }

        public bool DeleteBook(int index)
        {
            if (index >= 0 && index < this.books.Count)
            {
                this.books.RemoveAt(index);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Search for a book whith a specific author name and returns it.
        /// </summary>
        /// <param name="author">Name of the author.</param>
        /// <returns></returns>
        public int GetBookByAuthor(string author)
        {
            return this.GetBookByAuthor(0, author);
        }

        /// <summary>
        /// Get a the first book find from an author from the <paramref name="startIndex"/>.
        /// </summary>
        /// <param name="startIndex">The first index to look in the library.</param>
        /// <param name="author">The author of the books.</param>
        /// <returns>The index of the first book find.</returns>
        public int GetBookByAuthor(int startIndex, string author)
        {
            int index = this.books.FindIndex(startIndex, (book) => { return (book.Author == author); });
            if (index >= 0)
            {
                return index;
            }
            return -1;
        }

        /// <summary>
        /// Returns all the books of an author.
        /// </summary>
        /// <param name="author">The author's name.</param>
        /// <returns>All the index of the books.</returns>
        public int[] GetAllBooksByAuthor(string author)
        {
            int startIndex = 0;
            List<int> indexes = new List<int>();
            while (true)
            {
                startIndex = this.GetBookByAuthor(startIndex, author);
                if (startIndex >= 0)
                {
                    indexes.Add(startIndex);
                    startIndex++;
                }
                else
                    break;
            }
            return indexes.ToArray();
        }

        /// <summary>
        /// Display informations of a book in the console.
        /// </summary>
        /// <param name="bookIndex">The book index in the library.</param>
        public void DisplayBookInfo(int bookIndex)
        {
            Book book = this.books[bookIndex];
            Console.WriteLine("The book \"" + book.Title + "\" by " + book.Author + " was published by " + book.Publisher + " and was released " + book.ReleaseDate.ToShortDateString() + ".\n" +
                "ISBN-Number : " + book.ISBN_Number + ".\n");
        }
        #endregion
    }

    /// <summary>
    /// There is a book library. 
    /// Define classes respectively for a book and a library. 
    /// The library must contain a name and a list of books. 
    /// The books must contain the title, author, publisher, release date and ISBN-number. 
    /// In the class, which describes the library, create methods to add a book to the library, to search for a book by a predefined author, to display information about a book and to delete a book from the library.
    /// </summary>
    public static class Exo20
    {
        public static void Execute()
        {

        }
    }

    public static class TestLibrary
    {
        public static void Execute()
        {
            List<Book> books = new List<Book>(5)
            {
                new Book("Le prince de sang","J.K Rolling","Machin",new DateTime(1985,12,14),564373854),
                new Book("Ca","Stephen King","Bidule",new DateTime(1950,4,1),64373854),
                new Book("Farenheit 451","Ray Bradbery","Firestorm",new DateTime(1451,5,26),56437354),
                new Book("Ca 2","Stephen King","Bidule",new DateTime(1960,11,16),54373854),
                new Book("Le seigneur des poireaux","Golum 3e du nom","Truc",new DateTime(1745,1,6),56433854)
            };
            Library library = new Library("Michel Simon", books);

            library.AddBook(new Book("Le pd des étoiles", "Moi", "Toujours moi", new DateTime(2018, 9, 25), 19981612));
            for (int i = 0; i < library.Books.Count; i++)
            {
                library.DisplayBookInfo(i);
            }
            int index = 0;
            while (index >= 0)
            {
                index = library.GetBookByAuthor("Stephen King");
                library.DeleteBook(index);
            }

            Console.WriteLine("Books deleted.\n");

            for (int i = 0; i < library.Books.Count; i++)
            {
                library.DisplayBookInfo(i);
            }
        }
    }

    /// <summary>
    /// Write a test class, which creates an object of type library, adds several books to it and displays information about each of them. 
    /// Implement a test functionality, which finds all books authored by Stephen King and deletes them. 
    /// Finally, display information for each of the remaining books.
    /// </summary>
    public static class Exo21
    {
        public static void Execute()
        {

        }
    }

    /// <summary>
    /// We have a school. 
    /// In school we have classes and students. 
    /// Each class has a number of teachers. 
    /// Each teacher has a variety of disciplines taught. 
    /// Students have a name and a unique number in the class. 
    /// Classes have a unique text identifier. 
    /// Disciplines have a name, number of lessons and number of exercises. 
    /// The task is to shape a school with C# classes. 
    /// You have to define classes with their fields, properties, methods and constructors. 
    /// Also define a test class, which demonstrates, that the other classes work correctly.
    /// </summary>
    public static class Exo22
    {
        public static void Execute()
        {

        }
    }

    /// <summary>
    /// Write a generic class GenericList<T>, which holds a list of elements of type T. 
    /// Store the list of elements into an array with a limited capacity that is passed as a parameter of the constructor of the class. 
    /// Add methods to add an item, to access an item by index, to remove an item by index, to insert an item at given position, to clear the list, to search for an item by value and to override the method ToString().
    /// </summary>
    public static class Exo23
    {
        public static void Execute()
        {

        }
    }

    public class GenericList<T> : IAdd<T>, IRemove<T>, ISearch<T>
    {
        #region Fields & Properties
        private int nextIndex;
        private T[] elements;
        #endregion

        #region Constructors
        public GenericList(int capacity)
        {
            this.nextIndex = 0;
            this.elements = new T[capacity];
        }
        #endregion

        #region Accessors
        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < this.elements.Length)
                {
                    return this.elements[index];
                }
                else
                    throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < this.elements.Length)
                {
                    this.elements[index] = value;
                    if (index == nextIndex)
                        nextIndex = index;
                }
                else
                    throw new IndexOutOfRangeException();
            }
        }
        #endregion

        #region Methods
        public void Add(T item)
        {
            if (nextIndex == this.elements.Length)
            {
                List<T> temp = new List<T>(this.elements.Length * 2);
                for(int i = 0; i < this.elements.Length;i++)
                {
                    temp[i] = this.elements[i];
                }
                this.elements = temp.ToArray();
            }
            this.elements[nextIndex] = item;
            nextIndex++;
        }

        public void Remove(T item)
        {
            int index = this.Find(0, (element) => { return item.Equals(element); });
            if(index >= 0 && index < this.elements.Length)
            {
                this.elements[index] = default(T);
                this.FetchFromIndex(index);
            }
        }

        public void Remove(int index)
        {
            if(index >= 0 && index < this.elements.Length)
            {
                this.elements[index] = default(T);
                this.FetchFromIndex(index);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Clear()
        {
            for(int i = nextIndex - 1; i >= 0;i--)
            {
                this[i] = default(T);
            }
        }

        public int Find(int startIndex, Predicate<T> match)
        {
            int index = startIndex;
            while(index < this.elements.Length)
            {
                if(match(this.elements[index]))
                {
                    return index;
                }
            }
            return -1;
        }

        private void FetchFromIndex(int index)
        {
            while(index < this.elements.Length - 1)
            {
                this.elements[index] = this.elements[index + 1];
                index++;
            }
            this.elements[index] = default(T);
        }

        public override string ToString()
        {
            return base.ToString();
        }
        #endregion
    }

    public interface IAdd<T>
    {
        void Add(T item);
    }

    public interface IRemove<T>
    {
        void Remove(T item);
        void Remove(int index);
        void Clear();
    }

    public interface ISearch<T>
    {
        int Find(int startIndex, Predicate<T> match);
    }

    /// <summary>
    /// Implement auto-resizing functionality of the array from the previous task, when by adding an element, it reaches the capacity of the array.
    /// </summary>
    public static class Exo24
    {
        public static void Execute()
        {

        }
    }

    public class Fraction
    {
        #region Fields & Properties
        private int numerator;
        private int denominator;
        private decimal value;
        public decimal Value { get { return this.value; } }
        #endregion

        #region Constructors
        public Fraction() : this(0, 1)
        {
            
        }
        public Fraction(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
            if (denominator == 0)
                throw new DivideByZeroException();
            else
                this.value = (decimal)numerator / (decimal)denominator;
        }
        #endregion

        #region Static Methods
        public static Fraction Parse(string text)
        {
            string[] line = text.Split(new char[] { '/' },StringSplitOptions.RemoveEmptyEntries);
            int numerator = int.Parse(line[0]);
            int denominator = int.Parse(line[1]);
            return new Fraction(numerator, denominator);
        }
        #endregion

        #region Methods

        public void Cancel()
        {
            int commonDivisor = 1;
            while (commonDivisor > 0)
            {
                commonDivisor = 0;
                List<int> numeratorDivisors = new List<int>();
                List<int> denominatorDivisors = new List<int>();

                for (int i = 2; i < numerator; i++)
                {
                    if ((numerator % i) == 0)
                        numeratorDivisors.Add(i);
                }
                for (int i = 2; i < denominator; i++)
                {
                    if ((denominator % i) == 0)
                        denominatorDivisors.Add(i);
                }

                for (int i = 0; i < numeratorDivisors.Count; i++)
                {
                    for (int j = 0; j < denominatorDivisors.Count; j++)
                    {
                        if (numeratorDivisors[i] < denominatorDivisors[j])
                        {
                            break;
                        }
                        else if (numeratorDivisors[i] == denominatorDivisors[j])
                        {
                            commonDivisor = numeratorDivisors[i];
                            break;
                        }
                    }
                }
                if (commonDivisor != 0)
                {
                    this.numerator /= commonDivisor;
                    this.denominator /= commonDivisor;
                }
            }
        }

        #region Override
        public override string ToString()
        {
            string text = numerator + "/" + denominator + " = " + value;
            return text;
        }
        #endregion
        #endregion
    }

    /// <summary>
    /// Define a class Fraction, which contains information about the rational fraction (e.g. ¼ or ½).
    /// Define a static method Parse() to create a fraction from a sting (for example -3/4). 
    /// Define the appropriate properties and constructors of the class. 
    /// Also write property of type Decimal to return the decimal value of the fraction(e.g. 0.25).
    /// </summary>
    public static class Exo25
    {
        public static void Execute()
        {

        }
    }

    public static class FractionTest
    {
        public static void Execute()
        {
            Fraction testEmpty = new Fraction();
            Fraction test = new Fraction(12, 15);
            test.Cancel();

            Console.WriteLine("Write a fraction : ");
            string text = Console.ReadLine();
            Fraction parse = Fraction.Parse(text);
            parse.Cancel();

            Console.WriteLine(testEmpty.ToString());
            Console.WriteLine(test.ToString());
            Console.WriteLine(parse.ToString());
        }
    }

    /// <summary>
    /// Write a class FractionTest, which tests the functionality of the class Fraction from previous task. 
    /// Pay close attention on testing the function Parse with different input data.
    /// </summary>
    public static class Exo26
    {
        public static void Execute()
        {

        }
    }

    /// <summary>
    /// Write a function to cancel a fraction (e.g. if numerator and denominator are respectively 10 and 15, fraction to be cancelled to 2/3).
    /// </summary>
    public static class Exo27
    {
        public static void Execute()
        {

        }
    }
}
