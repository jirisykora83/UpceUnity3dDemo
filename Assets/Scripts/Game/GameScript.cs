using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameScript : MonoBehaviour 
{

	//--------------------------------------
	//  Variables - public
	//--------------------------------------

	// Main game camera
	public Camera MainCam;

	// Box around screen
	public BoxCollider2D TopWall;
	public BoxCollider2D BottomWall;
	public BoxCollider2D LeftWall;
	public BoxCollider2D RightWall;

	public GameObject UserBallPrefab;


	//--------------------------------------
	//  Variables - private
	//--------------------------------------

	// Currently user ball
	private GameObject userBallGameObject;

	// Gravitation vector
	private Vector2 graVector2;


	//--------------------------------------
	//  Main logic
	//--------------------------------------

	/// <summary>
	/// Call once after inicialization.
	/// </summary>
	void Start () 
	{
		// Set enviroment
		Application.targetFrameRate = 60;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		Screen.orientation = ScreenOrientation.Portrait;

		// Calucate and set box collider around screen
		TopWall.size = new Vector2(MainCam.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f, 0f)).x, 1f);
		TopWall.offset = new Vector2(-0.5f, MainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y);

		BottomWall.size = new Vector2(MainCam.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f, 0f)).x, 1f);
		BottomWall.offset = new Vector2(-0.5f, MainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).y - 1f);

		LeftWall.size = new Vector2(1f, MainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
		LeftWall.offset = new Vector2(MainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x - 1f, 0f);

		RightWall.size = new Vector2(1f, MainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
		RightWall.offset = new Vector2(MainCam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x, 0f);

		// Create game ball
		var location = new Vector3(Screen.width / 2f, Screen.height / 2f, 10);
		userBallGameObject = Instantiate(UserBallPrefab);
		userBallGameObject.name = "User ball";
		userBallGameObject.transform.position = Camera.main.ScreenToWorldPoint(location);
		userBallGameObject.transform.localScale = new Vector3(0.5f, 0.5f, 1);
	}
	
	/// <summary>
	/// Called once per frame.
	/// </summary>
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.LoadLevel(Scenes.MENU_SCENE_ID);
		}
	}

	/// <summary>
	/// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	/// Not framerate dependent!
	/// </summary>
	void FixedUpdate()
	{
		// Gravity for mobile platforme
		#if !UNITY_EDITOR || !UNITY_STANDALONE || !UNITY_WEBPLAYER
			graVector2.x = Input.acceleration.x;
			graVector2.y = Input.acceleration.y;
			Physics2D.gravity = graVector2 * 25f;
		#endif

		// Gravity for PC platform
		#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER
			graVector2.x = 0f;
			graVector2.y = -25f;
			Physics2D.gravity = graVector2;
		#endif
	}

}
