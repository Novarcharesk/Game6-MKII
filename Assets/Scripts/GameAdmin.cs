using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameAdmin : MonoBehaviour
{
    public static GameAdmin instance; // Singleton pattern to access the game manager from other scripts

    public int maxFriendshipPoints = 20;
    public int currentFriendshipPoints = 0;

    public Text winText; // Reference to the UI text for displaying the win message
    public Button restartButton; // Reference to the UI button to restart the game

    private bool isGameWon = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        // Disable the win text and restart button initially
        winText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    public void IncreaseFriendshipPoints(int points)
    {
        if (isGameWon) return; // Prevent further point increases after the game is won

        currentFriendshipPoints += points;

        if (currentFriendshipPoints >= maxFriendshipPoints)
        {
            WinGame();
        }
    }

    private void WinGame()
    {
        isGameWon = true;

        // Display the win text and restart button
        winText.text = "You won the game!";
        winText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }
}