using AutoMapper;
using FluentValidation;
using KarpaticaTravelAPI.Infrastructure;
using KarpaticaTravelAPI.Models.UserModel;
using KarpaticaTravelAPI.Repositories.UserRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Processors.UserProcessor
{
    public class UserProcessor : IUserProcessor
    {

        private IUserRepository _userRepository;
        private IMapper _mapper;
        private readonly ITokenManager _tokenManager;

        public UserProcessor(IUserRepository repository, ITokenManager tokenManager, IMapper mapper)
        {
            _userRepository = repository;
            _mapper = mapper;
            _tokenManager = tokenManager;
        }

        public async Task<LoginUserResult> LoginUser(string email, string password)
        {

            User user = await _userRepository.GetUserByEmail(email).ConfigureAwait(false);

            if (user == null)
            {
                return null;
            }

            if (HashManager.IsPasswordCorrect(password, user.Password, user.Salt))
            {
                return new LoginUserResult()
                {
                    Token = _tokenManager.GenerateJwtToken(user.Email, user.Username),
                    Username = user.Username,
                    Email = user.Email,
                    Id = user.Id
                };
            }

            return null;

        }

        public async Task<bool> CreateUser(UserDTO user)
        {
            try
            {
                UserDTOValidator rules = new UserDTOValidator();
                await rules.ValidateAndThrowAsync(user).ConfigureAwait(false);

                User newUser = _mapper.Map<UserDTO, User>(user);

                if (user.Id == Guid.Empty)
                {
                    newUser.Id = Guid.NewGuid();

                }

                (newUser.Password, newUser.Salt) = HashManager.GenerateHashSetKeys(user.Password);

                await _userRepository.CreateUser(newUser).ConfigureAwait(false);

                return true;
            }
            catch (ValidationException validationException)
            {
                Console.WriteLine(validationException.Message);
                return false;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }

        public async Task<bool> DeleteUser(Guid userId)
        {
            try
            {
                return await _userRepository.DeleteUser(userId).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }

        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            IEnumerable<User> resultList = await _userRepository.GetUsers().ConfigureAwait(false);
            return new List<UserDTO>(_mapper.Map<IEnumerable<UserDTO>>(resultList));
        }

        public async Task<UserDTO> GetUser(Guid id)
        {
            User result = await _userRepository.GetUser(id).ConfigureAwait(false);
            return (_mapper.Map<User, UserDTO>(result));
        }

        public async Task<bool> UpdateUser(Guid id, UserUpdateDTO userToUpdate)
        {
            try
            {
                UserUpdateDTOValidator rules = new UserUpdateDTOValidator();
                await rules.ValidateAndThrowAsync(userToUpdate).ConfigureAwait(false);

                User newUserObject = _mapper.Map<UserUpdateDTO, User>(userToUpdate);
                newUserObject.Id = id;
                
                (newUserObject.Password, newUserObject.Salt) = HashManager.GenerateHashSetKeys(userToUpdate.Password);

                return await _userRepository.UpdateUser(id, newUserObject).ConfigureAwait(false);
            }
            catch (ValidationException validationException)
            {
                Console.WriteLine(validationException.Message);
                return false;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }
    }
}
