using Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Implementations
{
    public class Bootstrap
    {
        public ServiceProvider Build()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<IChessGame>(new ChessGame());

            return services.BuildServiceProvider();
        }
    }
}
