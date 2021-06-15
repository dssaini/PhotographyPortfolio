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
    public class TagsController : ControllerBase
    {
        #region Global
        public readonly ItagServices _tagService;
        public TagsController(ItagServices tagService)
        {
            _tagService = tagService;
        }
        #endregion

        [HttpGet("getAllTags")]
        [ProducesResponseType(typeof(TagListViewModel), 200)]
        #region getAllTags
        public IActionResult getAllTags(bool isAdmin)
        {
            try
            {
                var response = this._tagService.getAllTags(isAdmin);
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

        [HttpGet("GetTagsById")]
        [ProducesResponseType(typeof(TagViewModel), 200)]
        #region GetTagsById
        public IActionResult GetTagsById(int id, bool isAdmin)
        {
            try
            {
                var response = this._tagService.getTagsById(isAdmin, id);
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
        [HttpPost("AddTags")]
        [ProducesResponseType(typeof(BaseViewModel), 200)]
        #region AddTags
        public IActionResult AddTags(TagViewModel tagViewModel)
        {
            try
            {
                int? response = this._tagService.AddTag(tagViewModel);
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
