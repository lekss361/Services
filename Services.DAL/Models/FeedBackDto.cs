namespace Services.Models;

using Services.DAL.Models;

public class FeedBackDto:BaseDto
{
    public string Text { get; set; }
    public UserDto User { get; set; }
}
