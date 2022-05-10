using Arquitectura.BL.Data;
using Owin;

namespace Arquitectura.API
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            //Configure the db context to use a single instance for request
            app.CreatePerOwinContext(ArquitecturaContext.Create);
        }
    }
}
