using UnityEngine;
using System.Collections;

public class kaki : MonoBehaviour {
	public string nama;
	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "musuh") {
			col.enabled = false;
			col.gameObject.transform.Translate (new Vector3(0,3,0));


			nama = col.gameObject.name;
			Invoke ("hapus",5);
		}
	}
	void hapus(){
		Destroy (GameObject.Find(nama));
	}
}
