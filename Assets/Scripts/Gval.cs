using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Gval
{
	private static GameState gameState = GameState.None;

	public static void ChangeGameState(GameState newState)
	{
		Debug.Log("Changed gameState to " + newState + ", previous state: " + gameState);
		gameState = newState;
	}

	public static GameState GetGameState()
	{
		return gameState;
	}

	public enum GameState
	{
		None = 0,
		MainMenu,
		GameOngoing,
		
		Count
	}

	public enum StatType
	{
		None = 0,
		HP,
		DMG,

		Count
	}

}
