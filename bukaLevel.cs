using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

public class bukaLevel : MonoBehaviour {
	public string level;
	public GameObject loading;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator buka(){
		AsyncOperation bukaScene = SceneManager.LoadSceneAsync (level);
		loading.gameObject.SetActive (true);
		yield return bukaScene;
	}

	public void playlevel(){
		
		StartCoroutine (buka ());

	}
}
