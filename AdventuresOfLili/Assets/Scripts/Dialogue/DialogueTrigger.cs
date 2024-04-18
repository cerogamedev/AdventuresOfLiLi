using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] public TextAsset inkJSON;

    public NPCScriptable _scriptObject;


    private bool playerInRange;
    private bool isStarting = false;
    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
    }
    private void Update()
    {
        if (playerInRange)
        {
            visualCue.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DialogueManager.Instance.inkFile = inkJSON;
                DialogueManager.Instance._npcName.text = _scriptObject._name;
                DialogueManager.Instance._npcPortrait.sprite = _scriptObject._portrait;
                if (!isStarting)
                {
                    DialogueManager.Instance.NewStoryHere();

                    DialogueManager.Instance.isInDialogue = true;
                    DialogueManager.Instance.StartTheDialogue();
                    isStarting = true;
                }
            }

        }
        else
            visualCue.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
            playerInRange = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
            playerInRange = false;
    }
}
