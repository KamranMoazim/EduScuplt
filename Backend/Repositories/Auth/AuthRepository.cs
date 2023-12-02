
using Backend.Models;
using Backend.Dtos.UserDtos;
using AutoMapper;
using Backend.Exceptions;
using Backend.Utils;


namespace Backend.Repositories.Auth
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
            // return _mapper.Map<List<UserDto>>(_context.Users.ToList());
            return _mapper.Map<List<User>>(_context.Users.ToList());
        }

        public User Login(LoginUserDto userDto)
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
                throw new InvalidException("Invalid Credentials");
            }

            // UserDto returnUserDto = _mapper.Map<User, UserDto>(user);

            return user;
        }

        public User Register(CreateUserDto userDto)
        {

            // check if email already exists
            User existingUser = _context.Users.FirstOrDefault(u => u.Email == userDto.Email);

            if (existingUser != null)
            {
                // throw new Exception("Email already exists");
                throw new InvalidException("Email already exists");
            }

            if (!AppUtils.IsStrongPassword(userDto.Password))
            {
                throw new InvalidException("Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one number and one special character");
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(userDto.Password);

            User user = new User
            {
                Email = userDto.Email,
                Password = hashedPassword,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                // ProfileURL = "",
                UserType = userDto.UserType,
                // UserType = "Student",
                PhoneNumber = userDto.PhoneNumber,
                // About = ""
            };

            // AppUtils.ExecuteWithExceptionHandling(() => _context.Users.Add(user));

            _context.Users.Add(user);
            _context.SaveChanges();

            // UserDto returnUserDto = _mapper.Map<User, UserDto>(user);

            return user;
        }



        public User GetUser(int userId)
        {
            User user = _context.Users.FirstOrDefault(u => u.ID == userId);

            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            return user;
        }

        public User GetUserByEmail(string email)
        {
            User user = _context.Users.FirstOrDefault(u => u.Email == email);

            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            return user;
        }
    }
}