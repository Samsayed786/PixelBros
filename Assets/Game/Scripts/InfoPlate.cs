using UnityEngine;
using UnityEngine.UI;

public class InfoPlate : MonoBehaviour
{
    public GameObject infoPanel; 
    public Text hintText; 
    public string hintMessage; 
    private bool playerNearby = false;

    void Start()
    {
        infoPanel.SetActive(false); 
        hintText.text = hintMessage; 
    }

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.Q))
        {
            infoPanel.SetActive(true); // Show the info panel when Q is pressed
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            infoPanel.SetActive(false); // Hide the info panel when Esc is pressed
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true; 
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false; 
            infoPanel.SetActive(false); // Hide the info panel if it's open
        }
    }
}
