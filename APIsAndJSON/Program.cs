using System.Threading.Tasks;
using APIsAndJSON;


namespace APIsAndJSON
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			RonVskanyeApi ronVsKanye = new RonVskanyeApi();
			await ronVsKanye.StartConversationAsync();
		}
	}
}
