using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace championnat
{
    internal class Constants
    {
        internal static readonly string PROVIDER = Environment.GetEnvironmentVariable("PROVIDER");
        internal static readonly string SERVER_NAME = Environment.GetEnvironmentVariable("SERVER_NAME");
        internal static readonly string PORT = Environment.GetEnvironmentVariable("PORT");
        internal static readonly string DATABASE_NAME = Environment.GetEnvironmentVariable("DATABASE_NAME");
        internal static readonly string USERNAME = Environment.GetEnvironmentVariable("USERNAME");
        internal static readonly string PASSWORD = Environment.GetEnvironmentVariable("PASSWORD");
    }
}
