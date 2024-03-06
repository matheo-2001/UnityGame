using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Si vous utilisez TextMeshPro pour l'affichage de texte
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private ItemCollector itemCollector;
    [SerializeField] private int requiredCoins = 10;
    [SerializeField] private TextMeshProUGUI notificationText; // Texte pour notifier l'utilisateur

    private void Start()
    {
        // Assurez-vous que le message est désactivé au démarrage
        notificationText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            int coinsNeeded = requiredCoins - itemCollector.Coins;
            if (itemCollector.Coins >= requiredCoins)
            {
                // Le joueur a assez de pièces, chargez la scène suivante ou terminez le jeu
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                // Affiche le message indiquant le nombre de pièces restantes nécessaires
                notificationText.text = "Il vous manque " + coinsNeeded + " pièces pour finir le jeu.";
                notificationText.gameObject.SetActive(true);
                // Optionnel : désactivez le message après quelques secondes
                StartCoroutine(DisableTextAfterTime(5)); // Désactive le texte après 5 secondes
            }
        }
    }

    private IEnumerator DisableTextAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        notificationText.gameObject.SetActive(false);
    }


}
