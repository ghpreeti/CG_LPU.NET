using System;
using LPU_Entity;
using System.Collections.Generic;

namespace LPU_Common
{
    public interface IStudentCRUD //in interfaces all methods are abstract
    {
        Student SearchStudentByID(int rollNo);
        List<Student> SearchStudentByName(string name);
        bool EnrollStudent(Student sObj);
        bool UpdateStudentDetail(int id,Student newObj);
        bool DropStudentDetails(int id);
    }
}
