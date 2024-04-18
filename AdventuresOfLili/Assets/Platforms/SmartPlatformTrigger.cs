using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartPlatformTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            GetComponentInParent<SmartPlatform>().isPlayerHere = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            GetComponentInParent<SmartPlatform>().isPlayerHere = false;
        }
    }
}
