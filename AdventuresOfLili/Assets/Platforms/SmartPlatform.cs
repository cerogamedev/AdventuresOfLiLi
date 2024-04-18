using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartPlatform : MonoBehaviour
{
    [Header("Smart Platform Properties")]
    [SerializeField] private GameObject[] goPoint;
    [SerializeField] public bool isPlayerHere = false;
    [SerializeField] private float moveSpeed;

    private BoxCollider2D bxCol;

    [SerializeField] private Sprite goSrpite, offSprite;
    [SerializeField] private SpriteRenderer sr;
    
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        bxCol = GetComponent<BoxCollider2D>();
        transform.position = goPoint[0].transform.position;
    }

    private void Update()
    {
        if (isPlayerHere)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, goPoint[1].transform.position, moveSpeed*Time.deltaTime);
            sr.sprite = goSrpite;
        }
        else if (isPlayerHere == false)
        {
            isPlayerHere = false;
            transform.position = Vector2.MoveTowards(this.transform.position, goPoint[0].transform.position, moveSpeed * Time.deltaTime);
            sr.sprite = offSprite;

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.transform.SetParent(transform);

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.gameObject.transform.SetParent(null);

    }
}
