using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Threading.Tasks;

namespace SavedTimesCosmos
{
    public class ProgramTest
    {
        // The Azure Cosmos DB endpoint for running this sample.
        private static readonly string EndpointUri = "https://ezcosmosdb.documents.azure.com:443/";

        // The primary key for the Azure Cosmos account.
        private static readonly string PrimaryKey =
            "UOQ5lpyVLw3OjcnDXO1l5VVdbYU3xEEvTkRuHnjPWT77XavvpOmQNmQlP50mMHHsvpnvwOxtFWMEsZz3MyerSA==";

        // The Cosmos client instance
        private CosmosClient cosmosClient;

        // The database we will create
        private Database database;

        // The container we will create.
        private Container container;

        // The name of the database and container we will create
        private string databaseId = "SavedTimes";
        private string containerId = "Items";

        // <Main>
        public async Task MainTest()
        {
            try
            {
                Console.WriteLine("Beginning operations...\n");
                ProgramTest p = new ProgramTest();
                await p.GetStartedDemoAsync();
            }
            catch (CosmosException de)
            {
                Exception baseException = de.GetBaseException();
                Console.WriteLine("{0} error occurred: {1}", de.StatusCode, de);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e);
            }
            finally
            {
                Console.WriteLine("End of demo, press any key to exit.");
                Console.ReadKey();
            }
        }
        // </Main>

        // <GetStartedDemoAsync>
        /// <summary>
        /// Entry point to call methods that operate on Azure Cosmos DB resources in this sample
        /// </summary>
        public async Task GetStartedDemoAsync()
        {
            CreateInstance();
            await this.CreateDatabaseAsync();
            await this.CreateContainerAsync();
            await this.ScaleContainerAsync();
            await this.AddItemsToContainerAsync();
            await this.QueryItemsAsync();
            await this.SaveTimeItemAsync(DateTime.Now);
            await this.DeleteSavedTimeItemAsync();
            await this.DeleteDatabaseAndCleanupAsync();
        }

        public async Task InitClient()
        {
            CreateInstance();
            await this.CreateDatabaseAsync();
            await this.CreateContainerAsync();
            await this.ScaleContainerAsync();
        }


        private void CreateInstance()
        {
            this.cosmosClient = new CosmosClient(EndpointUri, PrimaryKey, new CosmosClientOptions()
                { ApplicationName = "SavedTimesCosmos", ConnectionMode = ConnectionMode.Gateway });
        }
        // </GetStartedDemoAsync>

        // <CreateDatabaseAsync>
        /// <summary>
        /// Create the database if it does not exist
        /// </summary>
        private async Task CreateDatabaseAsync()
        {
            // Create a new database
            this.database = await this.cosmosClient.CreateDatabaseIfNotExistsAsync(databaseId);
            Console.WriteLine("Created Database: {0}\n", this.database.Id);
        }
        // </CreateDatabaseAsync>

        // <CreateContainerAsync>
        /// <summary>
        /// Create the container if it does not exist. 
        /// Specifiy "/partitionKey" as the partition key path since we're storing family information, to ensure good distribution of requests and storage.
        /// </summary>
        /// <returns></returns>
        private async Task CreateContainerAsync()
        {
            // Create a new container
            this.container = await this.database.CreateContainerIfNotExistsAsync(containerId, "/partitionKey");
            Console.WriteLine("Created Container: {0}\n", this.container.Id);
        }
        // </CreateContainerAsync>

        // <ScaleContainerAsync>
        /// <summary>
        /// Scale the throughput provisioned on an existing Container.
        /// You can scale the throughput (RU/s) of your container up and down to meet the needs of the workload. Learn more: https://aka.ms/cosmos-request-units
        /// </summary>
        /// <returns></returns>
        private async Task ScaleContainerAsync()
        {
            // Read the current throughput
            try
            {
                int? throughput = await this.container.ReadThroughputAsync();
                if (throughput.HasValue)
                {
                    Console.WriteLine("Current provisioned throughput : {0}\n", throughput.Value);
                    int newThroughput = throughput.Value + 100;
                    // Update throughput
                    await this.container.ReplaceThroughputAsync(newThroughput);
                    Console.WriteLine("New provisioned throughput : {0}\n", newThroughput);
                }
            }
            catch (CosmosException cosmosException) when (cosmosException.StatusCode == HttpStatusCode.BadRequest)
            {
                Console.WriteLine("Cannot read container throuthput.");
                Console.WriteLine(cosmosException.ResponseBody);
            }
        }
        // </ScaleContainerAsync>

