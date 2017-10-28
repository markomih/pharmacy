using System;
using System.Collections.Generic;
using System.Web.Http;
using Core.Entities;
using Services;
using WebGrease.Css.Extensions;

namespace API.Controllers
{
    public class TabletaController : ApiController
    {
        public IEnumerable<Tableta> Get()
        {
            var aps = ServiceProvider.Get<TabletaService>().GetAll();
            aps.ForEach(o =>
            {
                o.LekList = null;
                o.KontraindikacijaList = null;
            });

            return aps;
        }

        // GET api/Tableta/5
        public Tableta Get(int id)
        {
            var o = ServiceProvider.Get<TabletaService>().Get(id);

            if (o == null)
                return null;

            o.LekList = null;
            o.KontraindikacijaList = null;

            return o;
        }

        // POST api/Tableta
        public bool Post([FromBody] Tableta obj)
        {
            try
            {
                ServiceProvider.Get<TabletaService>().Create(obj);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        // PUT api/Tableta/5
        public void Put(int id, [FromBody] Tableta obj)
        {
            ServiceProvider.Get<TabletaService>().Update(id, obj);
        }

        // DELETE api/Tableta/5
        public void Delete(int id)
        {
            ServiceProvider.Get<TabletaService>().Delete(id);
        }
    }
}