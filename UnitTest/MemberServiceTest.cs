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
        [Fact]
        public async void GetMembersAsyncShouldBeOk()
        {
            //Arrange
            IUnitOfWork dbContext = Mock.Of<IUnitOfWork>();
            IMemberRepository Members = Mock.Of<IMemberRepository>();
            Mock.Get(dbContext)
                .Setup(dbContext => dbContext.Members)
                .Returns(Members);

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
            IMemberRepository Members = Mock.Of<IMemberRepository>();
            Mock.Get(dbContext)
                .Setup(dbContext => dbContext.Members)
                .Returns(Members);

            Member expectedContent = new Member() {Id = 2, Nickname = "titi", Type = "Member", Email = "titi@toto.fr", Password = "4vtbZCx1En4VqfCnDyfYitoW+dlLjaMppEpqsaHyKCo=", CreatedAt = DateTime.Parse("08/10/2022 12:03:38")};

            MemberService memberService = new MemberService(dbContext);

            Mock.Get(Members).Setup(Members => Members.GetByIdAsync(2)).ReturnsAsync(expectedContent);

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
            IMemberRepository Members = Mock.Of<IMemberRepository>();
            Mock.Get(dbContext)
                .Setup(dbContext => dbContext.Members)
                .Returns(Members);

            Member expectedContent = new Member() { Id = 2, Nickname = "titi", Type = "Member", Email = "titi@toto.fr", Password = "4vtbZCx1En4VqfCnDyfYitoW+dlLjaMppEpqsaHyKCo=", CreatedAt = DateTime.Parse("08/10/2022 12:03:38") };

            MemberService memberService = new MemberService(dbContext);

            Mock.Get(Members).Setup(Members => Members.GetByEmailAsync("titi@toto.fr")).ReturnsAsync(expectedContent);

            //Act
            Member member = await memberService.GetMemberByEmailAsync("titi@toto.fr");

            //Assert
            Assert.Equal(expectedContent, member);
        }

        [Fact]
        public async void RegisterAsyncShouldBeOk()
        {
            //Arrange
            IUnitOfWork dbContext = Mock.Of<IUnitOfWork>();
            IMemberRepository Members = Mock.Of<IMemberRepository>();
            Mock.Get(dbContext)
                .Setup(dbContext => dbContext.Members)
                .Returns(Members);

            Member newMember = new Member()
            {
                Nickname = "tata",
                Email = "tata@toto.fr",
                Password = "tatapassword"
            };

            Member newMemberWithPasswordEncrypted = new Member()
            {
                Nickname = "tata",
                Email = "tata@toto.fr",
                Password = "txn1kSaxajNgSQ5Fynth8XYY/DSeZal+iK2YmGUmG38="
            };

            Member expectedContent = new Member() { Id = 3, Nickname = "tata", Type = "Member", Email = "tata@toto.fr", Password = "txn1kSaxajNgSQ5Fynth8XYY/DSeZal+iK2YmGUmG38=", CreatedAt = DateTime.Now };

            MemberService memberService = new MemberService(dbContext);

            Mock.Get(Members).Setup(Members => Members.AddAsync(newMemberWithPasswordEncrypted)).ReturnsAsync(expectedContent);

            //Act
            Member member = await memberService.RegisterAsync(newMember);

            //Assert
            Assert.Equal(expectedContent, member);
        }

        [Fact]
        public async void UpdatePasswordAsyncShouldBeOk()
        {
            //Arrange
            IUnitOfWork dbContext = Mock.Of<IUnitOfWork>();
            IMemberRepository Members = Mock.Of<IMemberRepository>();
            Mock.Get(dbContext)
                .Setup(dbContext => dbContext.Members)
                .Returns(Members);

            Member modifiedMember = new Member()
            {
                Id = 2,
                Password = "titipassword"
            };

            Member modifiedMemberWithPasswordEncrypted = new Member()
            {
                Id = 2,
                Password = "4vtbZCx1En4VqfCnDyfYitoW+dlLjaMppEpqsaHyKCo="
            };

            Member expectedContent = new Member() { Id = 2, Nickname = "titi", Type = "Member", Email = "titi@toto.fr", Password = "4vtbZCx1En4VqfCnDyfYitoW+dlLjaMppEpqsaHyKCo=", CreatedAt = DateTime.Parse("11/10/2022 08:51:59"), UpdateAt = DateTime.Now };

            MemberService memberService = new MemberService(dbContext);

            Mock.Get(Members).Setup(Members => Members.UpdatePasswordAsync(modifiedMemberWithPasswordEncrypted)).ReturnsAsync(expectedContent);

            //Act
            Member member = await memberService.UpdatePasswordAsync(modifiedMember);

            //Assert
            Assert.Equal(expectedContent, member);
        }
    }
}
