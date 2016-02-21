using UnityEngine;
using System.Collections;

public class OnClickSetGameState : MonoBehaviour
{
	public Game.GameState to;

	void OnClick ()
	{
		BR.game.SetState (to);
	}
}
