using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Materialy.Controllers
{
    [ApiController]

    public class MaterialyController : ControllerBase
    {

        [HttpGet]
        [Route("api/materialy")]
        public List<Material> Materialy()
        {
            using (var db = new MyContext())
            {
                return db.Material.OrderBy(_ => _.MaterialNo).ToList();
            }
        }
        [HttpGet]
        [Route("api/materialy/szukaj")]
        public List<Material> MaterialySzukaj([FromQuery] string szukane)
        {
            // var ret = new List<Material>();
            // using (var db = new MyContext())
            // {
            //     var lista = db.Material.OrderBy(_ => _.MaterialNo).ToList();
            //     foreach (var m in lista)
            //     {
            //         if (m.Name.Contains(szukane))
            //         {
            //             ret.Add(m);
            //         }
            //     }
            // }
            // return ret;
            using (var db = new MyContext())
            {
                return db.Material
                            .Where(_ => _.MaterialNo.Contains(szukane))
                            .OrderBy(_ => _.MaterialNo)
                            .ToList();
            }
        }
    }
}
