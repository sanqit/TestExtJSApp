using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using TestExtJSApp.BL;


namespace TestExtJSApp.Services
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DataService" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select DataService.svc or DataService.svc.cs at the Solution Explorer and start debugging.
	[ServiceContract(Namespace = "")]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class DataService
	{
		/// <summary>
		/// получить данные для store
		/// </summary>
		/// <param name="limit"></param>
		/// <param name="page"></param>
		/// <param name="start"></param>
		/// <returns></returns>
		[OperationContract]
		public Stream GetData(int limit, int page, int start)
		{
			// За счет того, что все типы, учавствующие в бизнесс логике, можно сконфигурировать различные реализации, используя Construct Injection
			IAddressIterator data = new AddressIterator(100);
			return GetResponseData(data);
		}

		private static Stream GetResponseData<T>(IEnumerable<T> list)
		{
			var resultBytes = Encoding.UTF8.GetBytes(SerializeToExtJson(list));
			WebOperationContext.Current.OutgoingResponse.ContentType = "text/plain";
			return new MemoryStream(resultBytes);
		}

		private static string SerializeToExtJson<T>(IEnumerable<T> list)
		{
			if (list != null && list.Count() > 0)
			{
				return string.Format("{{total:{1},'data':{0}}}", JsonConvert.SerializeObject(list), list.Count());
			}
			return "{total:0,'data':0}";
		}
	}
}
