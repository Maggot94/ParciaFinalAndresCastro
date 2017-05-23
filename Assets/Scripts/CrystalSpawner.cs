using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSpawner : MonoBehaviour {


	public GameObject Crystal; 
	public GameObject Transform;

	public Vector3 RandomPos;

	public int a ;
	public int b; 
	public int c = 0; 

	public bool AnotherOne = false;

	// Use this for initialization
	void Start () {

		a = Random.Range (-7, 8);
		b = Random.Range (-4, 5);
		RandomPos = new Vector3 (a, b, c); 

		Transform.transform.position = RandomPos; 
		Instantiate (Crystal, Transform.transform.position , Transform.transform.rotation);  
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (AnotherOne == true) {
			
			a = Random.Range (-7, 8);
			b = Random.Range (-4, 5);
			RandomPos = new Vector3 (a, b, c); 
			Transform.transform.position = RandomPos; 
			Instantiate (Crystal, Transform.transform.position , Transform.transform.rotation);  
			AnotherOne = false; 
		}
	}
}
