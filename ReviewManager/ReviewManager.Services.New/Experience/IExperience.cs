using System;

namespace ReviewManager.Services.New.Experience
{
    public interface IExperience
    {
		string GenerateRatingMessage(int ratingQuantity, byte ratingAverage);
    }
}
