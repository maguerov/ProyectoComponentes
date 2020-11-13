using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi.Models;
using Entities_POJO;
using DynamoDbDemo.Entities;
using CloudPatterns.AWS;

namespace WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
    [RoutePrefix("api/Registro")]
    public class RegistroController:ApiController
    {
        ApiResponse response = new ApiResponse();

        public IHttpActionResult Post(Prueba res)
        {
            //comentario branch
            ReservationLibrary reservationLibrary = new ReservationLibrary();
            try
            {
                DateTime localDate = DateTime.Now;
                //encriptar contraseña
                Reservation res2 = new Reservation
                {
                    Fullname = "Dios",
                    DateTime = localDate,
                    Phone = 888888888,
                    Email = "dios@gmail.com"

                };
                reservationLibrary.AddRes(res2);
                response.Message = "Bienvido a SafeJob.";
                
                return Ok(response.Message);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }
    }
}