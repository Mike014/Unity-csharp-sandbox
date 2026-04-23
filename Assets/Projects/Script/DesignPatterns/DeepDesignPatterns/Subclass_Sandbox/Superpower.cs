public abstract class Superpower 
{
    // Questo e' public — e' il punto di ingresso dall'esterno
    public void Use()
    {
        Activate(); // la base class chiama il metodo astratto
    }

    // SANDBOX METHOD
    // abstract: le sottoclassi DEVONO implementarla
    // protected: solo le sottoclassi possono chiamarla
    // non è chiamata da codice esterno è il posto di lavoro della sottoclasse
    protected abstract void Activate();

    // PROVIDED OPERATIONS
    // protected: visibili solo alle sottoclassi
    // non sono virtual: non si sovrascrivono, si usano
    // l'implementazion reale qui chiarebbe AudioManager, PhysicsEngine, ecc

    protected void Move(float x, float y, float z)
    {
        // Chiamerebbe il physicsa engine - coupling centralizzato qui
    }

    protected void PlaySound(SoundId sound, float volume)
    {
        // Chiamerebbe AudioManager — coupling centralizzato qui
    }

    protected void SpawnParticles(ParticleType type, int count)
    {
        // Chiamerebbe il particle system — coupling centralizzato qui
    }

    protected float GetHeroX() { return 0f; }
    protected float GetHeroY() { return 0f; }
    protected float GetHeroZ() { return 0f; }
}

// public class SkyLaunch : Superpower
// {
//     protected override void Activate()
//     {
//         if (GetHeroZ() == 0)
//         {
            
//         }
//         else if (GetHeroZ() < 1.0f)
//         {
            
//         }
//         else
//         {
            
//         }
//     }
// }
