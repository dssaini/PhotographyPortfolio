using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enums;
using Core.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Dashboard;
using ViewModels;
using ViewModels.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        #region Global
        private readonly IDashboardService _dashboardService;
        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }
        #endregion
        [HttpGet("getDashboard")]
        [ProducesResponseType(typeof(DashboardViewModel), 200)]
        #region getDashboard
        public IActionResult getDashboard(bool isAdmin)
        {
            try
            {
                var response = this._dashboardService.getDashBoard(isAdmin);
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

    }
}
