using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPClient
{
    class Program
    {
        
        private static TcpClient _clientSocket = null;
        private static Stream _nStream = null;
        private static StreamWriter _sWriter = null;
        private static StreamReader _sReader = null;
        static void Main(string[] args)
        {
            try
            {
                using (_clientSocket = new TcpClient("283.6.0.2", 7070))
                {
                    using (_nStream = _clientSocket.GetStream())
                    {
                        while (true)
                        {
                            _sWriter = new StreamWriter(_nStream) { AutoFlush = true };

                            Console.WriteLine("Type your request here.. ");
                            string clientMsg = Console.ReadLine();

                            _sWriter.WriteLine(clientMsg);

                            _sReader = new StreamReader(_nStream);
                            string rdMsgFromServer = _sReader.ReadLine();
                            if (rdMsgFromServer != null)
                            {
                                Console.WriteLine("Client recieved typed Message from Server:" + rdMsgFromServer);
                            }
                            else
                            {
                                Console.WriteLine("Client recieved null message from Server. ");
                            }


                        }
                    }
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
            }
        }
    }
}

