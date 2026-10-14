using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Logicmanager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public int playerScore;
    public Text scoreText;
    public void addScore()
    {
        playerScore = playerScore + 1;
        scoreText.text = playerScore.ToString();
    }
    public void Restartgame()

    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
    
}
