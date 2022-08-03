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
    public class SubjectGpaServices:ICustomService<SubjectGPA>
    {
        private readonly IRepository<SubjectGPA> _repository;
        public SubjectGpaServices(IRepository<SubjectGPA> repository)
        {
            _repository = repository;
        }

        public void Delete(SubjectGPA entity)
        {
            try
            {
                if (entity !=null)
                {
                    _repository.Delete(entity);
                    _repository.SaveChanges();  
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public SubjectGPA Get(int id)
        {
            try
            {
                var obj = _repository.Get(id);
                if (obj != null)
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

        public IEnumerable<SubjectGPA> GetAll()
        {
            try
            {
                var obj = _repository.GetAll();
                if (obj != null)
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

        public void Insert(SubjectGPA entity)
        {
            try
            {
                if (entity !=null)
                {
                    _repository.Insert(entity);
                    _repository.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Remove(SubjectGPA entity)
        {
            try
            {
                if (entity !=null)
                {
                    _repository.Remove(entity);
                    _repository.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(SubjectGPA entity)
        {
            try
            {
                if (entity !=null)
                {
                    _repository.Update(entity);
                    _repository.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
