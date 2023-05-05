using pokemon;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Pokemon p = new Pokemon();

app.MapGet("/", () => "Welcome To Game Freak");

// Para Crear 1 pokemon
app.MapPost("/api/v1/pokemon/create1", (DTOpokemon x) => 
{
    p.create_one(x);
    return Results.Ok(p.get_all());
});

// Para Crear muchos pokemon
app.MapPost("/api/v1/pokemon/createall", (DTOpokemon[] x) =>
{
    p.create_several(x);
    return Results.Ok(p.get_all());
});

// Para Editar 1 pokemon
app.MapPut("/api/v1/pokemon/edit1/{id}", (int id, DTOpokemon x) =>
{
    p.edit_one(id, x);
    return Results.Ok(p.get_all());
});

// Para Eliminar 1 pokemon
app.MapDelete("/api/v1/pokemon/eliminar1/{id}", (int id) =>
{
    p.delete_one(id);
    return Results.Ok(p.get_all());
});

// Para Traer 1 pokemon
app.MapGet("/api/v1/pokemon/get1/{id}", (int id) =>
{
    return Results.Ok(p.get_one(id));
}); 

// Para Traer Todos los pokemons de un tipo
app.MapGet("/api/v1/pokemon/getalltype/{type}", (string type) =>
{
    return Results.Ok(p.get_all_type(type));
});

//--------- Métodos Adicionales-----------

// 1. Para Mostrar Todos los Pokemons en la Base de Datos
app.MapGet("/api/v1/pokemon/getall", () =>
{
    return Results.Ok(p.get_all());
});

app.Run();

/*--------Datos de prueba-----------

[{
    "id": 1,
    "nombre": "Pikachu",
    "tipo": "Eléctrico",
    "habilidades": [4, 20, 32, 40],
    "defensa": 29.5
},
{
    "id": 2,
    "nombre": "Eevee",
    "tipo": "Normal",
    "habilidades": [8, 2, 30, 23],
    "defensa": 19.5
}
,
{
    "id": 3,
    "nombre": "Eevee",
    "tipo": "Normal",
    "habilidades": [8, 2, 30, 40],
    "defensa": 4.5
}
,
{
    "id": 4,
    "nombre": "Lori",
    "tipo": "Normal",
    "habilidades": [8, 2, 30, 20],
    "defensa": 19.5
}]

{
    "id":1,
    "nombre": "Puchamon",
    "tipo": "Mamado",
    "habilidades": [11, 11, 11, 11],
    "defensa": 11
}
*/