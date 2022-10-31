using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DatingApp.API.Data;
using DatingApp.API.Data.Entities;
using DatingApp.API.DTOs;

namespace DatingApp.API.Services
{
    public class MemberService : IMemberService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public MemberService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public MemberDto GetMemberByUsernam(string Username)
        {
            var user = _context.AppUsers.FirstOrDefault(x=> x.Username == Username);
            if(user == null) return null;
            // return new MemberDto
            // {
            //     Avatar = user.Avatar,
            //     City = user.City,
            //     CreateAt = user.CreateAt,
            //     DateOfBirth = user.DateOfBirth,
            //     Email = user.Email,
            //     Gender = user.Gender,
            //     Introduction = user.Introduction,
            //     KnownAs = user.KnownAs,
            //     Username = user.Username
            // };
            return _mapper.Map<User, MemberDto>(user);
        }

        public List<MemberDto> GetMembers()
        {
            return _context.AppUsers.ProjectTo<MemberDto>(_mapper.ConfigurationProvider).ToList();
            // return _context.AppUsers.Select(user => new MemberDto
            // {
            //     Avatar = user.Avatar,
            //     City = user.City,
            //     CreateAt = user.CreateAt,
            //     DateOfBirth = user.DateOfBirth,
            //     Email = user.Email,
            //     Gender = user.Gender,
            //     Introduction = user.Introduction,
            //     KnownAs = user.KnownAs,
            //     Username = user.Username
            // }).ToList();
        }
    }
}