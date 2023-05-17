namespace Services.Models;

using Services.DAL.Models;

public class ServiceDto:BaseDto
{
    public string Name { get; set; }
    public int Cost { get; set; }
}
