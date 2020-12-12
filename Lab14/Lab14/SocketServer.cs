using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace Lab14
{
    class SocketServer
    {
       
        public static void Socket()
        {
           //public int port = 8005; // порт для приема входящих запросов
            // получаем адреса для запуска сокета
            IPEndPoint ipServ = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8005);  //ipv4
            //IPEndPoint ipClient = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);

            // создаем сокет
            Socket listenServ = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                // связываем сокет с локальной точкой, по которой будем принимать данные
                listenServ.Bind(ipServ);

                // начинаем прослушивание
                listenServ.Listen(10);//количество входящих подключений, которые могут быть поставлены в очередь сокета.

                Console.WriteLine("Сервер запущен. Ожидание подключений...");

                    Socket handlerServ = listenServ.Accept();// Если очередь запросов пуста, то метод Accept блокирует вызывающий поток до появления нового подключения.
                    // получаем сообщение
                    StringBuilder builderServ = new StringBuilder();
                    int bytesServ = 0; // количество полученных байтов
                    byte[] dataServ = new byte[256]; // буфер для получаемых данных
                        bytesServ = handlerServ.Receive(dataServ);
                        
                        BinaryFormatter formatter = new BinaryFormatter();
                        Stream stream = new MemoryStream();
                        Stream stream1 = new MemoryStream();
                        //Console.WriteLine
                        //formatter.Deserialize(dataServ);
                        //byte[] buffer = ((MemoryStream)stream).ToArray();
                        //stream1.Write(dataServ, 0, bytesServ);


                        //Stream streamt = new MemoryStream(dataServ);
                       
                        //formatter.Deserialize(streamt);
                        // Console.WriteLine(formatter);
                        //Check newPl = (Check)formatter.Deserialize(streamt);
                        //Console.WriteLine(newPl.ToString());


                        //BinaryFormatter formatterr = new BinaryFormatter();
                  
                        //MemoryStream streaml = new MemoryStream(dataServ);
                        //formatterr.Deserialize(streaml);
                        //Check newPl1 = (Check)formatterr.Deserialize(streaml);
                        //Console.WriteLine(newPl1.ToString());

                        //stream.Write(dataServ, 0, bytesServ);
                        
                        builderServ.Append(Encoding.Unicode.GetString(dataServ, 0, bytesServ));
                        Console.WriteLine(DateTime.Now.ToShortTimeString() + ": " + builderServ.ToString());

                    // закрываем сокет
                    handlerServ.Shutdown(SocketShutdown.Both);
                    handlerServ.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
