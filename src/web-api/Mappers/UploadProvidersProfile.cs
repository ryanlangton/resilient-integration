using AutoMapper;
using ResilientIntegration.Api.Model;
using ResilientIntegration.Core.Commands;

namespace ResilientIntegration.Api.Mappers
{
    public class UploadProvidersProfile : Profile
    {
        public UploadProvidersProfile()
        {
            CreateMap<UploadProvidersRequest, UploadProvidersCommand>();
            CreateMap<ProviderRequest, Provider>();
        }
    }
}
