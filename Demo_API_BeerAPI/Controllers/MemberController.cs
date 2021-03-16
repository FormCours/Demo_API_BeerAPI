using Demo_API_Intro.Models;
using Demo_API_Intro.ServiceData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Toolbox.Token;

namespace Demo_API_Intro.Controllers
{
    [RoutePrefix("api/Member")]
    [AllowAnonymous]
    public class MemberController : ApiController
    {
        // Pour que le JWT soit interprété par le systeme ASP.Net Framework
        //  - Ajout de la classe de démarrage Owin
        //  - On configure la lecture du token

        // Pour cela, il est necessaire d'ajouter les nuget packages : 
        //  - Dépendences de Owin (=> Installer automatiquement)
        //  - Microsoft.Owin.Security.Jwt
        //  - Microsoft.Owin.Host.SystemWeb
        //  - Microsoft.AspNet.WebApi.Owin


        [HttpPost]
        [Route("Register")]
        public IHttpActionResult Register(MemberRegister data)
        {
            if (data is null || !ModelState.IsValid)
                return BadRequest();

            int memberId = MemberService.Instance.Add(data);
            Member member = MemberService.Instance.GetOne(memberId);

            // Return JWT
            TokenGenerated token = GenerateToken(member);
            return Json(token);
        }

        [HttpPost]
        [Route("Login")]
        public IHttpActionResult Login(MemberLogin data)
        {
            if (data is null || !ModelState.IsValid)
                return BadRequest();

            Member member = MemberService.Instance.GetWithCredential(data.Email, data.Password);

            // Return JWT
            return Json(GenerateToken(member));
        }

        private TokenGenerated GenerateToken(Member member)
        {
            TokenData tokenData = new TokenData()
            {
                UserId = member.Id.ToString(),
                Email = member.Email,
                Role = member.Role
            };
            return TokenService.GenerateToken(tokenData);
        }
    }
}
