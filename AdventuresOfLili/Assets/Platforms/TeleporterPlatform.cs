using System.Collections;
using UnityEngine;

public class TeleporterPlatform : MonoBehaviour
{
    public Transform[] teleportPoints; 

    public float teleportDelay = 1f; 

    private int currentPointIndex = 0; 

    private bool isTeleporting = false; 

    private void Start()
    {
        StartCoroutine(TeleportSequence());
    }

    private IEnumerator TeleportSequence()
    {
        while (true)
        {
            yield return new WaitForSeconds(teleportDelay);
            Teleport();
        }
    }

    private void Teleport()
    {
        if (!isTeleporting)
        {
            isTeleporting = true;
            StartCoroutine(TeleportAnimation());

            currentPointIndex = (currentPointIndex + 1) % teleportPoints.Length;
        }
    }

    private IEnumerator TeleportAnimation()
    {
        yield return new WaitForSeconds(teleportDelay);
        transform.position = teleportPoints[currentPointIndex].position;
        isTeleporting = false;
    }
}
