using Report.WebApi.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Report.WebApi.ServiceRestSharp
{
    public class DirectoryServiceApi
    {
        private static DirectoryServiceApi _DirectoryServiceApiInstance;
        private RestClient client = new RestClient("http://localhost:5000/services/directory");
        public static DirectoryServiceApi DirectoryServiceApiGetIntance()
        {
            _DirectoryServiceApiInstance = _DirectoryServiceApiInstance ?? new DirectoryServiceApi();
            return _DirectoryServiceApiInstance;
        }
        public IRestResponse<List<ContactInformationsEntity>> GetContactInformation()
        {
            
            RestRequest request = new RestRequest();
            request.Method = Method.GET;
            request.Resource = "ContactInformation/GetAll";

            return client.Execute<List<ContactInformationsEntity>>(request);
        }
    }
}
