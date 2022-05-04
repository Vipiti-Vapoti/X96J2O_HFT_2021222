using ConsoleTools;
using System;
using System.Linq;
using X96J2O_HFT_2021222.Models;


namespace X96J2O_HFT_2021222.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                RestService rest = new RestService("http://localhost:35445/", typeof(Rent).Name);
                CrudService crud = new CrudService(rest);
                NonCrudService nonCrud = new NonCrudService(rest);

                var carSubMenu = new ConsoleMenu(args, level: 1)
                    .Add("List", () => crud.List<Car>())
                    .Add("Create", () => crud.Create<Car>())
                    .Add("Delete", () => crud.Delete<Car>())
                    .Add("Update", () => crud.Update<Car>())
                    .Add("Exit", ConsoleMenu.Close);

                var brandSubMenu = new ConsoleMenu(args, level: 1)
                     .Add("List", () => crud.List<Brand>())
                     .Add("Create", () => crud.Create<Brand>())
                     .Add("Delete", () => crud.Delete<Brand>())
                     .Add("Update", () => crud.Update<Brand>())
                     .Add("Exit", ConsoleMenu.Close);
                var rentSubmenu = new ConsoleMenu(args, level: 1)
                   .Add("List", () => crud.List<Rent>())
                   .Add("Create", () => crud.Create<Rent>())
                   .Add("Delete", () => crud.Delete<Rent>())
                   .Add("Update", () => crud.Update<Rent>())
                   .Add("Exit", ConsoleMenu.Close);

                var statsSubMenu = new ConsoleMenu(args, level: 1)
                    .Add("Average car price", () => nonCrud.AvgCarPrice())
                    .Add("Average yearly income by carmodells", () => nonCrud.AvgGetAvarageInComePerCarModellPerYearCarRentPrice())
                    .Add("Average price by brands", () => nonCrud.AvgRentPriceByBrand())
                    .Add("People who are fined for latency", () => nonCrud.HastoPayFine())
                    .Add("Cars out", () => nonCrud.StillOpenRentsByCarId())
                    .Add("Exit", ConsoleMenu.Close);

                var menu = new ConsoleMenu(args, level: 0)
                    .Add("rents", () => rentSubmenu.Show())
                    .Add("Cars", () => carSubMenu.Show())
                    .Add("Brands", () => brandSubMenu.Show())
                    .Add("Statistics", () => statsSubMenu.Show())
                    .Add("Exit", ConsoleMenu.Close);

                menu.Show();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
           
        }
    }
}
