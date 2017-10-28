using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Tracing;
using Core.Entities;
using Services;
using WebGrease.Css.Extensions;

namespace API.Controllers
{
    public class BolestController : ApiController
    {
        public IEnumerable<Bolest> Get()
        {
            var aps = ServiceProvider.Get<BolestService>().GetAll();
            aps.ForEach(o =>
            {
                o.LekList = null;
                o.KontraindikacijaList = null;
            });

            return aps;
        }

        // GET api/bolest/5
        public Bolest Get(int id)
        {
            var o = ServiceProvider.Get<BolestService>().Get(id);

            if (o == null)
                return null;

            o.LekList = null;
            o.KontraindikacijaList = null;

            return o;
        }

        // POST api/bolest
        public bool Post([FromBody] Bolest obj)
        {
            try
            {
                Configuration.Services.GetTraceWriter().Info(
            Request, "ProductsController", "Get the list of products.");

                ServiceProvider.Get<BolestService>().Create(obj);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        // PUT api/bolest/5
        public void Put(int id, [FromBody] Bolest obj)
        {
            ServiceProvider.Get<BolestService>().Update(id, obj);
        }

        // DELETE api/bolest/5
        public void Delete(int id)
        {
            ServiceProvider.Get<BolestService>().Delete(id);
        }
    }
}