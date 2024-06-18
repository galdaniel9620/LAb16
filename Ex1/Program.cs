using Ex1.Models;

//Seed();

using var dbContext = new StudentDbContext();
dbContext.SaveChanges();

var showAllStudents = dbContext.Students.OrderBy(x => x.FirstName ).ThenBy(x => x.LastName).ToList();
if (showAllStudents.Any())
{
    showAllStudents.ForEach(x => Console.WriteLine($"{x.FirstName} {x.LastName}"));
}

Console.WriteLine();
var youngStudent = dbContext.Students.Where(x => x.Department == Department.Constructions && x.Age > 20).FirstOrDefault();
if (youngStudent != null) Console.WriteLine($"{youngStudent.FirstName} {youngStudent.LastName} {youngStudent.Age}");



static void Seed()
{
    var dbContext = new StudentDbContext();

    dbContext.Add(new Student() { FirstName = "Saarah", LastName = "Stevenson", Age = 22, Department = Department.Letters });
    dbContext.Add(new Student() { FirstName = "Maja", LastName = "Williamson", Age = 18, Department = Department.Letters });
    dbContext.Add(new Student() { FirstName = "Velma", LastName = "French", Age = 17, Department = Department.It });
    dbContext.Add(new Student() { FirstName = "Yousuf", LastName = "Lovet", Age = 24, Department = Department.Constructions });
    dbContext.Add(new Student() { FirstName = "Yousuf", LastName = "Jede", Age = 24, Department = Department.Constructions });
    dbContext.Add(new Student() { FirstName = "Lottie", LastName = "Woodward", Age = 32, Department = Department.Constructions });
    dbContext.Add(new Student() { FirstName = "Delores", LastName = "Lin", Age = 28, Department = Department.Letters });
    dbContext.Add(new Student() { FirstName = "Derek", LastName = "Ferguson", Age = 25, Department = Department.It });
    dbContext.Add(new Student() { FirstName = "Dan", LastName = "Spence", Age = 25, Department = Department.It });
    dbContext.Add(new Student() { FirstName = "Helen", LastName = "Brennan", Age = 25, Department = Department.Constructions });


    dbContext.SaveChanges();
}