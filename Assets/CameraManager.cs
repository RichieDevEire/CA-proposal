using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour 
{
	public Transform[] views;
	public float changeSpeed;
	public Transform currentView;

	// Use this for initialization
	void Start () 
	{
		currentView = views[0];
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Alpha1)) 
		{
			currentView = views[0];
		}
		if(Input.GetKeyDown(KeyCode.Alpha2)) 
		{
			currentView = views[1];
		}
		if(Input.GetKeyDown(KeyCode.Alpha3)) 
		{
			currentView = views[2];
		}
		if(Input.GetKeyDown(KeyCode.Alpha4)) 
		{
			currentView = views[3];
		}
	}

	// Update is called once per frame
	void LateUpdate () 
	{
		// Lerping positions
		transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * changeSpeed);
	}
}
