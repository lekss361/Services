namespace Services.Models;

using Services.DAL.Models;

public class TimeDto :BaseDto
{
    public DateTime StartTime { get; set; }
    public StatusDto  Status { get; set; }
}
