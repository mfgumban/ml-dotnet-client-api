using DataServices.Test;
using MarkLogic.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;

namespace DSMVC.App_Start
{
    public class MarklogicContext
    {
       public IDatabaseClient dbClient;
        // what if we generate
       public BasicTestsClientService basicTestsClientService;
        
        public MarklogicContext()
        {
            var credentials = new NetworkCredential(ConfigurationManager.AppSettings["mlUser"], ConfigurationManager.AppSettings["mlPassword"], "public");
            dbClient = DatabaseClientFactory.Create(UriScheme.Http, ConfigurationManager.AppSettings["mlHost"], 8019, credentials, AuthenticationType.Digest);
            basicTestsClientService = BasicTestsClientService.Create(dbClient);
        }

    }
}