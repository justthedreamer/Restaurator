using Application.Queries;
using Application.Queries.Abstraction;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace gRPC_Service.Services;

public class MenuService(IQueryHandler<GetRestaurantMenu, Application.DTO.MenuDto> getRestaurantMenu) : RestaurantMenu.RestaurantMenuBase
{

    public override async Task<MenuDto> GetMenu(Empty request, ServerCallContext context)
    {
        var restaurantId = context.RequestHeaders.FirstOrDefault(h => h.Key == "restaurant-id")?.Value;

        if (restaurantId is null)
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Restaurant ID is missing."));
        }

        var restaurantIdGuid = Guid.Parse(restaurantId);
        
        var menuDto = await getRestaurantMenu.HandleAsync(new GetRestaurantMenu(){RestaurantId = restaurantIdGuid});
        
        var result = Convert(menuDto);

        return result;
    }

    private MenuDto Convert(Application.DTO.MenuDto applicationDto)
    {
        var menu = new MenuDto()
        {
            Services =
            {
                applicationDto.Services.Select(s => new ServiceDto()
                {
                    Id = s.Id.ToString(),
                    Name = s.Name,
                    Price = (float)s.Price
                })

            },
            MenuItems = { applicationDto.MenuItems.Select(m => new MenuItemDto()
            {
                Id = m.Id.ToString(),
                Name = m.Name,
                Price = (float)m.Price,
                Category = m.Category,
                Description = m.Description,
                PrepareTime = m.PrepareTime,
                Ingredients = { m.Ingredients }
            }) }
        };

        return menu;
    }
}
