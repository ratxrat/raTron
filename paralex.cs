using UnityEngine;
using System.Collections;

public class paralex : MonoBehaviour {
	public Transform[] background;
	public float smoot =1f;
	private float[] paralexScale;
	private Transform cam;
	private Vector3 prevCam;

	void Awake(){
		cam = Camera.main.transform;
	}

	// Use this for initialization
	void Start () {
		prevCam = cam.position;
		paralexScale = new float[background.Length];
		for (int i = 0; i < background.Length; i++) {
			paralexScale [i] = background [i].position.z*-1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < background.Length; i++) {
			float para = prevCam.x - cam.position.x * paralexScale [i];

			float bgTargetX = background [i].position.x + para;

			Vector3 bgTargetPos = new Vector3 (bgTargetX, background [i].position.y, background [i].position.z);

			background [i].position = Vector3.Lerp (background[i].position,bgTargetPos,smoot*Time.deltaTime);


		}
		prevCam = cam.position;
	}
}
