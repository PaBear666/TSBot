using AutoMapper;
using TSBot.Data.Entity;
using TSBot.Serviсes.Domain;

namespace TSBot.Serviсes
{
    public class ServiceAutoMapperProfile : Profile
    {
        public ServiceAutoMapperProfile()
        {
            CreateMap<User, UserEntity>().ReverseMap();
            CreateMap<Student, StudentEntity>().ReverseMap();
            CreateMap<Teacher, TeacherEntity>().ReverseMap();
            CreateMap<Chat, ChatEntity>().ReverseMap();
            CreateMap<Message, MessageEntity>().ReverseMap();
            CreateMap<Work, WorkEntity>().ReverseMap();
        }
    }
}
