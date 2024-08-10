using UnityEngine;

public class PlayerWin : MonoBehaviour
{
    public GameObject winScreenUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WinZone"))
        {
            Win();
        }
    }

    void Win()
    {
        
        winScreenUI.SetActive(true);
        
    }
}
