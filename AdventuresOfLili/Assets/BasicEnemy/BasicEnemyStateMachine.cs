using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicEnemyStateMachine
{
    public abstract void EnterState(BasicEnemyControll enemy);

    public abstract void UpdateState(BasicEnemyControll enemy);

    public abstract void ExitState(BasicEnemyControll enemy);

}
