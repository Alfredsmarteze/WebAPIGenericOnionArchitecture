using Domain_Layer.Models;
using ServiceLayer.CustomServices;
using Repository_Layer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.ICustomServices;

namespace ServiceLayer.CustomServices
{
    public class DepartmentServices:ICustomService<Department>
    {
        private readonly IRepository<Department> _repository;
        public DepartmentServices(IRepository<Department> repository)
        {
            _repository = repository;
        }

        public void Delete(Department entity)
        {
            try
            {
                if (entity!=null)
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

        public Department Get(int id)
        {
            try
            {
              var obj=  _repository.Get(id);
                if (obj!=null)
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

        public IEnumerable<Department> GetAll()
        {
            try
            {
                var obj = _repository.GetAll();
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

        public void Insert(Department entity)
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

        public void Remove(Department entity)
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

        public void Update(Department entity)
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
