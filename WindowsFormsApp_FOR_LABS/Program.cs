using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryCities;
using Newtonsoft.Json;

namespace Server
{
    class Program
    {
        private static ConcurrentDictionary<string, City> _cities = new ConcurrentDictionary<string, City>();
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
                        CityResponse response = new CityResponse { IsSuccess = false };
                        try
                        {
                            var request = JsonConvert.DeserializeObject<CityRequest>(json);
                            if (request != null)
                            {
                                response.Key = request.Key;
                                City city;
                                switch (request.Type)
                                {
                                    case CityRequestType.Get:
                                        if (_cities.TryGetValue(request.Key, out city))
                                        {
                                            response.City = city;
                                            response.IsSuccess = true;
                                        }
                                        else
                                        {
                                            response.ErrorMessage = "Ключ не найден";
                                        }
                                        break;
                                    case CityRequestType.Add:
                                        if (_cities.ContainsKey(request.Key))
                                        {
                                            response.ErrorMessage = "Город с таким ключем уже существует";
                                        }
                                        else
                                        {
                                            _cities.AddOrUpdate(request.Key, request.City, (s, city1) => request.City);
                                            response.IsSuccess = true;
                                        }
                                        break;
                                    case CityRequestType.Update:
                                        if (_cities.ContainsKey(request.Key))
                                        {
                                            _cities.AddOrUpdate(request.Key, request.City, (s, city1) => request.City);
                                            response.IsSuccess = true;
                                        }
                                        else
                                        {
                                            response.ErrorMessage = "Город с таким ключем не существует";
                                        }
                                        break;
                                    case CityRequestType.Remove:
                                        if (_cities.ContainsKey(request.Key))
                                        {
                                            if (_cities.TryRemove(request.Key, out city))
                                            {
                                                response.IsSuccess = true;
                                            }
                                            else
                                            {
                                                response.ErrorMessage = "Не удалось удалить город";
                                            }
                                        }
                                        else
                                        {
                                            response.ErrorMessage = "Город с таким ключем не существует";
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
