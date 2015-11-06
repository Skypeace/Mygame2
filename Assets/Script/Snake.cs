using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Snake : MonoBehaviour {

	Vector2 di = Vector2.right;
	List<Transform> tail = new List<Transform>();
	bool ate = false;
	public GameObject TailPrefab;


	void Start () {
		InvokeRepeating("Move", 0.1f, 0.1f);
	}

	void Update () {
		if (Input.GetKey(KeyCode.RightArrow))
			di = Vector2.right;
		else if (Input.GetKey(KeyCode.DownArrow))
			di = -Vector2.up;
		else if (Input.GetKey(KeyCode.LeftArrow))
			di = -Vector2.right;
		else if (Input.GetKey(KeyCode.UpArrow))
			di = Vector2.up;
	}
	void Move() {
		transform.Translate(di);
		Vector2 v = transform.position;
		if (ate) {
			GameObject g =(GameObject)Instantiate(TailPrefab, v, Quaternion.identity);

			tail.Insert(0, g.transform);

			ate = false;
		}

		else if (tail.Count > 0) {
			tail.Last().position = v;

			tail.Insert(0, tail.Last());
			tail.RemoveAt(tail.Count-1); 
		}
	}
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.name.StartsWith("RatPrefab")) {
				ate = true;
				Destroy(coll.gameObject);
		}
		else if (coll.name.StartsWith("TailPrefab")) {
			Invoke("Load",0);
		}
		else {
			Invoke("Load",0);
		}
		}
	public void Load (){
		Application.LoadLevel("Snake");
	}

}
