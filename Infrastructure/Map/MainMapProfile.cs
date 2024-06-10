using AutoMapper;
using Infrastructure.Security;

namespace Infrastructure.Map;

internal partial class MainMapProfile : Profile
{

    public MainMapProfile()
    {
        ApplyRestaurantMapping();
        ApplyStaffMapping();
        ApplyOrdersMapping();
        ApplySchedulesMapping();
    }

    partial void ApplyRestaurantMapping();
    partial void ApplyOrdersMapping();
    partial void ApplyStaffMapping();
    partial void ApplySchedulesMapping();
}