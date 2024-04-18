using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{
    public void EnterState(PlayerController player)
    {
        int RandomNumber = Random.Range(1, 4);
        AnimationConroller.Instance.anim.Play("Attack" + RandomNumber);
        PlayerController.Instance.moveSpeed = 3;

    }

    public void ExitState(PlayerController player)
    {
        PlayerController.Instance.moveSpeed = 7;

    }

    public void UpdateState(PlayerController player)
    {
        if (!AnimationConroller.Instance.isAttackAnimationPlaying)
        {
            if (player.IsWalking() && player.IsGrounded())
            {
                player.ChangeState(new WalkingState());
            }
            else if (!player.IsGrounded())
            {
                player.ChangeState(new JumpingState());
            }
            else if (player.IsGrounded() && !player.IsWalking())
            {
                player.ChangeState(new IdleState());
            }
        }
    }


}
