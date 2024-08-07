using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
	[Header("File Storage Config")]
	[SerializeField] private string fileName;
	[SerializeField] private bool useEncryption;

	private GameData gameData;
	private List<IDataPersistence> dataPersistenceObjects;
	private FileDataHandler dataHandler;

	public static DataPersistenceManager instance { get; private set; }

	private void Awake()
	{
		if (instance != null)
		{
			Debug.LogError("Found more than one DataPersistenceManager in the scene");
		}
		instance = this;
	}

	private void Start()
	{
		this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);
		this.dataPersistenceObjects = FindAllDataPersistenceObjects();
		LoadGame();
	}

	public void NewGame()
	{
		this.gameData = new GameData();
	}

	public void LoadGame()
	{
		this.gameData = dataHandler.Load();

		if (gameData == null)
		{
			Debug.Log("No data was found. Initializing data to defaults.");
			NewGame();
		}

		foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
		{
			dataPersistenceObj.LoadData(gameData);
		}

		//Gval.userData = gameData;
	}

	public void SaveGame()
	{
		foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
		{
			dataPersistenceObj.SaveData(ref gameData);
		}
		dataHandler.Save(gameData);

		//dataHandler.Save(Gval.userData);
	}

	private void OnApplicationQuit()
	{
		SaveGame();
	}

	private List<IDataPersistence> FindAllDataPersistenceObjects()
	{
		//IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

		IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsByType<MonoBehaviour>(FindObjectsInactive.Include, FindObjectsSortMode.InstanceID).OfType<IDataPersistence>();

		return new List<IDataPersistence>(dataPersistenceObjects);
	}

}
