using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunBeiQuery
{
    public class DBFactory
    {
        private DBFactory()
        {
        }

        static public HunBeiDBDataContext Create()
        {
            return new HunBeiDBDataContext();
        }
    }
}
