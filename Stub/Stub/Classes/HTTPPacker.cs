using System;
using System.Net.Sockets;
using System.Text;

namespace Stub
{
	// Token: 0x02000004 RID: 4
	internal class HTTPPacker
	{
		// Token: 0x06000024 RID: 36 RVA: 0x00003EF8 File Offset: 0x000020F8
		public void sendRequest(HTTPRequest request)
		{
			TcpClient tcpClient = new TcpClient();
			try
			{
				try
				{
					tcpClient.Connect(currentHost, currentPort);
				}
				catch
				{
				}
				NetworkStream stream = tcpClient.GetStream();
				byte[] bytes = Encoding.ASCII.GetBytes(request.RequestStr);
				stream.Write(bytes, 0, bytes.Length);
			}
			catch
			{
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00003F78 File Offset: 0x00002178
		public void makeRequest(string nHost, int nPort = 0, HTTPRequest req = null)
		{
			currentHost = cleanUrl(nHost);
			if (nPort != 0)
			{
				currentPort = cleanPort(nHost);
			}
			else
			{
				currentPort = nPort;
			}
			msgHost = currentHost;
			msgUrl = nHost;
			if (req == null)
			{
				req = new HTTPRequest();
				req.SetUrl(msgUrl);
				req.SetHost(currentHost);
				req.BuildGETRequest();
			}
			sendRequest(req);
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00004004 File Offset: 0x00002204
		public string cleanUrl(string url)
		{
			return url.Replace("http://", "").Replace("https://", "").Split(new char[]
			{
				'/'
			})[0].Split(new char[]
			{
				':'
			})[0];
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00004060 File Offset: 0x00002260
		public int cleanPort(string url)
		{
			int result;
			if (url.Replace("http://", "").Replace("https://", "").Split(new char[]
			{
				'/'
			})[0].Split(new char[]
			{
				':'
			}).Length > 1)
			{
				result = Convert.ToInt32(url.Replace("http://", "").Replace("https://", "").Split(new char[]
				{
					'/'
				})[0].Split(new char[]
				{
					':'
				})[1]);
			}
			else
			{
				result = 80;
			}
			return result;
		}

		// Token: 0x04000023 RID: 35
		private string msgUrl = "http://127.0.0.1/";

		// Token: 0x04000024 RID: 36
		private string msgHost = "127.0.0.1";

		// Token: 0x04000025 RID: 37
		public string lastMessage = "";

		// Token: 0x04000026 RID: 38
		public string currentHost = "127.0.0.1";

		// Token: 0x04000027 RID: 39
		public int currentPort = 80;
	}
}
