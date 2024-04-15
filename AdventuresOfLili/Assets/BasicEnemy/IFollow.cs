using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IFollow : BasicEnemyStateMachine
{
    public GameObject player;
    public override void EnterState(BasicEnemyControll enemy)
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void ExitState(BasicEnemyControll enemy)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(BasicEnemyControll enemy)
    {
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position,player.transform.position , enemy.moveSpeed * Time.deltaTime);
        if (!enemy.enemyHere)
            enemy.ChangeState(new IPatrol());
    }


}
