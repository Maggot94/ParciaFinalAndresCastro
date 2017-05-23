using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Nave : MonoBehaviour {
	
	[SerializeField]
	public float speed = 1.5f;
	public float aceleration = 2f;
	private Vector3 target; 
	public int ItemTotal = 30;
	public Text ItemCount;
	public Text WinText;

	public CrystalSpawner Cs; 

	// Use this for initialization
	void Start () {
		target = transform.position;
		SetItemScore ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown (0)) {

			target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			target.z = transform.position.z;
		}

		transform.position = Vector3.MoveTowards (transform.position, target, (speed * Time.deltaTime)* aceleration);
	}

	void OnCollisionEnter2D (Collision2D coll){

		if (coll.gameObject.tag == "Item") {

			Cs.AnotherOne = true; 
			ItemTotal--;
			Destroy (coll.gameObject);
			SetItemScore ();
		}

	}

	void SetItemScore(){
		ItemCount.text = "Total Restantes: " + ItemTotal.ToString();

		if (ItemTotal <= 0) {

			WinText.gameObject.SetActive (true); 
			Cs.AnotherOne = false; 
		}
	}
}
