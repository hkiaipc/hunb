using System;
using System.Collections.Generic;
using System.Text;

namespace DTC
{
    /// <summary>
    /// 
    /// </summary>
    public class ClientFactory
    {
        static private Client _client;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static public Client GetClient()
        {
            if (_client == null)
            {
                _client = new Client();
            }
            return _client;

        }
    }
}
