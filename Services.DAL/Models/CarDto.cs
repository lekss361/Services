namespace Services.Models;

using Services.DAL.Models;

public class CarDto :BaseDto
{
    public UserDto User { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
}
