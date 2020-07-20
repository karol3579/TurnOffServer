using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace Windows_Security
{
    class Server
    {

        TcpListener server = null;
        public void run()
        {
            Int32 port = 55123;
            
            server = new TcpListener(IPAddress.Any,port);
            server.Start();

            Byte[] bytes = new Byte[256];
            
            while (true)
            {
                Console.Write("Waiting for a connection... ");
                // Perform a blocking call to accept requests.
                // You could also use server.AcceptSocket() here.
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Connected!");

                Byte[] message = Encoding.ASCII.GetBytes("wylaczako xd");

               
                

                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();
                stream.Write(message, 0,message.Length);

                //turn off pc
                ShutDown shut = new ShutDown();
                shut.shutDown();


                // Shutdown and end connection
                stream.Close();
                client.Close();
            }
        }
    }
}       
    
