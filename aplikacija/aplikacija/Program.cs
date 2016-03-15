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
    public static string IdCreate()
    {
        string s = "abcdefghijklmnopqrstuvwxyz0123456789";
        StringBuilder builder = new StringBuilder();
        Random random = new Random();
        for (int i = 0; i < 4; i++)
        {
            int index = random.Next(1, 36);
            builder.Append(s[index]);
        }
        return builder.ToString();
    }
}

public abstract class Person
{
    public string Id { get; set; }
}

public class Student : Person
{
    public string _FirstName { get; set; }
    public string _LastName { get; set; }
    public float _GPA { get; set; }

    public Student(string _Id, string FirstName, string LastName, float GPA)
    {
        _FirstName = FirstName;
        _LastName = LastName;
        _GPA = GPA;
        _Id = Id;
    }
}

public class Validation
{
    public string Val_String(string val1)
    {

        if (string.IsNullOrEmpty(val1))
        {
            Console.WriteLine("You need to insert value.");
            return "null";
        }
        return val1;

    }
    public float Val_GPA_Type(string gp)
    {
        float f_value;

        if (float.TryParse(gp, out f_value))
        {
            return (float)f_value;
        }
        else
        {
            if (!float.TryParse(gp, out f_value))
            {
                Console.WriteLine("You need to insert numerical value.");
                return 0;
            }
            else
            {
                return (float)f_value;
            }
        }

    }

    public class Program
    {
        static void Main()
        {
            List<Student> students = new List<Student>(2);

        start:
            Validation v = new Validation();
            Console.WriteLine("Operation:");
            string op = Console.ReadLine();

            op = op.ToUpper();

            if (string.Equals(op, Operation.Enlist))
            {
                Console.WriteLine("Student");


            fn_goto:

                Console.WriteLine("First name: ");
                string fn = Console.ReadLine();
                if (v.Val_String(fn) == "null")
                {
                    goto fn_goto;
                }


            ln_goto:

                Console.WriteLine("Last name: ");
                string ln = Console.ReadLine();
                if (v.Val_String(ln) == "null")
                {
                    goto ln_goto;
                }

            gpa_goto:
                Console.WriteLine("GPA: ");
                string gpa = Console.ReadLine();
                if (v.Val_GPA_Type(gpa) == 0)
                {
                    goto gpa_goto;
                }

                string id = StudentIdGenerator.IdCreate();

                Student s = new Student(id, fn, ln, v.Val_GPA_Type(gpa));

                students.Add(s);
                goto start;
            }
            else if (string.Equals(op, Operation.Display))
            {
                int a = 1;
                students.Sort(delegate (Student x, Student y)
                {
                    return x._LastName.CompareTo(y._LastName);
                });
                foreach (Student s in students)
                {

                    Console.WriteLine("{0}. {1}, {2} - {3}", a++, s._LastName, s._FirstName, (float)s._GPA);

                }

                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Operation non-existing, please use appropriate operation");
                goto start;
            }
        }
    }
}


