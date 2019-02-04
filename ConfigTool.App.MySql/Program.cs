﻿using System.Threading.Tasks;
using ConfigTool.Api;

namespace ConfigTool.App.MySql
{
    public class Program
    {
        public static Task Main(string[] args)
        {
            return ProgramStart.RunAsync<Startup>(args);
        }
    }
}