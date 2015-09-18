using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int lives = 3;

    public float resetDelay = 1f;
    public Text livesText;
    public Text currentLevelText;
    public GameObject gameOver;
    public GameObject youWon;
    public GameObject bricksForFirstLevel;
    public GameObject bricksForSecondLevel;
    public GameObject paddle;
    public GameObject deathParticles;
    public static GameManager instance = null;

    private GameObject clonePaddle;
    private int bricks;
    private int currentlevelIndex;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        SetupStartSettings();
    }

    private void SetupStartSettings()
    {
        currentlevelIndex = 1;
        InitPaddle();
        InitFirstLevel();
    }

    private void InitPaddle()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
    }

    private void InitFirstLevel()
    {
        Instantiate(bricksForFirstLevel, transform.position, Quaternion.identity);
        var gameObjFirstLevel = GameObject.FindGameObjectsWithTag("Level1").FirstOrDefault();
        if (gameObjFirstLevel != null)
            bricks = gameObjFirstLevel.transform.childCount;
        
    }

    private void InitSecondLevel()
    {
        Instantiate(bricksForSecondLevel, transform.position, Quaternion.identity);
        var gameObjSecondLevel = GameObject.FindGameObjectsWithTag("Level2").FirstOrDefault();
        if (gameObjSecondLevel != null)
            bricks = gameObjSecondLevel.transform.childCount;
    }

    private void CheckGameOver()
    {
        if (bricks < 1 && currentlevelIndex == 1)
        {
            LoadSecondLevel();
            return;
        }

        if (bricks < 1 && currentlevelIndex == 2)
        {
            youWon.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
            return;
        }

        if (lives < 1)
        {
            gameOver.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
        }

    }

    private void LoadSecondLevel()
    {
        currentlevelIndex++;
        currentLevelText.text = "Уровень: " + currentlevelIndex;
        InitSecondLevel();

        DestroyPaddleWithBall();

        Invoke("InitPaddle", 0);
    }

    void Reset()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(Application.loadedLevel);
    }

    private void DestroyPaddleWithBall()
    {
        var ball = GameObject.FindGameObjectsWithTag("Ball").FirstOrDefault();
        if (ball != null)
            Destroy(ball);
        Destroy(clonePaddle);
    }

    public void LoseLife()
    {
        lives--;
        livesText.text = "Жизни: " + lives;
        Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
        DestroyPaddleWithBall();
        Invoke("InitPaddle", resetDelay);
        CheckGameOver();
    }

    void SetupPaddle()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
    }

    public void DestroyBrick()
    {
        bricks--;
        CheckGameOver();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
