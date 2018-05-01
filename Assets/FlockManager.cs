using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour 
{

	public Health[] objects;

	public List<GameObject> sentinals = new List<GameObject>();

	public List<GameObject> mechs = new List<GameObject>();

	public GameObject sentinalLeader;
	public GameObject secondSentinalLeader;

	// Use this for initialization
	void Start () 
	{
		objects = GameObject.FindObjectsOfType<Health>();

		for(int i = 0; i < objects.Length; i ++)
		{
			if(objects[i].characterType == Health.type.sentinal)
			{
				if(!sentinals.Contains(objects[i].gameObject))
				{
					sentinals.Add(objects[i].gameObject);
				}
			}

			if(objects[i].characterType == Health.type.mech)
			{
				if(!sentinals.Contains(objects[i].gameObject))
				{
					mechs.Add(objects[i].gameObject);
				}
			}
		}
	}

	void ChangeLeader()
	{
		if(sentinalLeader == null)
		{
			sentinalLeader = secondSentinalLeader;
		}

		for(int i = 0; i < sentinals.Count; i ++)
		{
			if(Vector3.Distance(sentinalLeader.transform.position, sentinals[i].transform.position) < Vector3.Distance(sentinalLeader.transform.position, secondSentinalLeader.transform.position) && sentinals[i].gameObject != sentinalLeader.gameObject)
			{
				secondSentinalLeader = sentinals[i].gameObject;
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		ChangeLeader();


	}
}
