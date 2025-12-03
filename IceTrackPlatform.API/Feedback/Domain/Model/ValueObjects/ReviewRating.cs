namespace IceTrackPlatform.API.Feedback.Domain.Model.ValueObjects;

public record ReviewRating(int Value)
{
    public ReviewRating() : this(0)
    {
    }
}

