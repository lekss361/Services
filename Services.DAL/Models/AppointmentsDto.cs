namespace Services.Models;

using Services.DAL.Models;

public class AppointmentsDto:BaseDto
{
    public   StatusDto Status { get; set; }
    public DateDto Date{ get; set;}
    public CarDto Car { get; set; }
    public ServiceDto Service { get; set; }
    public UserDto User { get; set;}
}
