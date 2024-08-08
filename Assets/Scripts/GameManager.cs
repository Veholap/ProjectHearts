using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IDataPersistence
{
    public static GameManager Instance;

    public Character heroBase;
    public Hero[] heroes;

    public GameObject enemyPrefab;
	public GameObject projectilePrefab;

	public bool gamePaused = true;
    public int waveCount = 1;

    public int enemiesDefeated = 0;
	public List<Enemy> enemies = new List<Enemy>();

	private void Awake()
	{
		if (GameManager.Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("TWO GameManager INSTANCES");
        }
	}

	// Start is called before the first frame update
	void Start()
    {
		gamePaused = true;
		MainMenuUI mainMenu = FindAnyObjectByType<MainMenuUI>(FindObjectsInactive.Include);
        mainMenu.EnableMainMenu(true);
	}

    public void LoadData(GameData data)
    {
        enemiesDefeated = data.enemiesDefeated;
    }

    public void SaveData(ref GameData data)
    {
        data.enemiesDefeated = enemiesDefeated;
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
		for (int i = 0; i < heroes.Length; i++)
		{
			heroes[i].characterType = Gval.CharacterType.HERO;
			// TODO load hero data from somewhere
			heroes[i].InitStats();
			heroes[i].SetStatValue(Gval.StatType.RANGE, 12f);
		}
		heroBase.characterType = Gval.CharacterType.BASE;
		heroBase.InitStats();
		heroBase.SetStatValue(Gval.StatType.CurHP, 100f);
		heroBase.SetStatValue(Gval.StatType.MaxHP, 100f);
		heroBase.SetStatValue(Gval.StatType.MSPEED, 2f);

		Gval.ChangeGameState(Gval.GameState.GameOngoing);
        waveCount = 1;
        SpawnWave(waveCount + Random.Range(10, 15));
    }

    public void SpawnWave(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
			Enemy enemy = Instantiate(enemyPrefab).GetComponent<Enemy>();
            enemy.targetPos = heroBase.transform.position + new Vector3(0f, Random.Range(-4f, 4f), 0f);
            enemy.transform.position = new Vector3(Random.Range(15f, 30f + i), Random.Range(-7f, 7f), 0f);
            enemy.originPos = enemy.transform.position;
            enemy.characterType = Gval.CharacterType.ENEMY;

            enemy.InitStats();
            float enemyHP = Random.Range(4f, 6f);
			enemy.SetStatValue(Gval.StatType.CurHP, enemyHP);
			enemy.SetStatValue(Gval.StatType.MaxHP, enemyHP);
			enemy.SetStatValue(Gval.StatType.RANGE, Random.Range(4f, 6f));
            enemy.SetStatValue(Gval.StatType.MSPEED, Random.Range(2f, 3f));
            enemies.Add(enemy);
		}
    }

}
