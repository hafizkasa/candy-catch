using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

 
    private void Awake()
    {
        instance = this;
    }

    public GameObject LifeHolder;

    int score = 0;

    int lives = 3;

    bool gameOver = false;

    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI MenuScore;

    public GameObject gameoverMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void incrementScore()
    {
        if (!gameOver)
        {
            score++;
            ScoreText.text = score.ToString();
        }
        
    }
    public void DecreaseLife()
    {
        if (lives > 0)
        {
            lives--;
            print(lives);

            LifeHolder.transform.GetChild(lives).gameObject.SetActive(false);
        }
       if (lives <= 0)
        {
            gameOver = true;
            GameOver();
        }
    }
    public void GameOver()
    {
        CandySpawner.instance.StopspawnCandies();

        GameObject.Find("Player").GetComponent<PlayerController>().canMove = false;

        gameoverMenu.SetActive(true);

        MenuScore.text = "Score: " + score.ToString();

        print("GameOver()");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
