using UnityEngine;
using System.Collections;

public class prespektip : MonoBehaviour {
	private Transform cam;
	public float speed;

	// Use this for initialization
	void Awake(){
		cam = Camera.main.transform;
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float camx = cam.position.x;
		

		transform.position = new Vector3 (-camx * speed,transform.position.y,transform.position.z);
	
	}
}
