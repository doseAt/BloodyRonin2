using UnityEngine;
using System.Collections;

public class Ronin : MonoBehaviour
{

	Rigidbody2D rigidbody;





	public bool alive;
	public int lives;
	public bool attackMode;
	public bool grounded;
	public Vector2 jumpForce;

	void Awake ()
	{
		lives = 3;
		alive = true;
		rigidbody = gameObject.GetComponent <Rigidbody2D> ();
	}

	//triggers the enemy collide
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Enemy") 
		{
			if (attackMode) 
			{
				//kill the enemy
			} 
			else 
			{
				lives--;
				if (lives <= 0)
					alive = false;
			}
		}
	}

	void Update()
	{
		if(!alive)
		{
			Dead ();
			BR.game.SetState (Game.GameState.END);
		}
	}

	void Dead()
	{
		//animate dead event
	}

	public void Jump()
	{
		rigidbody.AddForce (jumpForce, ForceMode2D.Impulse);
	}
		
	public void SetAttack(bool on_off)
	{
		attackMode = on_off;
	}
}
