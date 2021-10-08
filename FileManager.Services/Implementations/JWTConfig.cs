using FileManager.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Services.Implementations
{
    public class JWTConfig : IJWTConfig
    {
        public string SigningKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpiryTimeInMinutes { get; set; }
    }

    public class ServerFolderConfig : IServerFolderConfig
    {
        public string Folder { get; set; }
    }
}
