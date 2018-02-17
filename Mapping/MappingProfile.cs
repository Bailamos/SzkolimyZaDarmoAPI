using System.Linq;
using AutoMapper;
using Szkolimy_za_darmo_api.Controllers.Resources;
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
                    opt => opt.MapFrom(
                        training => training.Types.Select(
                            type => new TypeResource{TypeName = type.TypeName})));

            // CreateMap<SaveVehicleResource,Vehicle>()
             
          }
    }
}