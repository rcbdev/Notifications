
namespace Notifications.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Core.Server.Startup.Start())
            {
                System.Console.Read();
            }
        }
    }
}
