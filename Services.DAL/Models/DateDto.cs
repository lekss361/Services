namespace Services.Models;

using Services.DAL.Models;

public class DateDto  :BaseDto
{
    public DateTime StartDate { get; set; }
    public TimeDto Time { get; set;}
}
