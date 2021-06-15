using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enums;
using Core.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using ViewModels;
using ViewModels.ListModels;
using ViewModels.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        #region Global
        public readonly IPortfolioService _portfolioService;
        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }
        #endregion

        [HttpGet("getAllPortfolio")]
        [ProducesResponseType(typeof(PortfolioListViewModel), 200)]
        #region getAllPortfolio
        public IActionResult getAllPortfolio(bool isAdmin)
        {
            try
            {
                var response = this._portfolioService.getAllPortfolio(isAdmin);
                if (response == null)
                {
                    return Ok(new BaseViewModel
                    {
                        ResponseMessage = ResponseMessages.NoRecordFound,
                        StatusCode = ApiResponseCode.NotFound.GetResponseCode()
                    });
                }
                else
                {
                    response.StatusCode = ApiResponseCode.OK.GetResponseCode();
                    response.ResponseMessage = ResponseMessages.Success;
                    return Ok(response);
                }
            }
            catch
            {
                return Ok(new BaseViewModel
                {
                    ResponseMessage = ResponseMessages.ServerError,
                    StatusCode = ApiResponseCode.InternalServerError.GetResponseCode()
                });
            }
        }
        #endregion

        [HttpGet("GetPortfolioById")]
        [ProducesResponseType(typeof(PortfolioViewModel), 200)]
        #region GetPortfolioById
        public IActionResult GetPortfolioById(int id, bool isAdmin)
        {
            try
            {
                var response = this._portfolioService.getPortfolioById(isAdmin, id);
                if (response == null)
                {
                    return Ok(new BaseViewModel
                    {
                        ResponseMessage = ResponseMessages.NoRecordFound,
                        StatusCode = ApiResponseCode.NotFound.GetResponseCode()
                    });
                }
                else
                {
                    response.StatusCode = ApiResponseCode.OK.GetResponseCode();
                    response.ResponseMessage = ResponseMessages.Success;
                    return Ok(response);
                }
            }
            catch
            {
                return Ok(new BaseViewModel
                {
                    ResponseMessage = ResponseMessages.ServerError,
                    StatusCode = ApiResponseCode.InternalServerError.GetResponseCode()
                });
            }
        }
        #endregion

        [HttpPost("AddPortfolio")]
        [ProducesResponseType(typeof(BaseViewModel), 200)]
        #region AddPortfolio
        public IActionResult AddPortfolio(PortfolioViewModel portfolio)
        {
            try
            {
                int? response = this._portfolioService.AddPortfolio(portfolio);
                if (response == null)
                {
                    return Ok(new BaseViewModel
                    {
                        ResponseMessage = ResponseMessages.NoRecordFound,
                        StatusCode = ApiResponseCode.NotFound.GetResponseCode()
                    });
                }
                else if (response == 0)
                {
                    return Ok(new BaseViewModel
                    {
                        ResponseMessage = ResponseMessages.UnprocessableEntity,
                        StatusCode = ApiResponseCode.UnprocessableEntity.GetResponseCode()
                    });
                }
                else
                {
                    return Ok(new BaseViewModel
                    {
                        ResponseMessage = ResponseMessages.Success,
                        StatusCode = ApiResponseCode.OK.GetResponseCode()
                    });
                }

            }
            catch (Exception)
            {
                return Ok(new BaseViewModel
                {
                    ResponseMessage = ResponseMessages.ServerError,
                    StatusCode = ApiResponseCode.InternalServerError.GetResponseCode()
                });
            }
        }
        #endregion


    }
}
