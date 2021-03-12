using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api1.Controllers
{
    [ApiController]

    public class CzlowiekController : ControllerBase
    {

        LudzieDane d;
        public CzlowiekController(LudzieDane _d)
        {
            this.d = _d;
        }

        [HttpGet]
        [Route("api/ludzie/{nazwisko}")]
        public List<Czlowiek> Ludzie([FromQuery] string szukaj, [FromRoute] string nazwisko)
        {
            if (szukaj == null) szukaj = "";
            return d.GetLudzie()
                    .Where(_ => _.Imie.Contains(szukaj) || _.Nazwisko.Contains(szukaj))
                    .ToList();
        }

        [HttpPost]
        [Route("api/ludzie")]
        public Czlowiek LudzieDodaj([FromBody] Czlowiek ludz)
        {
            d.AddLudzie(ludz);
            return ludz;
        }



        public class Czlowiek
        {
            public string Imie { get; set; }
            public string Nazwisko { get; set; }

            public void FromString(string line)
            {
                var d = line.Split(';');
                this.Imie = d[0];
                this.Nazwisko = d[1];
            }
            public string ToLineString()
            {
                return $"{this.Imie};{this.Nazwisko};";
            }

        }

        public class LudzieDane
        {
            List<Czlowiek> _ludzie;
            bool dirty = false;

            public LudzieDane()
            {
                Task.Run(async () =>
                {
                    while (true)
                    {

                        if (dirty == true)
                        {
                            SaveLudzieLocal();
                            this.dirty = false;
                        }
                        await Task.Delay(20 * 1000);
                    }
                });
            }
            public List<Czlowiek> GetLudzie()
            {
                if (_ludzie != null) return _ludzie;
                var t = new List<Czlowiek>();
                var dane = System.IO.File.ReadAllLines("dane.txt");
                System.Console.WriteLine($"Odczytujemy dane z pliku");
                foreach (var l in dane)
                {
                    var l1 = new Czlowiek();
                    l1.FromString(l);
                    t.Add(l1);
                }
                _ludzie = t;
                return _ludzie;
            }

            public void AddLudzie(Czlowiek l)
            {
                var l1 = GetLudzie();
                l1.Add(l);
                this.dirty = true;
            }
            void SaveLudzieLocal()
            {

                var l = new List<string>();
                foreach (var c in GetLudzie().OrderBy(_ => _.Nazwisko).ThenBy(_ => _.Imie))
                {
                    l.Add(c.ToLineString());
                }
                System.Console.WriteLine($"Zapisujemy dane do pliku");
                System.IO.File.WriteAllLines("dane.txt", l);

                SingetoneExample.Instance();
            }
        }

        public class SingetoneExample
        {
            static SingetoneExample i;
            public static SingetoneExample Instance()
            {
                if (i == null)
                {
                    i = new SingetoneExample();

                }
                return i;
            }
        }
    }
}
