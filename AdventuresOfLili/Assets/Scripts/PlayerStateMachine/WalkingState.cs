using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : IState
{
    public void EnterState(PlayerController player)
    {
    }

    public void ExitState(PlayerController player)
    {
    }

    public void UpdateState(PlayerController player)
    {
        Vector2 pos = player.transform.position;

        var horizontalMove = player.inputHandler.GetMovementAxis();

        if (player.canMove)
            pos.x += horizontalMove * player.moveSpeed * Time.deltaTime;

        player.transform.position = pos;

        if (!player.IsGrounded())
        {
            player.ChangeState(new JumpingState());
        }
        if (player.IsGrounded() && !player.IsWalking())
        {
            player.ChangeState(new IdleState());
        }

    }
}
