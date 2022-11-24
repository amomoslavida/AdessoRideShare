namespace AdessoRideShare.Models;

public class travelPlan {
    public int ID { get; set; }
    public string? From { get; set; }
    public string? To { get; set; }

    public DateTime Date { get; set; }

    public string? explanation { get; set; } 
    public int maxSeats { get; set; }
    public bool? isPublished { get; set; }

    public int? NumberOfTravelers { get; set; } = 0;

}


