using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput : MonoSingleton<MobileInput> {
	// public static MobileInput Instance{ set; get; }
	// internal bool tap, release, hold;
	internal bool tap;
	internal bool release;
	internal bool hold;
	
	public Vector2 swipeDelta;

	private Vector2 initialPosition;
	private void Update()
	{
		// release = tap = false;
		tap = false;
		release = false;

		if(Input.GetMouseButtonDown(0))
		{
			initialPosition = Input.mousePosition;
			hold = tap = true;
			Debug.Log("initialPosition" + initialPosition);
		}
		else if(Input.GetMouseButtonUp(0))
		{
			release = true;
			hold = false;
		}
		if(hold)
		{
			swipeDelta = (Vector2)Input.mousePosition - initialPosition;
			Debug.Log("swipeDelta" + swipeDelta);
		}
	}
	

}
