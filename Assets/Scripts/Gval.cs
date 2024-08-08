using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Gval
{
	public static GameData userData;

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
		CurHP,
		MaxHP,
		DMG,
		RANGE,
		ASPEED, // attack speed
		MSPEED, // movement speed

		Count
	}

	public enum CharacterType
	{
		None = 0,
		HERO,
		ENEMY,
		BASE,

		Count
	}

	public enum EnemyType
	{
		None = 0,
		

		Count
	}

	public enum HeroType
	{
		None = 0,


		Count
	}

}
