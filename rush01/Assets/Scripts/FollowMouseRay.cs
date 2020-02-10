using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseRay : MonoBehaviour
{
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Destroy(gameObject);
		}

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, Mathf.Infinity))
		{
			transform.position = hit.point;
		}
	}
}
