namespace GameStore.Dtos;

public record UpdatedGameDto(
    string name,
    string Genre,
    decimal Price,
    DateOnly Releasedate
);