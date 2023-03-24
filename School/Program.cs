// Это худшее ТЗ, которое мне приходилось читать (и делать).

using School;

List<Student> GetStudents(List<Student> students)
{
    return students.FindAll(student => student.FullName.Length < 15);
}

var studentScoring = new StudentScoring<StudentsScoringManager>(new List<Student>
{
    new() { FullName = "Пупкин Василий" },
    new() { FullName = "Иванов Иван" },
    new() { FullName = "Абрамский Максим" },
    new() { FullName = "Коноплев Георгий" }
}, new StudentsScoringManager(), "+-");

var students = studentScoring.GetRatingByAlphabet();

studentScoring.AddAvgMarkStudent(students['А'][0], 5);
studentScoring.AddAvgMarkStudent(students['А'][0], 5);

studentScoring.AddAvgMarkStudent(students['П'][0], 4);
studentScoring.AddAvgMarkStudent(students['П'][0], 5);
studentScoring.MarkStudentPass(students['П'][0]);

studentScoring.AddAvgMarkStudent(students['И'][0], 5);
studentScoring.AddAvgMarkStudent(students['И'][0], 2);

studentScoring.MarkStudentPass(students['К'][0]);
studentScoring.MarkStudentPass(students['К'][0]);
studentScoring.MarkStudentPass(students['К'][0]);

studentScoring.ScoreStudentsByFilter(list => list.FindAll(student => student.Skips.Count == 0));
studentScoring.ScoreStudentsByFilter(GetStudents);

foreach (var student in studentScoring.Students)
{
    Console.WriteLine($"ФИО: {student.FullName}");
    Console.WriteLine($"Оценки: {string.Join(' ', student.Marks)}");
    Console.WriteLine($"Пропусков: {student.Skips.Count}");
    Console.WriteLine($"Рейтинг (после скоринга): {student.Rating}");
    Console.WriteLine();
}