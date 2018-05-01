using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{

	public float bulletLifeTime = 1.0f;
	// Use this for initialization
	void Start () 
	{
		Destroy(gameObject,bulletLifeTime);
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject)
		{
			Destroy(gameObject);
		}
	}
}
