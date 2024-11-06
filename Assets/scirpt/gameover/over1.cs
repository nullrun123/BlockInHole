using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerPositionManager : MonoBehaviour
{
    public Transform player; // Drag the Player object here in the Inspector
    public Button reloadButton; // Drag the Button object here in the Inspector
    public Button resetPositionButton; // Drag the Reset Position Button here in the Inspector

    private void Start()
    {
        // Add listeners to the buttons
        reloadButton.onClick.AddListener(OnReloadButtonClick);
        resetPositionButton.onClick.AddListener(OnResetPositionButtonClick);

        // Check if position data exists
        if (PlayerPrefs.HasKey("PlayerX"))
        {
            // Retrieve saved position and set player position
            float x = PlayerPrefs.GetFloat("PlayerX");
            float y = PlayerPrefs.GetFloat("PlayerY");
            float z = PlayerPrefs.GetFloat("PlayerZ");
            player.position = new Vector3(x, y, z);
        }
    }

     public void OnReloadButtonClick()
    {
        // Set new position for the player (change this to your desired position)
        Vector3 newPosition = new Vector3(17.5f, 1, 21.5f); // Example position
        PlayerPrefs.SetFloat("PlayerX", newPosition.x);
        PlayerPrefs.SetFloat("PlayerY", newPosition.y);
        PlayerPrefs.SetFloat("PlayerZ", newPosition.z);

        // Reload the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnResetPositionButtonClick()
    {
        // Reset position to the original position (change this to your starting position)
        Vector3 startingPosition = new Vector3(2.5f, 1, -43.5f); // Example starting position
        PlayerPrefs.SetFloat("PlayerX", startingPosition.x);
        PlayerPrefs.SetFloat("PlayerY", startingPosition.y);
        PlayerPrefs.SetFloat("PlayerZ", startingPosition.z);

        // Reload the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
