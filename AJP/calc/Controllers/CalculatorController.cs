using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace calc.Controllers
{
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        [HttpGet]
        [Route("api/dodaj")]
        public int Dodaj([FromQuery] int l1, [FromQuery]int l2){
            System.Console.WriteLine($"dodajemy {l1} do {l2}");
           return l1+l2;
        }
        [HttpGet]
        [Route("api/odejmij")]
        public int Odejmij([FromQuery] int l1, [FromQuery]int l2){
            System.Console.WriteLine($"odejmujemy {l1} do {l2}");
           return l1-l2;
        }
        [HttpGet]
        [Route("api/pomnoz")]
        public int Pomnoz([FromQuery] int l1, [FromQuery]int l2){
            System.Console.WriteLine($"Mnożymy {l1} razy {l2}");
           return l1*l2;
        }
        [HttpGet]
        [Route("api/podziel")]
        public int? Podziel([FromQuery] int l1,[FromQuery] int l2){
            if(l2==0) return 0;
            System.Console.WriteLine($"Dzielimy {l1} przez {l2}");
           return l1/l2;
        }
    }
}
