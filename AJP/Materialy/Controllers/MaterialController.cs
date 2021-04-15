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
    public class MaterialController : ControllerBase
    {
        [HttpGet]
        [Route("api/Material")]
        public List<Material> GetAllMaterial()
        {
            using (var db = new MyContext())
            {
                var u = db.Material.ToList();
                return u;
            }
        }
        [HttpGet]
        [Route("api/Material/{MaterialNo}")]
        public Material GetMaterial([FromRoute] string MaterialNo)
        {
            using (var db = new MyContext())
            {
                var u = db.Material.Where(_ => _.MaterialNo == MaterialNo).FirstOrDefault();
                return u;
            }
        }

        [HttpPost]
        [Route("api/Material")]
        public Material PostMaterial([FromBody] Material u)
        {
            using (var db = new MyContext())
            {
                if (db.Material.Where(_ => _.MaterialNo == u.MaterialNo).Count() == 0)
                {
                    db.Material.Add(u);
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
        [Route("api/Material/{MaterialNo}")]
        public Material DeleteMaterial([FromRoute] string MaterialNo)
        {
            using (var db = new MyContext())
            {
                db.Material.RemoveRange(db.Material.Where(_ => _.MaterialNo == MaterialNo));
                db.SaveChanges();
            }
            return new Material();
        }


    }

}
