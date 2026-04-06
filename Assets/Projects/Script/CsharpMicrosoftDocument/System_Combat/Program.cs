using UnityEngine; 

public class Program : MonoBehaviour
{
    void Start()
    {
        Main();
    }
    
    public static void Main()
    {
        // Crea un nemico con resistenza al fuoco e debolezza al ghiaccio
        DefenseStats orcDefenses = new DefenseStats(
            resistances: DamageType.Fire,
            weaknesses: DamageType.Ice
        );
        
        Character orc = new Character("Orc Warrior", 100f, orcDefenses);
        
        // Test 1: Attacco base (fisico)
        DamageInstance basicAttack = CombatSystem.CreateAttack(AttackType.BasicStrike);
        bool isAlive = orc.TakeDamage(in basicAttack, out CombatResult result1);
        
        Debug.Log($"Basic Attack - Damage: {result1.totalDamage}, Critical: {result1.wasCritical}");
        Debug.Log($"Orc Health: {orc.Health}");
        
        // Test 2: Palla di fuoco (nemico resistente!)
        DamageInstance fireball = CombatSystem.CreateAttack(AttackType.Fireball);
        isAlive = orc.TakeDamage(in fireball, out CombatResult result2);
        
        Debug.Log($"Fireball - Damage: {result2.totalDamage} (should be halved!)");
        Debug.Log($"Orc Health: {orc.Health}");
        
        // Test 3: Fulmine ghiacciato (nemico debole al ghiaccio!)
        DamageInstance iceShock = CombatSystem.CreateAttack(AttackType.IceShock);
        isAlive = orc.TakeDamage(in iceShock, out CombatResult result3);
        
        Debug.Log($"Ice Shock - Damage: {result3.totalDamage} (should be doubled!)");
        Debug.Log($"Orc Health: {orc.Health}");
        Debug.Log($"Applied Status: {result3.appliedStatus}");
        
        // Test 4: Verifica status
        if (orc.HasStatus(StatusEffect.Frozen))
        {
            Debug.Log("Orc is frozen!");
            orc.ClearStatus(StatusEffect.Frozen);
        }
        
        // Test 5: Validazione input utente
        Debug.Log("\nEnter attack type (0=Basic, 1=Fireball, 2=IceShock): ");
        int userInput = 1; // Simula input
        
        if (CombatSystem.TryParseAttackType(userInput, out AttackType attackType))
        {
            DamageInstance attack = CombatSystem.CreateAttack(attackType);
            orc.TakeDamage(in attack, out CombatResult result);
            Debug.Log($"User attack dealt {result.totalDamage} damage!");
        }
        else
        {
            Debug.Log("Invalid attack type!");
        }
        
        // Test 6: Critico manuale
        DamageInstance hugeDamage = new DamageInstance(
            baseDamage: 50f,
            damageTypes: DamageType.Physical | DamageType.Lightning,
            inflictedStatus: StatusEffect.Stunned,
            criticalChance: 1.0f // 100% critico
        );
        
        DamageInstance criticalHit = hugeDamage.WithCritical();
        orc.TakeDamage(in criticalHit, out CombatResult result4);
        
        Debug.Log($"Critical Hit! Damage: {result4.totalDamage}");
        Debug.Log($"Orc is alive: {orc.Health > 0}");
    }
}