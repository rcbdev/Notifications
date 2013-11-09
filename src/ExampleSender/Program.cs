using Notifications.Sender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleSender
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Title: ");
                var title = Console.ReadLine();

                Console.Write("Message: ");
                var message = Console.ReadLine();

                Console.Write("URL: ");
                var url = Console.ReadLine();

                Console.WriteLine("Message Type: ");
                Console.WriteLine("1: info");
                Console.WriteLine("2: success");
                Console.WriteLine("3: warning");
                Console.WriteLine("4: error");

                var typeNum = Console.ReadKey().Key;

                NotificationSender.NotificationType type;

                switch(typeNum)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        type = NotificationSender.NotificationType.Info;
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        type = NotificationSender.NotificationType.Success;
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        type = NotificationSender.NotificationType.Warning;
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        type = NotificationSender.NotificationType.Error;
                        break;
                    default:
                        type = NotificationSender.NotificationType.Info;
                        break;
                }

                Console.WriteLine();

                NotificationSender.SendNotification(message, title, type, url);

                Console.WriteLine("Notification Sent");
                Console.WriteLine("Send another? (y/n)");
                if (Console.ReadKey().Key == ConsoleKey.N)
                {
                    break;
                }
                Console.WriteLine();
                Console.WriteLine("-----------");
            }
        }
    }
}
