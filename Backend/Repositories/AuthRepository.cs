
using Backend.IRepositories;
using Backend.Models;
using Backend.Dtos;
using AutoMapper;
using Backend.Exceptions;


namespace Backend.Repositories
{

    public class AuthRepository : IAuthRepository
    {
        private readonly ProjectAppContext _context;
        private readonly IMapper _mapper;

        public AuthRepository(ProjectAppContext _ctx, IMapper map)
        {
            _context = _ctx;
            _mapper = map;
        }

        public IEnumerable<User> GetAll()
        {
            // _mapper.Map<IEnumerable<ProductImage>,IEnumerable<ProductImageDTO>>( _db.productImages.Where(i => i.ProductId == productId).ToList());
            // return _mapper.Map<IEnumerabsle<UserDto>,IEnumerable<User>>( _context.Users.ToList());
            // return (IEnumerable<UserDto>)_mapper.Map<IEnumerable<UserDto>, IEnumerable<User>>((IEnumerable<UserDto>)_context.Users.ToList());
            // return _mapper.Map<List<UserDto>>(_context.Users.ToList());
            return _mapper.Map<List<User>>(_context.Users.ToList());
        }


        public User Login(UserDto userDto)
        {
            // string hashedPassword = BCrypt.Net.BCrypt.HashPassword(userDto.Password);

            User user = _context.Users.FirstOrDefault(u => u.Email == userDto.Email);

            if (user == null)
            {
                // throw new Exception("User not found");
                throw new NotFoundException("User not found");
            }

            bool isValidPassword = BCrypt.Net.BCrypt.Verify(userDto.Password, user.Password);

            if (!isValidPassword)
            {
                // throw new Exception("Invalid password");
                throw new InvalidException("Invalid password");
            }

            // UserDto returnUserDto = _mapper.Map<User, UserDto>(user);

            return user;
        }


        public User Register(UserDto userDto)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(userDto.Password);

            User user = new User
            {
                Email = userDto.Email,
                Password = hashedPassword,
                FirstName = "",
                LastName = "",
                ProfileURL = "",
                // UserType = ProjectEnums.UserType.Student,
                UserType = "Student",
                PhoneNumber = "",
                About = ""
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            // UserDto returnUserDto = _mapper.Map<User, UserDto>(user);

            return user;
        }
    }
}