using TSBot.Serviñes.Domain;
using TSBot.Serviñes;
using TSBot.Data.Repositories.Abstract;
using Xunit;
using Moq;
using AutoMapper;
using TSBot.Data.Entity;

namespace TSBot.Test.Services
{
    public class UserServiceTests
    {
        
        private readonly Mapper _mapper = new Mapper(new MapperConfiguration(x => x.CreateMap<User, UserEntity>()));

        [Fact]
        public void Add_ShouldCreateNewUser()
        {
            //arrange 
            User user = new User
            {
                ChatTelegramId = 223123,
                Email = "email.ru"
            };
            var userRepository = new Mock<IUserRepository>(); 
            UserService userService = new UserService(userRepository.Object,_mapper);
            var userEntity = _mapper.Map<User, UserEntity>(user);

            //act
            var result = userService.AddUser(user);

            //assert
            userRepository.Verify(x => x.Add(userEntity), Times.Once());
        }
    }
}
