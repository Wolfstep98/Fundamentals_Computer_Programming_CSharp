using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_20_OOP_Principles
{
    public class Program
    {
        static void Main(string[] args)
        {

        }
    }

    //Exo 1
    /*
        We are given a school. 
        The school has classes of students. 
        Each class has a set of teachers. 
        Each teacher teaches a set of courses. 
        The students have a name and unique number in the class. 
        Classes have a unique text identifier. 
        Teachers have names. 
        Courses have a name, count of classes and count of exercises. 
        The teachers as well as the students are people.
        - Your task is to model the classes (in terms of OOP) along with their attributes and operations define the class hierarchy and create a class diagram with Visual Studio.
    */

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
