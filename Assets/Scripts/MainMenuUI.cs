using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public Canvas mainMenuCanvas;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //EnableMainMenu(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool MainMenuEnabled()
    {
        return mainMenuCanvas.gameObject.activeSelf;
    }

    public void EnableMainMenu(bool enable)
    {
		gameManager.PauseGame(enable);
		mainMenuCanvas.gameObject.SetActive(enable);
        if (enable == true)
        {
			Gval.ChangeGameState(Gval.GameState.MainMenu);
		}
	}

    public void StartLevel()
    {
        EnableMainMenu(false);
        gameManager.StartLevel(1); // TODO get level 
    }

}
