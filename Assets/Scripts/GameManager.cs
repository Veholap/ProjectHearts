using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gamePaused = true;

    // Start is called before the first frame update
    void Start()
    {
		gamePaused = true;
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame(bool pause)
    {
        gamePaused = pause;
    }

}
