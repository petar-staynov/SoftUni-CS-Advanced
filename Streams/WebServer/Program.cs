using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace WebServer
{
    class Program
    {
        private const int PortNumber = 5000;

        static void Main(string[] args)
        {
            var tcpListener = new TcpListener(IPAddress.Any, PortNumber);
            tcpListener.Start();
            Console.WriteLine("Listening on port {0}...", PortNumber);

            while (true)
            {
                using (NetworkStream stream = tcpListener.AcceptTcpClient().GetStream())
                {
                    byte[] request = new byte[4096];
                    stream.Read(request, 0, 4096);
                    //Console.WriteLine(Encoding.UTF8.GetString(request));
                    string requestinfo = Encoding.UTF8.GetString(request);
                    
                    int indexOfRequest = requestinfo.IndexOf("GET");

                    string requestString = requestinfo.Substring(indexOfRequest, 10);
                    Console.WriteLine(requestString);
                    if (requestString == "GET / HTTP")
                    {
                        string html = string.Format("{0}{1}{2}{3} - {4}{2}{1}{0}",
                            "<html>", "<body>", "<h1>", "Welcome to my awesome site!", DateTime.Now);
                        byte[] htmlBytes = Encoding.UTF8.GetBytes(html);
                        stream.Write(htmlBytes, 0, htmlBytes.Length);
                    }
                    else if (requestString == "GET /info ")
                    {
                        int coreCount = Environment.ProcessorCount;

                        string html = $"Current date and time: {DateTime.Now.Hour}:{DateTime.Now.Minute}. Logical processors = {coreCount}";
                        byte[] htmlBytes = Encoding.UTF8.GetBytes(html);
                        stream.Write(htmlBytes, 0, htmlBytes.Length);
                    }
                    else
                    {
                        string html = @"ERROR";
                        byte[] htmlBytes = Encoding.UTF8.GetBytes(html);
                        stream.Write(htmlBytes, 0, htmlBytes.Length);
                    }
                }
            }

        }
    }
}
