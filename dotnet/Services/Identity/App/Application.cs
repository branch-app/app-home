using Branch.Services.Identity.Libraries;
using Branch.Services.Identity.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ServiceStack.Redis;

namespace Branch.Services.Identity.App
{
	public partial class Application
	{
		private ILogger _logger { get; }
		private IRedisClientsManager _redisClientsManager { get; }
		private Config _config { get; }
		private XblIdentityCache _xblIdentityCache { get; }

		public Application(
			ILoggerFactory loggerFactory,
			IRedisClientsManager redisClientsManager,
			IOptionsMonitor<Config> options,
			XblIdentityCache xblIdentityCache
		)
		{
			_logger = loggerFactory.CreateLogger(typeof(Application));
			_redisClientsManager = redisClientsManager;
			_config = options.CurrentValue;
			_xblIdentityCache = xblIdentityCache;
		}
	}
}
