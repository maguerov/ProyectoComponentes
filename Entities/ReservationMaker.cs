using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudPatterns.AWS
{
    class ReservationMaker
    {
        private readonly AmazonDynamoDBClient _client;
        public ReservationMaker()
        {
            _client = new AmazonDynamoDBClient();

        }

        
        public List<Reservation> Reservations => new List<Reservation>
                {
                    new Reservation
                    {
                        Fullname = "Marlon",
                        DateTime = DateTime.UtcNow ,
                        Phone = 888888888,
                        Email = "m@gmail.com"

                    },

                    new Reservation
                    {
                        Fullname = "Migue",
                        DateTime = DateTime.UtcNow ,
                        Phone = 882222888,
                        Email = "migue@gmail.com"

                    },
                    new Reservation
                    {
                     Fullname = "Tray",
                        DateTime = DateTime.UtcNow ,
                        Phone = 2333333,
                        Email = "tray@gmail.com"

                    },

                };
        public void Init()
        {
            List<string> currentTables = _client.ListTables().TableNames;
            if (!currentTables.Contains("Reservation"))
            {
                var createTableRequest = new CreateTableRequest
                {
                    TableName = "Reservation",
                    ProvisionedThroughput = new ProvisionedThroughput
                    {
                        ReadCapacityUnits = 1,
                        WriteCapacityUnits = 1
                    },
                    KeySchema = new List<KeySchemaElement>
                    {
                        new KeySchemaElement
                        {
                            AttributeName = "Fullname",
                            KeyType = "HASH"
                        },
                        new KeySchemaElement
                        {
                            AttributeName = "DateTime",
                            KeyType = "RANGE"
                        },
                    },
                    AttributeDefinitions = new List<AttributeDefinition>()
                    {
                        new AttributeDefinition()
                        {
                            AttributeName = "Fullname",AttributeType = "S"
                        },
                        new AttributeDefinition()
                        {
                            AttributeName = "DateTime",AttributeType = "S"
                        }
                    
                }
                
                };

                CreateTableResponse createTableResponse = _client.CreateTable(createTableRequest);

                while (createTableResponse.TableDescription.TableStatus != "ACTIVE")
                {
                    System.Threading.Thread.Sleep(5000);
                }
            }

        }
    }
}

