using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObserver : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
            GetComponentInParent<BasicEnemyControll>().enemyHere = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
            GetComponentInParent<BasicEnemyControll>().enemyHere = false;
    }
}
