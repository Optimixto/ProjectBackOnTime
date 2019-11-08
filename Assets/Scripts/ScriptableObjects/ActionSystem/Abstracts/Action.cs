using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ScriptableObject
{
    public bool IsDone
    {
        get; protected set;
    }

    public void Init()
    {
        IsDone = false;

        SpecificInit();
    }

    protected virtual void SpecificInit()
    { }
    
    public void Act(MonoBehaviour monoBehaviour)
    {
        if(!IsDone)
            IsDone = PerformAction();
    }

    public void ResetAction()
    {
        Init();
    }

    /// <summary>
    /// This method's return value dictates if it's done performing the action.
    /// </summary>
    /// <returns></returns>
    protected abstract bool PerformAction();
}
