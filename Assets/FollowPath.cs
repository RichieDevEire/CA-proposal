using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : SteeringBehaviour {

    public Path path;

    Vector3 nextWaypoint;

    public void OnDrawGizmos()
    {
        if (isActiveAndEnabled)
        {
			Gizmos.color = Color.red;
            Gizmos.DrawLine(this.transform.position, nextWaypoint);
        }
    }
    public override Vector3 Calculate()
    {
        nextWaypoint = path.NextWaypoint();
		// Gets distance between this position and next waypoint
		if (Vector3.Distance(this.transform.position, nextWaypoint) < 3)
        {
            path.AdvanceToNext();
        }

        if (!path.looped && path.IsLast())
        {
            return boid.ArriveForce(nextWaypoint, 20);
        }
        else
        {
            return boid.SeekForce(nextWaypoint);
        }
    }
}
