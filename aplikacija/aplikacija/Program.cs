using System;
using System.Collections.Generic;


public static class Operation
{
    public static string Enlist = "ENLIST";
    public static string Display = "DISPLAY";
}

public class StudentIdGenerator
{
    public static int idCreate(int Value)
    {
        return Value+1;
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
    public string ValidateString(string Value)
    {
        if (string.IsNullOrEmpty(Value))
        {
            return "null";
        }
        return Value;
    }
    public float ValidateGPA(string StudentGpa)
    {
        float Value;
        if (float.TryParse(StudentGpa, out Value))
        {
            return (float)Value;
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
            List<Student> Students = new List<Student>(2);
            int Temp=0;
            int Value=0;
            do
            {
                Validation v = new Validation();
                Console.WriteLine("Operation:");
                string typedOperation = Console.ReadLine();
                typedOperation = typedOperation.ToUpper();
                bool checkEnlist = typedOperation.Equals(Operation.Enlist);
                bool checkDisplay = typedOperation.Equals(Operation.Display);

                while (checkEnlist == false && checkDisplay == false) 
                {
                    Console.WriteLine("Operation non-existing, please use appropriate operation");
                    Console.WriteLine("Operation:");
                    typedOperation= Console.ReadLine();
                    typedOperation = typedOperation.ToUpper();
                    checkEnlist = typedOperation.Equals(Operation.Enlist);
                    checkDisplay = typedOperation.Equals(Operation.Display);
                } 

                if (string.Equals(typedOperation, Operation.Enlist))
                {
                    Console.WriteLine("Student");

                    Console.WriteLine("First name: ");
                    string FirstName = Console.ReadLine();
                    while (v.ValidateString(FirstName) == "null")
                    {
                        Console.WriteLine("You need to insert Value.");
                        Console.WriteLine("First Name:");
                        FirstName = Console.ReadLine();
                    }

                    Console.WriteLine("Last name: ");
                    string LastName = Console.ReadLine();
                    while (v.ValidateString(LastName) == "null")
                    {
                        Console.WriteLine("You need to insert Value.");
                        Console.WriteLine("Last name:");
                        LastName = Console.ReadLine();
                    }

                    Console.WriteLine("GPA: ");
                    string StudentGpa = Console.ReadLine();
                    while (v.ValidateGPA(StudentGpa) == 0)
                    {
                        Console.WriteLine("You need to insert numerical Value.");
                        Console.WriteLine("GPA: ");
                        StudentGpa = Console.ReadLine();
                    }

                int id = StudentIdGenerator.idCreate(Value);
                Value++;
                Student Student = new Student(id, FirstName, LastName, v.ValidateGPA(StudentGpa));
                Students.Add(Student);
                }
                else if (string.Equals(typedOperation, Operation.Display))
                {
                    int orderValue = 1;
                    Students.Sort(delegate (Student x, Student y)
                    {
                        return x.PersonLastName.CompareTo(y.PersonLastName);
                    });
                    foreach (Student Student in Students)
                    {
                        Console.WriteLine("{0}. {1}, {2} - {3}  ", orderValue++, Student.PersonLastName, Student.PersonFirstName, (float)Student.StudentGPA);
                    }
                    Console.ReadKey();
                    Temp = 1;
                }
            } while (Temp == 0);
        }
 }


