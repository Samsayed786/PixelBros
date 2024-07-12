using UnityEngine;
using TMPro;

public class InfoPlate : MonoBehaviour
{
    public GameObject hintPanel; // The UI panel to display hint text
    public TMP_Text hintText; // The TextMeshPro component to display the hint
    public string hintMessage; // The hint message to display
    public TMP_Text promptText; // The TextMeshPro component to display the prompt
    private bool playerNearby = false;

    void Start()
    {
        hintPanel.SetActive(false); // Ensure the hint panel is hidden at the start
        promptText.gameObject.SetActive(false); // Ensure the prompt text is hidden at the start
        hintText.text = hintMessage; // Set the hint text
    }

    void Update()
    {
        if (playerNearby)
        {
            promptText.gameObject.SetActive(true); // Show the prompt text when player is near
            if (Input.GetKeyDown(KeyCode.Q))
            {
                hintPanel.SetActive(true); // Show the hint panel when Q is pressed
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            hintPanel.SetActive(false); // Hide the hint panel when Esc is pressed
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true; // Player is near the info plate
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false; // Player left the info plate area
            promptText.gameObject.SetActive(false); // Hide the prompt text
            hintPanel.SetActive(false); // Hide the hint panel if it's open
        }
    }
}
