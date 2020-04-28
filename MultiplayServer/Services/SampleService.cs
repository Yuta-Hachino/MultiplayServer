using MagicOnion;
using MagicOnion.Server;
using Microsoft.Extensions.Logging;
using Sample.Shared.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyVR.MultiplayServer.Services
{
    public class SampleService : ServiceBase<IMultiplayService>, IMultiplayService
    {
        public async UnaryResult<int> SumAsync(int x, int y)
        {
            Logger.Debug($"SumAsync Received:{x}, {y}");
            return x + y;
        }

        public async UnaryResult<int> ProductAsync(int x, int y)
        {
            Logger.Debug($"ProductAsync Received:{x}, {y}");
            return x * y;
        }
    }
}
