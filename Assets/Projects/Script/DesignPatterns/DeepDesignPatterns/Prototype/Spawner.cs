using System;

public class Spawner
{
    private Func<Monster> _spawnFunc;

    public Spawner(Func<Monster> spawnFunc) => _spawnFunc = spawnFunc;

    public Monster SpawnMonster() => _spawnFunc();
}

public class SpawnerFor<T> : Spawner where T : Monster, new()
{
    public SpawnerFor() : base (() => new T()) {}
    // public override Monster SpawnMonster() => new T();
}




