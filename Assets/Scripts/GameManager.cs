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

    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        isGameRunning = true;
        StartCoroutine(spawnTargets());
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnTargets()
    {
        while (isGameRunning)
        {
            yield return new WaitForSeconds(1.0f);
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
}
