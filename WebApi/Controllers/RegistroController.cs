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
        ReservationLibrary reservationLibrary = new ReservationLibrary();

        public IHttpActionResult Get()
        {
            IEnumerable<Reservation> savedRes = reservationLibrary.GetAllRes();
            response.Data = savedRes;
            return Ok(response);
        }

        public IHttpActionResult Post(Reservation res)
        {
            //comentario branch
            //comentario branch

            try
            {
                //comentario branch
                //comentario branch
                DateTime localDate = DateTime.Now;
                //encriptar contraseña
                res.DateTime = localDate;
               Reservation res2 = new Reservation
                {
                    Fullname = "Dios22",
                    DateTime = localDate,
                    Phone = 888888888,
                    Email = "dios@gmail.com"

                };
                reservationLibrary.AddRes(res);
                response.Message = "Bienvido a SafeJob.";
                
                return Ok(response.Message);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.AppMessage.Message));
            }
        }

        public IHttpActionResult Put(Reservation res)
        {


            try
            {
                String[] result2 = res.Fullname.Split(',');
                String[] result1 = res.Email.Split('T');
                string date = result1[0];
                string time = "T" + result1[1];
                Reservation result = reservationLibrary.SearchRes(result2[0], date, time).SingleOrDefault();
                if (result != null)
                {
                    //rolo fonseca
                    result.Email = result2[1];
                    reservationLibrary.ModifyRes(result);
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