using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace ControlTest;

public class Teacher
{
    public readonly StudentJournal StudentJournal = new();

    public Teacher()
    {
        StudentJournal.OnLoad += LoadData;
    }

    private List<StudentJournalData>? LoadData(string path)
    {
        using var reader = new StreamReader(path);
        using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ";" });
        var records = csv.GetRecords<StudentJournalData>().ToList();
        return records;
    }
}