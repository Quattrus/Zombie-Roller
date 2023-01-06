using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int selectedZombiePos = 0;
    public GameObject selectedZombie;
    public List<GameObject> zombies;
    public Vector3 initialScale;
    public Vector3 selectedScale;

    private void Start()
    {
        SelectZombie(selectedZombie);
    }

    private void Update()
    {
        MonitorInput();
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
}
