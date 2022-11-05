using System.ComponentModel.DataAnnotations;
using System.Net.Mime;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nomis.Api.Tron.Abstractions;
using Nomis.Tronscan.Interfaces;
using Nomis.Tronscan.Interfaces.Models;
using Nomis.Utils.Wrapper;
using Swashbuckle.AspNetCore.Annotations;

namespace Nomis.Api.Tron
{
    /// <summary>
    /// A controller to aggregate all Tron-related actions.
    /// </summary>
    [Route(BasePath)]
    [ApiVersion("1")]
    [SwaggerTag("Tron.")]
    internal sealed partial class TronController :
        TronBaseController
    {
        private readonly ILogger<TronController> _logger;
        private readonly ITronscanService _tronscanService;

        /// <summary>
        /// Initialize <see cref="TronController"/>.
        /// </summary>
        /// <param name="tronscanService"><see cref="ITronscanService"/>.</param>
        /// <param name="logger"><see cref="ILogger{T}"/>.</param>
        public TronController(
            ITronscanService tronscanService,
            ILogger<TronController> logger)
        {
            _tronscanService = tronscanService ?? throw new ArgumentNullException(nameof(tronscanService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Get Nomis Score for given wallet address.
        /// </summary>
        /// <param name="address" example="TWtergbRrmz7bsHduXV4vrV9NM6K53oWKh">Tron wallet address to get Nomis Score.</param>
        /// <returns>An Nomis Score value and corresponding statistical data.</returns>
        /// <remarks>
        /// Sample request:
        ///     GET /api/v1/tron/wallet/TWtergbRrmz7bsHduXV4vrV9NM6K53oWKh/score
        /// </remarks>
        /// <response code="200">Returns Nomis Score and stats.</response>
        /// <response code="400">Address not valid.</response>
        /// <response code="404">No data found.</response>
        /// <response code="500">Unknown internal error.</response>
        [HttpGet("wallet/{address}/score", Name = "GetTronWalletScore")]
        [AllowAnonymous]
        [SwaggerOperation(
            OperationId = "GetTronWalletScore",
            Tags = new[] { TronTag })]
        [ProducesResponseType(typeof(Result<TronWalletScore>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetTronWalletScoreAsync(
            [Required(ErrorMessage = "Wallet address should be set")] string address)
        {
            var result = await _tronscanService.GetWalletStatsAsync(address);
            return Ok(result);
        }
    }
}