using UnityEngine;
using System.Collections;

public class triger_lip : MonoBehaviour {
	public bool arahX = false;
	public bool arahY = false;
	public GameObject[] posisi;
	public int maju = 0;
	public int noAntrian = 0;

	public float waktu;

	void Update(){
		if (noAntrian >= posisi.Length) {
			noAntrian = 0;
		}
		if (maju == 1) {
			transform.position = Vector3.Lerp (transform.position, posisi [noAntrian].transform.position , waktu);
		}	
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "triger") {
			noAntrian += 1;
		}
	
	}

}
