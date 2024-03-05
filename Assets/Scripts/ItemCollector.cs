using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    int coins = 0;
    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] AudioSource coinSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coins++;
            coinText.text = "Coins: " + coins;
            coinSound.Play();
        }
    }
}
