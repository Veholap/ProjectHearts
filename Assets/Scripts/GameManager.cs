using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    public bool gamePaused = true;

    private float spawnTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
		gamePaused = true;
		MainMenuUI mainMenu = FindAnyObjectByType<MainMenuUI>(FindObjectsInactive.Include);
        mainMenu.EnableMainMenu(true);
	}

    // Update is called once per frame
    void Update()
    {
        if (gamePaused)
        {
            return;
        }
    }

    public void PauseGame(bool pause)
    {
        gamePaused = pause;
    }

    public void StartLevel(int level)
    {
        Gval.ChangeGameState(Gval.GameState.GameOngoing);
        SpawnWave(Random.Range(10, 15));
    }

    public void SpawnWave(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
			Enemy enemy = Instantiate(enemyPrefab).GetComponent<Enemy>();
            enemy.transform.position = new Vector3(Random.Range(15f, 30f + i), Random.Range(-6f, 6f), 0f);
		}
    }

}
