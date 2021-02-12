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
            // Rentalless();

            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            User user1 = new User() {Id=6,FirstName="Hasan",LastName="Mustan",Email="hasan@gmail.com",Password="123" };

             userManager.Add(user1);
            if (userManager.Add(user1).Success == true)
            {
                Console.WriteLine(userManager.Add(user1).Message);
            }else
            {
                Console.WriteLine(userManager.Add(user1).Message);
            }

            userManager.GetAllDetails();
            if (userManager.GetAllDetails().Success == true)
            {
                foreach (var users in userManager.GetAllDetails().Data)
                {
                    Console.WriteLine(users.UserName+" "+users.UserLastName+" "+users.UserEmail+" mailine sahip"+" "+users.UserCompanyName+" şiketinde çalışıyor" );
                }
            }

           //Customer customer1 = new Customer() { Id = 9, UserId = 1, CompanyName = "Deneme şirketi 4" };
           // customerManager.Add(customer1);
            Console.WriteLine("------------------------------");
            customerManager.GetAll();
            if (customerManager.GetAll().Success == true)
            {
                foreach (var customers in customerManager.GetAll().Data)
                {
                    Console.WriteLine(customers.CompanyName);
                }
             
            }
          //  Rentals rental1 = new Rentals() { Id = 8, CarId = 5, CustomerId = 4, RentDate = DateTime.Now };
           // rentalManager.Add(rental1);
            

            Console.WriteLine( "-----------------------------------");


        
            foreach (var rent in rentalManager.GetRentDetail().Data)
            {
                Console.WriteLine("{0} kişisi {1} arabasını {2} tarihinde kiraladı",rent.CustomerName,rent.CarName,rent.RentDate);
            }

           

        }

        private static void Rentalless()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("---------------Brand'a Göre geldi--------------------------------");
            foreach (var cars in carManager.GetAllByBrandId(2).Data)
            {
                Console.WriteLine(cars.Description);
            }
            Console.WriteLine("-------------------Color'a Göre Geldi----------------------------");
            foreach (var cars in carManager.GetAllByColorId(1).Data)
            {
                Console.WriteLine(cars.Description);
            }
            Console.WriteLine("-------------------Komple Geldi----------------------------");
            foreach (var cars in carManager.GetAll().Data)
            {
                Console.WriteLine(cars.Description);
            }

            Car car1 = new Car { Id = 5, BrandId = 1, ColorId = 2, DailyPrice = 150, ModelYear = 1987, Description = "" };
            carManager.Add(car1);
            Console.WriteLine("-------------------Eklenmediğinden Eskisi gibi geldi Çünkü Description en az 2 uzunluğunda olmalıydı----------------------------");
            foreach (var cars in carManager.GetAll().Data)
            {
                Console.WriteLine(cars.Description);
            }

            Console.WriteLine("-------------------Tablolar Birleşti / Hepsi geldi ----------------------------");
            if (carManager.GetAllDetails().Success == true)
            {
                foreach (var cars in carManager.GetAllDetails().Data)
                {
                    Console.WriteLine(cars.BrandName + " markasında " + cars.ColorName + " renginde " + cars.Description + " bir araba");
                }
            }
            else { Console.WriteLine(carManager.GetAllDetails().Message); };
        }
    }
}
