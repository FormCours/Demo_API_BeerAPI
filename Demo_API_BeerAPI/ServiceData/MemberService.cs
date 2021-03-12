using Demo_API_BeerAPI.DAL.Repositories;
using Demo_API_Intro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_API_Intro.ServiceData
{
    public class MemberService
    {
        #region Singleton
        private static Lazy<MemberService> _Instance = new Lazy<MemberService>(() => new MemberService());
        public static MemberService Instance { get { return _Instance.Value; } }
        #endregion

        private MemberRepository memberRepository;

        private MemberService()
        {
            memberRepository = new MemberRepository();
        }

        public Member GetOne(int id)
        {
            Demo_API_BeerAPI.DAL.Entities.MemberEntity memberEntity = memberRepository.Get(id);

            if (memberEntity is null)
                return null;

            return new Member()
            {
                Id = memberEntity.Id,
                Username = memberEntity.Username,
                Email = memberEntity.Email,
                Role = memberEntity.Role
            };
        }

        public Member GetWithCredential(string email, string password)
        {
            Demo_API_BeerAPI.DAL.Entities.MemberEntity memberEntity = memberRepository.GetByCredential(email, password);

            if (memberEntity is null)
                return null;

            return new Member()
            {
                Id = memberEntity.Id,
                Username = memberEntity.Username,
                Email = memberEntity.Email,
                Role = memberEntity.Role
            };
        }

        public int Add(MemberRegister member)
        {
            int newId = memberRepository.Insert(new Demo_API_BeerAPI.DAL.Entities.MemberEntity()
            {
                Username = member.Username,
                Email = member.Email,
                Password = member.Password
            });

            return newId;
        }

    }
}