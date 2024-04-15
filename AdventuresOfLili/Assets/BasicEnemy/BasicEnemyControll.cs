using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyControll : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private BasicEnemyStateMachine enemyState;
    private GameObject enemyControlObject;

    [Header("Move&Patroll")]
    public float moveSpeed;
    public GameObject[] Patroll;
    public bool enemyHere = false;


    [Header("Attack")]
    public GameObject AttackRange;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        enemyState = new IPatrol();
        enemyState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        enemyState.UpdateState(this);
        IsEnemyHere();
    }
    public void ChangeState(BasicEnemyStateMachine newState)
    {
        enemyState.ExitState(this);
        enemyState = newState;
        enemyState.EnterState(this);
    }
    public void IsEnemyHere()
    {
        BoxCollider2D collider = enemyControlObject.GetComponent<BoxCollider2D>();
        //Observer pattern ile gayet iyi yapýlabilir!!!!
    }
}
