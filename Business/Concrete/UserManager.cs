using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using CORE.Aspects.Autofac.Validation;
using CORE.Entities.Concrete;
using CORE.Utilities;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal userDal;
        public UserManager(IUserDal _userDal)
        {
            userDal = _userDal;
        }
        
        public IResult Add(User entity)
        {

            userDal.Add(entity);
            return new SuccessResult();

        }

        public IResult Delete(User entity)
        {
            userDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(userDal.GetAll(),"Tüm kullanıcılar listelendi");
        }

        public User GetByEmail(string email)
        {
            return userDal.Get(u => u.Email == email);
        }

        public IDataResult<User> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<OperationClaim>> GetClaim(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(userDal.GetClaims(user));
        }

        public IDataResult<List<User>> GetDataPhotoId(int Id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(User entity)
        {
            userDal.Update(entity);
            return new SuccessResult();
        }
    }
}
