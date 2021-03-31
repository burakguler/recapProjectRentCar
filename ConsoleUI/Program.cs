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
                    ("Araba: "+ car.Id+" "+ car.Name+"\n"+"------------RENKE GÖRE------------"+"\n"+
                    "Açıklama: " + car.Description + "\n"+
                    "Marka: " + car.BrandId + "\n"+
                    "Renk: " + car.ColorId + "\n" +
                    "Model: " + car.ModelYear + "\n" +
                    "Günlük Kiralama Ücreti: $" + car.DailyPrice + "\n" +
                    "Haftalık Kiralama Ücreti: $" + car.WeeklyPrice + "\n" +
                    "Aylık Kiralama Ücreti: $" + car.MonthlyPrice + "\n"+ "\t\t\n"
                    ); 
            }

            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                foreach (var brand in brandManager.GetNameById(2))
                {
                    Console.WriteLine
                            ("Araba: " + car.Id + " " + car.Name + " " + brand.BrandName + "\n" + "----------- TUM OZELLIKLER -------------" + "\n" +
                            "Açıklama: " + car.Description + "\n" +
                            "Marka: " + car.BrandId + "\n" +
                            "Renk: " + car.ColorId + " " + "\n" +
                            "Model: " + car.ModelYear + "\n" +
                            "Günlük Kiralama Ücreti: $" + car.DailyPrice + "\n" +
                            "Haftalık Kiralama Ücreti: $" + car.WeeklyPrice + "\n" +
                            "Aylık Kiralama Ücreti: $" + car.MonthlyPrice + "\n" + "\t\t\n"
                            );

                    foreach (var color in colorManager.GetNameById(2))
                    {
                        Console.WriteLine
                            ("Araba: " + car.Id + " " + car.Name + " " + brand.BrandName + "\n" + "----------- TUM OZELLIKLER -------------" + "\n" +
                            
                            );
                    }
                     
                }
               
            }
        }
    }
}
