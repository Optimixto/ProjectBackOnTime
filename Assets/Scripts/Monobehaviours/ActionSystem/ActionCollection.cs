using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionCollection : MonoBehaviour
{
    public Action[] actions = new Action[0];

    public bool IsEmpty
    {
        get; private set;
    }

    private int currentAction;

    private void Awake()
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].Init();
        }

        if (actions.Length == 0)
        {
            IsEmpty = true;
        }
        else
            currentAction = 0;
    }

    public void Act()
    {
        if(!IsEmpty)
        {
            if(currentAction != actions.Length)
            {
                if (!actions[currentAction].IsDone)
                {
                    actions[currentAction].Act(this);
                }
                else
                    currentAction++;
            }
        }
    }

    public void ResetActions()
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].ResetAction();
        }

        currentAction = 0;
    }

    public bool CheckIfAllActionsAreDone()
    {
        //if empty, we consider all actions done
        if(IsEmpty)
        {
            return true;
        }

        if (currentAction == actions.Length)
            return true;

        return false;
    }
}
