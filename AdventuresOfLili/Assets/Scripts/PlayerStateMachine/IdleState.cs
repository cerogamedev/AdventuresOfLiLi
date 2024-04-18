using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    public void EnterState(PlayerController player)
    {

    }

    public void ExitState(PlayerController player)
    {
    }

    public void UpdateState(PlayerController player)
    {


        if (player.IsWalking() && player.IsGrounded())
        {
            player.ChangeState(new WalkingState());
        }
        else if (!player.IsGrounded())
        {
            player.ChangeState(new JumpingState());
        }
    }
}
