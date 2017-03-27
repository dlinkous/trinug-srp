using System;
using Xunit;
using ReviewManager.Services.New.Experience;

namespace ReviewManager.Tests.Unit
{
    public class AmiableExperienceTests
    {
		[Fact]
		public void GenerateRatingMessage_NoRatings()
		{
			var experience = new AmiableExperience();
			var message = experience.GenerateRatingMessage(0, 0);
			Assert.Equal("There are no ratings.  Please consider rating this item.", message);
		}

		[Fact]
		public void GenerateRatingMessage_TooFewRatings()
		{
			var experience = new AmiableExperience();
			var message = experience.GenerateRatingMessage(1, 3);
			Assert.Equal("This item needs more ratings.  Please consider rating this item.", message);
		}

		[Fact]
		public void GenerateRatingMessage_ManyRatings()
		{
			var experience = new AmiableExperience();
			var message = experience.GenerateRatingMessage(5, 3);
			Assert.Equal("This item has been rated by many customers.", message);
		}

		[Fact]
		public void GenerateRatingMessage_LoveIt()
		{
			var experience = new AmiableExperience();
			var message = experience.GenerateRatingMessage(5, 5);
			Assert.Equal("Our customers love this item!", message);
		}
	}
}
