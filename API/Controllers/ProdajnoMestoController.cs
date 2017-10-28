using System;
using System.Collections.Generic;
using System.Web.Http;
using Core.Entities;
using Services;
using WebGrease.Css.Extensions;

namespace API.Controllers
{
    public class ProdajnoMestoController : ApiController
    {
        public IEnumerable<ProdajnoMesto> Get()
        {
            var aps = ServiceProvider.Get<ProdajnoMestoService>().GetAll();
            aps.ForEach(o =>
            {
                o.ReceptList = null;
                o.LekList = null;
                o.ZaposleniList = null;
            });

            return aps;
        }

        // GET api/ProdajnoMesto/5
        public ProdajnoMesto Get(int id)
        {
            var o = ServiceProvider.Get<ProdajnoMestoService>().Get(id);

            if (o == null)
                return null;

            o.ReceptList = null;
            o.LekList = null;
            o.ZaposleniList = null;

            return o;
        }

        // POST api/ProdajnoMesto
        public bool Post([FromBody] ProdajnoMesto obj)
        {
            try
            {
                ServiceProvider.Get<ProdajnoMestoService>().Create(obj);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        // PUT api/ProdajnoMesto/5
        public void Put(int id, [FromBody] ProdajnoMesto obj)
        {
            ServiceProvider.Get<ProdajnoMestoService>().Update(id, obj);
        }

        // DELETE api/ProdajnoMesto/5
        public void Delete(int id)
        {
            ServiceProvider.Get<ProdajnoMestoService>().Delete(id);
        }
    }
}