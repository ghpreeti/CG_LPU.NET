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
            bool flag = false;
            try
            {
                if (id != 0)
                {
                    flag = sDao.DropStudentDetails(id);
                }
                else
                {
                    throw new LPUException("Invalid Student ID");
                }
            }
            catch (LPUException e)
            {
                throw e;
            }
            return flag;

        }

        public bool EnrollStudent(Student sObj)
        {
            return sDao.EnrollStudent(sObj);
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
           return sDao.SearchStudentByName(name);
        }

        public bool UpdateStudentDetail(int id, Student newObj)
        {
            bool flag = false;
            try
            {
                if (id > 0 && newObj != null)
                {
                    flag = sDao.UpdateStudentDetail(id, newObj);
                }
                else
                {
                    throw new LPUException("Invalid input data");
                }
            }
            catch (LPUException e)
            {
                throw e;
            }
            return flag;
        }
    }
}
