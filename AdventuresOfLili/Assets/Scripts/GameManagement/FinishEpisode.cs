using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FinishEpisode : MonoBehaviour
{
    public static Action LevelIsOver;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
            LevelIsOver?.Invoke();
    }
}
