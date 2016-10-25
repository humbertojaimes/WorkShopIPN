using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace WorkShopIPN.Communication
{
	public class ImageClient
	{
		public ImageClient()
		{
		}

		private readonly HttpClient _imageClient = new HttpClient();

		public async Task<byte[]> GetImage(string imageUrl)
		{
			byte[] response = null;

			using (Stream responseStream = _imageClient.GetStreamAsync(imageUrl).Result)
			{
				using (MemoryStream responseMemoryStream = new MemoryStream())
				{
					responseStream.CopyTo(responseMemoryStream);
					response = responseMemoryStream.ToArray();
				}

			}

			return response;
		}


	}

}

