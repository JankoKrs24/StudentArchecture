using Application.DTOs;
using Application.DTOs.Course;
using Application.DTOs.Student;
using Application.Services;
using Domain.Infrastructure;
using Domain.Models;
using Infrastructure.Services;
using Persistence.Data;
using System;

SchoolContext context = new SchoolContext();

UnitOfWork unitOfWork = new UnitOfWork(context);

IStudentService _student = new StudentService();

AddStudentDto dto = new AddStudentDto()
{
    FirstName = "Mirko",
    LastName = "Savkovic",
    Address = new AddressDto("Srbija", "Kraljevo", "Zrtve fasizma 14", "27000")
};

await _student.AddStudent(dto);

List<StudentDto> students = await _student.GetAll();

foreach(StudentDto s in students)
{
    Console.WriteLine(s.FirstName + " " + s.LastName);
}






/////////////////////////
//                     //
//       COURSE        //
//                     //
/////////////////////////
//ICourseService _course = new CourseService();

//EditCourseDto dto = new EditCourseDto()
//{
//    Id = 2,
//    CourseName="Data Base: Intermediant",
//    CourseCode=44879
//};

//await _course.UpdateCourse(dto);

//Console.WriteLine(dto.Id + "  " + dto.CourseName + "  " + dto.CourseCode);






//AddCourseDto dto = new AddCourseDto()
//{
//    CourseName = "Matematika 1",
//    CourseCode = 5564
//};

//await _course.AddCourse(dto);


//List<CourseDto> courses = await _course.GetAll();

//foreach (CourseDto c in courses)
//{
//    Console.WriteLine(c.Id + "  " + c.CourseName + "  " + c.CourseCode);
//}

//////////////////////////////////////////////////////////////////////////////////

//var student = unitOfWork.StudentRepository.GetById(1);
//var course = unitOfWork.CourseRepository.GetById(4);
//var teacher = unitOfWork.TeacherRepository.GetById(1);

//Teacher t = new Teacher();

//t.FirstName = "asdfa";
//t.LastName = "asdfv";
//t.Created = DateTime.Now;
//t.Address = Address.CreateInstance("asd", "asd", "asd", "asd");

//unitOfWork.TeacherRepository.Delete(4);
//unitOfWork.Save();

////Student student = new Student();
////student.FirstName = "Milovan";
////student.LastName = "Krstic";
////student.Address = Address.CreateInstance("Srbija", "Beograd", "Krusevacka 35", "11000");
////student.Created = DateTime.Now;



////try
////{
////    unitOfWork.StudentRepository.Create(student);
////    unitOfWork.Save();

////    var students = unitOfWork.StudentRepository.GetAll();

////    foreach (var st in students)
////    {
////        Console.WriteLine(st.FirstName);
////    }

////}
////catch (Exception ex)
////{
////    Console.WriteLine(ex.Message);
////}




