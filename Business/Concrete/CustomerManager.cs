using Business.Abstract;
using Business.Constants;
using CORE.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal customerDal;
        public CustomerManager(ICustomerDal _customerDal)
        {
            customerDal = _customerDal;
        }
        public IResult Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(customerDal.GetAll(),Messages.CustomersListed);
        }

        public IDataResult<Customer> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
