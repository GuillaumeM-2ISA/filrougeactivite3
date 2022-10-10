using BLLS;
using DAL.UOW;
using DAL.UOW.Repositories;
using Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest
{
    public class MemberServiceTest
    {
        /*
        [Fact]
        public async void GetMembersAsyncShouldBeOk()
        {
            //Arrange
            IUnitOfWork dbContext = Mock.Of<IUnitOfWork>();
            IMemberRepository Members = Mock.Of<IMemberRepository>();

            List<Member> expectedContent = new List<Member>()
                {
                    new Member() {Id = 1, Nickname = "toto", Type = "Moderator", Email = "toto@toto.fr", Password = "3F9kY2n69M3Nj1B5NCZTSZSxLUtEzpCwnDChBjViJNQ=", CreatedAt = DateTime.Parse("08/10/2022 12:03:38")},
                    new Member() {Id = 2, Nickname = "titi", Type = "Member", Email = "titi@toto.fr", Password = "4vtbZCx1En4VqfCnDyfYitoW+dlLjaMppEpqsaHyKCo=", CreatedAt = DateTime.Parse("08/10/2022 12:03:38")}
                };

            MemberService memberService = new MemberService(dbContext);

            Mock.Get(Members).Setup(Members => Members.GetAllAsync()).ReturnsAsync(expectedContent);

            //Act
            IEnumerable<Member> members = await memberService.GetMembersAsync();

            //Assert
            Assert.Equal(expectedContent, members);
        }
        
        [Fact]
        public async void GetMemberByIdAsyncShouldBeOk()
        {
            //Arrange
            IUnitOfWork dbContext = Mock.Of<IUnitOfWork>();

            Member expectedContent = new Member() {Id = 2, Nickname = "titi", Type = "Member", Email = "titi@toto.fr", Password = "4vtbZCx1En4VqfCnDyfYitoW+dlLjaMppEpqsaHyKCo=", CreatedAt = DateTime.Parse("08/10/2022 12:03:38")};

            MemberService memberService = new MemberService(dbContext);

            //Act
            Member member = await memberService.GetMemberByIdAsync(2);

            //Assert
            Assert.Equal(expectedContent, member);
        }

        [Fact]
        public async void GetMemberByEmailAsyncShouldBeOk()
        {
            //Arrange
            IUnitOfWork dbContext = Mock.Of<IUnitOfWork>();

            Member expectedContent = new Member() { Id = 2, Nickname = "titi", Type = "Member", Email = "titi@toto.fr", Password = "4vtbZCx1En4VqfCnDyfYitoW+dlLjaMppEpqsaHyKCo=", CreatedAt = DateTime.Parse("08/10/2022 12:03:38") };

            MemberService memberService = new MemberService(dbContext);

            //Act
            Member member = await memberService.GetMemberByEmailAsync("titi@toto.fr");

            //Assert
            Assert.Equal(expectedContent, member);
        }
        */
    }
}
