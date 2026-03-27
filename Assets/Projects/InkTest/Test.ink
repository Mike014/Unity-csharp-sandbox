-> Incontro_Mercante

=== Incontro_Mercante ===
= introduzione
Il mercante ti fissa con sospetto. "Cosa vuoi per quella spada?"
* "Voglio monete d'oro[."]," dissi con tono fermo.
    "Mi sembra un prezzo onesto," rispose il mercante.
    -> Incontro_Mercante.mercante_contratta
* [Ignoralo e vattene] Ti volti senza dire una parola e chiudi la porta.
    Senti il mercante borbottare alle tue spalle.
    -> Incontro_Mercante.introduzione 
* "Non è in vendita."[]
    "Peccato, avrei pagato bene."
    -> Incontro_Mercante.mercante_arrabbiato

= mercante_arrabbiato
Il mercante sbatte i pugni sul bancone! "Non farmi perdere tempo!"
-> END

= mercante_contratta
"Vediamo quanto vorresti darmi...?"
-> contrattazione
     
=== contrattazione ===
"Sono tutt'orecchi..." disse il mercante.

* (proposto_5) [Ti propongo 5 monete...]
    "Troppo poco amico mio... Riprova."
    -> contrattazione

* { proposto_5 } [Va bene, facciamo 7 monete...]
    "Stai migliorando, ma non basta."
    -> contrattazione

// Il più (+) la rende sempre disponibile, finché non viene cliccata (poiché porta a END)
+ [10 monete...]
    "Andata!"
    -> ispezione_scrivania
    
=== ispezione_scrivania ===
Ti avvicini a una vecchia scrivania di quercia coperta di scartoffie.
* [Apri il cassetto di sinistra]
    La maniglia è incastrata. Ci metti un po' di forza.
    // Inizia il Flusso Innestato (uso due asterischi per il secondo livello)
    ** [Forza con un pugnale]
        La lama scivola e righi il legno, ma il cassetto si apre. È vuoto.
    ** [Usa un incantesimo di sblocco]
        Un lampo azzurro e il cassetto si spalanca senza far rumore. Niente dentro.
* [Apri il cassetto di destra]
    Scorre dolcemente. All'interno trovi solo un vecchio calamaio secco.
* [Non toccare nulla]
    Decidi che è meglio non lasciare impronte.
    -> DONE
- (fine_ispezione) // QUESTO È IL GATHER
// Indipendentemente da quale cassetto hai aperto, o come lo hai aperto, il flusso atterra qui.
Fai un passo indietro e ti guardi di nuovo attorno. La stanza è buia.

-> END