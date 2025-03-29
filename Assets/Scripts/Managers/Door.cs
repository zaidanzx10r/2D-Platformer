using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public GameObject ePanel;
    private bool isPlayerTouchingDoor = false;

    private void Start()
    {
        ePanel.SetActive(false);
    }

    private void Update()
    {
        if (isPlayerTouchingDoor && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("LevelSelector");
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ePanel.SetActive(true);
            isPlayerTouchingDoor = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        ePanel?.SetActive(false);
        isPlayerTouchingDoor = false;
    }
}
