using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SoftPlanAPI.Queries;
using System.Net;
using SoftPlanAPI.Queries.IQueries;
using SoftPlanAPI.Services;

namespace SoftPlanAPI.Controllers
{
    [Route("api/v{version:apiversion}/interestTaxes")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class InterestTaxesController : ControllerBase
    {
        #region Construtor/Injection
        //public readonly IProjectRepository _project;
        private readonly IInterestTax _interest;

        public InterestTaxesController(IInterestTax interest)
            => _interest = interest;
        #endregion

        #region Get List of Projects
        /// <summary>
        /// Get the Interest taxes
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("taxaJuros")]
        [ProducesResponseType(200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ResponseMessage<decimal>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetInterestTaxes()
        {
            ResponseMessage<decimal> result = _interest.GetInterestTax();
            return Ok(result);
        }
        #endregion
    }
}