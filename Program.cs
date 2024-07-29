using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace burowe {
    class Program {
        static void Main(string[] args) {

            if (args[0] == "sender") {
                Sender();
            } else if (args[0] == "receiver") {
                Receiver();
            }
        }

        static void Sender() {
        Console.Write("Enter PORT: \n> ");
        int port = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter USERNAME: \n> ");
        string? username = Console.ReadLine();

        Console.Write("Enter MESSAGE: \n> ");

        UdpClient sender = new UdpClient();

        while (true) {
            string? message = Console.ReadLine();
            byte[] buffer = Encoding.ASCII.GetBytes(username + ": " + message);
            sender.Send(buffer, buffer.Length, new IPEndPoint(IPAddress.Loopback, port));

            Console.Write("> ");
        }
        
        }

        static void Receiver() {
            Console.Write("Enter PORT: ");
            int port = Convert.ToInt32(Console.ReadLine());

            UdpClient receiver = new UdpClient(port);
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);

            Console.WriteLine("Listening for messages on port " + port);

            while (true)
            {
                byte[] buffer = receiver.Receive(ref remoteEndPoint);
                string message = Encoding.ASCII.GetString(buffer);
                Console.WriteLine("> " + message);
            }
        }

}

}