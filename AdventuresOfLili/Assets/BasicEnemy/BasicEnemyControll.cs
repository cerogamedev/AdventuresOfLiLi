using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyControll : MonoBehaviour
{
    [HideInInspector] public Animator anim;
    private Rigidbody2D rb;
    private BasicEnemyStateMachine enemyState;
    private GameObject enemyControlObject;
    private GameObject player;

    [Header("Move&Patroll")]
    public float moveSpeed;
    public GameObject[] Patroll;

    [Header("Attack")]
    public GameObject AttackRange;
    public bool enemyHere = false;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        AttackRange.SetActive(false);
        moveSpeed = GetComponent<Enemy>().MoveSpeed;
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
    }

    public void ChangeState(BasicEnemyStateMachine newState)
    {
        enemyState.ExitState(this);
        enemyState = newState;
        enemyState.EnterState(this);
    }
    public void EnemyAttackOpen()
    {
        AttackRange.SetActive(true);
    }
    public void EnemyAttackClose()
    {
        AttackRange.SetActive(false);
    }
}
