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