namespace School;

public class Student
{
    public string FullName { get; set; }
    public List<int> Marks { get; } = new();
    public List<int> Skips { get; } = new();
    public double Rating { get; set; }
}