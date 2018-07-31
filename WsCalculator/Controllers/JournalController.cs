using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Commons.DTO;
using Data;
using WsCalculator.Models;

namespace WsCalculator.Controllers
{
    [RoutePrefix("api/journal")]
    public class JournalController : ApiController
    {

        private readonly JournalDBOperations journalDBOperations = new JournalDBOperations();

        /// <summary>
        /// A JSON with result operation.
        /// </summary>
        /// <returns>A JSON with result operation.</returns>
        [Route("query")]
        [HttpPost] //Always explicitly state the accepted HTTP method
        public IHttpActionResult Query([FromBody]RootQueryRequest rootRequest)
        {
            RootQueryResponse rootResponse = new RootQueryResponse()
            {
                Operations = journalDBOperations.GetOperationsById(rootRequest.Id)
            };

            return Ok(rootResponse);
        }
    }
}