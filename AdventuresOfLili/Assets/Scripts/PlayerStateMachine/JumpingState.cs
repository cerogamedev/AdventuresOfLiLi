using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : IState
{

    public void EnterState(PlayerController player)
    {
        AudioManager.Instance.PlaySfx(AudioManager.Instance.Jumping);
    }

    public void ExitState(PlayerController player)
    {
    }

    public void UpdateState(PlayerController player)
    {

        if (player.IsGrounded() && !player.IsWalking())
        {
            player.ChangeState(new IdleState());
        }
        if (player.IsGrounded() && player.IsWalking())
        {
            player.ChangeState(new WalkingState());
        }

    }
}
