using DAL.UOW;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLS
{
    class MemberService : IMemberService
    {
        private readonly IUnitOfWork _dbContext;

        public MemberService(IUnitOfWork dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Member> RegisterAsync(Member newMember)
        {
            return await _dbContext.Members.AddAsync(newMember);
        }
    }
}
