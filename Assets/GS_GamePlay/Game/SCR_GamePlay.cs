using UnityEngine;
using UnityEngine.UI;

public enum GameStatus
{
    WELCOM, PLAY, PAUSE, FINISH
}

public class SCR_GamePlay : SCR_SingletonMonobihavior<SCR_GamePlay>
{
    
    public GameStatus status;
    public float Height;
    public float Width;
    public Text scoreDisplay;
    public Text finalScore;
    public GameObject panel;
    [HideInInspector]public int score = 0;

    void Start()
    {
        panel.SetActive(false);
        scoreDisplay.text = score.ToString();
        status = GameStatus.PLAY;
    }

    void Update()
    {

    }

    public void AddScore(int value)
    {
        score += value;
        scoreDisplay.text = score.ToString();
    }

    public void Over()
    {
        status = GameStatus.FINISH;
        finalScore.text = "Your Score : " + score.ToString();
        panel.SetActive(true);
    }

    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}