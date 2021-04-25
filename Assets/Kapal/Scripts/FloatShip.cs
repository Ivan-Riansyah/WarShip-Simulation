using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FloatShip : MonoBehaviour
{
	public Vector3 COM;
	[Space(15)]
	public float waterLevel = 0.0f;
	public float floatThreshold = 2f;
	public float waterDensity = 0.125f;
	public float downForce = 4.0f;

	private float forceFactor;
	private Vector3 floatForce;

	Transform m_COM;

	private void Update()
	{
		Balance();
	}

	void FixedUpdate()
	{
		forceFactor = 1.0f - ((transform.position.y - waterLevel) / floatThreshold);

		if (forceFactor > 0.0f)
		{
			floatForce = -Physics.gravity * GetComponent<Rigidbody>().mass * (forceFactor - GetComponent<Rigidbody>().velocity.y * waterDensity);
			floatForce += new Vector3(0.0f, -downForce * GetComponent<Rigidbody>().mass, 0.0f);
			GetComponent<Rigidbody>().AddForceAtPosition(floatForce, transform.position);
		}

	}
	void Balance()
	{
		if (!m_COM)
		{
			m_COM = new GameObject("COM").transform;
			m_COM.SetParent(transform);
		}

		m_COM.position = COM;
		GetComponent<Rigidbody>().centerOfMass = m_COM.position;
	}
}