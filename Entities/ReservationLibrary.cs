using Amazon.DynamoDBv2.DocumentModel;
using CloudPatterns.AWS.DynamoDb;
using Entities_POJO;
using System.Collections.Generic;


namespace CloudPatterns.AWS
{
    class ReservationLibrary
    {
        private readonly DynamoService _dynamoService;

        public ReservationLibrary()
        {
            _dynamoService = new DynamoService();
        }

        public void AddRes(Reservation res)
        {
            _dynamoService.Store(res);
        }

        public void ModifyRes(Reservation res)
        {
            _dynamoService.UpdateItem(res);
        }

        public IEnumerable<Reservation> GetAllRes()
        {
            return _dynamoService.GetAll<Reservation>();
        }

        public IEnumerable<Reservation> SearchRes(string fullName, string datetime)
        {
            IEnumerable<Reservation> filteredDvds = _dynamoService.DbContext.Query<Reservation>(fullName, QueryOperator.Equal, datetime);

            return filteredDvds;
        }

        public void DeleteRes(Reservation res)
        {
            _dynamoService.DeleteItem(res);
        }

        #region TODO
        //public List<DVD> SearchDvdByTitle(string title)
        //{
        //    // Define item hash-key
        //    var hashKey = new AttributeValue { S = title };

        //    // Create the key conditions from hashKey
        //    var keyConditions = new Dictionary<string, Condition>
        //    {
        //        // Hash key condition. ComparisonOperator must be "EQ".
        //        { 
        //            "Title",
        //            new Condition
        //            {
        //                ComparisonOperator = "EQ",
        //                AttributeValueList = new List<AttributeValue> { hashKey }
        //            }
        //        }
        //    };

        //    // Define marker variable
        //    Dictionary<string, AttributeValue> startKey = null;

        //    do
        //    {
        //        // Create Query request
        //        var request = new QueryRequest
        //        {
        //            TableName = "DVD",
        //            ExclusiveStartKey = startKey,
        //            KeyConditions = keyConditions
        //        };

        //        // Issue request
        //        var result = _dynamoService.DynamoClient.Query(request);

        //        // View all returned items
        //        List<Dictionary<string, AttributeValue>> items = result.Items;
        //        foreach (Dictionary<string, AttributeValue> item in items)
        //        {
        //            foreach (var keyValuePair in item)
        //            {
        //                Console.WriteLine("{0} : S={1}, N={2}, SS=[{3}], NS=[{4}]",
        //                    keyValuePair.Key,
        //                    keyValuePair.Value.S,
        //                    keyValuePair.Value.N,
        //                    string.Join(", ", keyValuePair.Value.SS ?? new List<string>()),
        //                    string.Join(", ", keyValuePair.Value.NS ?? new List<string>()));
        //            }
        //        }

        //        // Set marker variable
        //        startKey = result.LastEvaluatedKey;
        //    } while (startKey != null && startKey.Count > 0);

        //    return new List<DVD>();

        //}
        #endregion
    }
}
