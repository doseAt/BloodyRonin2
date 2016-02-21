using UnityEngine;
using System.Collections;

public class GroundChecker : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Ground")
			BR.ronin.grounded = true;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "Ground")
			BR.ronin.grounded = false;
	}
}
