using UnityEngine;
using System.Collections;

public class UserBall : MonoBehaviour 
{
	//--------------------------------------
	//  Private variables
	//--------------------------------------

	private static float MAX_SPEED = 20f;


	//--------------------------------------
	//  Logic
	//--------------------------------------

	
	// Update is called once per frame
	void Update () 
	{
		GetComponent<Rigidbody2D>().velocity = Vector3.ClampMagnitude(GetComponent<Rigidbody2D>().velocity, MAX_SPEED);
	}

}
