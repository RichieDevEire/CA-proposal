using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech : MonoBehaviour 
{
	Transform mechTransform;
	Transform firePoint;

	public float range = 10f;
	public GameObject bulletPrefab;



	float shootCooldown = 0.5f;
	float shootCooldownLeft = 0f;

	// Use this for initialization
	void Start () 
	{
		mechTransform = transform.Find("Torso");
		firePoint = transform.Find("FIREPOINT");

	}


	// Update is called once per frame
	void Update () 
	{
		//make array of sentinal gameobjects by finding sentinals scripts
		Sentinal[] sentinals = GameObject.FindObjectsOfType<Sentinal>();

		Sentinal closestEnemy = null;
		float dist = Mathf.Infinity;
		// search sentinals to find closest one to this object
		foreach(Sentinal s in sentinals)
		{
			float d = Vector3.Distance(this.transform.position, s.transform.position);
			if(closestEnemy == null || d < dist)
			{
				closestEnemy = s;
				dist = d;
			}
		}
		// if there are no more sentinals
		if(closestEnemy == null)
		{
			Debug.Log("No Sentinals To Shoot");
			return;
		}
		// rotate towards enemy
		Vector3 dir = closestEnemy.transform.position - this.transform.position;

		Quaternion lookAtRot = Quaternion.LookRotation(dir);

		//Debug.Log(lookAtRot.eulerAngles);
		mechTransform.rotation = Quaternion.Euler(lookAtRot.eulerAngles.x -90, lookAtRot.eulerAngles.y, lookAtRot.eulerAngles.z);


	}
}

