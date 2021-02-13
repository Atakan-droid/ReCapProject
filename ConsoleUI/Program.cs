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

            //NewUserAdded(userManager);
            // UsersListed(userManager);
            // CustomersListed(customerManager);
            //RentBackFunc(rentalManager);
            // RentUpdated(rentalManager);
            ListAllRents(rentalManager);

        }

        private static void ListAllRents(RentalManager rentalManager)
        {
            Console.WriteLine("---------------Tüm Kiralanmalar Liste Halinde Gösteriliyor--------------------");

            foreach (var rent in rentalManager.GetRentDetail().Data)
            {
                Console.WriteLine("{0} kişisi {1} arabasını {2} tarihinde kiraladı", rent.CustomerName, rent.CarName, rent.RentDate);
            }
        }

        private static void RentUpdated(RentalManager rentalManager)
        {
            Console.WriteLine("------------------RentBack Yapılıyor---------------------------");

            var result2 = rentalManager.RentalBack(12);
            if (result2.Success == true)
            {
                Console.WriteLine(result2.Message);
            }
        }

        private static void NewUserAdded(UserManager userManager)
        {
            User user1 = new User() { Id = 6, FirstName = "Hasan", LastName = "Mustan", Email = "hasan@gmail.com", Password = "123" };

            var result4 = userManager.Add(user1);
            if (result4.Success == true)
            {
                Console.WriteLine(result4.Message);
            }
            else
            {
                Console.WriteLine(result4.Message);
            }
        }

        private static void UsersListed(UserManager userManager)
        {
            var result = userManager.GetAllDetails();
            if (result.Success == true)
            {
                foreach (var users in result.Data)
                {
                    Console.WriteLine(users.UserName + " " + users.UserLastName + " " + users.UserEmail + " mailine sahip" + " " + users.UserCompanyName + " şiketinde çalışıyor");
                }
            }
        }

        private static void CustomersListed(CustomerManager customerManager)
        {
            Console.WriteLine("--------------Müşteriler listelniyor----------------");
            var result1 = customerManager.GetAll();
            if (result1.Success == true)
            {
                foreach (var customers in result1.Data)
                {
                    Console.WriteLine(customers.CompanyName);
                }

            }
        }

        private static void RentBackFunc(RentalManager rentalManager)
        {
            Console.WriteLine("-------------------Rent Fonksiyonu Çalışıyor-------------");

            Rentals rental1 = new Rentals { Id = 12, CarId = 2, CustomerId = 4, RentDate = DateTime.Now, ReturnDate = null };
            var result = rentalManager.Add(rental1);
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else { Console.WriteLine(result.Message); };
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
