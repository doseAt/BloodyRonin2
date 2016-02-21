using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	public enum GameState {END, GAME, PAUSED, GET_READY}
	GameState currentState;
	public delegate void GSChanged(GameState gs);
	public static event GSChanged StateChanged;


	void Awake()
	{
		currentState = GameState.END;
	}

	public bool SetState(GameState toState)
	{
		if (currentState == toState)
			return false;

		switch (toState) {
		case GameState.GET_READY:
			Time.timeScale = 1.0f;
			break;
		case GameState.GAME:
			Time.timeScale = 1.0f;
			break;
		case GameState.PAUSED:
			Time.timeScale = 0.0f;
			break;
		case GameState.END:
			Time.timeScale = 1.0f;
			break;
		}


		if (currentState == GameState.PAUSED && toState == GameState.GAME) {
			currentState = toState;
			return true;
		} else {
			currentState = toState;
			if (StateChanged != null)
				StateChanged (currentState);
			return true;
		}
	}
	




}
