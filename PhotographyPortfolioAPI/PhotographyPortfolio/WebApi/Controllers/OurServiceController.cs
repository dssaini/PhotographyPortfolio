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
    public class OurServiceController : ControllerBase
    {
        #region Global
        public readonly IOurServices _ouservices;
        public OurServiceController(IOurServices ourServices)
        {
            _ouservices = ourServices;
        }
        #endregion

        [HttpGet("getAllServices")]
        [ProducesResponseType(typeof(OurServicesListViewModel), 200)]
        #region getAllServices
        public IActionResult getAllServices(bool isAdmin)
        {
            try
            {
                var response = this._ouservices.getAllService(isAdmin);
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

        [HttpGet("GetServicesById")]
        [ProducesResponseType(typeof(OurServicesViewModel), 200)]
        #region GetServicesById
        public IActionResult GetServicesById(int id, bool isAdmin)
        {
            try
            {
                var response = this._ouservices.getServicesById(isAdmin, id);
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

        [HttpPost("AddService")]
        [ProducesResponseType(typeof(BaseViewModel), 200)]
        #region AddService
        public IActionResult AddService(OurServicesViewModel servicesViewModel)
        {
            try
            {
                int? response = this._ouservices.AddServices(servicesViewModel);
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
