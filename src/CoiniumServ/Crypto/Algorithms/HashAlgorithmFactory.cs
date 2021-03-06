#region License
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
using Coinium.Repository.Context;
using Serilog;

namespace Coinium.Crypto.Algorithms
{
    public class HashAlgorithmFactory : IHashAlgorithmFactory
    {
        /// <summary>
        /// The application context.
        /// </summary>
        private readonly IApplicationContext _applicationContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="HashAlgorithmFactory" /> class.
        /// </summary>
        /// <param name="applicationContext">The application context.</param>
        public HashAlgorithmFactory(IApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        /// <summary>
        /// Gets the specified algorithm name.
        /// </summary>
        /// <param name="algorithmName">Name of the algorithm.</param>
        /// <returns></returns>
        public IHashAlgorithm Get(string algorithmName)
        {
            // Default to Scrypt
            if (string.IsNullOrWhiteSpace(algorithmName)) 
                algorithmName = Algorithms.Scrypt;

            return _applicationContext.Container.Resolve<IHashAlgorithm>(algorithmName);
        }
    }
}