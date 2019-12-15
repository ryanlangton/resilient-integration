using System;

namespace ResilientIntegration.Api.Model
{
    public class UploadProvidersRequest
    {
        public ProviderRequest[] Providers { get; set; }
    }

    public class ProviderRequest
    {
        public long Index { get; set; }
        public Guid Guid { get; set; }
        public bool IsActive { get; set; }
        public string VisitCost { get; set; }
        public Uri Picture { get; set; }
        public long Age { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string About { get; set; }
        public string Registered { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Practice { get; set; }
    }
}
