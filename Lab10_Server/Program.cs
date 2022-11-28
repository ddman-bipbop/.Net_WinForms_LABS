using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryAuto;
using Newtonsoft.Json;

namespace Server
{
    class Program
    {
        private static ConcurrentDictionary<string, Auto> _autos = new ConcurrentDictionary<string, Auto>();
        static void Main(string[] args)
        {
            // Устанавливаем для сокета локальную конечную точку
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 11000);

            // Создаем сокет Tcp/Ip
            Socket sListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Назначаем сокет локальной конечной точке и слушаем входящие сокеты
            try
            {
                sListener.Bind(ipEndPoint);
                sListener.Listen(10);
                // Начинаем слушать соединения
                while (true)
                {
                    Console.WriteLine("Ожидаем соединение через порт {0}", ipEndPoint);
                    // Программа приостанавливается, ожидая входящее соединение
                    Socket socket = sListener.Accept();
                    Task taskSocket = new Task(Action, socket);
                    taskSocket.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.ReadLine();
            }
        }
        
        private static void Action(object o)
        {
            Socket socket = o as Socket;
            if (socket != null)
            {
                while (true)
                {
                    try
                    {
                        // Мы дождались клиента, пытающегося с нами соединиться
                        byte[] bytes = new byte[10240];
                        int bytesRec = socket.Receive(bytes);
                        string json = Encoding.UTF8.GetString(bytes, 0, bytesRec);
                        AutoResponse response = new AutoResponse { IsSuccess = false };
                        try
                        {
                            var request = JsonConvert.DeserializeObject<AutoRequest>(json);
                            if (request != null)
                            {
                                response.Key = request.Key;
                                Auto city;
                                switch (request.Type)
                                {
                                    case AutoRequestType.Get:
                                        if (_autos.TryGetValue(request.Key, out city))
                                        {
                                            response.Auto = city;
                                            response.IsSuccess = true;
                                        }
                                        else
                                        {
                                            response.ErrorMessage = "Ключ не найден";
                                        }
                                        break;
                                    case AutoRequestType.Add:
                                        if (_autos.ContainsKey(request.Key))
                                        {
                                            response.ErrorMessage = "Машина с таким ключем уже существует";
                                        }
                                        else
                                        {
                                            _autos.AddOrUpdate(request.Key, request.Auto, (s, city1) => request.Auto);
                                            response.IsSuccess = true;
                                        }
                                        break;
                                    case AutoRequestType.Update:
                                        if (_autos.ContainsKey(request.Key))
                                        {
                                            _autos.AddOrUpdate(request.Key, request.Auto, (s, city1) => request.Auto);
                                            response.IsSuccess = true;
                                        }
                                        else
                                        {
                                            response.ErrorMessage = "Машина с таким ключем не существует";
                                        }
                                        break;
                                    case AutoRequestType.Remove:
                                        if (_autos.ContainsKey(request.Key))
                                        {
                                            if (_autos.TryRemove(request.Key, out city))
                                            {
                                                response.IsSuccess = true;
                                            }
                                            else
                                            {
                                                response.ErrorMessage = "Не удалось удалить Машину";
                                            }
                                        }
                                        else
                                        {
                                            response.ErrorMessage = "Машина с таким ключем не существует";
                                        }
                                        break;
                                    default:
                                        throw new ArgumentOutOfRangeException();
                                }
                            }
                        }
                        catch (Exception exception)
                        {
                            response.ErrorMessage = exception.Message;
                        }
                        // Показываем данные на консоли
                        Console.WriteLine("Полученный json: " + json);
                        // Отправляем ответ клиенту\
                        var jsonResponse = JsonConvert.SerializeObject(response);
                        byte[] msg = Encoding.UTF8.GetBytes(jsonResponse);
                        Console.Write("Отправленный json: " + jsonResponse);
                        socket.Send(msg);
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
        }
    }
}

