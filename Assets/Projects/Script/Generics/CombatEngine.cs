// File: CombatEngine.cs
using UnityEngine;

public static class CombatEngine
{
    // Il metodo universale. Usa i generics <T> vincolati all'interfaccia.
    public static void ExecuteAttack<T>(
        in HeavyAttackData attack, 
        ref float targetHealth, 
        out bool isLethal) where T : IDamageable
    {
        // 1. Calcolo puro dei danni
        float finalDamage = attack.BaseDamage + attack.FireDamage;
        
        // 2. Sottrazione diretta dalla memoria originale
        targetHealth -= finalDamage;
        
        // 3. Verifica del colpo di grazia
        isLethal = targetHealth <= 0;
    }
}

/*
Questo è il cervello del sistema. 
Sarà una classe static, ovvero una classe "strumento" che esiste sempre e non va mai attaccata a un GameObject.
*/


/*
- ref (Accesso Totale): La variabile deve avere un valore iniziale. 
Il metodo riceve le chiavi originali: può leggere il dato e, se lo ritiene necessario, modificarlo. 
La parola chiave va scritta esplicitamente sia nel metodo che durante la chiamata.

- out (Solo Scrittura / Output Multiplo): La variabile può essere vuota all'inizio. 
Il metodo riceve la scatola vuota e ha l'obbligo assoluto di infilarci un valore dentro prima di finire. 
In Unity si usa quasi sempre per far restituire a una funzione più di un singolo risultato (es. un bool e i dati dell'impatto).

- in (Sola Lettura per Performance): La variabile deve avere un valore iniziale. 
Il metodo riceve l'originale per evitare di sprecare memoria con delle copie, ma il compilatore gli vieta categoricamente di modificarlo. 
È la chiave per passare grosse struct personalizzate nei cicli Update di Unity senza intasare il Garbage Collector.

- ref readonly (Sola Lettura Rigorosa): Molto simile a in, ma con regole architettoniche più severe. 
Mentre in permette al compilatore di fare dei trucchetti creando variabili temporanee se gli passi un valore volante, ref readonly esige l'accesso a una variabile concreta e già allocata, 
garantendo prestazioni assolute senza eccezioni.
*/

/*
Metodo generico — funziona con qualsiasi tipo T
static — si chiama dalla classe, non da un'istanza

I tre modificatori di parametro:
- in HeavyAttackData attack  leggi ma non modificare — zero copie in memoria
- ref float targetHealth passa l'originale — le modifiche persistono fuori
- out bool isLethal DEVE essere assegnato dentro il metodo

Vincolo — T deve implementare IDamageable
Senza vincolo potresti passare qualsiasi tipo, anche un int
where T : IDamageable
*/