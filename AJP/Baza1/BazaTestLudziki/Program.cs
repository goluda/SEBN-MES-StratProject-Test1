using System;
using System.Linq;

namespace BazaTestLudziki
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //DodajLudzika();
            //ListaLudzikow();
            //SzukajZosi();

            DodajTest();
            ListaLudzikow();
            UsunTest();
            ListaLudzikow();
        }

        private static void UsunTest()
        {
            using (var db = new MyContext())
            {
                db.ludziki.RemoveRange(db.ludziki.Where(_ => _.imie == "Test"));
                db.SaveChanges();
            }
        }

        private static void DodajTest()
        {
            using (var db = new MyContext())
            {
                db.ludziki.Add(new ludziki
                {
                    imie = "Test",
                    nazisko = "Test"
                });
                db.SaveChanges();
            }
        }

        private static void SzukajZosi()
        {
            using (var db = new MyContext())
            {
                var zosie = db.ludziki.Where(_ => _.imie == "Zosia").ToList();
                foreach (var z in zosie)
                {
                    System.Console.WriteLine($" {z.id} {z.imie} {z.nazisko}");
                }
            }
        }

        private static void DodajLudzika()
        {
            using (var db = new MyContext())
            {
                db.ludziki.Add(new ludziki
                {
                    imie = "Zosia",
                    nazisko = "samosia"
                });
                db.SaveChanges();
            }
        }

        private static void ListaLudzikow()
        {
            using (var db = new MyContext())
            {
                var ludziki = db.ludziki.ToList();
                foreach (var l in ludziki)
                {
                    System.Console.WriteLine($" - {l.id} {l.imie} {l.nazisko}");
                }
                System.Console.WriteLine("---------");
            }
        }
    }
}
