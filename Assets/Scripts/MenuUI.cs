using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    private bool playerNamed;
    public string playerName;
    [SerializeField] GameObject nameDemand;


    void Start()
    {
        playerNamed = false; 
    }


    void Update()
    {
        
    }

    public void NewPlayerName(string playerName)
    {
        GameManager.Instance.playerName = playerName;

        if (playerName != null)
        {
            playerNamed = true;
        }
    }

    public void StartGame()
    {
        if ( playerNamed==true )
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            nameDemand.SetActive(true);
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
