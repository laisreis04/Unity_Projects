using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  //FOR - editing TextMesh Pro
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI gameOverText;
    public Button restartBtn;
    public GameObject titleObject;
    private int score;
    public bool isGameActive;
    private float spawnRate = 1.0f;
    

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;  // FOR - To start the game as true and spawning obejcts
        score = 0;
        spawnRate /= difficulty;

        StartCoroutine(SpawnTarget());
        UpdateScore(0);

        titleObject.SetActive(false);
        
        

    }

    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            
        }
        
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoretext.text = "Score:  " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartBtn.gameObject.SetActive(true);
        isGameActive = false; //FOR  - Stopping the spawn objects
    }

    public void RestartGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
