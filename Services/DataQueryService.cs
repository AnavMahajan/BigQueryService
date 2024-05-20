using Google.Cloud.BigQuery.V2;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendApi.DataServices
{
    public class DataQueryService
    {
        private readonly BigQueryClient _client;

        public DataQueryService(string projectId)
        {
            // Creating BigQueryClient using the provided project ID
            _client = BigQueryClient.Create(projectId);
        }

        public async Task<List<BigQueryRow>> QueryData(string query)
        {
            var result = await _client.ExecuteQueryAsync(query, parameters: new List<BigQueryParameter>());
            var rows = new List<BigQueryRow>();

            await foreach (var row in result.GetRowsAsync())
            {
                rows.Add(row);
            }

            return rows;
        }
    }
}
