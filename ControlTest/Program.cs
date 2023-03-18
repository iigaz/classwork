// See https://aka.ms/new-console-template for more information

using ControlTest;

var teacher = new Teacher();
teacher.StudentJournal.LoadJournalData("Test.csv");
Console.WriteLine(teacher.StudentJournal.GetJournalItemsByName("Kislov")[0].StudentName);