using JXTNext.Sitefinity.SalarySurvey.Web.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace JXTNext.Sitefinity.SalarySurvey.Web.Services.Interfaces
{
    [ServiceContract]
    public interface ISalaryAlert
    {
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        SalaryAlertMetaDataResponseModel MetaData();
    }
}
