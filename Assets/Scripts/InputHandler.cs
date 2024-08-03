using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class InputHandler : MonoBehaviour
{
    public MainMenuUI mainMenu;
    public GameManager gameManager;

	private List<KeyCode> keys;

	private void Awake()
	{
        keys = new List<KeyCode>();
        int keyCount = System.Enum.GetValues(typeof(KeyCode)).Length;
		for (int i = 0; i < keyCount; i++)
        {
            keys.Add((KeyCode)i);
        }
        Debug.Log("KEYS COUNT: " + keyCount);

        if (mainMenu == null)
        {
			mainMenu = FindAnyObjectByType<MainMenuUI>(FindObjectsInactive.Include);
		}
        if (gameManager == null)
        {
			gameManager = FindAnyObjectByType<GameManager>(FindObjectsInactive.Include);
		}
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            for (int i = 0; i < keys.Count; i++)
            {
                if (Input.GetKeyDown(keys[i]))
                {
                    Debug.Log("KEY PRESSED: " + keys[i].ToString());
                    HandleKeyPressed(keys[i]);
                }
                else if (Input.GetKey(keys[i]))
                {
					//Debug.Log("KEY HELD: " + keys[i].ToString());
				}
            }
        }
    }

    public void HandleKeyPressed(KeyCode key)
    {

		switch (key)
		{
			case KeyCode.Escape:
				if (mainMenu.MainMenuEnabled())
				{
					mainMenu.EnableMainMenu(false);
				}
				else
				{
					mainMenu.EnableMainMenu(true);
				}
				break;

			case KeyCode.Space:
				if (Gval.GetGameState() == Gval.GameState.GameOngoing)
                {
                    gameManager.PauseGame(!gameManager.gamePaused);
                }
		        break;

			default:
				// No input handling
		        break;
		}
    }

    public void HandleKeyHeld(KeyCode key)
    {

    }

}
