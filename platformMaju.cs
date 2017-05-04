using UnityEngine;
using System.Collections;

public class platformMaju : MonoBehaviour {
	public GameObject poinA;
	public GameObject PoinB;
	public float speed;
	public bool naek = false;

	int kepoint=1;
	int mulai = 0;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (mulai == 1) {
			if (!naek) {
				if (kepoint == 1) {
					transform.Translate (speed * Time.deltaTime, 0, 0);
				} else {
					transform.Translate (-speed * Time.deltaTime, 0, 0);
				}	
			} else {
				if (kepoint == 1) {
					transform.Translate (0, speed * Time.deltaTime, 0);
				} else {
					transform.Translate (0, -speed * Time.deltaTime, 0, 0);
				}
			}
		}
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.name == poinA.gameObject.name) {
			kepoint = 1;
			Debug.Log ("Di A");
		}else if(col.gameObject.name == PoinB.gameObject.name){
			kepoint = 0;
			Debug.Log ("Di B");
		}
		if(col.tag == "Player"){
			mulai = 1;
			col.transform.parent = this.transform;
		}
	
	}
	void OnTriggerExit2D(Collider2D col){
		if(col.tag == "Player"){
			col.transform.parent = null;
		}
	}
}
