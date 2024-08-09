using UnityEngine;
using TMPro;

public class RevealHint : MonoBehaviour
{
    public GameObject text3DObject; 
    public GameObject hintTextObject; 
    private bool playerInRange = false;

    private void Start()
    {
        text3DObject.SetActive(false); 
        hintTextObject.SetActive(false); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            hintTextObject.SetActive(true); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            hintTextObject.SetActive(false); 
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.Q))
        {
            text3DObject.SetActive(true); 
            hintTextObject.SetActive(false); 
        }
    }
}
