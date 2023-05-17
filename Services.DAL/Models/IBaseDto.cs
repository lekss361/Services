namespace Services.DAL.Models;

public interface IBaseDto
{
    int Id { get; set; }
    bool IsActive { get; set; }

}