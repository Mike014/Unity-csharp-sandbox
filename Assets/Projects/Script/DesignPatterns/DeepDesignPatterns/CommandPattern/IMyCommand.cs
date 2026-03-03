// Interfaccia che definisce cosa deve fare un comando
public interface IMyCommand
{
    void Execute();
    void Undo(); 
}