using Domain_Layer.Models;
using Repository_Layer.IRepository;
using ServiceLayer.ICustomServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.CustomServices
{
    public class StudentServices:ICustomService<Student>
    {
        private readonly IRepository<Student> _studentRepository;
        public StudentServices(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void Delete(Student entity)
        {
            try
            {
                if (entity !=null)
                {
                    _studentRepository.Delete(entity);
                    _studentRepository.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Student Get(int id)
        {
            try
            {
                var obj = _studentRepository.Get(id);
                if (obj != null)
                {
                    return obj;
                }
                else{
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Student> GetAll()
        {
            try
            {
                var obj=_studentRepository.GetAll();
                if (obj !=null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Insert(Student entity)
        {
            try
            {
                if (entity !=null)
                {
                    _studentRepository.Insert(entity);
                    _studentRepository.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Remove(Student entity)
        {
            try
            {
                if (entity !=null)
                {
                    _studentRepository.Remove(entity);
                    _studentRepository.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(Student entity)
        {
            try
            {
                if (entity !=null)
                {
                    _studentRepository.Update(entity);
                    _studentRepository.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
