using System;
using System.Collections.Generic;
using System.Text;


public static class Operation
{
    public static string Enlist = "ENLIST";
    public static string Display = "DISPLAY";
}

public class StudentIdGenerator
{
    public static int IdCreate(int value)
    {
        return value+1;
    }
}

public abstract class Person
{
    public int PersonId { get; set; }
    public string PersonFirstName { get; set; }
    public string PersonLastName { get; set; }
}

public class Student : Person
{
    public float StudentGPA { get; set; }

    public Student(int Id, string FirstName, string LastName, float GPA)
    {
        PersonFirstName = FirstName;
        PersonLastName = LastName;
        StudentGPA = GPA;
        PersonId = Id;
    }
}

public class Validation
{
    public string ValidateString(string value)
    {

        if (string.IsNullOrEmpty(value))
        {
            return "null";
        }
        return value;

    }
    public float ValidateGPA(string gpa)
    {
        float value;
        if (float.TryParse(gpa, out value))
        {
            return (float)value;
        }
        else 
        {
            return 0;
        }
     }
}


public class Program
    {
        static void Main()
        {
            List<Student> students = new List<Student>(2);
            int temp=0;
            int value=0;
            do
            {
                Validation v = new Validation();
                Console.WriteLine("Operation:");
                string op = Console.ReadLine();
                op = op.ToUpper();
                bool check_enlist = op.Equals(Operation.Enlist);
                bool check_display = op.Equals(Operation.Display);

                while (check_enlist == false && check_display == false) 
                {
                    Console.WriteLine("Operation non-existing, please use appropriate operation");
                    Console.WriteLine("Operation:");
                    op = Console.ReadLine();
                    op = op.ToUpper();
                    check_enlist = op.Equals(Operation.Enlist);
                    check_display = op.Equals(Operation.Display);
                } 

                if (string.Equals(op, Operation.Enlist))
                {
                    Console.WriteLine("Student");

                    Console.WriteLine("First name: ");
                    string FirstName = Console.ReadLine();
                    while (v.ValidateString(FirstName) == "null")
                    {
                        Console.WriteLine("You need to insert value.");
                        Console.WriteLine("First Name:");
                        FirstName = Console.ReadLine();
                    }

                    Console.WriteLine("Last name: ");
                    string LastName = Console.ReadLine();
                    while (v.ValidateString(LastName) == "null")
                    {
                        Console.WriteLine("You need to insert value.");
                        Console.WriteLine("Last name:");
                        LastName = Console.ReadLine();
                    }

                    Console.WriteLine("GPA: ");
                    string gpa = Console.ReadLine();
                    while (v.ValidateGPA(gpa) == 0)
                    {
                        Console.WriteLine("You need to insert numerical value.");
                        Console.WriteLine("GPA: ");
                        gpa = Console.ReadLine();
                    }

                int id = StudentIdGenerator.IdCreate(value);
                value++;
                Console.WriteLine(value);
                Console.WriteLine(id);


                    Student Student = new Student(id, FirstName, LastName, v.ValidateGPA(gpa));
                    students.Add(Student);
                }
                else if (string.Equals(op, Operation.Display))
                {
                    int a = 1;
                    students.Sort(delegate (Student x, Student y)
                    {
                        return x.PersonLastName.CompareTo(y.PersonLastName);
                    });
                    foreach (Student s in students)
                    {

                        Console.WriteLine("{0}. {1}, {2} - {3}   {4}", a++, s.PersonLastName, s.PersonFirstName, (float)s.StudentGPA,s.PersonId);
                    }


                    Console.ReadKey();
                    temp = 1;
                }
            } while (temp == 0);
        }
 }


