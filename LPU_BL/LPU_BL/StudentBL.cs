using System;
using System.Collections.Generic;
using LPU_Common;
using LPU_Entity;
using LPU_DAL;
using LPU_Exceptions;


namespace LPU_BL
{
    public class StudentBL : IStudentCRUD
    {
        StudentDAO sDao = null;
        public StudentBL()
        {
            sDao = new StudentDAO();
        }
        public bool DropStudentDetails(int id)
        {
            throw new NotImplementedException();
        }

        public bool EnrollStudent(Student sObj)
        {
            throw new NotImplementedException();
        }

        public Student SearchStudentByID(int rollNo)
        {
            Student s1 = null;
            try
            {
                s1 = sDao.SearchStudentByID(rollNo);
            }
            catch (LPUException e) { 
                throw e;
            }
            return s1;
        }

        public List<Student> SearchStudentByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateStudentDetail(int id, Student newObj)
        {
            throw new NotImplementedException();
        }
    }
}
