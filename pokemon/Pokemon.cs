namespace pokemon;

class Pokemon : IPokemon
{
    // Data Base
    private List<DTOpokemon> DB;

    public Pokemon()
    {
        this.DB = new List<DTOpokemon>();
    }

    // Método para Crear 1 pokemon
    public void create_one(DTOpokemon poke)
    {
        poke.habilidades = this.correctValues(poke.habilidades);
        poke.defensa = this.perfectDefense(poke.defensa);
        this.DB.Add(poke);
    }

    // Método para Crear muchos pokemons
    public void create_several(DTOpokemon[] listPK)
    {
        foreach (DTOpokemon poke in listPK)
        {
            poke.habilidades = this.correctValues(poke.habilidades);
            poke.defensa = this.perfectDefense(poke.defensa);
            this.DB.Add(poke);
        }
    }

    // Método para Editar 1 pokemon
    public void edit_one(int id, DTOpokemon poke)
    {
        DTOpokemon newpoke = this.DB.Single(poke => poke.id == id);
        newpoke.nombre = poke.nombre;
        newpoke.tipo = poke.tipo;
        newpoke.habilidades = this.correctValues(poke.habilidades);
        newpoke.defensa = this.perfectDefense(poke.defensa);
    }

    // Método para Eliminar 1 pokemon
    public void delete_one(int id)
    {
        this.DB.RemoveAll(poke => poke.id == id);
    }

    // Método para Traer 1 pokemon
    public DTOpokemon get_one(int id)
    {
        return (this.DB.Single(poke => poke.id == id));
    }

    // Método para Traer Todos los Pokemons de un Tipo
    public List<DTOpokemon> get_all_type(string type)
    {
        var x = this.DB.Where(poke => poke.tipo == type);
        List<DTOpokemon> correct_type_list = x.ToList();
        return correct_type_list;
    }

    //----------- Métodos Adicionales ------------------------

    // 1. Método para Mostrar Todos los Pokemons en la Base de Datos
    public List<DTOpokemon> get_all()
    {
        return this.DB;
    }
    

    //---------- Métodos para valdar el cumplimineto de requisitos ---------------------
    
    // Método para validar que los valores de las habilidades sean correctos.
    public List<int> correctValues(List<int> h)
    {
        List<int> easy = new List<int>();
        foreach (int x in h)
        {
            if (x >= 0 && x <= 40) { easy.Add(x); }
            if (x < 0) { easy.Add(0); }
            if (x > 40) { easy.Add(40); }
        }
        return easy;
    }

    // Método para validar los valores correctos de la Defensa
    public double perfectDefense (double d)
    {
        if (d <= 30 && d > 0) { d = d; }
        if (d > 30) { d = 30; }
        if (d < 1) { d = 1; }

        return d;
    }
}