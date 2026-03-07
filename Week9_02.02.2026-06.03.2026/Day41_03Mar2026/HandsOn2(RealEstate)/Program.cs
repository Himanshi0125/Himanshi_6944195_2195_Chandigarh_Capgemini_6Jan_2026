using System;
using System.Collections.Generic;
using System.Linq;

// RealEstateListing class
public class RealEstateListing
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public string Location { get; set; }

    public RealEstateListing(int id, string title, string description, int price, string location)
    {
        ID = id;
        Title = title;
        Description = description;
        Price = price;
        Location = location;
    }
}

// RealEstateApp class
public class RealEstateApp
{
    private List<RealEstateListing> listings = new List<RealEstateListing>();

    // Add listing
    public void AddListing(RealEstateListing listing)
    {
        listings.Add(listing);
    }

    // Remove listing by ID
    public void RemoveListing(int listingID)
    {
        var listing = listings.FirstOrDefault(l => l.ID == listingID);
        if (listing != null)
        {
            listings.Remove(listing);
        }
    }

    // Update listing
    public void UpdateListing(RealEstateListing updatedListing)
    {
        var listing = listings.FirstOrDefault(l => l.ID == updatedListing.ID);
        if (listing != null)
        {
            listing.Title = updatedListing.Title;
            listing.Description = updatedListing.Description;
            listing.Price = updatedListing.Price;
            listing.Location = updatedListing.Location;
        }
    }

    // Get all listings
    public List<RealEstateListing> GetListings()
    {
        return listings;
    }

    // Get listings by location
    public List<RealEstateListing> GetListingsByLocation(string location)
    {
        return listings
            .Where(l => l.Location.Equals(location, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    // Get listings by price range
    public List<RealEstateListing> GetListingsByPriceRange(int minPrice, int maxPrice)
    {
        return listings
            .Where(l => l.Price >= minPrice && l.Price <= maxPrice)
            .ToList();
    }
}

// Example usage
class Program
{
    static void Main(string[] args)
    {
        RealEstateApp app = new RealEstateApp();

        app.AddListing(new RealEstateListing(1, "Luxury Apartment", "Sea facing", 5000000, "Mumbai"));
        app.AddListing(new RealEstateListing(2, "Villa", "Spacious villa", 12000000, "Delhi"));
        app.AddListing(new RealEstateListing(3, "Studio Flat", "Compact flat", 2000000, "Mumbai"));

        Console.WriteLine("All Listings:");
        foreach (var l in app.GetListings())
        {
            Console.WriteLine($"{l.ID} {l.Title} {l.Location} {l.Price}");
        }

        Console.WriteLine("\nListings in Mumbai:");
        foreach (var l in app.GetListingsByLocation("Mumbai"))
        {
            Console.WriteLine(l.Title);
        }

        Console.WriteLine("\nListings between 1M and 6M:");
        foreach (var l in app.GetListingsByPriceRange(1000000, 6000000))
        {
            Console.WriteLine(l.Title);
        }
    }
}