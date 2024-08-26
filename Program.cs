
var builder = WebApplication.CreateBuilder(args);

// Configura Kestrel para que escuche en todas las interfaces de red en el puerto 80
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(80);
});

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura CORS para permitir cualquier origen
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


var app = builder.Build();

// Aplica la política CORS
app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Lista de Pokémon
var pokemons = new List<Pokemon>
{
    new Pokemon
    {
        Name = "Pikachu",
        Type = new[] { "Electric" },
        Weakness = new[] { "Ground" },
        Image = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/025.png"
    },
    new Pokemon
    {
        Name = "Charmander",
        Type = new[] { "Fire" },
        Weakness = new[] { "Water", "Ground", "Rock" },
        Image = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/004.png"
    },
    new Pokemon
    {
        Name = "Bulbasaur",
        Type = new[] { "Grass", "Poison" },
        Weakness = new[] { "Fire", "Psychic", "Flying", "Ice" },
        Image = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/001.png"
    },
    new Pokemon
    {
        Name = "Squirtle",
        Type = new[] { "Water" },
        Weakness = new[] { "Electric", "Grass" },
        Image = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/007.png"
    },
    new Pokemon
    {
        Name = "Jigglypuff",
        Type = new[] { "Normal", "Fairy" },
        Weakness = new[] { "Steel", "Poison" },
        Image = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/039.png"
    }
};

// Endpoint para obtener la lista de Pokémon
app.MapGet("/pokemon", () =>
{
    return pokemons;
})
.WithName("GetPokemons")
.WithOpenApi();

// Endpoint para buscar un Pokémon por nombre
app.MapGet("/pokemon/{name}", (string name) =>
{
    var pokemon = pokemons.FirstOrDefault(p => string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase));
    if (pokemon == null)
    {
        return Results.NotFound(new { Message = $"Pokemon with name '{name}' not found." });
    }
    return Results.Ok(pokemon);
})
.WithName("GetPokemonByName")
.WithOpenApi();

app.Run();

// Definición de la clase Pokemon
record Pokemon
{
    public string Name { get; init; }
    public string[] Type { get; init; }
    public string[] Weakness { get; init; }
    public string Image { get; init; }
}
