using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRM;

public class Looker : MonoBehaviour
{
	public GameObject head;

    public VRMLookAtHead lookAtHead;

    public List<GameObject> nearbyObjects;

    void Update()
    {
        FindNearestObject();
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Object")
        {
            if (GetTarget() == null)
            {
                SetTarget(other.gameObject);
            }

            if (!nearbyObjects.Contains(other.gameObject))
            {
                nearbyObjects.Add(other.gameObject);
            }
        }
	}

	private void OnTriggerExit(Collider other)
	{
        if (other.gameObject.tag == "Object")
        {
            if (nearbyObjects.Contains(other.gameObject))
            {
                nearbyObjects.Remove(other.gameObject);
            }

            if (other.gameObject == GetTarget())
            {
                FindNearestObject();
            }
        }
	}

	private void FindNearestObject()
	{
		if (nearbyObjects.Count == 0)
		{
			SetTarget(null);
		}
		else if (nearbyObjects.Count == 1)
		{
			SetTarget(nearbyObjects[0]);
		}
		else
		{
			SetTarget(nearbyObjects[0]);

			var nearestObjectDistance = GetDistance(head.transform.position, GetTarget().transform.position);

			for (int i = 1; i < nearbyObjects.Count; i++)
			{
				if (GetDistance(head.transform.position, nearbyObjects[i].transform.position) < nearestObjectDistance)
				{
					SetTarget(nearbyObjects[i]);

					nearestObjectDistance = GetDistance(head.transform.position, GetTarget().transform.position);
				}
			}
		}	
	}

	private float GetDistance(Vector3 a, Vector3 b)
	{
		return (a - b).sqrMagnitude;
	}

    private Transform GetTarget()
    {
        return lookAtHead.Target;
    }

    private void SetTarget(GameObject target)
    {
		if (target != null)
		{
			lookAtHead.Target = target.transform;
		}
		else
		{
			lookAtHead.Target = null;
		}
    }
}