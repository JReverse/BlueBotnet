using System;

namespace Stub
{
	internal class HTTPRequest
	{
		// Token: 0x06000029 RID: 41 RVA: 0x00004154 File Offset: 0x00002354
		public void BuildGETRequest()
		{
			RequestStr = "";
			RequestStr += GETPiece;
			RequestStr += HostPiece;
			RequestStr += UserAgentPiece;
			RequestStr += AcceptPiece;
			RequestStr += AcceptLangPiece;
			RequestStr += AcceptEncodingPiece;
			RequestStr += ConnectionPiece;
			RequestStr += "/r/n";
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00004224 File Offset: 0x00002424
		public void BuildPOSTRequest()
		{
			RequestStr = "";
			RequestStr += POSTPiece;
			RequestStr += HostPiece;
			RequestStr += UserAgentPiece;
			RequestStr += AcceptPiece;
			RequestStr += AcceptLangPiece;
			RequestStr += AcceptEncodingPiece;
			RequestStr += ContentTypePiece;
			RequestStr += ContentLengthPiece;
			RequestStr += ConnectionPiece;
			RequestStr += "/r/n";
			RequestStr += POSTBody;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00004339 File Offset: 0x00002539
		public void SetUrl(string url)
		{
			GETPiece = GETStr.Replace("//URL//", url);
			POSTPiece = POSTStr.Replace("//URL//", url);
		}

		// Token: 0x0600002C RID: 44 RVA: 0x0000436A File Offset: 0x0000256A
		public void SetHost(string host)
		{
			HostPiece = HostStr.Replace("//URL//", host);
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00004384 File Offset: 0x00002584
		public void SetUserAgent(string userAgent)
		{
			UserAgentPiece = UserAgentStr.Replace("//USERAGENT//", userAgent);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x0000439E File Offset: 0x0000259E
		public void SetAccept(string accept)
		{
			AcceptPiece = AcceptStr.Replace("//ACCEPT//", accept);
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000043B8 File Offset: 0x000025B8
		public void SetAcceptLang(string acceptLang)
		{
			AcceptLangPiece = AcceptLangStr.Replace("//ACCEPTLANG//", acceptLang);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000043D2 File Offset: 0x000025D2
		public void SetAcceptEncoding(string acceptEncoding)
		{
			AcceptEncodingPiece = AcceptEncodingStr.Replace("//ACCEPTENCODING//", acceptEncoding);
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000043EC File Offset: 0x000025EC
		public void SetConnection(string connection)
		{
			ConnectionPiece = ConnectionStr.Replace("//CONNECTION//", connection);
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00004408 File Offset: 0x00002608
		public void SetPOSTBody(string body)
		{
			POSTBody = body;
			ContentLengthPiece = ContentLengthStr.Replace("//CONTENTLENGTH//", body.Length.ToString());
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00004441 File Offset: 0x00002641
		public void SetPOSTContentType(string contentType)
		{
			ContentTypePiece = ContentTypeStr.Replace("//CONTENTTYPE//", contentType);
		}

		// Token: 0x04000028 RID: 40
		public string GETPiece = "";

		// Token: 0x04000029 RID: 41
		public string POSTPiece = "";

		// Token: 0x0400002A RID: 42
		public string HostPiece = "";

		// Token: 0x0400002B RID: 43
		public string UserAgentPiece = "";

		// Token: 0x0400002C RID: 44
		public string AcceptPiece = "";

		// Token: 0x0400002D RID: 45
		public string AcceptLangPiece = "";

		// Token: 0x0400002E RID: 46
		public string AcceptEncodingPiece = "";

		// Token: 0x0400002F RID: 47
		public string ConnectionPiece = "";

		// Token: 0x04000030 RID: 48
		public string ContentTypePiece = "";

		// Token: 0x04000031 RID: 49
		public string ContentLengthPiece = "";

		// Token: 0x04000032 RID: 50
		public string RequestStr = "";

		// Token: 0x04000033 RID: 51
		private string GETStr = "GET //URL// HTTP/1.1/r/n";

		// Token: 0x04000034 RID: 52
		private string POSTStr = "POST //URL// HTTP/1.1/r/n";

		// Token: 0x04000035 RID: 53
		private string HostStr = "Host: //URL///r/n";

		// Token: 0x04000036 RID: 54
		private string UserAgentStr = "User-Agent: //USERAGENT///r/n";

		// Token: 0x04000037 RID: 55
		private string AcceptStr = "Accept: //ACCEPT///r/n";

		// Token: 0x04000038 RID: 56
		private string AcceptLangStr = "Accept-Language: //ACCEPTLANG///r/n";

		// Token: 0x04000039 RID: 57
		private string AcceptEncodingStr = "Accept-Encoding: //ACCEPTENCODING///r/n";

		// Token: 0x0400003A RID: 58
		private string ContentTypeStr = "Content-Type: //CONTENTTYPE///r/n";

		// Token: 0x0400003B RID: 59
		private string ContentLengthStr = "Content-Length: //CONTENTLENGTH///r/n";

		// Token: 0x0400003C RID: 60
		private string ConnectionStr = "Connection: //CONNECTION///r/n";

		// Token: 0x0400003D RID: 61
		private string POSTBody;
	}
}
