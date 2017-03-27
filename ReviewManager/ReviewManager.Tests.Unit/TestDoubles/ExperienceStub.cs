using System;
using ReviewManager.Services.New.Experience;

namespace ReviewManager.Tests.Unit.TestDoubles
{
	internal class ExperienceStub : IExperience
	{
		public string GenerateRatingMessage(int ratingQuantity, byte ratingAverage)
		{
			return "UnitTestRatingMessage";
		}
	}
}
