using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine("------------------------------------------");
            //Araba Ekliyoruz
            carManager.Add(new Car {Id=8,BrandId=4,ColorId=4,DailyPrice=400,Description="Yeni Araba",ModelYear=1988 });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine(  "------------------------------------------------");
            carManager.Delete(3);
            //Ikea silindi
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine("------------------------------------------------");
            //Yeni Araba nın acıklaması yeni olmayan şeklinde değişti
            carManager.Update(new Car { Id = 8, BrandId = 4, ColorId = 4, DailyPrice = 400, Description = "Yeni Olmayan", ModelYear = 1988 });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
