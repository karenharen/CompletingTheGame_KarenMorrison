using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public bool isGameRunning;
    public GameObject titleScreen;

    class SpawnRate
    {
        private float baseRate;
        private int difficulty;

       public SpawnRate (int diff)
        {
            baseRate = 1.0f;
            difficulty = diff;
        }

        public float GetRate()
        {
            return baseRate / difficulty;
        }

    }

    private SpawnRate spawnRate;

    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnTargets()
    {
        while (isGameRunning)
        {
            yield return new WaitForSeconds(spawnRate.GetRate());
            int targetIndex = Random.Range(0, targets.Count);
            Instantiate(targets[targetIndex]);
        }
        
    }

    public void UpdateScore(int addScore)
    { 
        if (isGameRunning)
        {
            score += addScore;
            if (score < 0)
            {
                score = 0;
            }
            scoreText.text = "Score: " + score;
        }
        

    }

    public void GameOver()
    {
        isGameRunning = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        spawnRate = new SpawnRate(difficulty);
        Debug.Log("Spawn Rate is set to " + spawnRate.GetRate());
        titleScreen.gameObject.SetActive(false);
        isGameRunning = true;
        StartCoroutine(spawnTargets());
        UpdateScore(0);
    }
}
