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
        
    }

    public override void UpdateState(BasicEnemyControll enemy)
    {
        enemy.anim.Play("Walk");

        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position,player.transform.position , enemy.moveSpeed * Time.deltaTime);

        if (Vector2.Distance(enemy.transform.position, player.transform.position) < 1.5f)
            enemy.ChangeState(new IAttack());
        
        if (!enemy.enemyHere)
            enemy.ChangeState(new IPatrol());
        if ((enemy.transform.position.x - player.transform.position.x) < 0f)
        {
            enemy.transform.localScale = new Vector3(-0.61f, enemy.transform.localScale.y, enemy.transform.localScale.z);

        }
        if ((enemy.transform.position.x - player.transform.position.x) > 0f)
        {
            enemy.transform.localScale = new Vector3(+0.61f, enemy.transform.localScale.y, enemy.transform.localScale.z);
        }
    }


}
