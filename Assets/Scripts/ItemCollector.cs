using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    int coins = 0;
    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] AudioSource coinSound;

    // Ajout d'un accesseur public pour lire le nombre de pièces
    public int Coins => coins;

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

