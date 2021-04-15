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
    public class BomController : ControllerBase
    {
        [HttpGet]
        [Route("api/Bom")]
        public List<Bom> GetAllBom()
        {
            using (var db = new MyContext())
            {
                var u = db.Bom
                            .Include(_ => _.material)
                            .ToList();
                return u;
            }
        }
        [HttpGet]
        [Route("api/Bom/ForMaterial")]
        public List<Bom> GetForMaterial([FromQuery] string MaterialNo)
        {
            using (var db = new MyContext())
            {
                var u = db.Bom
                            .Include(_ => _.material)
                            .Where(_ => _.MaterialNo == MaterialNo)
                            .ToList();
                return u;
            }
        }
        [HttpGet]
        [Route("api/Bom/{id}")]
        public Bom GetBom([FromRoute] int id)
        {
            using (var db = new MyContext())
            {
                var u = db.Bom
                        .Include(_ => _.material)
                        .Where(_ => _.Id == id)
                        .FirstOrDefault();
                return u;
            }
        }

        [HttpPost]
        [Route("api/Bom")]
        public Bom PostBom([FromBody] Bom u)
        {
            u.material = null;
            using (var db = new MyContext())
            {
                if (db.Bom.Where(_ => _.Id == u.Id).Count() == 0)
                {
                    db.Bom.Add(u);
                }
                else
                {
                    db.Entry(u).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                db.SaveChanges();
                return u;
            }
        }

        [HttpDelete]
        [Route("api/Bom/{id}")]
        public Bom DeleteBom([FromRoute] int id)
        {
            using (var db = new MyContext())
            {
                db.Bom.RemoveRange(db.Bom.Where(_ => _.Id == id));
                db.SaveChanges();
            }
            return new Bom();
        }


    }

}
