using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class kontrol : MonoBehaviour {

	public float speed = 30;
	public float speedTangga;
	public float ngajol = 50;
	bool ditaneh = true;
	int maju = 0;
	int btn_tangga =0;

	bool ditangga = false;

	float ver;
	//public float waktu;

	public Rigidbody2D rb;

	private Animator anim;
	private kontak_lip kon;


	public string btn_name;


	public int deketBtn = 0;
	public static int kenaMusuh = 0;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rb = GetComponent <Rigidbody2D> ();


	}
	
	// Update is called once per frame
	void Update () {
		ver = Input.GetAxis ("Horizontal");
		if (ver > 0) {
			kanan ();

		} else if (ver < 0) {
			kiri ();
		} else {
			anim.SetFloat ("walk", 0f);
		}
		if(kenaMusuh == 0){
			if (maju < 0) {
				gameObject.transform.Translate (new Vector3 (-speed * Time.deltaTime, 0, 0));
				gameObject.transform.localScale = new Vector3 (-1f, 1f, 01f);
				anim.SetFloat ("walk", 1f);
			}
			else if (maju > 0) {
				gameObject.transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
				gameObject.transform.localScale = new Vector3 (1f, 1f, 1f);
				anim.SetFloat ("walk", 1f);
			} else{
				gameObject.transform.Translate (new Vector3 (0, 0, 0));
				anim.SetFloat ("walk", 0f);
			}
		}
		// naek tangga

			if (btn_tangga == 1) {
				rb.gravityScale = 0;
				transform.Translate (new Vector3 (0, speedTangga, 0));
			} 
		else if (btn_tangga == -1) {
				rb.gravityScale = 0;
				transform.Translate (new Vector3 (0, speedTangga * -1f, 0));
			} else {
				transform.Translate (new Vector3 (0, 0, 0));
			}

		if (Input.GetKeyDown (KeyCode.J)) {
			gameManager.nyawa += 1;
		
		}
		

	}
	void FixedUpdate(){
		if (ditaneh) {
			
			if (Input.GetButtonDown ("Jump")) {
				jump ();
			}
		}
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "ground") {
			
			anim.SetBool ("jump", false);
			ditaneh = true;
		}
		if (col.tag == "tangga"){
			ditangga = true;
		}
		if (col.tag == "koin"){
			gameManager.koin += 1;
			Destroy (col.gameObject);
		}
		if (col.tag == "konci"){
			gameManager.konci += 1;
			Destroy (col.gameObject);
		}
		if (col.tag == "panto") {
			if (gameManager.konci == gameManager.needKey){
				gameManager.beres = 1;
			}
			else{
				gameManager.konci_kurang = 1;
			}
		}
		if(col.tag == "jebakan"){
			gameObject.SetActive(false);
			gameManager.paeh = 1;
		}


	}
	void OnTriggerStay2D(Collider2D col){
		if (col.tag == "ground") {

			anim.SetBool ("jump", false);
			ditaneh = true;
		}
		if (col.tag == "tangga"){
			ditangga = true;
		}
	}
	void OnTriggerExit2D(Collider2D col){
		if (col.tag == "ground") {
			anim.SetBool ("jump",true);
			ditaneh = false;
		}
		if (col.tag == "tangga"){
			ditangga = false;
			rb.gravityScale = 1f;

		}
		if (col.tag == "panto") {
			gameManager.konci_kurang = 0;
		}
	
	}

	//custom function
	public void kanan(){
		gameObject.transform.Translate (new Vector3 (speed*Time.deltaTime,0,0));
		gameObject.transform.localScale = new Vector3 (1f,1f,1f);
		anim.SetFloat ("walk", 1f);
	}
	public void kiri(){
		gameObject.transform.Translate (new Vector3 (-speed*Time.deltaTime,0,0));
		gameObject.transform.localScale = new Vector3 (-1f,1f,1f);
		anim.SetFloat ("walk", 1f);
	}
	public void jump(){
		//gameObject.transform.Translate (new Vector3.le0,ngajol*Time.deltaTime,0);
		//Vector3 posisi = transform.position;
		//transform.position = Vector3.Lerp(posisi,new Vector3(transform.position.x, transform.position.y * ngajol, transform.position.z),waktu);
		if (ditaneh) {
			rb.AddRelativeForce (transform.up * ngajol);
		}
	}
	public void kiri_down(){
		
		//maju_kiri = true;
		maju = -1;
	}

	public void kanan_down(){
		//maju_kanan = true;
		maju = 1;
	}
	public void maju_up(){
		//maju_kanan = false;
		//maju_kiri = false;
		maju = 0;
	}
	public void naekTangga_down(){
		if (ditangga) {
			btn_tangga = 1;
		}
	}
	public void turunTangga_down(){
		if (ditangga) {
			btn_tangga = -1;
		}
	}
	public void tangga_up(){
		btn_tangga = 0;
		rb.gravityScale = 1;
	}
	public void button_up()
	{
		if (deketBtn == 1)
		{
			kon = GameObject.Find (btn_name).GetComponent<kontak_lip> ();
			kon.move = 1;
		}
	}
}
