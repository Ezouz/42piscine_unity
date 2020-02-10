using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoeAttackScript : MonoBehaviour
{
	public bool followPlayer = false;

	private GameObject mayaObject;

	void Start()
	{
		mayaObject = GameObject.Find("Maya");
		Invoke("destroyMyself", 5f);
	}

	void Update()
	{
		if (followPlayer)
			transform.position = mayaObject.transform.position;
	}

	private void destroyMyself()
	{
		Destroy(gameObject);
	}
}
