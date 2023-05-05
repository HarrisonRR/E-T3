namespace pokemon;

interface IPokemon
{
    // Método para Crear 1 pokemon 
    public void create_one(DTOpokemon poke);

    // Método para Crear muchos pokemons
    public void create_several(DTOpokemon[] listPK);

    // Método para Editar 1 pokemon
    public void edit_one(int id, DTOpokemon poke);

    // Método para Eliminar 1 pokemon
    public void delete_one(int id);

    // Método para Traer 1 pokemon
    public DTOpokemon get_one(int id);

    // Método para Traer Todos los Pokemons de un Tipo
    public List<DTOpokemon> get_all_type(string type);

    // ---------------------------------------------------
    // ----------------- Métodos Adicionales -------------

    // 1. Método para Mostrar Todos los Pokemons en la Base de Datos
    public List<DTOpokemon> get_all();

}