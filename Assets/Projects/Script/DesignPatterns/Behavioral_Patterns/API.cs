// Definisci un'API per i comportamenti
// API C# che le spell possono chiamare
public abstract class API
{
    abstract public void SetHealth(int wizard, int amount);
    abstract public void SetWisdom(int wizard, int amount);
    abstract public void PlaySound(int soundId);
    abstract public void SpawnParticles(int particleType);
} 