using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Properties")]
    public int Health;
    public int MoveSpeed;

    public int currentHealth;

    void Start()
    {
        currentHealth = Health;
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            GetComponent<BasicEnemyControll>().ChangeState(new IDead());
        }
    }
    public void GetDamage(int damage)
    {
        currentHealth -= damage;
    }
    public void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
