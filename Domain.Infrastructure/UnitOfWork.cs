using Domain.Infrastructure.Repository;
using Domain.Interfaces;
using Domain.Models;
using Domain.Service;
using Domain.Service.Interfaces;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastructure
{
    public class UnitOfWork:IUnitOfWork
    {
        private SchoolContext context;
        private ICourseRepository courseRepository;
        private IDepartmentRepository departmentRepository;
        private IStudentRepository studentRepository;
        private ITeacherRepository teacherRepository;

        public UnitOfWork(SchoolContext context)
        {
            this.context = context;
        }


        public ICourseRepository CourseRepository
        {
            get
            {
                if(this.courseRepository == null)
                {
                    this.courseRepository = new CourseRepository(context);
                }
                return courseRepository;
            }
        }

        public IDepartmentRepository DepartmentRepository
        {
            get
            {
                if (this.departmentRepository == null)
                {
                    this.departmentRepository = new DepartmentRepository(context);
                }
                return departmentRepository;
            }
        }

        public IStudentRepository StudentRepository
        {
            get
            {
                if (this.studentRepository == null)
                {
                    this.studentRepository = new StudentRepository(context);
                }
                return studentRepository;
            }
        }

        public ITeacherRepository TeacherRepository
        {
            get
            {
                if (this.teacherRepository == null)
                {
                    this.teacherRepository = new TeacherRepository(context);
                }
                return teacherRepository;
            }
        }

        public async Task Save()
        {
           await context.SaveChangesAsync();
        }
    }
}
