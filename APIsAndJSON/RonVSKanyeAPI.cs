using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

class RonVskanyeApi
{
	public async Task StartConversationAsync()
	{
		var ronSwansonApiUrl = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
		var kanyeWestApiUrl = "https://api.kanye.rest/quotes";

		using (var httpClient = new HttpClient())
		{
			for (int turn = 0; turn < 5; turn++) // Repeat the conversation 5 times
			{
				var ronResponse = await httpClient.GetStringAsync(ronSwansonApiUrl);
				var kanyeResponse = await httpClient.GetStringAsync(kanyeWestApiUrl);

				var ronQuotes = ParseRonSwansonQuotes(ronResponse);
				var kanyeQuotes = TryParseKanyeQuotes(kanyeResponse);

				for (int i = 0; i < 5; i++) // Simulate 5 lines of dialogue
				{
					if (i < ronQuotes.Count)
					{
						Console.WriteLine("Ron Swanson: " + ronQuotes[i]);
						Console.WriteLine("");
                    }

					if (i < kanyeQuotes.Count)
					{
						Console.WriteLine("Kanye West: " + kanyeQuotes[i]);
						Console.WriteLine("");
					}
				}
			}
		}

		Console.ReadLine();
	}

	private JArray ParseRonSwansonQuotes(string response)
	{
		
		return new JArray(response);
	}

	private JArray TryParseKanyeQuotes(string response)
	{
		try
		{
			return JArray.Parse(response);
		}
		catch (JsonReaderException)
		{
			return new JArray(response);
		}
	}
}

