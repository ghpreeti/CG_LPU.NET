using System;
using System.Collections.Generic;
using LPU_Common;
using LPU_Entity;
using LPU_DAL;
using LPU_Exceptions;

namespace LPU_BL
{
    public class BookBL : IRepo<Book>
    {
        BookDAO bDao = null;

        public BookBL()
        {
            bDao = new BookDAO();
        }

        // DELETE
        public bool DeleteDetails(int id)
        {
            bool flag = false;
            try
            {
                if (id != 0)
                {
                    flag = bDao.DeleteDetails(id);
                }
                else
                {
                    throw new BookException("Invalid Book ID");
                }
            }
            catch (BookException e)
            {
                throw e;
            }
            return flag;
        }

        // CREATE
        public bool AddDetails(Book obj)
        {
            bool flag = false;
            try
            {
                if (obj != null)
                {
                    flag = bDao.AddDetails(obj);
                }
                else
                {
                    throw new BookException("Invalid Book Data");
                }
            }
            catch (BookException e)
            {
                throw e;
            }
            return flag;
        }

        // READ BY ID
        public Book ShowDetailsByID(int id)
        {
            Book b = null;
            try
            {
                b = bDao.ShowDetailsByID(id);
            }
            catch (BookException e)
            {
                throw e;
            }
            return b;
        }

        // READ ALL
        public List<Book> ShowAll()
        {
            return bDao.ShowAll();
        }

        // UPDATE
        public bool UpdateDetails(int id, Book obj)
        {
            bool flag = false;
            try
            {
                if (id > 0 && obj != null)
                {
                    flag = bDao.UpdateDetails(id, obj);
                }
                else
                {
                    throw new BookException("Invalid input data");
                }
            }
            catch (BookException e)
            {
                throw e;
            }
            return flag;
        }
    }
}
