namespace School;

public interface IScorable<in T> where T : class
{
    int Scoring(ScoringType scoringType, T subject);
    ScoringType SelectScoringStrategy(string type);
}