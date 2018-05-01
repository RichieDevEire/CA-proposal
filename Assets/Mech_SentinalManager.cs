using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech_SentinalManager : MonoBehaviour 
{
	GameObject[] sentinals;
	public List <GameObject> sentinalList = new List<GameObject>();
	GameObject[] mechs;
	public List <GameObject> mechList = new List<GameObject>();

	// Use this for initialization
	void Start () 
	{
		sentinals = GameObject.FindGameObjectsWithTag("Sentinal");
		mechs = GameObject.FindGameObjectsWithTag("Mech");

		for(int i = 0; i < sentinals.Length; i ++)
		{
			sentinalList.Add(sentinals[i].gameObject);
		}

		for(int i = 0; i < mechs.Length; i ++)
		{
			mechList.Add(mechs[i].gameObject);
		}

		sentinals = new GameObject[0];
		mechs = new GameObject[0];
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
