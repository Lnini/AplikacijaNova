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