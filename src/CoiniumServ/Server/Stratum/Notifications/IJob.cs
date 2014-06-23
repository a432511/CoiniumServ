﻿/*
 *   CoiniumServ - crypto currency pool software - https://github.com/CoiniumServ/CoiniumServ
 *   Copyright (C) 2013 - 2014, Coinium Project - http://www.coinium.org
 *
 *   This program is free software: you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation, either version 3 of the License, or
 *   (at your option) any later version.
 *
 *   This program is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details.
 *
 *   You should have received a copy of the GNU General Public License
 *   along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using Coinium.Coin.Daemon.Responses;
using Coinium.Crypto;
using Coinium.Transactions;

namespace Coinium.Server.Stratum.Notifications
{
    public interface IJob : IEnumerable<object>
    {
        UInt64 Id { get; }

        string PreviousBlockHashReversed { get;  }

        string CoinbaseInitial { get; }

        string CoinbaseFinal { get; }

        string Version { get; }

        string NetworkDifficulty { get; }

        string nTime { get; }

        bool CleanJobs { get; set; }

        IBlockTemplate BlockTemplate { get; }

        GenerationTransaction GenerationTransaction { get; }

        IMerkleTree MerkleTree { get; }

        new IEnumerator<object> GetEnumerator();
    }
}