using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private bool isDestroy;

	// Use this for initialization
	void Start () {
		isDestroy = false;
	}

	// Update is called once per frame
	void Update () {

	}

	public bool getDestroy()
	{
		return isDestroy;
	}

	void OnCollisionEnter(Collision collision)
	{
    if (collision.gameObject.name.EndsWith("Wall"))
		{
			isDestroy = true;
    }
	}
}
