using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            
            foreach (var car in carManager.GetCarsByColorId(3))
            {
                Console.WriteLine
                    ("------------For COLOR ID------------" + "\n" + 
                    "Car:" + car.Id+" -> "+ car.Name+"\n"+
                    "Description: " + car.Description + "\n"+
                    "Brand: " + car.BrandId + "\n"+
                    "Color: " + car.ColorId + "\n" +
                    "Model: " + car.ModelYear + "\n" +
                    "Daily Price: $" + car.DailyPrice + "\n" +
                    "Weekly Price: $" + car.WeeklyPrice + "\n" +
                    "Monthly Price: $" + car.MonthlyPrice + "\n"+ "\t\t\n"
                    ); 
            }

            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine
                    ("------------For BRAND ID------------" + "\n" +
                    "Car:" + car.Id + " -> " + car.Name + "\n" +
                    "Description: " + car.Description + "\n" +
                    "Brand: " + car.BrandId + "\n" +
                    "Color: " + car.ColorId + "\n" +
                    "Model: " + car.ModelYear + "\n" +
                    "Daily Price: $" + car.DailyPrice + "\n" +
                    "Weekly Price: $" + car.WeeklyPrice + "\n" +
                    "Monthly Price: $" + car.MonthlyPrice + "\n" + "\t\t\n"
                    );
            }

            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                foreach (var brand in brandManager.GetNameById(2))
                {
                    Console.WriteLine
                            ("-----------All Features-------------" + "\n" + 
                            "Car:" + car.Id + " -> " + brand.BrandName + " " + car.Name + "\n" + 
                            "Description: " + car.Description + "\n" +
                            "Brand: " + car.BrandId); 
                    foreach (var color in colorManager.GetNameById(3))
                    {
                        Console.WriteLine
                            ("Color Id: "+car.ColorId+"\nColor: " + color.ColorName);
                    }
                    
                    Console.WriteLine
                            ("Model: " + car.ModelYear + "\n"+
                            "Daily Price: $" + car.DailyPrice + "\n" +
                            "Weekly Price: $" + car.WeeklyPrice + "\n" +
                            "Monthly Price: $" + car.MonthlyPrice + "\n" + "\t\t\n"); 
                }
               
            }
           
        }
    }
}
