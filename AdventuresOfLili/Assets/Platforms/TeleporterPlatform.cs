using System.Collections;
using UnityEngine;

public class TeleporterPlatform : MonoBehaviour
{
    public Transform[] teleportPoints; // Teleport edilecek noktalar�n transformlar�

    public float teleportDelay = 1f; // Teleportasyon aras�ndaki gecikme s�resi

    private int currentPointIndex = 0; // �u anki teleport noktas�n�n dizinini tutar

    private bool isTeleporting = false; // Teleportasyonun devam edip etmedi�ini belirler

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
        // Teleport animasyonu burada ger�ekle�tirilebilir
        Debug.Log("Teleporting to point " + (currentPointIndex + 1) + ": " + teleportPoints[currentPointIndex].name);

        // Teleport i�lemi i�in bekletme s�resi
        yield return new WaitForSeconds(teleportDelay);

        // Karakterin pozisyonunu hedef noktaya ayarla
        transform.position = teleportPoints[currentPointIndex].position;

        Debug.Log("Teleportation to point " + (currentPointIndex + 1) + " completed.");

        isTeleporting = false;
    }
}
