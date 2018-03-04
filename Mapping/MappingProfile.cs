using System;
using System.Linq;
using AutoMapper;
using Szkolimy_za_darmo_api.Controllers.Resources.Return;
using Szkolimy_za_darmo_api.Controllers.Resources.Query;
using Szkolimy_za_darmo_api.Controllers.Resources.Save;
using Szkolimy_za_darmo_api.Core.Models;
using Szkolimy_za_darmo_api.Core.Models.Query;

namespace Szkolimy_za_darmo_api.Mapping
{
    public class MappingProfile : Profile
    {
          public MappingProfile() {
            Generics();
            DomainToResource();
            ResourceToDomain();        
          }

        private void DomainToResource()
        {           
            CreateMap<Training, TrainingResource>()
                .ForMember(
                    trainingResource => trainingResource.MarketStatus,
                    opt => opt.MapFrom(
                        training => new MarketStatusResource{Id = training.MarketStatus.Id, Status = training.MarketStatus.Status}))
                .ForMember(
                    trainingResource => trainingResource.Tags,
                    opt => opt.MapFrom(
                        training => training.Tags.Select(Type => new TagResource{Name = Type.TagName})));
            CreateMap<User, SaveUserResource>()
                .ForMember(saveEntryResource => saveEntryResource.Entry, opt => opt.Ignore());
            CreateMap<User, UserResource>()
                .ForMember(
                    userResource => userResource.IsAlreadyRegistered,
                    opt => opt.Ignore());
        }

        private void ResourceToDomain() {
            CreateMap<TrainingQueryResource, TrainingQuery>()
                .ForMember(
                    trainingQuery => trainingQuery.Localizations,
                    opt => opt.MapFrom(
                        trainingQuery => trainingQuery.Localizations
                            .Split(',', StringSplitOptions.None)
                            .Select(Int32.Parse)
                            .ToArray()
                    ))
                .ForMember(
                    trainingQuery => trainingQuery.Categories,
                    opt => opt.MapFrom(
                        trainingQuery => trainingQuery.Categories
                            .Split(',', StringSplitOptions.None)
                            .ToArray()));
            CreateMap<TagResource, Tag>();     
            CreateMap<SaveTrainingResource, Training>()
                .ForMember(training => training.Id, opt => opt.Ignore())
                .ForMember(training => training.LastUpdate, opt => opt.Ignore())
                .ForMember(
                    training => training.Tags,
                    opt => opt.MapFrom(
                        trainingResource => trainingResource.Tags.Select(
                            Tag => new TrainingTag{TagName = Tag})));                                              
            CreateMap<SaveUserResource, User>()
                .ForMember(user => user.Entries, opt => opt.Ignore());
            CreateMap<SaveEntryResource, Entry>()
                .ForMember(entry => entry.TrainingId, opt => opt.MapFrom(saveEntryResource => saveEntryResource.TrainingId));
            CreateMap<SaveInstructorResource,Instructor>()
                .ForMember(instructor => instructor.Id, opt => opt.Ignore())
                .ForMember(instructor => instructor.Trainings, opt => opt.Ignore());
          }

          private void Generics() {
            CreateMap(typeof(QueryResult<>), typeof(QueryResultResource<>));
          }
    }
}