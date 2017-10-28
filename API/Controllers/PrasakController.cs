using System;
using System.Collections.Generic;
using System.Web.Http;
using Core.Entities;
using Services;
using WebGrease.Css.Extensions;

namespace API.Controllers
{
    public class PrasakController : ApiController
    {
        public IEnumerable<Prasak> Get()
        {
            var aps = ServiceProvider.Get<PrasakService>().GetAll();
            aps.ForEach(o =>
            {
                o.LekList = null;
                o.KontraindikacijaList = null;
            });

            return aps;
        }

        // GET api/Prasak/5
        public Prasak Get(int id)
        {
            var o = ServiceProvider.Get<PrasakService>().Get(id);

            if (o == null)
                return null;

            o.LekList = null;
            o.KontraindikacijaList = null;

            return o;
        }

        // POST api/Prasak
        public bool Post([FromBody] Prasak obj)
        {
            try
            {
                ServiceProvider.Get<PrasakService>().Create(obj);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        // PUT api/Prasak/5
        public void Put(int id, [FromBody] Prasak obj)
        {
            ServiceProvider.Get<PrasakService>().Update(id, obj);
        }

        // DELETE api/Prasak/5
        public void Delete(int id)
        {
            ServiceProvider.Get<PrasakService>().Delete(id);
        }
    }
}