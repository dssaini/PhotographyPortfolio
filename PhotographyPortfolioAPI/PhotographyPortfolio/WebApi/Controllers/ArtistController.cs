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
    public class ArtistController : ControllerBase
    {
        #region Global
        public readonly IArtistServices _artistService;
        public ArtistController(IArtistServices artistServices)
        {
            _artistService = artistServices;   
        }
        #endregion

        [HttpGet("getAllArtist")]
        [ProducesResponseType(typeof(AboutTheArtistListViewModel), 200)]
        #region GetAllArtist
        public IActionResult GetAllArtist(bool isAdmin)
        {
            try
            {
                var response = this._artistService.getAllArtist(isAdmin);
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

        [HttpGet("GetArtistById")]
        [ProducesResponseType(typeof(AboutTheArtistViewModel), 200)]
        #region GetArtistById
        public IActionResult GetArtistById(int id, bool isAdmin)
        {
            try
            {
                var response = this._artistService.getArtistById(isAdmin, id);
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

        [HttpPost("AddArtist")]
        [ProducesResponseType(typeof(BaseViewModel), 200)]
        #region AddArtist
        public IActionResult AddArtist(AboutTheArtistViewModel artistViewModel)
        {
            try
            {
                int? response = this._artistService.AddArtist(artistViewModel);
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
