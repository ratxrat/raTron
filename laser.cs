using UnityEngine;
using System.Collections;

public class laser : MonoBehaviour {
	public float waktu;
	public GameObject PeluruLaser;
	int hurung = 0;
	public AudioSource suara;

	// Use this for initialization
	void Start () {

		Invoke ("Nembak", waktu);
	}
	void Nembak(){
		if (hurung == 0) {
			PeluruLaser.gameObject.SetActive (true);
			suara.Play ();
			hurung = 1;
		} else {
			PeluruLaser.gameObject.SetActive (false);
			hurung = 0;
		}
		Invoke ("Nembak", waktu);
	}
	void Update(){
		
	}
}
