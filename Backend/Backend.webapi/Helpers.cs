using System.IdentityModel.Tokens.Jwt;

namespace Backend.webapi;

public static class Helpers
{
    public static int GetUserIdFromJwt(string jwt)
    {
        jwt = jwt.Replace("Bearer ", "");
        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadJwtToken(jwt);
        return int.Parse(token.Claims.First(x => x.Type.Equals("userId")).Value);
    }

    public static string GetUserLoginFromJwt(string jwt)
    {
        jwt = jwt.Replace("Bearer ", "");
        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadJwtToken(jwt);
        return token.Claims.First(x => x.Type.Equals("userLogin")).Value;
    }
}