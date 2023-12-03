using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;

    public Text scoreText;
    public GameObject playButton; // can be refed as a button but there are multiple components
    public GameObject gameOver;
    public Player player;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Pause(); // want game to be paused
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();
        gameOver.SetActive(false);
        playButton.SetActive(false);

        Time.timeScale = 1;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i=0; i<pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject); // make sure you destroy the entire game object
        }
    }

    public void Pause()
    {
        Time.timeScale = 0; // nothing will update as delta time = 0
        player.enabled = false;
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);
        
        Pause();
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString(); // converts int to String
    }
}
