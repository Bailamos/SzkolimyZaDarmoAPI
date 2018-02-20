using System.Linq;
using AutoMapper;
using Szkolimy_za_darmo_api.Controllers.Resources;
using Szkolimy_za_darmo_api.Controllers.Resources.Save;
using Szkolimy_za_darmo_api.Core.Models;

namespace Szkolimy_za_darmo_api.Mapping
{
    public class MappingProfile : Profile
    {
          public MappingProfile() {
            CreateMap<Type, TypeResource>();

            CreateMap<Training, TrainingResource>()
                .ForMember(
                    trainingResource => trainingResource.types, 
                    opt => opt.MapFrom(v => v.Types.Select(
                        vf => new TrainingTypeResource {TypeName = vf.TypeName})))
                .ForMember(trainingResource => trainingResource.Id, opt => opt.MapFrom(training => training.Id))
                .ForMember(trainingResource => trainingResource.LastUpdate, opt => opt.MapFrom(training => training.LastUpdate));

            CreateMap<SaveTrainingResource,Training>()
                .ForMember(training => training.Id, opt => opt.Ignore())
                .ForMember(training => training.LastUpdate, opt => opt.Ignore())
                .ForMember(
                    training => training.Description,
                    opt => opt.MapFrom(
                        trainingResource => trainingResource.Description))
                .ForMember(
                    training => training.Types,
                    opt => opt.MapFrom(trainingResource => trainingResource.Types.Select(Type => new TrainingType{TypeName = Type})));
          }
    }
}