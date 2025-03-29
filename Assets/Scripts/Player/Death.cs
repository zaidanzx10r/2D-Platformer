using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject deathPanel;

    private void Start()
    {
        deathPanel.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0.0f;
            deathPanel.SetActive(true);
        }
    }
}
