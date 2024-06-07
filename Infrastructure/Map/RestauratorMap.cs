using AutoMapper;
using Infrastructure.Security;

namespace Infrastructure.Map;

internal partial class RestauratorMap : Profile
{
    private readonly IGuidEncryptionService _encryptionService;

    public RestauratorMap(IGuidEncryptionService encryptionService)
    {
        _encryptionService = encryptionService;
        InitializeRestaurantMapping();
        InitializeStaffMapping();
        InitializeOrdersMapping();
    }

    partial void InitializeRestaurantMapping();
    partial void InitializeOrdersMapping();
    partial void InitializeStaffMapping();
}