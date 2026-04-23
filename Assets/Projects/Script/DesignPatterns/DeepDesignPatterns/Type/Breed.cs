// BREED - il "tipo oggetto"
// Contiene dati condivisi tra tutti i mostri della stessa razza
// Non è una base class - è un contenitore di dati
public class Breed
{
    // Dati della razza - uguali per tutti i mostri di questa razza
    public int StartingHealth { get; private set; }
    public string Attack { get; private set; }

    public Breed(int startingHealth, string attack) => (StartingHealth, Attack) = (startingHealth, attack);

    // Factory method - crea un Monster inizializzato con questa razza
    // Centralizza la creazione: l'unico modo per creare un mostro è passare da qui
    public Monster NewMonster()
    {
        return new Monster(this);
    }
}

// MONSTER - l'istanza concreta
// Contiene solo stato specificio dell'istanza (es. salute corrente)
// Delega i dati condivisi alla sua Breed
public class Monster
{
    // Stato specificio dell'istanza - ogni mostro ha la sua salute corrente
    private int _currentHealth;

    // Riferimento al tipo - immutabile dolo la costruzione
    private Breed _breed;

    // Il costruttore è privato - si passa da Breed.NewMonster()
    // Questo garantisce che ogni Monster sia sempre inizializzato correttamente
    internal Monster(Breed breed)
    {
        _breed = breed;
        _currentHealth = breed.StartingHealth; // prende la salute iniziale dalla razza
    }

    // Delega alla breed - Monster non sa nulla dell'attack string
    public string GetAttack()
    {
        return _breed.Attack;
    }

    public int CurrentHealth => _currentHealth;
}

/*
// Creo le razze - potrebbero venire da un file JSON o ScriptableObject
Breed dragonBreed = new Breed(230, "The dragon breathes fire!");
Breed trollBreed = new Breed(48, "The troll clubs you!");

// Creo mostri tramite la bread - non con new Monster()
Monster dragon = dragonBreed.NewMonster();
Monster troll = trollBreed.NewMonster();

// I mostri delegano alla loro breed
Debug.Log(dragon.GetAttack());
Debug.Log(troll.GetAttack());
*/

  
