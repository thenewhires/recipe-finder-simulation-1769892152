using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowReactApp");

app.MapGet("/recipes", ([FromQuery] string ingredients) =>
{
    // Simulate a database or recipe data
    var recipes = new List<Recipe>
    {
        new Recipe { Id = 1, Name = "Pasta Carbonara", Ingredients = "Pasta, Eggs, Bacon, Parmesan", Instructions = "Cook pasta. Mix eggs, cheese, and bacon. Combine.",}, // Missing pepper
        new Recipe { Id = 2, Name = "Tomato Soup", Ingredients = "Tomatoes, Onion, Garlic, Broth", Instructions = "Saute onion and garlic. Add tomatoes and broth. Simmer.", },
        new Recipe { Id = 3, Name = "Chicken Stir-Fry", Ingredients = "Chicken, Soy Sauce, Vegetables", Instructions = "Stir-fry chicken and vegetables. Add soy sauce.", }
    };

    if (string.IsNullOrEmpty(ingredients))
    {
        return Results.Ok(recipes);
    }

    //Bug: this is case sensitive. Should be case-insensitive.
    var filteredRecipes = recipes.Where(r => r.Ingredients.Contains(ingredients)).ToList();

    // Intentional bug: Not returning the result as Ok
    return Results.NotFound();
})
.WithName("GetRecipes")
.WithOpenApi();

app.Run();

record Recipe
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Ingredients { get; set; }
    public string? Instructions { get; set; }
}