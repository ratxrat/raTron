using UnityEngine;
using System.Collections;

public class kontak_lip : MonoBehaviour {

	public int move = 0;
	private kontrol kon;
	public GameObject lip;
	public GameObject player;
	Animator anim;
	private triger_lip lipp;

	void Start(){
		kon = player.gameObject.GetComponent<kontrol> ();
		lipp = lip.GetComponent<triger_lip> ();
		anim = GetComponent<Animator> ();
	
	}
	void Update(){
		lipp.maju = move;
		if (move == 1) {
			anim.SetBool ("on", true);
		} else {
			anim.SetBool ("on", false);
		}
	}
	void OnTriggerEnter2D(Collider2D col){
		
		if (col.tag == "Player"){
			kon.btn_name = gameObject.name;
			kon.deketBtn = 1;
			Debug.Log ("deket kontak nama; " + gameObject.name);

		}
	}

		
	}
