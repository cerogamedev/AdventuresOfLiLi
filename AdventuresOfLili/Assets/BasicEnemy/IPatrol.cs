using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPatrol : BasicEnemyStateMachine
{
    Vector2 Point;
    public override void EnterState(BasicEnemyControll enemy)
    {
        Point = GetPoint(enemy.Patroll[0], enemy.Patroll[1]);
    }

    public override void ExitState(BasicEnemyControll enemy)
    {

    }

    public override void UpdateState(BasicEnemyControll enemy)
    {

        if (Vector2.Distance(enemy.transform.position, Point) < 0.5f)
        {
            Point = GetPoint(enemy.Patroll[0], enemy.Patroll[1]);
        }

        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, Point, enemy.moveSpeed * Time.deltaTime);

        if (enemy.enemyHere)
        {
            enemy.ChangeState(new IFollow());
        }

    }

    public Vector2 GetPoint(GameObject leftOrder, GameObject rigthOrder)
    {
        Vector2 goPoint = new Vector2(Random.Range(leftOrder.transform.position.x, rigthOrder.transform.position.x), leftOrder.transform.position.y);
        return goPoint;

    }
}
