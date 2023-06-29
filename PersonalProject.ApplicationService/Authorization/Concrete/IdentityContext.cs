using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using PersonalProject.ApplicationService.Authorization.Abstract;
using PersonalProject.ApplicationService.Authorization.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProject.ApplicationService.Authorization.Concrete
{
    public class IdentityContext : IIdentityContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IdentityContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IdentityModel GetInfo(string token)
        {
            if (!string.IsNullOrEmpty(token))
            {
                JwtSecurityToken jwtSecurityToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
                string lang = ((jwtSecurityToken.Claims.FirstOrDefault((Claim c) => c.Type == "Lang") != null) ? jwtSecurityToken.Claims.FirstOrDefault((Claim c) => c.Type == "Lang")!.Value : "");
                string email = ((jwtSecurityToken.Claims.FirstOrDefault((Claim c) => c.Type == "Email") != null) ? jwtSecurityToken.Claims.FirstOrDefault((Claim c) => c.Type == "Email")!.Value : "");
                string userId = ((jwtSecurityToken.Claims.FirstOrDefault((Claim c) => c.Type == "UserId") != null) ? jwtSecurityToken.Claims.FirstOrDefault((Claim c) => c.Type == "UserId")!.Value : "");
                string memberId = ((jwtSecurityToken.Claims.FirstOrDefault((Claim c) => c.Type == "MemberId") != null) ? jwtSecurityToken.Claims.FirstOrDefault((Claim c) => c.Type == "MemberId")!.Value : "");
                string memberCode = ((jwtSecurityToken.Claims.FirstOrDefault((Claim c) => c.Type == "MemberCode") != null) ? jwtSecurityToken.Claims.FirstOrDefault((Claim c) => c.Type == "MemberCode")!.Value : "");
                string merchantId = ((jwtSecurityToken.Claims.FirstOrDefault((Claim c) => c.Type == "MerchantId") != null) ? jwtSecurityToken.Claims.FirstOrDefault((Claim c) => c.Type == "MerchantId")!.Value : "");
                string merchantNumber = ((jwtSecurityToken.Claims.FirstOrDefault((Claim c) => c.Type == "MerchantNumber") != null) ? jwtSecurityToken.Claims.FirstOrDefault((Claim c) => c.Type == "MerchantNumber")!.Value : "");
                string userStatus = ((jwtSecurityToken.Claims.FirstOrDefault((Claim c) => c.Type == "UserStatus") != null) ? jwtSecurityToken.Claims.FirstOrDefault((Claim c) => c.Type == "UserStatus")!.Value : "");
                string changePasswordRequired = ((jwtSecurityToken.Claims.FirstOrDefault((Claim c) => c.Type == "ChangePasswordRequired") != null) ? jwtSecurityToken.Claims.FirstOrDefault((Claim c) => c.Type == "ChangePasswordRequired")!.Value : "");
                string passwordStatus = ((jwtSecurityToken.Claims.FirstOrDefault((Claim c) => c.Type == "PasswordStatus") != null) ? jwtSecurityToken.Claims.FirstOrDefault((Claim c) => c.Type == "PasswordStatus")!.Value : "");
                string userRoles = ((jwtSecurityToken.Claims.FirstOrDefault((Claim c) => c.Type == "UserRoles") != null) ? jwtSecurityToken.Claims.FirstOrDefault((Claim c) => c.Type == "UserRoles")!.Value : "");
                string roleScore = ((jwtSecurityToken.Claims.FirstOrDefault((Claim c) => c.Type == "RoleScore") != null) ? jwtSecurityToken.Claims.FirstOrDefault((Claim c) => c.Type == "RoleScore")!.Value : "");
                string ticketType = ((jwtSecurityToken.Claims.FirstOrDefault((Claim c) => c.Type == "TicketType") != null) ? jwtSecurityToken.Claims.FirstOrDefault((Claim c) => c.Type == "TicketType")!.Value : "");
                string userType = ((jwtSecurityToken.Claims.FirstOrDefault((Claim c) => c.Type == "UserType") != null) ? jwtSecurityToken.Claims.FirstOrDefault((Claim c) => c.Type == "UserType")!.Value : "");
                long nbf = ((jwtSecurityToken.Claims.FirstOrDefault((Claim c) => c.Type == "nbf") != null) ? Convert.ToInt64(jwtSecurityToken.Claims.FirstOrDefault((Claim c) => c.Type == "nbf")!.Value) : 0);
                long exp = ((jwtSecurityToken.Claims.FirstOrDefault((Claim c) => c.Type == "exp") != null) ? Convert.ToInt64(jwtSecurityToken.Claims.FirstOrDefault((Claim c) => c.Type == "exp")!.Value) : 0);
                long iat = ((jwtSecurityToken.Claims.FirstOrDefault((Claim c) => c.Type == "iat") != null) ? Convert.ToInt64(jwtSecurityToken.Claims.FirstOrDefault((Claim c) => c.Type == "iat")!.Value) : 0);
                return new IdentityModel(lang, email, userId, memberId, memberCode, merchantId, merchantNumber,
                    userStatus, changePasswordRequired, passwordStatus, userRoles, roleScore, ticketType, userType, exp,
                    nbf, iat);
            }
            throw new Exception();
        }
    }
}
