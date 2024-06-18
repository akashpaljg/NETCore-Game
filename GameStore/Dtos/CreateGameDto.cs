namespace GameStore.Dtos;

public record CreateGameDto(
    string name,
    string Genre,
    decimal Price,
    DateOnly Releasedate
);