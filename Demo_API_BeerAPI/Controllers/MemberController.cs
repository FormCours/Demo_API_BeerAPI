using Demo_API_Intro.Models;
using Demo_API_Intro.ServiceData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Demo_API_Intro.Controllers
{
    [RoutePrefix("api/Member")]
    public class MemberController : ApiController
    {
        [HttpPost]
        [Route("Register")]
        public IHttpActionResult Register(MemberRegister data)
        {
            if (data is null)
                return BadRequest();

            int memberId = MemberService.Instance.Add(data);
            Member member = MemberService.Instance.GetOne(memberId);

            // TODO - Make a Token
            return Json(member);
        }

        [HttpPost]
        [Route("Login")]
        public IHttpActionResult Login(MemberLogin data)
        {
            if (data is null)
                return BadRequest();

            Member member = MemberService.Instance.GetWithCredential(data.Email, data.Password);

            // TODO - Make a Token
            return Json(member);
        }

    }
}
