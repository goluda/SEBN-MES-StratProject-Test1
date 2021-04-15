using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Materialy.Controllers
{
    [ApiController]
    public class MaterialyController : ControllerBase
    {


        [HttpGet]
        [Route("api/MaterialyOld")]
        public List<Material> Materialy()
        {
            using (var db = new MyContext())
            {
                return db.Material.OrderBy(_ => _.MaterialNo).ToList();
            }
        }
        [HttpGet]
        [Route("api/MaterialyOld/{MaterialNo}")]
        public CompleteMaterial Materialy([FromRoute] string MaterialNo)
        {
            var cm = new CompleteMaterial();
            using (var db = new MyContext())
            {
                cm.Material = db.Material.Where(_ => _.MaterialNo == MaterialNo).FirstOrDefault();
            }
            cm.Routing = new RoutingOldController().RoutingForMaterial(MaterialNo);
            cm.Bom = new BomOldController().BomForMaterial(MaterialNo);
            CalculateSum(cm);
            CalculateSubParts(cm);
            return cm;
        }

        private void CalculateSubParts(CompleteMaterial cm)
        {
            foreach (var b in cm.Bom)
            {
                System.Console.WriteLine($"Szukamy danych dla komponentu {b.ComponentNo}");
                b.SubMaterial = this.Materialy(b.ComponentNo);
            }
        }

        private void CalculateSum(CompleteMaterial cm)
        {
            // cm.TotalTime = 0;
            // foreach (var r in cm.Routing)
            // {
            //     cm.TotalTime += r.Time;
            // }

            // cm.TotalPrice = 0;
            // foreach (var r in cm.Bom)
            // {
            //     cm.TotalPrice += r.Qty * r.material.Price;
            // }

            cm.TotalTime = cm.Routing.Sum(_ => _.Time);
            cm.TotalPrice = cm.Bom.Sum(_ => _.Qty * _.material.Price);

        }
        [HttpGet]
        [Route("api/MaterialyOld/szukaj")]
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

        public class CompleteMaterial
        {
            public Material Material { get; set; }
            public int TotalTime { get; set; }
            public int TotalPrice { get; set; }
            public List<Bom> Bom { get; set; }
            public List<Routing> Routing { get; set; }


        }
    }

    [ApiController]
    public class BomOldController : ControllerBase
    {

        [HttpGet]
        [Route("api/BomOld/{MaterialNo}")]
        public List<Bom> BomForMaterial([FromRoute] string MaterialNo)
        {
            using (var db = new MyContext())
            {
                return db.Bom
                        .Include(_ => _.material)
                        .Where(_ => _.MaterialNo == MaterialNo)
                        .ToList();
            }
        }
    }
    [ApiController]
    public class RoutingOldController : ControllerBase
    {

        [HttpGet]
        [Route("api/RoutingOld/{MaterialNo}")]
        public List<Routing> RoutingForMaterial([FromRoute] string MaterialNo)
        {
            using (var db = new MyContext())
            {
                return db.Routing.Where(_ => _.MaterialNo == MaterialNo).ToList();
            }
        }

    }
}
