using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace calc.Controllers
{

    [ApiController]
    public class CalculatorMemoryController : ControllerBase
    {
        Memory memory;

        public CalculatorMemoryController(Memory _memory)
        {
            memory = _memory;
        }

        [HttpGet]
        [Route("api1/history")]
        public List<string> GetHistory()
        {
            return memory.History;
        }

        [HttpGet]
        [Route("api1/dodaj")]
        public int Dodaj([FromQuery] int l1)
        {
            memory.History.Add($"dodajemy {l1} do {memory.Last}");
            memory.Last += l1;
            return memory.Last;
        }
        [HttpGet]
        [Route("api1/odejmij")]
        public int Odejmij([FromQuery] int l1)
        {
            memory.History.Add($"odejmujemy {l1} od {memory.Last}");
            memory.Last -= l1;
            return memory.Last;
        }
        [HttpGet]
        [Route("api1/pomnoz")]
        public int Pomnoz([FromQuery] int l1)
        {
            memory.History.Add($"mnożymy {l1} razy {memory.Last}");
            memory.Last *= l1;
            return memory.Last;
        }
        [HttpGet]
        [Route("api1/podziel")]
        public int? Podziel([FromQuery] int l1)
        {
            if (l1 == 0) return 0;
            memory.History.Add($"dzielimy {memory.Last} razy {l1}");
            memory.Last /= l1;
            return memory.Last;
        }
    }

    public class Memory
    {
        public int Last { get; set; }
        public List<string> History { get; set; } = new List<string>();
    }
}
