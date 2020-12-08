using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Tye.Hosting.Model
{
    public class DockerExtraHostMapping
    {
        public DockerExtraHostMapping(string additionalHost, string hostInDocker)
        {
            AdditionalHost = additionalHost;
            HostInDocker = hostInDocker;
        }

        public string AdditionalHost { get; }
        public string HostInDocker { get; }
    }
}
