using Microsoft.IdentityModel.Tokens;
using Operational.Service.Security;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;

namespace Operational.Repository.Security
{
    public class TokenService : ITokenService
    {
        public bool IsTokenValid(string key, string issuer, string token)
        {
            var mySecret = Encoding.UTF8.GetBytes(key);
            var mySecurityKey = new SymmetricSecurityKey(mySecret);

            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                if (DBValidToken(token))
                {
                    tokenHandler.ValidateToken(token, new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = issuer,
                        ValidAudience = issuer,
                        IssuerSigningKey = mySecurityKey,
                    }, out SecurityToken validatedToken);
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public string GetTokenUserName(string token)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token);
                var tokenS = jsonToken as JwtSecurityToken;
                token = tokenS.Claims.First(claim => claim.Type == "sub").Value;
            }
            catch
            {
                return token;
            }
            return token;
        }

        private bool DBValidToken(string jw_token)
        {
            bool Isvalid = false;
            using (SqlConnection objConnection = Connection.GetConnection())
            {
                string query = "SELECT user_name FROM users_token where jw_token='" + jw_token + "' and expaire_date_time > '" + DateTime.Now + "'";
                SqlCommand cmd = new(query, objConnection);
                using (IDataReader dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Isvalid = true;
                    }
                }

                objConnection.Close();
                return Isvalid;
            }
        }
    }
}
