using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class musuh : MonoBehaviour {
	
	public float speed = -1.5f;
	Rigidbody2D rb;
	GameObject player;
	public float force;
	//Animator p_anim;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("player");
		//p_anim = player.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3(speed*Time.deltaTime,0,0));
	}
	void OnTriggerEnter2D(Collider2D col){
		

			if (col.tag == "poina") {
				speed = 1.5f;
			transform.localScale = new Vector2 (-1, 1);
			}
			if (col.tag == "poinb") {
				speed = -1.5f;
				
			transform.localScale = new Vector2 (1, 1);
			}
		if (col.gameObject.name == "badan") {
			



			rb = player.GetComponent<Rigidbody2D> ();
			rb.AddForce (new Vector2(-1f,2f) * force);
			Invoke ("hapus_anim",0.5f);
			kontrol.kenaMusuh = 1;
			gameManager.darah -= 1;

			
		}

		
	}

	void hapus_anim(){
		
		kontrol.kenaMusuh = 0;
	}

}
