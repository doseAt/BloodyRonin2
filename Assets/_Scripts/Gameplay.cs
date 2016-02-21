using UnityEngine;
using System.Collections;

public class Gameplay : MonoBehaviour
{
	//controls
	Vector3 startDot;
	Vector3 endDot;





	//about the ronin
	public float attackTime;
	public int attacksAvailable;

	void Awake ()
	{
		Game.StateChanged += OnGameStateChanged;
	}



	void Update()
	{
		Controls ();
	}

	void Controls()
	{
		if (!BR.ronin.alive)
			return;
		
		if(Input.GetMouseButtonDown (0))
		{
			startDot = Input.mousePosition;
		}
		else if(Input.GetMouseButtonUp (0))
		{
			endDot = Input.mousePosition;
			Vector3 move = endDot - startDot;
			//Debug.LogError (move);
			//check what player did:
			//1. it was click
			if(move.magnitude < 1)
			{
				//Debug.Log ("Click");
				RoninAttackOn ();
			}
			//2. it was swipped up
			else if(move.y > 2 && move.x <1 && move.x > -1)
			{
				//Debug.Log ("Swipe Up");
				RoninJump ();
			}
			//3. it was swipped down
			else if(move.y < 2 && move.x <1 && move.x > -1)
			{
				//Debug.Log ("Swipe down");
				//clear blood
			}
			//4. it was swipped right
			else if(move.y <1  && move.y > -1 && move.x > 2)
			{
				//Debug.Log ("Swipe right");
				//drop shuriken or some shit like that
			}
		}
	}

	void RoninAttackOn()
	{
		if(!BR.ronin.attackMode && attacksAvailable>0)
		{
			BR.ronin.SetAttack (true);
			attacksAvailable--;
			Invoke ("RoninAttackOff", attackTime);
		}
	}

	void RoninAttackOff()
	{
		BR.ronin.attackMode = false;
	}

	void RoninJump()
	{
		if(BR.ronin.grounded)
			BR.ronin.Jump ();
	}















	public void GetReady ()
	{
		
	}

	public void EndGame ()
	{
		
	}

	public void StartGame ()
	{
		
	}

	public void OnGameStateChanged (Game.GameState currState)
	{
		if (currState == Game.GameState.GET_READY)
			GetReady ();
		else if (currState == Game.GameState.GAME)
			StartGame ();
		else if (currState == Game.GameState.END)
			EndGame ();
	}
}
