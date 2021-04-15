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
    public class RoutingController : ControllerBase
    {
        [HttpGet]
        [Route("api/Routing")]
        public List<Routing> GetAllRouting()
        {
            using (var db = new MyContext())
            {
                var u = db.Routing.ToList();
                return u;
            }
        }
        [HttpGet]
        [Route("api/Routing/ForMaterial")]
        public List<Routing> GetAllRouting([FromQuery] string MaterialNo)
        {
            using (var db = new MyContext())
            {
                var u = db.Routing
                    .Where(_ => _.MaterialNo == MaterialNo)
                    .ToList();
                return u;
            }
        }

        [HttpGet]
        [Route("api/Routing/{id}")]
        public Routing GetRouting([FromRoute] int id)
        {
            using (var db = new MyContext())
            {
                var u = db.Routing.Where(_ => _.Id == id).FirstOrDefault();
                return u;
            }
        }

        [HttpPost]
        [Route("api/Routing")]
        public Routing PostRouting([FromBody] Routing u)
        {
            using (var db = new MyContext())
            {
                if (db.Routing.Where(_ => _.Id == u.Id).Count() == 0)
                {
                    db.Routing.Add(u);
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
        [Route("api/Routing/{id}")]
        public Routing DeleteRouting([FromRoute] int id)
        {
            using (var db = new MyContext())
            {
                db.Routing.RemoveRange(db.Routing.Where(_ => _.Id == id));
                db.SaveChanges();
            }
            return new Routing();
        }


    }

}
