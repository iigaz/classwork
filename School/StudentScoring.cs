namespace School;

public class StudentScoring<T> where T : IScorable<Student>
{
    public StudentScoring(List<Student> students, T scoringManager, string scoringType)
    {
        ScoringManager = scoringManager;
        Students = students;
        ScoringType = ScoringManager.SelectScoringStrategy(scoringType);
    }

    public T ScoringManager { get; }
    public ScoringType ScoringType { get; }
    public List<Student> Students { get; }

    public void MarkStudentPass(Student student)
    {
        student.Skips.Add(-1);
    }

    public void ScoreAllStudents()
    {
        foreach (var student in Students)
            student.Rating = ScoringManager.Scoring(ScoringType, student);
    }

    public void ScoreStudentsByFilter(Func<List<Student>, List<Student>> filter)
    {
        foreach (var student in filter(Students))
            student.Rating = ScoringManager.Scoring(ScoringType, student);
    }

    public Dictionary<char, List<Student>> GetRatingByAlphabet()
    {
        var result = new Dictionary<char, List<Student>>();
        Students.ForEach(student =>
        {
            if (result.ContainsKey(student.FullName[0]))
                result[student.FullName[0]].Add(student);
            else
                result[student.FullName[0]] = new List<Student> { student };
        });
        return result;
    }

    public void AddAvgMarkStudent(Student student, int mark)
    {
        if (mark is < 2 or > 5)
            throw new ArgumentException("Mark is out of range");
        student.Marks.Add(mark);
    }
}