using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MS.Afterworks.HappyFace.Cognitive
{
    /// <summary>
    /// container for subscription credentials. Make sure to enter 
    /// </summary>
    public class ApiKeyServiceClientCredentials : ServiceClientCredentials
    {
        public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("Ocp-Apim-Subscription-Key", "ENTER KEY HERE");
            return base.ProcessHttpRequestAsync(request, cancellationToken);
        }
    }
}
