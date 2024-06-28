using Application.Interfaces;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Interface;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static Domain.Entities.User;

namespace Infrastructure.Data
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IRepositoryUser _repositoryUser;
        private readonly AuthenticationServiceOptions _options;

        public AuthenticationService(IRepositoryUser repositoryUser, IOptions<AuthenticationServiceOptions> options)
        {
            _repositoryUser = repositoryUser;
            _options = options.Value;
        }

        public User? ValidateUser(AuthenticationRequest authenticationRequest)
        {
            if (string.IsNullOrEmpty(authenticationRequest.Email) || string.IsNullOrEmpty(authenticationRequest.Password))
                return null;

            //Me busca por email al objeto usuario. 
            var user = _repositoryUser.GetByEmail(authenticationRequest.Email);
            
            if (user == null) return null;

              if(user.Type == User.UserType.Client || user.Type == User.UserType.Admin)
                {
                if(user.Password == authenticationRequest.Password) return user;
                }

            return null;
        }

        public string Authenticate(AuthenticationRequest authenticationRequest)
        {
            //se fija si existe el usuario que se intenta autenticar y se comprueva mail y pass
            var user = ValidateUser(authenticationRequest);
                
            if (user == null)
            {
                throw new Exception("no encontrado");
            }

            //El secret se guarda en una variable. 
            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_options.SecretForKey));

            //El secret se hashea.
            var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

            //Se crea el Claim
            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.Id.ToString()));
            claimsForToken.Add(new Claim("given_name", user.Name));
            claimsForToken.Add(new Claim("role", user.Type.ToString() ?? UserType.Admin.ToString()));

            //Se crea el JWT de seguridad con el objeto JwtSecurityToken.
            var jwtSecurityToken = new JwtSecurityToken(
              _options.Issuer, //Quien creeo el token
              _options.Audience, //A quien va dirigido
              claimsForToken, //el Claims que tiene Id, nombre, y tipo de usuario
              DateTime.UtcNow, //Fecha de creacion
              DateTime.UtcNow.AddHours(1), //se acalara cuanto va a vivir el token, fecha de expiracion.
              credentials); //El secreto hasheado. 

            //Se crea el token de seguridad con el jwt a trabez del objeto JwtSecurityTokenHandler
            var tokenToReturn = new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);

            //Se retorna el Jwt como string
            return tokenToReturn.ToString();
        }

        public class AuthenticationServiceOptions
        {
            public const string AuthenticationService = "AuthenticationService";

            public string Issuer { get; set; } 
            public string Audience { get; set; }
            public string SecretForKey { get; set; }
        }
    }
}