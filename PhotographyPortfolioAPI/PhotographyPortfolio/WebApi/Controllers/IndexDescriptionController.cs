using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Enums;
using Core.Helpers;
using Data.Models;
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
    public class IndexDescriptionController : ControllerBase
    {
        #region Global
        public readonly IindexdescriptionService _Description;

        public IndexDescriptionController(IindexdescriptionService description, IMapper mapper)
        {
            _Description = description;
                
        }
        #endregion

        [HttpGet("GetAllIndex")]
        [ProducesResponseType(typeof(Index_descriptionListViewModel), 200)]
        #region GetAllIndex
        public IActionResult GetAllIndex(bool isAdmin)
        {
            try
            {
                var response = this._Description.getAllIndex(isAdmin);
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

        [HttpGet("GetIndexById")]
        [ProducesResponseType(typeof(Index_descriptionViewModel), 200)]
        #region GetIndexById
        public IActionResult GetCarouselById(int id, bool isAdmin)
        {
            try
            {
                var response = this._Description.getIndexById(isAdmin, id);
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

        [HttpPost("AddIndex")]
        [ProducesResponseType(typeof(BaseViewModel), 200)]
        #region AddIndex
        public IActionResult AddIndex(Index_descriptionViewModel index_DescriptionViewModel)
        {
            try
            {
                int? response = this._Description.AddIndex(index_DescriptionViewModel);
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
