using UnityEngine;

// Eredita da BaseManager
public class CombatManager : BaseManager
{
    #region IManager Implementation
    
    // Override della proprietà State dal BaseManager
    public override string State
    {
        get { return _state; }
        set { _state = value; }
    }
    
    // Override del metodo Initialize dal BaseManager
    public override void Initialize()
    {
        _state = "Combat Manager Initialized...";
        Debug.Log(_state);
    }
    
    #endregion
}