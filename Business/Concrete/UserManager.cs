using Business.Abstract;
using Business.Constants;
using CORE.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
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
            if (entity.Password.Length <= 6) { return new ErrorResult(Messages.NewUserErrorPassword); } 
            else
            {
                userDal.Add(entity);
                         return new ErrorResult("Başarılı oluşturma");
            }

           
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

        public IDataResult<List<User_CustomerDTOs>> GetAllDetails()
        {
            return new SuccessDataResult<List<User_CustomerDTOs>>(userDal.GetAllUserInformation(), Messages.AllUsersListed);
        }

        public IDataResult<User> GetById(int Id)
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
