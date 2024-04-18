using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAttack : BasicEnemyStateMachine
{
    public GameObject player;

    public override void EnterState(BasicEnemyControll enemy)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        

    }

    public override void ExitState(BasicEnemyControll enemy)
    {

    }

    public override void UpdateState(BasicEnemyControll enemy)
    {
        if (Vector2.Distance(enemy.transform.position, player.transform.position) > 1.5f)
        {
            enemy.EnemyAttackClose();
            enemy.ChangeState(new IFollow());

        }
        enemy.anim.Play("Attack");
    }
    
}