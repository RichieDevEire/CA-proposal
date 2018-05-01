using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTest : MonoBehaviour 
{

	public GameObject currentTarget;

	Transform firePoint;

	[Header("Shooting Variables")]
	public GameObject bulletPrefab;
	public float fireRate;
	public float startFireRate;

	public float shootForce;

	[Header("Debug Variables")]
	public bool debug;
	public float debugFirePointRadius;

	public Mech_SentinalManager mech_sentinalManager;

	// Use this for initialization
	void Start () 
	{
		firePoint = transform.GetChild(2).transform;
		mech_sentinalManager = GameObject.FindObjectOfType<Mech_SentinalManager>();

		if(this.gameObject.tag == "Mech")
		{
			currentTarget = mech_sentinalManager.sentinalList[0].gameObject;
		}
	}

	void SetTarget()
	{
		for(int i = 0; i < mech_sentinalManager.sentinalList.Count; i ++)
		{
			if(Vector3.Distance(this.transform.position, mech_sentinalManager.sentinalList[i].transform.position) < Vector3.Distance(this.transform.position, currentTarget.transform.position))
			{
				currentTarget = mech_sentinalManager.sentinalList[i].gameObject;
			}
		}
	}

	void FirePointLookAt()
	{
		firePoint.transform.LookAt(currentTarget.transform);
	}

	void Firing()
	{
		fireRate -= 1 * Time.deltaTime;

		if(fireRate <= 0)
		{
			GameObject bulletPrefabInstance;
			bulletPrefabInstance = Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.identity) as GameObject;

			Rigidbody rb;
			rb = bulletPrefabInstance.GetComponent<Rigidbody>();
			rb.AddForce(firePoint.forward * shootForce);

			fireRate = startFireRate;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		SetTarget();
		FirePointLookAt();
		Firing();
	}

	void OnDrawGizmos()
	{
		if(debug)
		{
			Gizmos.color = Color.blue;
			Gizmos.DrawWireSphere(firePoint.position, debugFirePointRadius);

			Debug.DrawRay(firePoint.position, firePoint.forward * debugFirePointRadius, Color.red);
		}
	}
}
