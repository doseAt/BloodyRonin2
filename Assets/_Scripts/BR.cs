using UnityEngine;
using System.Collections;

public class BR : MonoBehaviour
{

	public static Game game;
	public static Ronin ronin;

	void Awake ()
	{
		game = GameObject.Find ("Game").GetComponent<Game> ();
		ronin = GameObject.Find ("Ronin").GetComponent<Ronin> ();
	}
}
