using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("---------------Brand'a Göre geldi--------------------------------");
            foreach (var cars in carManager.GetAllByBrandId(2))
            {
                Console.WriteLine(cars.Description);
            }
            Console.WriteLine("-------------------Color'a Göre Geldi----------------------------");
            foreach (var cars in carManager.GetAllByColorId(1))
            {
                Console.WriteLine(cars.Description);
            }
            Console.WriteLine("-------------------Komple Geldi----------------------------");
            foreach (var cars in carManager.GetAll())
            {
                Console.WriteLine(cars.Description);
            }

            Car car1 = new Car {Id=5,BrandId=1,ColorId=2,DailyPrice=150,ModelYear=1987,Description="" };
            carManager.Add(car1);
            Console.WriteLine("-------------------Eklenmediğinden Eskisi gibi geldi Çünkü Description en az 2 uzunluğunda olmalıydı----------------------------");
            foreach (var cars in carManager.GetAll())
            {
                Console.WriteLine(cars.Description);
            }
        }
    }
}
