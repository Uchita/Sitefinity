using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.Connector.BusinessLogics.Mappers
{
    public interface IMemberMapper
    {
        IntegrationMapperType mapperType { get; }
        dynamic Register_ConvertToAPIEntity<T>(T registerDetails);
    }
}
