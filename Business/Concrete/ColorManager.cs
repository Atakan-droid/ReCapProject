using Business.Abstract;
using CORE.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IBusinessService<Color>
    {
        public void Add(Color brand)
        {
            throw new NotImplementedException();
        }

        public void Delete(Color brand)
        {
            throw new NotImplementedException();
        }

        public List<Color> GetAll()
        {
            throw new NotImplementedException();
        }

        public Color GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Color brand)
        {
            throw new NotImplementedException();
        }

        IResult IBusinessService<Color>.Add(Color brand)
        {
            throw new NotImplementedException();
        }

        IResult IBusinessService<Color>.Delete(Color brand)
        {
            throw new NotImplementedException();
        }

        IDataResult<List<Color>> IBusinessService<Color>.GetAll()
        {
            throw new NotImplementedException();
        }

        IDataResult<Color> IBusinessService<Color>.GetById(int Id)
        {
            throw new NotImplementedException();
        }

        IResult IBusinessService<Color>.Update(Color brand)
        {
            throw new NotImplementedException();
        }
    }
}
