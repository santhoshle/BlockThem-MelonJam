using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour {

	public GameObject enemyPrefab;
	public GameObject blockerPrefab;
	public float spawnSpeed;
	public float blockerLifetime;

	List<EnemyObj> enemies = new List<EnemyObj>();

	// Use this for initialization
	void Start () {
		InvokeRepeating("Spawn", 2, spawnSpeed);
	}

	// Update is called once per frame
	void Update () {

		EnemyObj destroy = null;
		foreach (EnemyObj enemy in enemies)
		{
			if(enemy.gameObj.GetComponent<Enemy> ().getDestroy())
			{
				Destroy (enemy.gameObj, 0);
				destroy = enemy;
				continue;
			}
			Vector3 direction = enemy.direction * 0.1f;
			direction.y = 0;
			enemy.gameObj.transform.Translate(direction);
		}

		if(destroy != null)
		{
			enemies.Remove(destroy);
		}

		if (Input.GetButtonDown("Fire1"))
		{
			var v3 = Input.mousePosition;
			Debug.Log("height "+Camera.main.pixelHeight);
			Debug.Log("v3 "+v3);
			v3.x = Input.mousePosition.x;
      //v3.z = Camera.main.pixelHeight - Input.mousePosition.y;
			v3.z = Input.mousePosition.y;
			v3.y = 0;

			Vector3 clickPosition = Camera.main.ScreenToWorldPoint(v3);
			Debug.Log("clickPosition "+clickPosition);
			float x = clickPosition.x / 2;
			float z = clickPosition.z;
			CreateBlocker(new Vector3(x, 0, z));
			//Debug.Log ("mouseDown = " + this.ScreenToWorldPoint(v3));
		}
	}

	void CreateBlocker(Vector3 position) {
		Debug.Log("position"+position);
		GameObject gameObject = (GameObject) Instantiate(blockerPrefab, position, Quaternion.identity);
		Destroy (gameObject, blockerLifetime);
	}

	void Spawn() {
		int x = (int) Random.Range(-2f, 2f);
		int z = (int) Random.Range(-2f, 2f);
		Vector3 direction = Vector3.right;

		if(x < 0) {
			direction = -Vector3.right;
		}
		else if(z > 0) {
			direction = Vector3.forward;
		}
		else if(z < 0) {
			direction = -Vector3.forward;
		}

		GameObject gameObject = (GameObject) Instantiate(enemyPrefab, new Vector3(x, 0, z), Quaternion.identity);
		enemies.Insert(0, new EnemyObj(gameObject, direction));
	}
}
