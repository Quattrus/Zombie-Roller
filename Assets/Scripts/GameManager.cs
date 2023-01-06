using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int selectedZombiePos = 0;
    public GameObject selectedZombie;
    public List<GameObject> zombies;
    public Vector3 initialScale;
    public Vector3 selectedScale;
    public float pushStrength = 10;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScore;
    public GameObject playGameScreen;
    public GameObject gameOverScreen;
    public GameObject tutorialScreen;
    public GameObject titleScreen;
    private int score = 0;
    private int deadZombies = 0;

    private void Start()
    {
        SelectZombie(selectedZombie);
        scoreText.text = "Score: " + score;
        playGameScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        tutorialScreen.SetActive(false);
    }

    private void Update()
    {
        MonitorInput();
        CheckGameOver();
    }

    private void SelectZombie(GameObject newZombie)
    {
        selectedZombie.transform.localScale = initialScale;
        selectedZombie = newZombie;
        newZombie.transform.localScale = selectedScale;
    }

    private void MonitorInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GetZombieLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GetZombieRight();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            PushUp();
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void GetZombieLeft()
    {
        if(selectedZombiePos == 0)
        {
            selectedZombiePos = 3;
            SelectZombie(zombies[3]);
        }
        else
        {
            selectedZombiePos = selectedZombiePos - 1;
            GameObject newZombie = zombies[selectedZombiePos];
            SelectZombie(newZombie);
        }
    }

    private void GetZombieRight()
    {
        if(selectedZombiePos == 3)
        {
            selectedZombiePos = 0;
            SelectZombie(zombies[0]);
        }
        else 
        {
            selectedZombiePos = selectedZombiePos + 1;
            GameObject newZombie = zombies[selectedZombiePos];
            SelectZombie(newZombie);
        }
    }

    private void PushUp()
    {
        Rigidbody rb = selectedZombie.GetComponent<Rigidbody>();
        rb.AddForce(0, 0, pushStrength, ForceMode.Impulse);
    }

    public void AddPoint()
    {
        score = score + 1;
        scoreText.text = "Score: " + score;
    }

    public void ZombieDied()
    {
        deadZombies = deadZombies + 1;
    }

    public void TutorialActive()
    {
        tutorialScreen.SetActive(true);
        titleScreen.SetActive(false);
    }

    public void Back() 
    {
        titleScreen.SetActive(true);
        tutorialScreen.SetActive(false);
    }

    public void StartGame()
    {
        playGameScreen.SetActive(true);
        titleScreen.SetActive(false);
        for(int i = 0; i < zombies.Count; i++)
        {
            zombies[i].GetComponent<Rigidbody>().useGravity = true;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    private void CheckGameOver()
    {
        if(deadZombies >= 4)
        {
            gameOverScreen.SetActive(true);
            playGameScreen.SetActive(false);
            finalScore.text = "Final Score: " + score;
        }
    }
}
