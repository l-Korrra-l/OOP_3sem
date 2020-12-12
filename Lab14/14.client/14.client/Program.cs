using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;

namespace Lab14
{
    class Program
    {
            // адрес и порт сервера, к которому будем подключаться
            static int port = 8005; // порт сервера
            static string address = "127.0.0.1"; // адрес сервера
            static void Main(string[] args)
            {
                try
                {
                    IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);

                    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    // подключаемся к удаленному хосту
                    socket.Connect(ipPoint);
                     Check first = new Check("Title", new DateTime(2020, 11, 12), "Hello", "client", 100500);
                     Console.Write("Отправляемое сообщение:");
                     string buff = first.ToString();
                     Console.WriteLine(buff);
                    

                    BinaryFormatter formatter = new BinaryFormatter();
                    MemoryStream stream = new MemoryStream();

                
                    formatter.Serialize(stream, first);
                    byte[] buffer = stream.ToArray();
                    byte[] bu = Encoding.Unicode.GetBytes(buff);
                    socket.Send(bu);

                    // закрываем сокет

                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.Read();
            }
    }
    
}
