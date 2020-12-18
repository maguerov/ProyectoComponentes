
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CloudPatterns.AWS
{
    class Program
    {
        public static ReservationMaker reservationMaker = new ReservationMaker();
        public static ReservationLibrary reservationLibrary = new ReservationLibrary();

        static void Main(string[] args)
        {

            /*Intialize and create tables if they don't already exist*/
            // reservationMaker.Init();

            //Test


            var cont = 1;

            do
            {
               cont = menu();


            } while (cont != 6);




        }


        public static int menu()
        {
            print("Menu");
            print("1. Reservar cancha");
            print("2. Ver reservaciones");
            print("3. Consultar reservacion");
            print("4. Eliminar");
            print("5. Actualizar");
            print("6. Salir");

            var option = Int32.Parse(Console.ReadLine());
            string name, dateS, timeS,name2, dateS2;
            switch (option)
            {
                case 1:
                    print("Persona encargada de la reservación:");
                    name = Console.ReadLine();
                    print("Fecha");
                    dateS = Console.ReadLine();
                    print("Hora");
                    timeS = Console.ReadLine();

                    var parsedDate = DateTime.Parse(dateS + " " + timeS);
                    print("Número de contacto");
                    var phone = Int32.Parse(Console.ReadLine());
                    print("Correo Electronico:");
                    var email = Console.ReadLine();
                    Reservation res = new Reservation
                    {
                        Fullname = name,
                        DateTime = parsedDate,
                        Phone = phone,
                        Email = email

                    };
                    
                    Create(res);
                    break;
                case 2:
                   ReadAll();
                    break;

                case 3:
                    print("Persona encargada de la reservación:");
                    name = Console.ReadLine();
                    print("Fecha");
                    dateS = Console.ReadLine();
                    print("Hora");
                    timeS = Console.ReadLine();
                    //ReadOne(name, dateS+ " "+ timeS);
                    ReadOne(name, dateS,timeS);
                    break;
                case 4:
                    print("Persona encargada de la reservación:");
                    name2 = Console.ReadLine();
                    print("Fecha");
                    dateS2 = Console.ReadLine();
                    print("Hora");
                    timeS = Console.ReadLine();
                    Delete(name2, dateS2,timeS);
                    break;
                case 5:
                    print("Persona encargada de la reservación:");
                    name2 = Console.ReadLine();
                    print("Fecha");
                    dateS2 = Console.ReadLine();
                    print("Hora");
                    timeS = Console.ReadLine();
                    Update(name2, dateS2, timeS);
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }

            return option;
        }


        public static void Create(Reservation res)
        {
            reservationLibrary.AddRes(res);
        }

        public static void Delete(string fullname, string date, string time)
        {
            /*Delete*/
            Reservation result = reservationLibrary.SearchRes(fullname,date,time).SingleOrDefault();
            if (result != null)
            {
                reservationLibrary.DeleteRes(result);
            }
        }

        public static void ReadAll()
        {
            /*Read*/
            IEnumerable<Reservation> savedRes = reservationLibrary.GetAllRes();

            foreach (var savedR in savedRes)
            {
                Console.WriteLine("Items");
                Console.WriteLine("Name : {0}", savedR.Fullname);
                Console.WriteLine("DateTime : {0}", savedR.DateTime);
                Console.WriteLine("Email : {0}", savedR.Email);
            }
        }

        public static void ReadOne(string fullname, string date,string time)
        {
            /*Read*/
            Reservation result = reservationLibrary.SearchRes(fullname, date,time).SingleOrDefault();

      
                Console.WriteLine("Items");
                Console.WriteLine("Name : {0}", result.Fullname);
                Console.WriteLine("DateTime : {0}", result.DateTime);
                Console.WriteLine("Email : {0}", result.Email);
           
        }

        public static void Update(string fullname, string date,string time)
        {
            /*Update*/
            Reservation result = reservationLibrary.SearchRes(fullname, date,time).SingleOrDefault();
            if (result != null)
            {
                //rolo fonseca
                result.Email = "Will Smith";
                reservationLibrary.ModifyRes(result);

            }
        }

        public static void print(string s)
        {
            Console.WriteLine(s);
        }


    }


}
