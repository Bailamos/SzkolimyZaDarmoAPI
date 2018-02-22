using System.Linq;
using AutoMapper;
using Szkolimy_za_darmo_api.Controllers.Resources;
using Szkolimy_za_darmo_api.Controllers.Resources.Query;
using Szkolimy_za_darmo_api.Controllers.Resources.Save;
using Szkolimy_za_darmo_api.Core.Models;
using Szkolimy_za_darmo_api.Core.Models.Query;

namespace Szkolimy_za_darmo_api.Mapping
{
    public class MappingProfile : Profile
    {
          //TODO: Refactor
          public MappingProfile() {
            //Domain to resource
            // CreateMap<Type, TypeResource>();
            CreateMap<Training, TrainingResource>()
                .ForMember(
                    trainingResource => trainingResource.MarketStatus,
                    opt => opt.MapFrom(
                        training => new MarketStatusResource{Id = training.MarketStatus.Id, Status = training.MarketStatus.Status}))
                .ForMember(
                    trainingResource => trainingResource.Tags,
                    opt => opt.MapFrom(
                        training => training.Tags.Select(Type => new TagResource{Name = Type.TagName})));

            //Resource to Domain
            CreateMap<TagResource, Tag>();
            CreateMap<SaveTrainingResource,Training>()
                .ForMember(training => training.Id, opt => opt.Ignore())
                .ForMember(training => training.LastUpdate, opt => opt.Ignore())
                .ForMember(
                    training => training.Tags,
                    opt => opt.MapFrom(trainingResource => trainingResource.Tags.Select(Type => new TrainingTag{TagName = Type})));

            CreateMap<TrainingQueryResource, TrainingQuery>();
          }
    }
}