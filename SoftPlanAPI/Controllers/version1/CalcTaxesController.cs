using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using MediatR;
using SoftPlanAPI.Queries.IQueries;
using SoftPlanAPI.Queries;
using SoftPlanAPI.Services;

namespace SoftPlanAPI.Controllers
{
    [Route("api/v{version:apiversion}/calcTaxes")]
    [ApiVersion("1.0")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class CalcTaxesController : ControllerBase
    {
        #region Construtor/Injection        
        private readonly IInterestTax _interest;

        public CalcTaxesController(IInterestTax interest)
        {
            _interest = interest;
        }
        #endregion

        /// <summary>
        /// Calculing the interest
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("calculajuros/{initialValue:decimal}/{qtdMonths:int}")]
        [ProducesResponseType(typeof(ResponseMessage<decimal>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult CalculaJuros(decimal initialValue, int qtdMonths)
        {
            var InterestTaxes = _interest.GetInterestTax();

            //ResponseMessage<decimal> result = await  _mediator.Send(CalcTaxes.Factory.Create(initialValue, qtdMonths, InterestTaxes));
            return Ok();
        }

        #region Show me the code        
        /// <summary>
        /// Show me the code
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("showmethecode")]
        [ProducesResponseType(200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ResponseMessage<decimal>), (int)HttpStatusCode.OK)]
        public string ShowMeTheCode()
        {
            return "https://github.com/JoaoLuizDeveloper/SoftPlanProject";
        }
        #endregion
    }
}