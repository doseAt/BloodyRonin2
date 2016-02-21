using UnityEngine;
using System.Collections;

public class BackgroundMover : MonoBehaviour {

	public GameObject[] backGrounds = new GameObject[4];
	int i = 0;

	GameObject currentBackGround;
	GameObject lastBackGround;
	
	void Awake()
	{
		currentBackGround = Instantiate (backGrounds [0], Vector3.zero, Quaternion.identity) as GameObject;
	}

	void FixedUpdate () 
	{
		if(currentBackGround.transform.position.x < 1024) //TODO: ubaciti ovo za game, 1024 je za test(Screen.width/2))
		{
			//if(i==4)
			//	i=0;
			//else 
			//	i++;
			if(i==0)
			{
			lastBackGround = currentBackGround;
			currentBackGround = Instantiate (backGrounds[i], new Vector3(1549, 0, 0), Quaternion.identity) as GameObject;
			currentBackGround.transform.Translate(1549, 0, 0);
			UIWidget currentWidget = currentBackGround.GetComponent<UIWidget>();
			currentWidget.SetAnchor(lastBackGround, 1548, 0, 1548, 0);
			i++;
			}
		}
	}
}
