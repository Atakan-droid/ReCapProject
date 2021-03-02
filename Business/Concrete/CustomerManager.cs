using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using CORE.Aspects.Autofac.Validation;
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
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer entity)
        {
            customerDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(Customer entity)
        {
            customerDal.Delete(entity);
            return new SuccessResult();
        }

        [SecuredOperation("user,admin")]
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(customerDal.GetAll(),Messages.CustomersListed);
        }

        public IDataResult<Customer> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Customer>> GetDataPhotoId(int Id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Customer entity)
        {
            customerDal.Update(entity);
            return new SuccessResult();
        }
    }
}
