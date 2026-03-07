using System;

// Rating class
class Rating
{
    int imdbRating;
    int nominee;

    public Rating(int imdbRating, int nominee)
    {
        this.imdbRating = imdbRating;
        this.nominee = nominee;
    }

    // Properties to access private fields
    public int ImdbRating
    {
        get { return imdbRating; }
    }

    public int Nominee
    {
        get { return nominee; }
    }
}

// Validator class
class Validator
{
    public string canBeConsideredForTheAward(Rating rating)
    {
        if (rating.ImdbRating < 7)
        {
            throw new MovieRatingException("Movie not eligible for FilmFare award");
        }
        else if (rating.Nominee < 4)
        {
            throw new MovieRatingException("Minimum 4 nominee required");
        }

        return "Considered for the award";
    }

    public string sendInvite(Rating rating)
    {
        try
        {
            canBeConsideredForTheAward(rating);
            return "Actors and Directors invited";
        }
        catch (MovieRatingException)
        {
            return "Not invited";
        }
        catch (Exception)
        {
            return "Other exception";
        }
    }
}

// Custom Exception
class MovieRatingException : Exception
{
    public MovieRatingException(string msg) : base(msg)
    {
    }
}

public class Source
{
    public static void Main(string[] args)
    {
        Rating rating = new Rating(9, 7);
        Validator v = new Validator();

        try
        {
            string s = v.canBeConsideredForTheAward(rating);
            string t = v.sendInvite(rating);

            Console.WriteLine(s.ToLower());
            Console.WriteLine(t.ToLower());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
