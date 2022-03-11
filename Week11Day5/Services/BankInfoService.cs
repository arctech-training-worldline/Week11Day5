using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using WorldlineLiveServiceReference;
using System.Linq;

namespace Week11Day4.Services
{
    public class BankInfoService : IBankInfoService
    {
        public readonly string serviceUrl = "https://bankdetailsdemo.azurewebsites.net/WebServices/SoapDemo.asmx";
        public readonly EndpointAddress endpointAddress;
        public readonly BasicHttpBinding basicHttpBinding;

        public BankInfoService()
        {
            endpointAddress = new EndpointAddress(serviceUrl);

            basicHttpBinding = new BasicHttpBinding(
                endpointAddress.Uri.Scheme.ToLower() == "http" ?
                    BasicHttpSecurityMode.None :
                    BasicHttpSecurityMode.Transport)
            {
                OpenTimeout = TimeSpan.MaxValue,
                CloseTimeout = TimeSpan.MaxValue,
                ReceiveTimeout = TimeSpan.MaxValue,
                SendTimeout = TimeSpan.MaxValue
            };
        }

        public async Task<List<BankDetails>> GetByIfscAsync(string ifsc)
        {
            var wsClient = new SoapDemoSoapClient(basicHttpBinding, endpointAddress);
            var getBranchDetailsByIfscResponse = await wsClient.GetBranchDetailsByIfscAsync(ifsc);

            var x = await wsClient.GetBranchDetailsByBankAsync("STate bank", 10, 100);
            var y = await wsClient.GetBranchDetailsByIfscAsync("ICIC0000011");

            return new List<BankDetails> { getBranchDetailsByIfscResponse.Body.GetBranchDetailsByIfscResult };
        }
    }
}
