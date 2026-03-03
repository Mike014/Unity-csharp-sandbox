[System.Serializable] // Permette di vedere i dati nell'Inspector di Unity se necessario
public struct HeavyAttackData
{
    public float BaseDamage;
    public float ArmorPenetration;
    public float FireDamage;

    // Costruttore per facilitare la creazione di nuovi attacchi da codice
    public HeavyAttackData(float baseDmg, float pen, float fire)
    {
        BaseDamage = baseDmg;
        ArmorPenetration = pen;
        FireDamage = fire;
    }

    // Struct vs Class: Usiamo una struct (Tipo Valore) perché i dati di un attacco sono volatili e ne creeremo tantissimi al secondo (pensa ai proiettili di una mitragliatrice). 
    // Se usassimo una class (Tipo Riferimento), ogni proiettile creerebbe "spazzatura" in memoria, scatenando il Garbage Collector e causando micro-lag (stuttering) nel gioco. 
    // L'implicazione di in: 
    // Proprio perché è una struct, quando la passeremo al motore di calcolo useremo il modificatore in per evitare che la CPU ne faccia una copia inutile per ogni calcolo.
}
