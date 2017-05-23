using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private Transform target ; 
	public float speed = 1f;
	public float PatrolSpeed = 0.5f;

	public int a;
	public int b;

	public int c;
	public int d; 

	public Vector3 RandomPosi;
	public Vector3 RandomPosF; 

	public float ChangeDirection = 4f; 
	public float ChangeDirection2 = 4f; 

	public bool Change = false;
	public bool Change2 = true;
	// Use this for initialization
	void Start () {
		
		a = Random.Range (-7, 8);
		b = Random.Range (-4, 5);
		RandomPosi = new Vector3 (a, b, 0);

		c = Random.Range (-7, 8);
		d = Random.Range (-4, 5);
		RandomPosF = new Vector3 (c, d, 0);


	}
	
	// Update is called once per frame
	void Update () {

		if (Change2 == true) {
			ChangeDirection -= Time.deltaTime; 
			transform.position = Vector3.MoveTowards (transform.position, RandomPosF,  PatrolSpeed * Time.deltaTime);

			if (ChangeDirection <= 0) {
				
				Change = true; 
				ChangeDirection2 = 4f; 
				Change2 = false;
			}
		}
			if (Change == true) {
			

				ChangeDirection2 -= Time.deltaTime;
			    transform.position = Vector3.MoveTowards (transform.position, RandomPosi, PatrolSpeed * Time.deltaTime);

				if (ChangeDirection2 <= 0) {

					
					Change = false;
					ChangeDirection = 4f;
				    Change2 = true;
				}
			}
		}

	void OnTriggerStay2D (Collider2D other)
	{
		target = other.gameObject.transform; 
		transform.LookAt (target.position);
		transform.Rotate (new Vector3 (0, -90, 0), Space.Self);
		transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
	}

	void OnCollisionEnter2D (Collision2D other){
		if (other.gameObject.tag == "Player") {

			Destroy (other.gameObject); 
		}
	}

}
