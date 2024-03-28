using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Configuration
{
    public class EndpointConfiguration
    {
        public string Name { get; set; }
        public string Uri { get; set; }

        public IList<EndpointConfiguration> Endpoints { get; set; }
    }
}
