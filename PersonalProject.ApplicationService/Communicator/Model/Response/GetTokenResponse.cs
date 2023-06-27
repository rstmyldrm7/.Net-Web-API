using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProject.ApplicationService.Communicator.Model.Response
{
    public class GetTokenResponse
    {
        public bool fail { get; set; }
        public int statusCode { get; set; }
        public TokenResult result { get; set; }
        public int count { get; set; }
        public string responseCode { get; set; }
        public string responseMessage { get; set; }
    }
    public class TokenResult
    {
        public int userId { get; set; }
        public string token { get; set; }
    }
}
