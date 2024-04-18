using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField] private GameObject[] hearts;
    [SerializeField] private int FullHealth;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Trap"))
        {
            this.transform.position = GameManager.Instance.currentRespawnPoint.transform.position;
            hearts[FullHealth - 1].SetActive(false);
            FullHealth -= 1;

            if (FullHealth <= 0)
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

}
