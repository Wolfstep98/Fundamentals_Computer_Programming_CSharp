using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chapter_20_OOP_Principles.Geometry;
using Chapter_20_OOP_Principles.Animals;

namespace Chapter_20_OOP_Principles
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Exo234.Execute();
            //Exo5.Execute();
            Exo6.Execute();
        }
    }

    //Exo 1
    /*
        We are given a school. OK
        The school has classes of students. OK
        Each class has a set of teachers. OK
        Each teacher teaches a set of courses. OK
        The students have a name and unique number in the class. OK
        Classes have a unique text identifier. OK
        Teachers have names. OK
        Courses have a name, count of classes and count of exercises. OK
        The teachers as well as the students are people. OK
        Your task is to model the classes (in terms of OOP) along with their attributes and operations define the class hierarchy and create a class diagram with Visual Studio. OK
    */
    namespace Education
    {
        public class School
        {
            #region Fields
            private Class[] m_Classes;
            #endregion

            #region Constructors

            #endregion
        }

        public class Class
        {
            #region Fields
            private string m_Name;
            private Student[] m_Students;
            private Teacher[] m_Teachers;
            #endregion

            #region Constructors

            #endregion
        }

        public class Course
        {
            #region Fields
            private string m_Name;
            private int m_CountOfClasses;
            private int m_CountOfExercices;
            #endregion

            #region Constructors

            #endregion
        }

        public class Student : People
        {
            #region Fields
            private int m_ID;
            #endregion

            #region Constructors
            public Student() { }
            public Student(int id)
            {
                this.m_ID = id;
            }
            #endregion
        }

        public class Teacher : People
        {
            #region Fields
            private Course[] m_Courses;
            #endregion

            #region Constructors
            public Teacher() : this("Noname") { }
            public Teacher(string name) : this(name, null) { }
            public Teacher(Course[] courses) : this("Noname", courses) { }
            public Teacher(string name, Course[] courses) : base(name)
            {
                this.m_Courses = courses;
            }
            #endregion
        }

        public class People
        {
            #region Fields
            protected string m_Name;
            #endregion

            #region Constructors
            public People() : this("Noname") { }
            public People(string name)
            {
                this.m_Name = name;
            }
            #endregion
        }
    }

    // Exo 2
    /*
        Define a class Human with properties "first name" and "last name". OK
        Define the class Student inheriting Human , which has the property "mark". OK
        Define the class Worker inheriting Human with the property "wage" and "hours worked". OK
        Implement a "calculate hourly wage" method, which calculates a worker’s hourly pay rate based on wage and hours worked. 
        Write the corresponding constructors and encapsulate all data in properties.
    */

    namespace PayingEducation
    {
        public class Human
        {
            #region Fields
            protected string m_FirstName = "";
            protected string m_LastName = "";
            #endregion

            #region Constructors
            public Human(string firstName, string lastName)
            {
                this.m_FirstName = firstName;
                this.m_LastName = lastName;
            }
            #endregion
        }

        public class Student : Human, IComparable<Student>
        {
            #region Fields
            protected int mark = 0;
            #endregion

            #region Constructors
            public Student(string firstName, string lastName, int mark) : base(firstName, lastName)
            {
                this.mark = mark;
            }
            #endregion

            #region Methods
            public int CompareTo(Student other)
            {
                if (this.mark < other.mark)
                    return -1;
                else if (this.mark > other.mark)
                    return 1;
                else
                    return 0;
            }

            public override string ToString()
            {
                return "Student : " + this.m_FirstName + " " + this.m_LastName + " with mark : " + this.mark.ToString();
            }
            #endregion
        }

        public class Worker : Human, IComparable<Worker>
        {
            #region Fields
            protected decimal wage = 0;
            protected int hoursWorked = 0;
            #endregion

            #region Constructors
            public Worker(string firstName, string lastName, decimal wage, int hoursWorked) : base(firstName, lastName)
            {
                this.wage = wage;
                this.hoursWorked = hoursWorked;
            }
            #endregion

            #region Methods
            public decimal CalculateHourlyWage()
            {
                return this.wage / hoursWorked;
            }

            public int CompareTo(Worker other)
            {
                decimal hourlyWage = this.CalculateHourlyWage();
                decimal otherHourlyWage = other.CalculateHourlyWage();
                return decimal.Compare(hourlyWage, otherHourlyWage);
            }

            public override string ToString()
            {
                return "Worker : " + this.m_FirstName + " " + this.m_LastName + " with hourly wage : " + this.CalculateHourlyWage().ToString();
            }
            #endregion
        }
    }

    // Exo3
    // Initialize an array of 10 students and sort them by mark in ascending order.
    // Use the interface System.IComparable<T>.
    // Exo4
    // Initialize an array of 10 workers and sort them by salary in descending order.
    public static class Exo234
    {
        private static readonly string[] StudentsFirstNames = new string[10] { "Wilhelm", "Benji", "Benjo", "Kazzoie", "Smash", "Bros", "Lol", "Bowser", "Regis", "Luigi" };
        private static readonly string[] StudentsLastNames = new string[10] { "Machin", "Bidule", "Truc", "Avion", "Voiture", "Moto", "Oisal", "Monstre", "Nom", "Farod" };

        public static void Execute()
        {
            // Students
            Random random = new Random();
            PayingEducation.Student[] students = new PayingEducation.Student[10];
            Console.WriteLine("Students :");
            for(int i = 0; i < students.Length; i++)
            {
                students[i] = new PayingEducation.Student(StudentsFirstNames[i], StudentsLastNames[i], random.Next(0, 100000));
                Console.WriteLine(students[i].ToString());
            }
            Array.Sort(students);

            Console.WriteLine();

            Console.WriteLine("Students sorted :");
            foreach(PayingEducation.Student student in students)
            {
                Console.WriteLine(student.ToString());
            }

            Console.WriteLine();

            // Workers
            PayingEducation.Worker[] workers = new PayingEducation.Worker[10];
            Console.WriteLine("Workers :");
            for (int i = 0; i < workers.Length; i++)
            {
                workers[i] = new PayingEducation.Worker(StudentsFirstNames[i], StudentsLastNames[i], random.Next(1000, 10000), random.Next(0,150));
                Console.WriteLine(workers[i].ToString());
            }
            Array.Sort(workers);

            Console.WriteLine();

            Console.WriteLine("Workers sorted :");
            foreach (PayingEducation.Worker worker in workers)
            {
                Console.WriteLine(worker.ToString());
            }
        }
    }

    namespace Geometry
    {
        public abstract class Shape
        {
            #region Fields
            protected float width = 0;
            protected float height = 0;
            #endregion

            #region Constructors
            public Shape(float width, float height)
            {
                this.width = width;
                this.height = height;
            }
            #endregion

            #region Methods
            public abstract float CalculateSurface();

            public override string ToString()
            {
                return "Shape : Width(" + this.width + ") & Height(" + this.height + ")";
            }
            #endregion
        }

        public class Triangle : Shape
        {
            #region Constructors
            public Triangle(float width, float height) : base(width, height)
            {

            }
            #endregion

            #region Methods
            public override float CalculateSurface()
            {
                float surface = (this.width * this.height) / 2.0f;
                return surface;
            }

            public override string ToString()
            {
                return base.ToString() + " is a Triangle with an area of " + this.CalculateSurface();
            }
            #endregion
        }

        public class Rectangle : Shape
        {
            #region Constructors
            public Rectangle(float width, float height) : base(width, height)
            {

            }
            #endregion

            #region Methods
            public override float CalculateSurface()
            {
                float surface = this.width * this.height;
                return surface;
            }

            public override string ToString()
            {
                return base.ToString() + " is a Rectangle with an area of " + this.CalculateSurface();
            }
            #endregion
        }

        public class Circle : Shape
        {
            #region Fields
            protected float radius = 0;
            #endregion

            #region Constructors
            public Circle(float radius) : base(radius, radius)
            {
                this.radius = radius;
            }
            #endregion

            #region Methods
            public override float CalculateSurface()
            {
                float surface = (float)Math.PI * this.radius * this.radius;
                return surface;
            }

            public override string ToString()
            {
                return "Shape : Radius(" + this.radius + ")" + " is a Circle with an area of " + this.CalculateSurface();
            }
            #endregion
        }
    }

    // Exo 5
    /// <summary>
    /// Define an abstract class Shape with abstract method CalculateSurface() and fields width and height.
    /// Define two additional classes for a triangle and a rectangle, which implement CalculateSurface().
    /// This method has to return the areas of the rectangle(height* width) and the triangle (height* width/2 ). 
    /// Define a class for a circle with an appropriate constructor, which initializes the two fields(height and width ) with the same value(the radius) and implement the abstract method for calculating the area.
    /// Create an array of different shapes and calculate the area of each shape in another array.
    /// </summary>
    public static class Exo5
    {
        public static void Execute()
        {
            Random random = new Random();
            int length = random.Next(10, 100);
            Shape[] shapes = new Shape[length];
            float[] areas = new float[length];

            for(int i = 0; i < shapes.Length; i++)
            {
                int shapeNumber = random.Next(0, 3);
                switch(shapeNumber)
                {
                    case 0:
                        shapes[i] = new Triangle((float)random.NextDouble() * (100.0f - 1.0f) + 1.0f, (float)random.NextDouble() * (100.0f - 1.0f) + 1.0f);
                        break;
                    case 1:
                        shapes[i] = new Rectangle((float)random.NextDouble() * (100.0f - 1.0f) + 1.0f, (float)random.NextDouble() * (100.0f - 1.0f) + 1.0f);
                        break;
                    case 2:
                        shapes[i] = new Circle((float)random.NextDouble() * (100.0f - 1.0f) + 1.0f);
                        break;
                    default:
                        shapes[i] = new Triangle((float)random.NextDouble() * (100.0f - 1.0f) + 1.0f, (float)random.NextDouble() * (100.0f - 1.0f) + 1.0f);
                        break;
                }
            }

            for(int i = 0; i < shapes.Length && i < areas.Length; i++)
            {
                areas[i] = shapes[i].CalculateSurface();
            }

            Console.WriteLine("Shapes with areas : ");
            Console.WriteLine();
            for (int i = 0; i < shapes.Length && i < areas.Length; i++)
            {
                Console.WriteLine(shapes[i].ToString() + " : " + areas[i].ToString());
            }
        }
    }

    // Exo 6
    /// <summary>
    /// Implement the following classes: Dog , Frog , Cat , Kitten and Tomcat . 
    /// All of them are animals(Animal). Animals are characterized by age , name and gender.
    /// Each animal makes a sound(use a virtual method in the Animal class). 
    /// Create an array of different animals and print on the console their name, age and the corresponding sound each one makes.
    /// </summary>
    public static class Exo6
    {
        public static void Execute()
        {
            Animal[] animals = new Animal[5];
            animals[0] = new Dog(true, 10, "Doggo");
            animals[1] = new Frog(false, 2, "Froggo");
            animals[2] = new Cat(true, 1, "Catouuuu");
            animals[3] = new Kitten(false, 5, "Kitty");
            animals[4] = new Tomcat(true, 11, "Rambo");

            foreach(Animal animal in animals)
            {
                Console.WriteLine(animal.ToString() + " " + animal.Sound());
            }
        }
    }

    namespace Animals
    {
        public abstract class Animal
        {
            #region Fields
            protected bool isMale = false;
            protected int age = 0;
            protected string name = "noname";
            #endregion

            #region Contructors
            public Animal(bool isMale, int age, string name)
            {
                this.isMale = isMale;
                this.age = age;
                this.name = name;
            }
            #endregion

            #region Methods
            public abstract string Sound();
            #endregion
        }

        public class Dog : Animal
        {
            #region Constructors
            public Dog(bool isMale, int age, string name) : base(isMale, age, name)
            {

            }
            #endregion

            #region Methods
            public override string Sound()
            {
                return "WOOF";
            }

            public override string ToString()
            {
                return this.name + " is a dog and is " + this.age.ToString() + " years old and is a " + ((this.isMale) ? "male" : "female") + ".";
            }
            #endregion
        }

        public class Frog : Animal
        {
            #region Constructors
            public Frog(bool isMale, int age, string name) : base(isMale, age, name)
            {

            }
            #endregion

            #region Methods
            public override string Sound()
            {
                return "CROAAAK";
            }

            public override string ToString()
            {
                return this.name + " is a frog and is " + this.age.ToString() + " years old and is a " + ((this.isMale) ? "male" : "female") + ".";
            }
            #endregion
        }

        public class Cat : Animal
        {
            #region Constructors
            public Cat(bool isMale, int age, string name) : base(isMale, age, name)
            {

            }
            #endregion

            #region Methods
            public override string Sound()
            {
                return "MEOW";
            }

            public override string ToString()
            {
                return this.name + " is a cat and is " + this.age.ToString() + " years old and is a " + ((this.isMale) ? "male" : "female") + ".";
            }
            #endregion
        }

        public class Kitten : Animal
        {
            #region Constructors
            public Kitten(bool isMale, int age, string name) : base(isMale, age, name)
            {

            }
            #endregion

            #region Methods
            public override string Sound()
            {
                return "Meooowwww";
            }

            public override string ToString()
            {
                return this.name + " is a kitten and is " + this.age.ToString() + " years old and is a " + ((this.isMale) ? "male" : "female") + ".";
            }
            #endregion
        }

        public class Tomcat : Animal
        {
            #region Constructors
            public Tomcat(bool isMale, int age, string name) : base(isMale, age, name)
            {

            }
            #endregion

            #region Methods
            public override string Sound()
            {
                return "MRRWWAAOOWWW";
            }

            public override string ToString()
            {
                return this.name + " is a tomcat and is " + this.age.ToString() + " years old and is a " + ((this.isMale) ? "male" : "female") + ".";
            }
            #endregion
        }
    }

    // Exo 8
    /// A bank holds different types of accounts for its customers: deposit accounts, loan accounts and mortgage accounts. OK
    /// In the general case, there interest is calculated as follows: number_of_months* interest_rate.
    /// Your task is to write an object-oriented model of the bank system. 
    /// You must identify the classes, interfaces, base classes and abstract actions and implement the interest calculation functionality.
    public static class Exo8
    {
        public static void Execute()
        {
            // Faire Test Unitaire !!!
        }
    }

    namespace Arnaqueurs
    {
        public class Bank
        {
            #region Fields
            protected Dictionary<Customer, Account> customersAccounts = null;
            #endregion

            #region Constructors
            public Bank(Dictionary<Customer, Account> customersAccounts)
            {
                this.customersAccounts = customersAccounts;
            }
            #endregion

            #region Accessors
            public IAccount this[Customer customer]
            {
                get
                {
                    if(!this.customersAccounts.ContainsKey(customer))
                        return null;
                    return this.customersAccounts[customer];
                }
            }
            #endregion

            #region Properties
            public void AddCustomer(Customer customer, Account account = null)
            {
                if (this.customersAccounts.ContainsKey(customer))
                    throw new ArgumentException("The customer you provided already exists in the bank.");

                this.customersAccounts.Add(customer, account);
            }
            public void RemoveCustomer(Customer customer)
            {
                if (!this.customersAccounts.ContainsKey(customer))
                    throw new ArgumentException("The customer you provided doesn't exists in the bank.");
                this.customersAccounts.Remove(customer);
            }

            public void ChangeAccount(Customer customer, Account newAccount)
            {
                if(!this.customersAccounts.ContainsKey(customer))
                    throw new ArgumentException("The customer you provided doesn't exists in the bank.");
                if(this.customersAccounts[customer] != null)
                {
                    newAccount.CopyAccount(this.customersAccounts[customer]);
                }

                this.customersAccounts[customer] = newAccount;
            }
            #endregion
        }

        #region Accounts
        /// <summary>
        /// Define the account type.
        /// </summary>
        public enum AccountType
        {
            Deposit,
            Loan,
            Mortgage,
            None
        }

        public interface IAccount
        {
            AccountType AccountType { get; }

            void Deposit(decimal amount);
            decimal Withdraw();
            decimal Withdraw(decimal amount);
            decimal CalculateInterest(DateTime dateTime);
        }

        /// <summary>
        /// Base class for all accounts.
        /// Define basics actions for all accounts : deposit, withdraw.
        /// All accounts have a customer, balance and interest rate (monthly based).
        /// All accounts can calculate their interest for a given period (in months).
        /// </summary>
        public abstract class Account : IAccount
        {
            #region Fields
            protected Customer customer = null;
            protected decimal balance = 0.0m;
            protected decimal interestRate = 0.0m;
            protected DateTime openingDate;
            protected AccountType accountType = AccountType.None;
            #endregion

            #region Constructors
            public Account(Customer customer, decimal balance, decimal interestRate, DateTime openingDate)
            {
                this.customer = customer;
                this.balance = balance;
                this.interestRate = interestRate;
                this.openingDate = openingDate;
            }
            #endregion

            #region Properties
            public AccountType AccountType { get { return this.accountType; } }
            #endregion

            #region Methods
            public abstract void Deposit(decimal amount);
            public abstract decimal Withdraw();
            public abstract decimal Withdraw(decimal amount);
            public virtual decimal CalculateInterest(DateTime dateTime)
            {
                if (dateTime < this.openingDate)
                    throw new ArgumentOutOfRangeException("You can't compute interest from a date which is before the opening date.");

                decimal interest = 0.0m;
                DateTime temp = this.openingDate;
                while(temp.Year != dateTime.Year && temp.Month != dateTime.Month)
                {
                    interest += this.interestRate;
                    temp.AddMonths(1);
                }
                return interest;
            }
            public virtual void CopyAccount(Account account)
            {
                this.balance += account.balance;
            }
            #endregion
        }

        /// <summary>
        /// Deposit accounts allow depositing and withdrawing.
        /// Deposit accounts have no interest rate if their balance is positive and less than 1000. 
        /// </summary>
        public class DepositAccount : Account
        {
            #region Constructors
            public DepositAccount(Customer customer, decimal balance, decimal interestRate, DateTime openingDate) : base(customer, balance, interestRate, openingDate)
            {
                this.accountType = AccountType.Deposit;
            }
            #endregion

            #region Methods            
            public override void Deposit(decimal amount)
            {
                if (amount < 0.0m)
                    throw new ArgumentOutOfRangeException("You can't add negative sum to the balance : " + amount);

                this.balance += amount;
            }

            public override decimal Withdraw(decimal amount)
            {
                if (amount < 0.0m)
                    throw new ArgumentOutOfRangeException("You can't add negative sum to the balance : " + amount);
                this.balance -= amount;
                return amount;
            }

            public override decimal CalculateInterest(DateTime dateTime)
            {
                if (dateTime < this.openingDate)
                    throw new ArgumentOutOfRangeException("You can't compute interest from a date which is before the opening date.");

                if (this.balance >= 0.0m && this.balance <= 1000.0m)
                    return 0.0m;
                else
                    return base.CalculateInterest(dateTime);
            }

            public override decimal Withdraw()
            {
                return this.balance;
            }
            #endregion
        }

        /// <summary>
        /// Loan accounts allow only depositing.
        /// Loan accounts have no interest rate during the first 3 months if held by individuals and during the first 2 months if held by a company.
        /// </summary>
        public class LoanAccount : Account
        {
            #region Constructors
            public LoanAccount(Customer customer, decimal balance, decimal interestRate, DateTime openingDate) : base(customer, balance, interestRate, openingDate)
            {
                this.accountType = AccountType.Loan;
            }
            #endregion

            #region Methods           
            public override void Deposit(decimal amount)
            {
                if (amount < 0.0m)
                    throw new ArgumentOutOfRangeException("You can't add negative sum to the balance : " + amount);

                this.balance += amount;
            }

            public override decimal Withdraw(decimal amount)
            {
                throw new MethodAccessException("You can't withdraw money from a Loan account.");
            }

            public override decimal CalculateInterest(DateTime dateTime)
            {
                if (dateTime < this.openingDate)
                    throw new ArgumentOutOfRangeException("You can't compute interest from a date which is before the opening date.");

                if (dateTime.Year == this.openingDate.Year)
                {
                    if (dateTime.Month - openingDate.Month <= 2)
                        return 0.0m;
                    else if (dateTime.Month - openingDate.Month <= 3 && this.customer.IsIndividual)
                        return 0.0m;
                }
                else if (dateTime.Year - this.openingDate.Year == 1)
                {
                    if(this.openingDate.Month + 2 % 12 - dateTime.Month <= 0)
                        return 0.0m;
                    else if (this.openingDate.Month + 2 % 12 - dateTime.Month <= 0 && this.customer.IsIndividual)
                        return 0.0m;
                }

                decimal interestSubstracted = this.interestRate * ((this.customer.IsIndividual) ? 2 : 3);

                // Calculate interest
                decimal interest = base.CalculateInterest(dateTime);
                return interest - interestSubstracted;
            }

            public override decimal Withdraw()
            {
                return this.balance;
            }
            #endregion
        }

        /// <summary>
        /// Mortgage accounts allow only depositing.
        /// Mortgage accounts have ½ the interest rate during the first 12 months for companies and no interest rate during the first 6 months for individuals.
        /// </summary>
        public class MortgageAccount : Account
        {
            #region Constructors
            public MortgageAccount(Customer customer, decimal balance, decimal interestRate, DateTime openingDate) : base(customer, balance, interestRate, openingDate)
            {
                this.accountType = AccountType.Mortgage;
            }
            #endregion

            #region Methods
            public override void Deposit(decimal amount)
            {
                if (amount < 0.0m)
                    throw new ArgumentOutOfRangeException("You can't add negative sum to the balance : " + amount);

                this.balance += amount;
            }

            public override decimal Withdraw(decimal amount)
            {
                throw new MethodAccessException("You can't withdraw money from a Mortgage account.");
            }

            public override decimal CalculateInterest(DateTime dateTime)
            {
                if (dateTime < this.openingDate)
                    throw new ArgumentOutOfRangeException("You can't compute interest from a date which is before the opening date.");

                if (dateTime.Year == this.openingDate.Year)
                {
                    if (dateTime.Month - openingDate.Month <= 6 && this.customer.IsIndividual)
                        return 0.0m;
                }
                else if (dateTime.Year - this.openingDate.Year == 1)
                {
                    if (this.openingDate.Month + 6 % 12 - dateTime.Month <= 0)
                        return 0.0m;
                    else if (this.openingDate.Month - dateTime.Month <= 0 && !this.customer.IsIndividual)
                        return base.CalculateInterest(dateTime) / 2.0m;
                }

                decimal interestSubstracted = this.interestRate * 6.0m;

                // Calculate interest
                decimal interest = base.CalculateInterest(dateTime);
                return interest - interestSubstracted;
            }

            public override decimal Withdraw()
            {
                return this.balance;
            }
            #endregion
        }

        // Abstract Factory for Exo 9
        public abstract class AbstractAccountFactory
        {
            public abstract Account CreateAccount(AccountType accountType, Customer customer, decimal balance, decimal interestRate, DateTime openingTime);
        }

        public class AccountFactory : AbstractAccountFactory
        {
            public override Account CreateAccount(AccountType accountType, Customer customer, decimal balance, decimal interestRate, DateTime openingTime)
            {
                Account account = null;
                switch(accountType)
                {
                    case AccountType.Deposit:
                        account = new DepositAccount(customer, balance, interestRate, openingTime);
                        break;
                    case AccountType.Loan:
                        account = new LoanAccount(customer, balance, interestRate, openingTime);
                        break;
                    case AccountType.Mortgage:
                        account = new MortgageAccount(customer, balance, interestRate, openingTime);
                        break;
                    default:
                        throw new ArgumentException("Your account type is not valid !");
                }
                return account;
            }
        }
        #endregion

        /// <summary>
        /// Basic class for costumers.
        /// Customers can be individuals or companies.
        /// </summary>
        public class Customer
        {
            #region Fields
            protected bool isIndividual = false;
            #endregion

            #region Constructors
            public Customer(bool isIndividual)
            {
                this.isIndividual = isIndividual;
            }
            #endregion

            #region Properties
            public bool IsIndividual { get { return this.isIndividual; } }
            #endregion
        }
    }
}
