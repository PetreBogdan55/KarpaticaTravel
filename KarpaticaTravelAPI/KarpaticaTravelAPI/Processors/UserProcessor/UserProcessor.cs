using AutoMapper;
using FluentValidation;
using KarpaticaTravelAPI.Models.UserModel;
using KarpaticaTravelAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Processors.UserProcessor
{
    public class UserProcessor : IUserProcessor
    {

        private IUserRepository _userRepository;
        private IMapper _mapper;

        public UserProcessor(IUserRepository repository, IMapper mapper)
        {
            _userRepository = repository;
            _mapper = mapper;
        }

        public async Task<bool> CreateUser(UserDTO user)
        {
            try
            {
                UserDTOValidator rules = new UserDTOValidator();
                await rules.ValidateAndThrowAsync(user).ConfigureAwait(false);

                User newUser = _mapper.Map<UserDTO, User>(user);
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

        public async Task<bool> DeleteUser(int userId)
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

        public async Task<UserDTO> GetUser(int id)
        {
            User result = await _userRepository.GetUser(id).ConfigureAwait(false);
            return (_mapper.Map<User, UserDTO>(result));
        }

        public async Task<bool> UpdateUser(int id, UserUpdateDTO userToUpdate)
        {
            try
            {
                UserUpdateDTOValidator rules = new UserUpdateDTOValidator();
                await rules.ValidateAndThrowAsync(userToUpdate).ConfigureAwait(false);

                User newUserObject = _mapper.Map<UserUpdateDTO, User>(userToUpdate);
                newUserObject.Id = id;

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
