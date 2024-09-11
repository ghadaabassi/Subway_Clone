using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Text playText;
    public Text instructionsText;
    public Text exitText;

    private void Start()
    {
        // Subscribe to button click events
        playText.GetComponent<Button>().onClick.AddListener(Play);
        instructionsText.GetComponent<Button>().onClick.AddListener(Instructions);
        exitText.GetComponent<Button>().onClick.AddListener(Exit);
    }

    // Button click event handlers
    private void Play()
    {
        SceneManager.LoadScene("YourGameScene"); // Replace "YourGameScene" with the actual scene name
    }

    private void Instructions()
    {
        // Add logic to show instructions or switch to an instructions scene
        Debug.Log("Instructions clicked");
    }

    private void Exit()
    {
        Application.Quit();
    }
}
