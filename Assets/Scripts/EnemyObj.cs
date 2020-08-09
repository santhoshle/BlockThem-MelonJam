using System.Collections;
using System;
using UnityEngine;

public class EnemyObj : IComparable<EnemyObj> {

	public GameObject gameObj;
	public Vector3 direction;

	public EnemyObj(GameObject newGameObj, Vector3 newDirection)
	 {
			 gameObj = newGameObj;
			 direction = newDirection;
	 }

	public int CompareTo(EnemyObj other)
    {
        if(other == null)
        {
            return 1;
        }

        //Return the difference in power.
        return -1;
    }

}
