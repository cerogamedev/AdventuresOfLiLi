using System.Collections;
using UnityEngine;

public class TeleporterPlatform : MonoBehaviour
{
    public Transform[] teleportPoints; // Teleport edilecek noktalarýn transformlarý

    public float teleportDelay = 1f; // Teleportasyon arasýndaki gecikme süresi

    private int currentPointIndex = 0; // Þu anki teleport noktasýnýn dizinini tutar

    private bool isTeleporting = false; // Teleportasyonun devam edip etmediðini belirler

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
        // Teleport animasyonu burada gerçekleþtirilebilir
        Debug.Log("Teleporting to point " + (currentPointIndex + 1) + ": " + teleportPoints[currentPointIndex].name);

        // Teleport iþlemi için bekletme süresi
        yield return new WaitForSeconds(teleportDelay);

        // Karakterin pozisyonunu hedef noktaya ayarla
        transform.position = teleportPoints[currentPointIndex].position;

        Debug.Log("Teleportation to point " + (currentPointIndex + 1) + " completed.");

        isTeleporting = false;
    }
}
