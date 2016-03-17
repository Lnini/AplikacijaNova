public class StudentIdGenerator
{
    private static StudentIdGenerator instance;
    private int id = -1;
    private StudentIdGenerator() { }

    public static int Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new StudentIdGenerator();


            }
            instance.id++;
            return instance.id;

        }
    }
}