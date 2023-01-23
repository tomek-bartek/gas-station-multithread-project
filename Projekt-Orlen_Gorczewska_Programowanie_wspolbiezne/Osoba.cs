using System;
using System.Threading;
using System.Web;

namespace Projekt_Orlen_Gorczewska_Programowanie_wspolbiezne
{
    public class Osoba
    {
        public string Imie;
        public float Pieniadze = 300f;
        public Semaphore semaphore2 = null;
     
        public Osoba(string imie, int pieniadze, Semaphore semaphore2)
        {
            this.Imie = imie;
            this.Pieniadze = pieniadze;
            this.semaphore2 = semaphore2;
        }
     
        public void Placi(float kwota)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("{0} ....idzie do kasy", this.Imie);
            Console.ResetColor();
            semaphore2.WaitOne();

            if (this.Pieniadze > kwota)
            {
                this.Pieniadze = Pieniadze - kwota;
                StacjaBenzynowaStatic.PieniadzeWKasie += kwota;
               
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("{0} płaci za paliwo ", this.Imie);
                Console.WriteLine("W kasie na stacji benzynowej po płatności {0} jest teraz {1}",this.Imie, StacjaBenzynowaStatic.PieniadzeWKasie);
                Console.ResetColor();
                semaphore2.Release();
            }
            else
            {
                Console.Beep();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("{0} ma w portfelu {1} a zatankował za {2} !!!!! ZABLOKOWAŁ KASĘ!!!! ", this.Imie, this.Pieniadze, kwota);
                Console.ResetColor();
                for (int i = 0; i < 5; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Czekamy na Policję!!!!");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                }
                Console.WriteLine("Policja przyjechała i {0} został aresztowany. Kasa jest znowu wolna", this.Imie);
                Console.ResetColor();
                semaphore2.Release();
            }

        }
    }
}