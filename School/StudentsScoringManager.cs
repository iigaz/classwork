namespace School;

public class StudentsScoringManager : IScorable<Student>
{
    // Список студентов переместился в StudentScoring, так как здесь ему не место.
    public int Scoring(ScoringType scoringType, Student subject)
    {
        return scoringType switch
        {
            ScoringType.Coefficient => (int)((1.0 + subject.Marks.Sum(mark => mark switch
            {
                5 => 0.02,
                4 => 0.01,
                3 => -0.01,
                2 => -0.02,
                _ => 0
            }) - 0.1 * subject.Skips.Count) * 100),
            ScoringType.Percent => (int)(subject.Marks.Average() * 100) / 5 -
                                   subject.Skips.Count * 100 / subject.Marks.Count,
            ScoringType.Sum => subject.Marks.Sum() / (subject.Marks.Count + subject.Skips.Count),
            _ => throw new ArgumentOutOfRangeException(nameof(scoringType), scoringType, null)
        };
    }

    public ScoringType SelectScoringStrategy(string type)
    {
        return type switch
        {
            "%" => ScoringType.Percent,
            "k" => ScoringType.Coefficient,
            _ => ScoringType.Sum
        };
    }
}