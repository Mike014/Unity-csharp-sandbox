// BASE CLASS - definisce la struttura
public abstract class SandboxBase
{
    // Punto di ingresso pubblico - il mondo esterno chiama solo questo
    public void Execute()
    {
        SandBox();
    }

    // SANDBOX METHOD
    // abstract: obbliga le sottoclassi a implementarla
    // protected: non è chiamabile dall'esterno
    protected abstract void SandBox();

    // PROVIDED OPERATIONS
    // protected: solo le sottoclassi le vedono
    // non virtual: non si sovrascrivono, si usano
    protected void OperationA()
    {
        // Logica centralizzata — coupling con sistemi esterni sta qui
    }

    protected void OperationB()
    {
        // Logica centralizzata — coupling con sistemi esterni sta qui
    }

    protected void OperationC()
    {
        // Logica centralizzata — coupling con sistemi esterni sta qui
    }
}

// SOTTOCLASSE — definisce il comportamento specifico
public class ConcreteVariantA : SandboxBase
{
    protected override void SandBox()
    {
        // Usa solo gli strumenti della base class
        // Nessuna dipendenza esterna
        OperationA();
        OperationC();
    }
}

// ALTRA SOTTOCLASSE — comportamento diverso, stessi strumenti
public class ConcreteVariantB : SandboxBase
{
    protected override void SandBox()
    {
        OperationB();
        OperationA();
        OperationB();
    }
}