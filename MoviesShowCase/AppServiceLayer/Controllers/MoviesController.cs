using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL.Models;
namespace AppServiceLayer.Controllers
{
  
    public class MoviesController : ApiController
    {
        MovieDAL MoviesDAL = new MovieDAL();

        [HttpPost]
        [Route("Movie/SaveMovie")]
        public HttpResponseMessage PostEmpInfo(Movie movie)
        {
           var result= MoviesDAL.AddMovie(movie);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
          }

        [HttpDelete]
        [Route("Movie/DeleteEmp/{id}")]
        public HttpResponseMessage DeleteMovie(int id)
        {
            var result = MoviesDAL.DeleteMovie(id);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [HttpPut]
        [Route("Movie/UpdateEmp")]
        public HttpResponseMessage UpdateMoview([FromBody] Movie movie)
        {
            var result = MoviesDAL.UpdateMovie(movie);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [HttpGet]
        [Route("Movie/GetAll")]
        public HttpResponseMessage GetAllEmpInfo()
        {
            var movieInfoes = MoviesDAL.GetallMovies();
            if (movieInfoes!=null)
            {
                return Request.CreateResponse(HttpStatusCode.OK,movieInfoes);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [HttpGet]
        [Route("Movie/GetById/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            var movieInfo = MoviesDAL.GetMovieById(id);
            if (movieInfo != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, movieInfo);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }


    }
}
