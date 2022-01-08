using AutoMapper;

namespace ProjetoModeloDDD.MVC.AutoMapper
{
    public class AutoMapperConfig //Instalar o AutoMapper V 3.2.1
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            }); 
        }
    }
} 