namespace ControlTest;

public interface IJournalManager<T>
{
    void AddJournalItem(T item);
    bool ChangeItem(Guid guid, T item);
    List<T> GetAllJournalItemsByFilter(Predicate<T> filter);
    T? GetItemById(Guid guid);
    List<T> GetJournalItemsByName(string name);
    void LoadJournalData(string path);
}