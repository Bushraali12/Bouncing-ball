using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject Titlescreen;
    public List<GameObject> target;
    private int score;
    public TextMeshProUGUI scoreText;
    public float spawnrate = 1.0f; // Corrected type to float
    public TextMeshProUGUI gameovertext;
    public bool isgameactive;
    public Button restartButton;
    void Start()
    {
        Titlescreen.SetActive(false);
      
    }
    public void Gameover()
    {
        isgameactive=false;
        gameovertext.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    // Update is called once per frame
    IEnumerator spawntarget()
    {
        while (isgameactive)
        {
            yield return new WaitForSeconds(spawnrate);
            int index = Random.Range(0, target.Count);
            Instantiate(target[index]);
            // UpdateScore(5);
        }
    }
    public void UpdateScore(int scoretoadd)
    {
        score += scoretoadd;
        scoreText.text= "score:" + score;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void startgame(int difficult)
    {
        isgameactive=true;
        spawnrate /=difficult;
        StartCoroutine(spawntarget()); // Added parentheses to invoke the method
        score=0;
    }
}