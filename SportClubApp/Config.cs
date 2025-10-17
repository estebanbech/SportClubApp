using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClubApp
{
    public static class Config
    {
        public static string ConnectionString =>
            "Server=localhost;Port=3306;Database=clubdeportivo;User=root;Password=root;";
    }
}
