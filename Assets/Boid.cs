using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour {
    List<SteeringBehaviour> behaviour = new List<SteeringBehaviour>();
    
    public Vector3 force = Vector3.zero;
    public Vector3 accel = Vector3.zero;
    public Vector3 velocity = Vector3.zero;
    public float mass = 1;
    public float maximumSpeed = 8.0f;   
    
    // Use this for initialization
    void Start () {

        SteeringBehaviour[] behaviour = GetComponents<SteeringBehaviour>();

        foreach (SteeringBehaviour b in behaviour)
        {
            this.behaviour.Add(b);
        }
	}

    public Vector3 SeekForce(Vector3 target)
    {
        Vector3 desired = target - transform.position;
        desired.Normalize();
		desired *= maximumSpeed;
        return desired - velocity;
    }
    public Vector3 ArriveForce(Vector3 target, float slowingDistance = 15.0f, float deceleration = 1.0f)
    {
        Vector3 toTarget = target - transform.position;

        float distance = toTarget.magnitude;
        if (distance == 0)
        {
            return Vector3.zero;
        }
		float ramped = maximumSpeed * (distance / (slowingDistance * deceleration));

		float clamped = Mathf.Min(ramped, maximumSpeed);
        Vector3 desired = clamped * (toTarget / distance);

        return desired - velocity;
    }
    Vector3 Calculate()
    {
        force = Vector3.zero;

        foreach (SteeringBehaviour b in behaviour)
        {
            if (b.isActiveAndEnabled)
            {
                force += b.Calculate() * b.weight;
            }
        }
        return force;
    }
		
	// Update is called once per frame
	void Update () {
        force = Calculate();
        Vector3 newAccelerate = force / mass;
		Vector3 globalUp = new Vector3(0, 0.5f, 0);
		Vector3 accelUp = accel * 0.1f;
		Vector3 bankUp = accelUp + globalUp;
        float smooth = Mathf.Clamp(6.0f * Time.deltaTime, 0.20f, 0.6f) / 2.0f;
		accel = Vector3.Lerp(accel, newAccelerate, smooth);
        
		velocity += accel * Time.deltaTime;

		velocity = Vector3.ClampMagnitude(velocity, maximumSpeed);

		smooth = Time.deltaTime * 3f;
        Vector3 tempUpVec = transform.up;
		tempUpVec = Vector3.Lerp(tempUpVec, bankUp, smooth);

        if (velocity.magnitude  > 0.0001f)
        {
			transform.LookAt(transform.position + velocity, tempUpVec);
            velocity *= 0.9f;
        }
        transform.position += velocity * Time.deltaTime;        
	}
}
