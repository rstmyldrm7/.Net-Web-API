using MediatR;
using PersonalProject.ApplicationService.Communicator.Abstract;
using PersonalProject.Domain.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using static Kimlik.KPSPublicSoapClient;

namespace PersonalProject.ApplicationService.Communicator.Concrete
{
    public class KimlikCommunicator : IKimlikCommunicator
    {
        public async Task<bool> VerifyIdentity(long IdentityNumber, string Name, string Surname, DateTime BirthYear)
        {
            try
            {
                using (Kimlik.KPSPublicSoapClient servis = new Kimlik.KPSPublicSoapClient(EndpointConfiguration.KPSPublicSoap))
                {
                    var response = await servis.TCKimlikNoDogrulaAsync(IdentityNumber, Name.ToUpper(), Surname.ToUpper(), BirthYear.Year);
                    return response.Body.TCKimlikNoDogrulaResult;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
