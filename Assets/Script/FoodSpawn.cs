using UnityEngine;
using System.Collections;

public class FoodSpawn : MonoBehaviour {

	public GameObject RatPrefab;

	public Transform RightRim;
	public Transform LeftRim;
	public Transform BottomRim;
	public Transform TopRim;

	void Start () {
		InvokeRepeating("Spawn", 2, 4);
	}
	void Spawn(){

		int x = (int)Random.Range( LeftRim.position.x, RightRim.position.x);
		int y = (int)Random.Range( BottomRim.position.y, TopRim.position.y);
		Instantiate(RatPrefab, new Vector2(x, y), Quaternion.identity);
	}
}
