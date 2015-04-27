using System;
using UnityEngine;

public class SplashScreenMain : MonoBehaviour
{
    private DateTime starTime;

    /// <summary>
    /// Call once after inicialization.
    /// </summary>
    void Start () 
    {
		starTime = DateTime.Now;

		// Set enviroment
		Application.targetFrameRate = 30;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		Screen.orientation = ScreenOrientation.Portrait;
    }
	
    // Update is called once per frame
    void Update () 
    {
		if ((DateTime.Now - starTime).TotalMilliseconds > 500)
		{
			Application.LoadLevel(Scenes.MENU_SCENE_ID);
		}
    }
}
