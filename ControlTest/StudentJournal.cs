namespace ControlTest;

public class StudentJournal : IJournalManager<StudentJournalData>
{
    public delegate List<StudentJournalData>? LoadHandler(string path);

    private readonly List<StudentJournalData> _studentJournal = new();

    public void AddJournalItem(StudentJournalData item)
    {
        _studentJournal.Add(item);
    }

    public bool ChangeItem(Guid guid, StudentJournalData item)
    {
        var index = _studentJournal.FindIndex(item => item.Id == guid);
        if (index <= -1) return false;
        _studentJournal.RemoveAt(index);
        _studentJournal.Insert(index, item);
        return true;
    }

    public List<StudentJournalData> GetAllJournalItemsByFilter(Predicate<StudentJournalData> filter)
    {
        return _studentJournal.Where(student => filter(student)).ToList();
    }

    public StudentJournalData? GetItemById(Guid guid)
    {
        return _studentJournal.Find(student => student.Id == guid);
    }

    public List<StudentJournalData> GetJournalItemsByName(string name)
    {
        return _studentJournal.Where(student => student.StudentName == name).ToList();
    }

    public void LoadJournalData(string path)
    {
        var temp = OnLoad?.Invoke(path);
        if (temp == null) return;
        _studentJournal.Clear();
        _studentJournal.AddRange(temp);
    }

    public event LoadHandler? OnLoad;
}