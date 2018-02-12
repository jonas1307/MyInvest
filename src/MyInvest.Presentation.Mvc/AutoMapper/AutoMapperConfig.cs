using AutoMapper;

namespace MyInvest.Presentation.Mvc.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelProfile>();
                x.AddProfile<ViewModelToDomainProfile>();
            });
        }
    }
}