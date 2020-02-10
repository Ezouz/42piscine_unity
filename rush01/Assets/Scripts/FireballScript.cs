using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
	[SerializeField]private Vector3 destination;
	[SerializeField]private float speed;

	void Start()
	{
		speed = 10f;
		Invoke("destroyMyself", 5f);
	}

	void FixedUpdate()
	{
		if (destination != Vector3.zero)
			transform.Translate((destination - transform.position).normalized * speed * Time.fixedDeltaTime);
	}

	public void setDestination(Vector3 dest)
	{
		destination = dest;
	}

	private void destroyMyself()
	{
		Destroy(gameObject);
	}
}
