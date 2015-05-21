using DotNetOracleLogger.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DotNetOracleLogger.Controllers
{
    public class LogsController : ApiController
    {
        // GET api/logs
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/logs/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/logs
        public void Post([FromBody]LogRequestMessage value)
        {

            Log4NetLogger.LoggerMsg(Log4NetLoggerLevel.Info, value.logger, value.message);

            try
            {
                var aa = 2;
                var bb = 0;
                var a = aa / bb;
            }
            catch (Exception e)
            {
                Log4NetLogger.LoggerMsgException(Log4NetLoggerLevel.Error, value.logger, "Exception!", e);
            }

        }

        // PUT api/logs/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/logs/5
        public void Delete(int id)
        {
        }
    }
}
