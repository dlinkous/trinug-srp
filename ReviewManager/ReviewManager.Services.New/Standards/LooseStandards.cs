using System;

namespace ReviewManager.Services.New.Standards
{
	public class LooseStandards : IStandards
	{
		public string CleanComment(string comment)
		{
			var cleanedComment = comment;
			foreach (var badWord in GetBadWords())
			{
				cleanedComment = cleanedComment.Replace(badWord, GetReplacement());
			}
			return cleanedComment;
		}

		private string[] GetBadWords()
		{
			return new string[] { "poo", "pee", "competitor" };
		}

		private string GetReplacement()
		{
			return "CENSORED";
		}
	}
}
