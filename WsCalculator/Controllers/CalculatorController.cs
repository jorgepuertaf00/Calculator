using Calculator.BL;
using Commons.DTO;
using Data;
using System;
using System.Linq;
using System.Web.Http;
using WsCalculator.Models;

namespace WsCalculator.Controllers
{
    [RoutePrefix("api/calculator")]
    public class CalculatorController : ApiController
    {
        private readonly JournalDBOperations journalDBOperations = new JournalDBOperations();

        /// <summary>
        /// A JSON with result operation.
        /// </summary>
        /// <returns>A JSON with result operation.</returns>
        [Route("add")]
        [HttpPost] //Always explicitly state the accepted HTTP method
        public IHttpActionResult Add([FromBody]RootAddRequest rootRequest)
        {

            ContextOperation context = new ContextOperation();
            RootAddResponse rootResponse = new RootAddResponse()
            {
                Sum = context.Sum(rootRequest.Addends)
            };


            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
            string XEviTrackingId = string.Empty;
            if (headers.Contains("XEviTrackingId"))
            {
                XEviTrackingId = headers.GetValues("XEviTrackingId").FirstOrDefault();

                OperationDTO operation = new OperationDTO()
                {
                    Calculation = String.Join(context.MultipleArgsOperationStrategy.OperatorCode, rootRequest.Addends) + "=" + rootResponse.Sum,
                    Id = XEviTrackingId,
                    Date = DateTime.Now,
                    Operation = context.MultipleArgsOperationStrategy.Name
                };

                this.journalDBOperations.PersistOperation(operation);

            }

            return Ok(rootResponse);
        }


        /// <summary>
        /// A JSON with result operation.
        /// </summary>
        /// <returns>A JSON with result operation.</returns>
        [Route("sub")]
        [HttpPost] //Always explicitly state the accepted HTTP method
        public IHttpActionResult Sub([FromBody]RootSubRequest rootRequest)
        {

            ContextOperation context = new ContextOperation();
            RootSubResponse rootResponse = new RootSubResponse()
            {
                Difference = context.Diff(rootRequest.Minuend, rootRequest.Subtrahend)
            };


            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
            string XEviTrackingId = string.Empty;
            if (headers.Contains("XEviTrackingId"))
            {
                XEviTrackingId = headers.GetValues("XEviTrackingId").FirstOrDefault();


                OperationDTO operation = new OperationDTO()
                {
                    Calculation = (rootRequest.Minuend + context.BinaryOperationStrategy.OperatorCode + rootRequest.Subtrahend) + "=" + rootResponse.Difference,
                    Id = XEviTrackingId,
                    Date = DateTime.Now,
                    Operation = context.BinaryOperationStrategy.Name
                };
                this.journalDBOperations.PersistOperation(operation);
            }

            return Ok(rootResponse);
        }

        /// <summary>
        /// A JSON with result operation.
        /// </summary>
        /// <returns>A JSON with result operation.</returns>
        [Route("mult")]
        [HttpPost] //Always explicitly state the accepted HTTP method
        public IHttpActionResult Mult([FromBody]RootMultRequest rootRequest)
        {
            ContextOperation context = new ContextOperation();
            RootMultResponse rootResponse = new RootMultResponse()
            {
                Product = context.Multiply(rootRequest.Factors)
            };

            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
            string XEviTrackingId = string.Empty;
            if (headers.Contains("XEviTrackingId"))
            {
                XEviTrackingId = headers.GetValues("XEviTrackingId").FirstOrDefault();

                OperationDTO operation = new OperationDTO()
                {
                    Calculation = String.Join(context.MultipleArgsOperationStrategy.OperatorCode, rootRequest.Factors) + "=" + rootResponse.Product,
                    Id = XEviTrackingId,
                    Date = DateTime.Now,
                    Operation = context.MultipleArgsOperationStrategy.Name
                };

                this.journalDBOperations.PersistOperation(operation);
            }

            return Ok(rootResponse);
        }

        /// <summary>
        /// A JSON with result operation.
        /// </summary>
        /// <returns>A JSON with result operation.</returns>
        [Route("div")]
        [HttpPost] //Always explicitly state the accepted HTTP method
        public IHttpActionResult Div([FromBody]RootDivRequest rootRequest)
        {
            double remainder = 0;
            ContextOperation context = new ContextOperation();
            RootDivResponse rootResponse = new RootDivResponse()
            {
                Quotient = context.Division(rootRequest.Dividend, rootRequest.Divisor, out remainder),
                Remainder = remainder
            };


            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
            string XEviTrackingId = string.Empty;
            if (headers.Contains("XEviTrackingId"))
            {
                XEviTrackingId = headers.GetValues("XEviTrackingId").FirstOrDefault();


                OperationDTO operation = new OperationDTO()
                {
                    Calculation = (rootRequest.Dividend + context.BinaryOperationStrategy.OperatorCode + rootRequest.Divisor) + "=" + rootResponse.Quotient,
                    Id = XEviTrackingId,
                    Date = DateTime.Now,
                    Operation = context.BinaryOperationStrategy.Name
                };
                this.journalDBOperations.PersistOperation(operation);
            }


            return Ok(rootResponse);
        }

        /// <summary>
        /// A JSON with result operation.
        /// </summary>
        /// <returns>A JSON with result operation.</returns>
        [Route("sqrt")]
        [HttpPost] //Always explicitly state the accepted HTTP method
        public IHttpActionResult Sqrt([FromBody]RootSqrtRequest rootRequest)
        {
            ContextOperation context = new ContextOperation();
            RootSqrtResponse rootResponse = new RootSqrtResponse()
            {
                Square = context.Square(rootRequest.Number),
            };

            System.Net.Http.Headers.HttpRequestHeaders headers = this.Request.Headers;
            string XEviTrackingId = string.Empty;
            if (headers.Contains("XEviTrackingId"))
            {
                XEviTrackingId = headers.GetValues("XEviTrackingId").FirstOrDefault();


                OperationDTO operation = new OperationDTO()
                {
                    Calculation = (context.UnaryOperationStrategy.OperatorCode + rootRequest.Number) + "=" + rootResponse.Square,
                    Id = XEviTrackingId,
                    Date = DateTime.Now,
                    Operation = context.UnaryOperationStrategy.Name
                };
                this.journalDBOperations.PersistOperation(operation);
            }

            return Ok(rootResponse);
        }
    }
}
