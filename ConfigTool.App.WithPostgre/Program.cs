using System.Threading.Tasks;
using ConfigTool.Api;

namespace ConfigTool.App.WithPostgre
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ProgramStart.RunAsync<Startup>(args);
        }
    }
}