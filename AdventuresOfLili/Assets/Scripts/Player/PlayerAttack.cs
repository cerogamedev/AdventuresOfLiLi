using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Controll")]
    private float timeBtwAttack;
    public float StartTimeBtwAttack;

    public Transform AttackPos;
    public LayerMask WhatIsEnemy;
    public float AttackRange;
    public int Damage;

    void Update()
    {
        if (timeBtwAttack <= 0f)
        {
            if (InputHandler.Instance.IsAttack)
            {
                AudioManager.Instance.PlaySfx(AudioManager.Instance.Sword);
                PlayerController.Instance.ChangeState(new AttackState());
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(AttackPos.position, AttackRange, WhatIsEnemy);
                for (int i = 0; i<enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().GetDamage(Damage);
                }
                timeBtwAttack = StartTimeBtwAttack;

            }

        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
 
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackPos.position, AttackRange);
    }
}
