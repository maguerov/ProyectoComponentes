using System;
using Amazon.DynamoDBv2.DataModel;

namespace Entities_POJO
{
    public class Reservation
    {

        [DynamoDBHashKey]
        public string Fullname { get; set; }
        [DynamoDBRangeKey]
        public DateTime DateTime { get; set; }

        public int Phone { get; set; }

        public string Email { get; set; }


    }
}