        // <AddItemsToContainerAsync>
        /// <summary>
        /// Add Family items to the container
        /// </summary>
        public async Task AddItemsToContainerAsync()
        {
            // Create a family object for the Morning.1 entity
            SavedTimeEntity entity = new SavedTimeEntity
            {
                Id = "Morning.2",
                PartitionKey = "Morning",
                SavedTime = DateTime.Now
            };

            try
            {
                // Read the item to see if it exists.  
                ItemResponse<SavedTimeEntity> response =
                    await this.container.ReadItemAsync<SavedTimeEntity>(entity.Id,
                        new PartitionKey(entity.PartitionKey));
                Console.WriteLine("Item in database with id: {0} already exists\n", response.Resource.Id);
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                // Create an item in the container representing the Morning Entity.
                // Note we provide the value of the partition key for this item, which is "Morning"
                ItemResponse<SavedTimeEntity> andersenFamilyResponse =
                    await this.container.CreateItemAsync<SavedTimeEntity>(entity,
                        new PartitionKey(entity.PartitionKey));

                // Note that after creating the item, we can access the body of the item with the Resource property off the ItemResponse.
                // We can also access the RequestCharge property to see the amount of RUs consumed on this request.
                Console.WriteLine("Created item in database with id: {0} Operation consumed {1} RUs.\n",
                    andersenFamilyResponse.Resource.Id, andersenFamilyResponse.RequestCharge);
            }
        }

        // </AddItemsToContainerAsync>

        // <QueryItemsAsync>
        /// <summary>
        /// Run a query (using Azure Cosmos DB SQL syntax) against the container
        /// Including the partition key value of lastName in the WHERE filter results in a more efficient query
        /// </summary>
        public async Task<List<SavedTimeEntity>> QueryItemsAsync()
        {
            var sqlQueryText = "SELECT * FROM c WHERE c.PartitionKey = 'Morning'";

            Console.WriteLine("Running query: {0}\n", sqlQueryText);

            QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
            FeedIterator<SavedTimeEntity> queryResultSetIterator =
                this.container.GetItemQueryIterator<SavedTimeEntity>(queryDefinition);

            List<SavedTimeEntity> savedTimes = new List<SavedTimeEntity>();

            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<SavedTimeEntity> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (SavedTimeEntity entity in currentResultSet)
                {
                    savedTimes.Add(entity);
                    Console.WriteLine("\tRead {0}\n", entity);
                }
            }

            return savedTimes;
        }
        // </QueryItemsAsync>

        public async Task<DateTime> GetSavedTimeItemAsync()
        {
            ItemResponse<SavedTimeEntity> response =
                await this.container.ReadItemAsync<SavedTimeEntity>("Morning.1", new PartitionKey("Morning"));
            var itemBody = response.Resource;

            // update SavedTime  to now
            return itemBody.SavedTime;
        }

        public async Task SaveTimeItemAsync(DateTime dt)
        {
            ItemResponse<SavedTimeEntity> response =
                await this.container.ReadItemAsync<SavedTimeEntity>("Morning.1", new PartitionKey("Morning"));
            var itemBody = response.Resource;

            // update SavedTime  to now
            itemBody.SavedTime = dt;


            // replace the item with the updated content
            response =
                await this.container.ReplaceItemAsync<SavedTimeEntity>(itemBody, itemBody.Id,
                    new PartitionKey(itemBody.PartitionKey));
            Console.WriteLine("Updated SavedTime");
        }

        // <DeleteFamilyItemAsync>
        /// <summary>
        /// Delete an item in the container
        /// </summary>
        public async Task DeleteSavedTimeItemAsync()
        {
            var partitionKeyValue = "Morning";
            var familyId = "Morning.1";

            // Delete an item. Note we must provide the partition key value and id of the item to delete
            ItemResponse<SavedTimeEntity> response =
                await this.container.DeleteItemAsync<SavedTimeEntity>(familyId, new PartitionKey(partitionKeyValue));
            Console.WriteLine("Deleted Entity [{0},{1}]\n", partitionKeyValue, familyId);
        }
        // </DeleteFamilyItemAsync>

        // <DeleteDatabaseAndCleanupAsync>
        /// <summary>
        /// Delete the database and dispose of the Cosmos Client instance
        /// </summary>
        public async Task DeleteDatabaseAndCleanupAsync()
        {
            DatabaseResponse databaseResourceResponse = await this.database.DeleteAsync();
            // Also valid: await this.cosmosClient.Databases["FamilyDatabase"].DeleteAsync();

            Console.WriteLine("Deleted Database: {0}\n", this.databaseId);

            //Dispose of CosmosClient
            this.cosmosClient.Dispose();
        }
        // </DeleteDatabaseAndCleanupAsync>
    }
}