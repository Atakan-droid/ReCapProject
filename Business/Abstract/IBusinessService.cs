using CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IBusinessService<T> 
    {
        List<T> GetAll();
        T GetById(int Id);
        void Add(T brand);
        void Delete(T brand);
        void Update(T brand);
    }
}
