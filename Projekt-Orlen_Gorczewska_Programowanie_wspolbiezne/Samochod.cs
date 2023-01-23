using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Projekt_Orlen_Gorczewska_Programowanie_wspolbiezne
{
    public class Samochod
    {
        public string Marka;
        public int IloscPaliwa = 80;
        public int PojemnoscBaku = 100;
        public int ZuzuciePaliwa = 15;
        public Osoba kierowca;
        public Semaphore semaphore1;
        public Semaphore semaphore2;
        public Samochod(string marka, int iloscPaliwa, int pojemnoscBaku, int zuzuciePaliwa, Osoba kierowca, Semaphore semaphore1, Semaphore semaphore2)
        {
            Marka = marka;
            IloscPaliwa = iloscPaliwa;
            PojemnoscBaku = pojemnoscBaku;
            ZuzuciePaliwa = zuzuciePaliwa;
            this.kierowca = kierowca;
            this.semaphore1 = semaphore1;
            this.semaphore2 = semaphore2;
            
        }
    
        public void Jedzie()
        {
            
            while (true)
            {
                
                Thread.Sleep(1000);
                Console.ResetColor();
                Console.WriteLine("wrummm... {0} i {1} jedzie i ma jeszcze {2} litrów paliwa", Marka, this.kierowca.Imie, IloscPaliwa);
                if (IloscPaliwa <= 20)
                {
                    this.Tankuje();
                }
                this.IloscPaliwa = this.IloscPaliwa - this.ZuzuciePaliwa;

            }
        }
        public void Tankuje()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0} zjechał swoją {1} na stację Orlen - w baku ma i czeka {2} ", this.kierowca.Imie, this.Marka, this.IloscPaliwa);
            semaphore1.WaitOne();
            int iloscPaliwaPrzedTankowaniem = this.IloscPaliwa;
            float kosztZatankowanegoPaliwa;
            while (this.IloscPaliwa <this.PojemnoscBaku -5)
            {
                this.IloscPaliwa = this.IloscPaliwa + 5;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} tankuje {1}, a ...w baku jest już {2} ",this.kierowca.Imie, this.Marka, this.IloscPaliwa);
                Thread.Sleep(1000);
            }
            Console.WriteLine("{0} już zatankował {1} teraz idzie zapłacić {2}", this.kierowca.Imie, this.Marka,StacjaBenzynowaStatic.CenaBenzyny*this.IloscPaliwa-iloscPaliwaPrzedTankowaniem);
            kosztZatankowanegoPaliwa = (this.IloscPaliwa - iloscPaliwaPrzedTankowaniem) * StacjaBenzynowaStatic.CenaBenzyny;
            kierowca.Placi(kosztZatankowanegoPaliwa);

            Console.ForegroundColor =ConsoleColor.Green;
            Console.WriteLine("{0} Juz zatankował i zapłacił teraz jedzie dalej... jego samochód {1} ma {2} litrów paliwa", this.kierowca.Imie, this.Marka, this.IloscPaliwa);
            semaphore1.Release();
        }


    }
}
