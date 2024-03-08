using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Si vous utilisez TextMeshPro pour l'affichage de texte
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    [SerializeField] private ItemCollector itemCollector;
    [SerializeField] private int requiredCoins = 15;
    [SerializeField] private TextMeshProUGUI notificationText; // Texte pour notifier l'utilisateur
    [SerializeField] private Button reloadButton; // Assurez-vous d'attribuer ce bouton dans l'�diteur Unity

    private void Start()
    {
        // Assurez-vous que le message est d�sactiv� au d�marrage
        notificationText.gameObject.SetActive(false);
        reloadButton.gameObject.SetActive(false); // D�sactiver le bouton au d�marrage
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            int coinsNeeded = requiredCoins - itemCollector.Coins;
            if (itemCollector.Coins >= requiredCoins)
            {
                // Le joueur a assez de pi�ces, chargez la sc�ne "Main Menu"
                SceneManager.LoadScene("Main Menu");
            }
            else
            {
                notificationText.text = "Il vous manque " + coinsNeeded + " pi�ces pour finir le jeu.";
                notificationText.gameObject.SetActive(true);
                reloadButton.gameObject.SetActive(true); // Activer le bouton
                StartCoroutine(DisableUIAfterTime(5)); // D�sactive le texte et le bouton apr�s 5 secondes
            }
        }
    }

    private IEnumerator DisableTextAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        notificationText.gameObject.SetActive(false);
    }

    private IEnumerator DisableUIAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        notificationText.gameObject.SetActive(false);
        reloadButton.gameObject.SetActive(false); // D�sactiver le bouton
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
