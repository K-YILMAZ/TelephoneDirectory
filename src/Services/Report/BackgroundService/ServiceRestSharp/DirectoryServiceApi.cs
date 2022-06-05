using Report.WebApi.Models;
using RestSharp;
using System.Collections.Generic;

namespace ReportBackgroundService.ServiceRestSharp
{
    public static class DirectoryServiceApi<T> where T:class
    {
        private static RestClient client = new RestClient("http://localhost:5000/services/directory");

        //"ContactInformation/GetAll"
        public static IRestResponse<List<T>> GetContactInformation(Method method,string resource,Parameter parameter)
        {
            RestRequest request = new RestRequest();
            request.Method =method;
            request.Resource =resource ;
            return client.Execute<List<T>>(request);
        }


    }
}
