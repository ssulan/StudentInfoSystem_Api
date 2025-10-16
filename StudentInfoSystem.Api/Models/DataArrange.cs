using System;
using System.Reflection;
using System.Text.RegularExpressions;
namespace StudentInfoSystem.Api.Models
{
	public class DataArrange
	{
		

		public string FirstCharToUpper(string s)
		{
			List<string> list = new List<string>();

			if (string.IsNullOrEmpty(s))
			{
				return string.Empty;//early return
			}

            //The spaces in the data are removed and the words are assigned to an array
            s = s.Trim();
			string[] elements = Regex.Replace(s, @"\s+", " ").Split(" ");


			//The first letter of the incoming data is capitalized while the rest are converted to lowercase
			for (int i = 0; i < elements.Length; i++)
			{
				list.Add(char.ToUpper(elements[i][0]) + elements[i].Substring(1).ToLower() );
			}

            //The formatted data is joined with spaces in between and returned
            return string.Join(" ",list);

		}

	}
}

