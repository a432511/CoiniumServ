﻿#region License
// 
//     CoiniumServ - Crypto Currency Mining Pool Server Software
//     Copyright (C) 2013 - 2014, CoiniumServ Project - http://www.coinium.org
//     http://www.coiniumserv.com - https://github.com/CoiniumServ/CoiniumServ
// 
//     This software is dual-licensed: you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
// 
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
//    
//     For the terms of this license, see licenses/gpl_v3.txt.
// 
//     Alternatively, you can license this software under a commercial
//     license or white-label it as set out in licenses/commercial.txt.
// 
#endregion
using AustinHarris.JsonRpc;
using Coinium.Daemon;
using Coinium.Daemon.Responses;
using Coinium.Mining.Shares;
using Coinium.Server.Mining.Vanilla;
using Serilog;

namespace Coinium.Service.Vanilla
{
    /// <summary>
    /// Stratum protocol implementation.
    /// </summary>
    public class VanillaService : JsonRpcService, IRpcService
    {
        private readonly IDaemonClient _daemonClient; // TODO: remove this!

        private readonly IShareManager _shareManager;

        public VanillaService(IShareManager shareManager, IDaemonClient daemonClient)
        {
            _daemonClient = daemonClient;
            _shareManager = shareManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>Documentation:
        /// https://en.bitcoin.it/wiki/Getwork
        /// https://github.com/sinisterchipmunk/bitpool/wiki/Bitcoin-Mining-Pool-Developer's-Reference
        /// https://bitcointalk.org/index.php?topic=51281.0
        /// </remarks>
        [JsonRpcMethod("getwork")]
        public Work Getwork(string data = null)
        {
            var context = (HttpServiceContext)JsonRpcContext.Current().Value;
            var miner = (VanillaMiner)(context.Miner);

            // TODO: fixme! instead use jobmanager and sharemanager.

            if (data == null)
                _daemonClient.Getwork();
            else
            {
                var result = _daemonClient.Getwork(data);
                if(result)
                    Log.ForContext<VanillaMiner>().Verbose("Found block!: {0}", data);

                return null;
            }    

            return null;
        }     
    }
}
