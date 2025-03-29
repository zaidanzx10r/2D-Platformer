using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject introPanel;
    public GameObject instructionPanel;

    [SerializeField]
    private Rigidbody2D rb;
    

    private void Start()
    {
        if (introPanel == null)
        {
            instructionPanel.SetActive(true);
        }

        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        // Show the intro panel at the start
        introPanel.SetActive(true);
        instructionPanel.SetActive(false);
    }

    public void CloseIntro()
    {
        // Hide the intro panel
        introPanel.SetActive(false);
        // Show the info panel
        instructionPanel.SetActive(true);
    }

    public void CloseInstructions()
    {
        // Hide the info panel
        instructionPanel.SetActive(false);
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    
}
