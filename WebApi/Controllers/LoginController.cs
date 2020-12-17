using CloudPatterns.AWS;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi.Models;

namespace WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        ApiResponse response = new ApiResponse();
        ReservationLibrary reservationLibrary = new ReservationLibrary();
        public IHttpActionResult Post(Reservation res)
        {


            try
            {
                string date = "2020-01-01";
                string time = "T16:00:00.000Z";
                Reservation result = reservationLibrary.SearchRes(res.Fullname,date, time).SingleOrDefault();
                if (result != null)
                {
                    response.Message = "Bienvido a SafeJob.";
                  
                }
                else
                {
                    response.Message = "Credenciales incorrectas";
                }
                

                return Ok(response.Message);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }
    }
}