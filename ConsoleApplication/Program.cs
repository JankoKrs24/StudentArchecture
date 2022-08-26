using Domain.Models;
using Persistence.Data;

var context = new SchoolContext();

var students = context.Students;

foreach(Student s in students)
{
    Console.WriteLine(s.FirstName);
}