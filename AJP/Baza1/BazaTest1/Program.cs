using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BazaTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ListaLudzikow();
            ListaAdresow();
        }

        private static void ListaAdresow()
        {
            using (var db = new MyContext())
            {
                System.Console.WriteLine($"ADRESY-----");
                var adresy = db.adres
                                .Include(_ => _.ludzik1)
                                .ToList();

                foreach (var a in adresy)
                {
                    System.Console.WriteLine($"{a.id} {a.aders} {a.ludzik} {a.ludzik1.imie} {a.ludzik1.nazisko}");
                }
            }
        }

        private static void ListaLudzikow()
        {
            using (var db = new MyContext())
            {
                foreach (var l in db.ludziki)
                {
                    System.Console.WriteLine($" {l.id} {l.imie} {l.nazisko}");
                }
            }
        }
    }
}
