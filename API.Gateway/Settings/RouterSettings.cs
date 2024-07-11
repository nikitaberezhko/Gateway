using Route = API.Gateway.Infrastructure.Route;

namespace API.Gateway.Settings;

public class RouterSettings
{
    public List<Route> Routes { get; set; }
}