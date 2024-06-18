namespace GameStore.Dtos;

public record GameDto(
    int Id,
    string name,
    string Genre,
    decimal Price,
    DateOnly Releasedate
); 