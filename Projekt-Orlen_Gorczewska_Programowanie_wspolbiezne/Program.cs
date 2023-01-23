using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Projekt_Orlen_Gorczewska_Programowanie_wspolbiezne
{
    public class Program
    {
        static Semaphore semaphoreDystrybutorowPaliwa = new Semaphore(StacjaBenzynowaStatic.LiczbaDystrybutorowPaliwa, StacjaBenzynowaStatic.LiczbaDystrybutorowPaliwa);
        static Semaphore semaphoreKasy = new Semaphore(StacjaBenzynowaStatic.LiczbaKas, StacjaBenzynowaStatic.LiczbaKas);

        static void Main(string[] args)
        {
            //to służy do uruchamiania 
            int liczbaSamochodow = 10;
            for (int i = 0; i < liczbaSamochodow; i++)
            {
                Thread samochod1 = new Thread(new Samochod("Toyota "+i, 50, 80, 10, new Osoba("Tomek "+i, 400, semaphoreKasy), semaphoreDystrybutorowPaliwa, semaphoreKasy).Jedzie);
                samochod1.Start();
            }

            //Thread samochod2 = new Thread(new Samochod("Mercedes",50,80,15,new Osoba("Bartek",400 ,semaphoreKasy), semaphoreDystrybutorowPaliwa,semaphoreKasy).Jedzie);
            //samochod2.Start();
            //Thread samochod3 = new Thread(new Samochod("Ferrari",50,120,10,new Osoba("Adam",400, semaphoreKasy), semaphoreDystrybutorowPaliwa,semaphoreKasy).Jedzie);
            //samochod3.Start();
            Console.ReadKey();
        }
    }
}
