using Owin;
//using Microsoft.Owin;
//[assembly: OwinStartup(typeof(auction_portal.Startup))]
namespace auction_portal
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }

}