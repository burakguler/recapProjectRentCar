using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.InMemory;
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
                Console.WriteLine
                    ("Araba: "+ car.Id+"\n"+"---------------------------"+"\n"+
                    "Açıklama: " + car.Description + "\n"+
                    "Marka: " + car.BrandId + "\n"+
                    "Renk: " + car.ColorId + "\n" +
                    "Model: " + car.ModelYear + "\n" +
                    "Günlük Kiralama Ücreti: $" + car.DailyPrice + "\n" +
                    "Haftalık Kiralama Ücreti: $" + car.WeeklyPrice + "\n" +
                    "Aylık Kiralama Ücreti: $" + car.MonthlyPrice + "\n"+ "\t\t\n"
                    ); 
            }
        }
    }
}
