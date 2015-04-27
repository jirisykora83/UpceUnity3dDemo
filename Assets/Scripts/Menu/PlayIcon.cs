using UnityEngine;
using UnityEngine.EventSystems;


public class PlayIcon : MonoBehaviour, IPointerDownHandler
{

	/// <summary>
	/// Call once after inicialization.
	/// </summary>
	private void Start()
	{
		// Set enviroment
		Application.targetFrameRate = 60;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		Screen.orientation = ScreenOrientation.Portrait;
	}


	/// <summary>
	/// Handle event on mouse down (also on touch down).
	/// </summary>
	public void OnPointerDown(PointerEventData eventData)
	{
		Application.LoadLevel(Scenes.GAME_SCENE_ID);
	}
}
