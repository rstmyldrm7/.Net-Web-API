using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProject.ApplicationService.Authorization.Model
{
    public class IdentityModel
    {
        public string Lang { get; protected set; }

        public string Email { get; protected set; }
        public string UserId { get; protected set; }
        public string MemberId { get; protected set; }
        public string MemberCode { get; protected set; }
        public string MerchantId { get; protected set; }
        public string MerchantNumber { get; protected set; }
        public string UserStatus { get; protected set; }
        public string ChangePasswordRequired { get; protected set; }
        public string PasswordStatus { get; protected set; }
        public string UserRoles { get; protected set; }
        public string RoleScore { get; protected set; }
        public string TicketType { get; protected set; }
        public string UserType { get; protected set; }
        public long nbf { get; protected set; }
        public long exp { get; protected set; }
        public long iat { get; protected set; }

        public IdentityModel(string lang, string email, string userId, string memberId, string memberCode, string merchantId, string merchantNumber, string userStatus, string changePasswordRequired, string passwordStatus, string userRoles, string roleScore, string ticketType,string userType, long exp, long nbf, long iat)
        {
            Lang = lang;
            Email = email;
            UserId = userId;
            MemberId = memberId;
            MemberCode = memberCode;
            MerchantId = merchantId;
            MerchantNumber = merchantNumber;
            UserStatus = userStatus;
            ChangePasswordRequired = changePasswordRequired;
            PasswordStatus = passwordStatus;
            UserRoles = userRoles;
            RoleScore = roleScore;
            TicketType = ticketType;
            UserType = userType;
            this.nbf = nbf;
            this.iat = iat;
            this.exp = exp;
        }
    }
}
