using Business.Abstract;
using CORE.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBusinessService<Brand>
    {
        public void Add(Brand brand)
        {
            throw new NotImplementedException();
        }

        public void Delete(Brand brand)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetAll()
        {
            throw new NotImplementedException();
        }

        public Brand GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Brand brand)
        {
            throw new NotImplementedException();
        }

        IResult IBusinessService<Brand>.Add(Brand brand)
        {
            throw new NotImplementedException();
        }

        IResult IBusinessService<Brand>.Delete(Brand brand)
        {
            throw new NotImplementedException();
        }

        IDataResult<List<Brand>> IBusinessService<Brand>.GetAll()
        {
            throw new NotImplementedException();
        }

        IDataResult<Brand> IBusinessService<Brand>.GetById(int Id)
        {
            throw new NotImplementedException();
        }

        IResult IBusinessService<Brand>.Update(Brand brand)
        {
            throw new NotImplementedException();
        }
    }
}
