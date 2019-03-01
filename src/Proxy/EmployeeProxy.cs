namespace Linn.Products.Proxy
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading;

    using Linn.Common.Proxy;
    using Linn.Common.Serialization.Json;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Repositories;
    using Linn.Products.Proxy.Exceptions;

    using Newtonsoft.Json.Linq;

    public class EmployeeProxy : IEmployeeRepository
    {
        private readonly IRestClient restClient;

        private readonly string rootUri;

        public EmployeeProxy(IRestClient restClient, string rootUri)
        {
            this.restClient = restClient;
            this.rootUri = rootUri;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            var uri = new Uri($"{this.rootUri}/employees", UriKind.RelativeOrAbsolute);
            var response = this.restClient.Get(
                CancellationToken.None,
                uri,
                new Dictionary<string, string>(),
                DefaultHeaders.JsonGetHeaders()).Result;

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ProxyException($"Error trying to get Employees");
            }

            var json = new JsonSerializer();
            var result = json.Deserialize<dynamic>(response.Value);
            var array = (JArray)result.items;
            return array.ToObject<IEnumerable<Employee>>();
        }
    }
}
