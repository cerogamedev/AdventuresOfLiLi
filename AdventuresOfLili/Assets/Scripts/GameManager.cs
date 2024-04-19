using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoSingleton<GameManager>
{
    private GameObject[] respawnPoints;
    public GameObject currentRespawnPoint;
    private int index = 0;

    [SerializeField] private GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        respawnPoints = GameObject.FindGameObjectsWithTag("Respawn");
    }
    void Start()
    {
        currentRespawnPoint = respawnPoints[0];
    }


    private void OnEnable()
    {
        FinishEpisode.LevelIsOver += LevelIsOver_GameManager;
    }
    private void OnDisable()
    {
        FinishEpisode.LevelIsOver -= LevelIsOver_GameManager;

    }
    public void LevelIsOver_GameManager()
    {
        index++;
        if (index <= respawnPoints.Length-1)
        {
            currentRespawnPoint = respawnPoints[index];
            player.transform.position = currentRespawnPoint.transform.position;
        }
        else
        {
            Application.Quit();
        }
    }
}
