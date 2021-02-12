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
            User user1 = new User() {Id=6,FirstName="Hasan",LastName="Mustan",Email="hasan@gmail.com",Password="1234" };

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
           

            Console.WriteLine("------------------------------");
            customerManager.GetAll();
            if (customerManager.GetAll().Success == true)
            {
                foreach (var customers in customerManager.GetAll().Data)
                {
                    Console.WriteLine(customers.CompanyName);
                }
             
            }
            Console.WriteLine( "-----------------------------------");

            Rentals rental1 = new Rentals() {Id=3,CarId=1,CustomerId=1,RentDate=DateTime.Now};
            Rentals rental2 = new Rentals() { Id = 4, CarId = 2, CustomerId = 2, RentDate = DateTime.Now ,ReturnDate=DateTime.Today};
            rentalManager.Add(rental1);
            if (rentalManager.Add(rental1).Success == true)
            {
                Console.WriteLine(rentalManager.Add(rental1).Message);
            }
            else { Console.WriteLine(rentalManager.Add(rental1).Message); }

            if (rentalManager.Add(rental2).Success == true)
            {
                Console.WriteLine(rentalManager.Add(rental2).Message);
            }
            else { Console.WriteLine(rentalManager.Add(rental2).Message); }

            Console.WriteLine("---------------------------------------------------");
            foreach (var rents in rentalManager.GetRentDetail().Data)
            {
                Console.WriteLine("{0} kişisi {1} adında bir arabayı {2} tarihinde kiraladı",rents.CustomerName,rents.CarName,rents.RentDate  );
            }
            Console.WriteLine();


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
