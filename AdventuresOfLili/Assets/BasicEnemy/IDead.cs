using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDead : BasicEnemyStateMachine
{
    public override void EnterState(BasicEnemyControll enemy)
    {
    }

    public override void ExitState(BasicEnemyControll enemy)
    {
    }

    public override void UpdateState(BasicEnemyControll enemy)
    {
        enemy.anim.Play("Dead");
    }

}
