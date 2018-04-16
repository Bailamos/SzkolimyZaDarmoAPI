using System;
using System.Linq;
using AutoMapper;
using Szkolimy_za_darmo_api.Controllers.Resources.Return;
using Szkolimy_za_darmo_api.Controllers.Resources.Query;
using Szkolimy_za_darmo_api.Controllers.Resources.Save;
using Szkolimy_za_darmo_api.Core.Models;
using Szkolimy_za_darmo_api.Core.Models.Query;
using static Szkolimy_za_darmo_api.Controllers.Resources.Return.UserResource;
using System.Collections.Generic;
using Szkolimy_za_darmo_api.Controllers;
using Szkolimy_za_darmo_api.Controllers.Resources.Response;

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
                    trainingResource => trainingResource.Voivodeship,
                    opt => opt.MapFrom(
                        training => new VoivodeshipResource{Id = training.Voivodeship.Id, VoivodeshipName = training.Voivodeship.VoivodeshipName}))
                .ForMember(
                    trainingResource => trainingResource.Tags,
                    opt => opt.MapFrom(
                        training => training.Tags.Select(Type => new TagResource{Name = Type.TagName})))
                .ForMember(
                    trainingResource => trainingResource.Counties,
                    opt => opt.MapFrom(
                        training => training.Counties.Select(County => new CountyResource{Id = County.CountyId, CountyName = County.County.CountyName})))
                .ForMember(
                    trainingResource => trainingResource.MarketStatuses,
                    opt => opt.MapFrom(
                        training => training.MarketStatuses.Select(MarketStatus => new MarketStatusResource{Id = MarketStatus.MarketStatusId, Status = MarketStatus.MarketStatus.Status})));

            CreateMap<Training, InstructorTrainingResource>()
                .ForMember(
                    instructorTrainingResource => instructorTrainingResource.Tags,
                    opt => opt.MapFrom(
                        training => training.Tags.Select(Type => new TagResource{Name = Type.TagName})));

            CreateMap<User, SaveUserResource>()
                .ForMember(saveEntryResource => saveEntryResource.Entry, opt => opt.Ignore());
  
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

            CreateMap<UserQueryResource, UserQuery>()
                .ForMember(
                    userQuery => userQuery.Categories,
                    opt => opt.MapFrom(
                        userQuery => userQuery.Categories
                            .Split(',', StringSplitOptions.None)
                            .ToArray()
                    ));

            CreateMap<TagResource, Tag>();   

            CreateMap<SaveTrainingResource, Training>()
                .ForMember(training => training.Id, opt => opt.Ignore())
                .ForMember(training => training.LastUpdate, opt => opt.Ignore())
                .ForMember(training => training.Tags, opt => opt.Ignore()) 
                .ForMember(training => training.Counties, opt => opt.Ignore())
                .ForMember(training => training.MarketStatuses, opt => opt.Ignore())
                .AfterMap((saveTrainingResource, training) => {
                    var removedTags = training.Tags
                        .Where(trainingTag => !saveTrainingResource.Tags.Contains(trainingTag.TagName)).ToList();
                    foreach (var f in removedTags)
                        training.Tags.Remove(f);
                    var addedTags = saveTrainingResource.Tags
                        .Where(tag => !training.Tags.Any(trainingTag => trainingTag.TagName == tag))
                        .Select(tag => new TrainingTag { TagName = tag })
                        .ToList();   
                    foreach (var f in addedTags)
                        training.Tags.Add(f);

                    var removedCounties = training.Counties
                        .Where(trainingCounty => !saveTrainingResource.Counties.Contains(trainingCounty.CountyId)).ToList();
                    foreach(var f in removedCounties)
                        training.Counties.Remove(f);
                    var addedCounties = saveTrainingResource.Counties
                        .Where(id => !training.Counties.Any(trainingCounty => trainingCounty.CountyId == id))
                        .Select(id => new TrainingLocalization { CountyId = id })
                        .ToList();  
                    foreach (var f in addedCounties)
                        training.Counties.Add(f);
                    
                    
                    var removedMarketStatuses = training.MarketStatuses
                        .Where(trainingMarketStatus => !saveTrainingResource.MarketStatuses.Contains(trainingMarketStatus.MarketStatusId)).ToList();
                    foreach(var f in removedMarketStatuses)
                        training.MarketStatuses.Remove(f);

                    var addedMarketStatuses = saveTrainingResource.MarketStatuses
                        .Where(id => !training.MarketStatuses.Any(trainingMarketStatus => trainingMarketStatus.MarketStatusId == id))
                        .Select(id => new TrainingMarketStatus { MarketStatusId = id })
                        .ToList();  
                    foreach (var f in addedMarketStatuses)
                        training.MarketStatuses.Add(f);
                }); 
                                                           
            CreateMap<SaveUserResource, User>()
                .ForMember(user => user.Entries, opt => opt.Ignore())
                .ForMember(user => user.Notes, opt => opt.Ignore())
                .AfterMap((userResource, user) => {
                    if (userResource.Note != null)
                        user.Notes.Add(
                            new Note{
                                Description = userResource.Note.Description,
                                UserPhoneNumber = userResource.PhoneNumber
                            });
                });

            CreateMap<SaveEntryResource, Entry>()
                .ForMember(entry => entry.TrainingId, opt => opt.MapFrom(saveEntryResource => saveEntryResource.TrainingId));
                
            CreateMap<SaveInstructorResource,Instructor>()
                .ForMember(instructor => instructor.Id, opt => opt.Ignore())
                .ForMember(instructor => instructor.Trainings, opt => opt.Ignore());

            CreateMap<SaveReminderResource, Reminder>()
                .ForMember(reminder => reminder.Id, opt => opt.Ignore());

            CreateMap<SaveUserLogResource, UserLog>()
                .ForMember(log => log.Id, opt => opt.Ignore())
                .ForMember(log => log.Date, opt => opt.Ignore())
                .ForMember(log => log.User, opt => opt.Ignore())
                .ForMember(log => log.UserPhoneNumber, opt => opt.Ignore());

          }

          private void Generics() {
            CreateMap(typeof(QueryResult<>), typeof(QueryResultResource<>));
          }
        // private void updateCollection<Titem>(ICollection<Titem> collectionToUpdate, ICollection<Titem> newCollection) {
        //    var removedItems = training.Tags
        //                 .Where(trainingTag => !saveTrainingResource.Tags.Contains(trainingTag.TagName)).ToList();
                    
        // }
    }

}