using System;
using System.Linq;

namespace BazaTestLudziki
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ListaLudzikow();
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
            }
        }
    }
}
