using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Excercise4MondayClient
{
    class Program
    {
        private static TcpClient client = new TcpClient("localhost", 50000);
        private static StreamReader sr = new StreamReader(client.GetStream());
        private static StreamWriter sw = new StreamWriter(client.GetStream());

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }

        private void Run()
        {
            Thread readerThread = new Thread(Reader);
            readerThread.Start();
            Thread writerThread = new Thread(Writer);
            writerThread.Start();
        }
        private void Reader()
        {
            string read = sr.ReadLine();
            do
            {
                Console.WriteLine(read);
                read = sr.ReadLine();
            } while (read != "" && read != null);
        }
        private void Writer()
        {
            string data = "";
            do
            {
                data = Console.ReadLine();
                sw.WriteLine(data);
                sw.Flush();
            } while (data != "" && data != null);
        }
    }
}
