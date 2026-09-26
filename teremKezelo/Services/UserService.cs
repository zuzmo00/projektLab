using AutoMapper;
using teremKezelo.DbCOntext;
using teremKezelo.DTOS.UserDtos;
using teremKezelo.Entities;

namespace teremKezelo.Services
{
    public interface IUserService
    {
        public Task<ApplicationUser> CreateUserAsync(UserCreateDto userDto);
    }
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public UserService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApplicationUser> CreateUserAsync(UserCreateDto userDto)
        {
            var user = _mapper.Map<ApplicationUser>(userDto);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
