using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Baca;
using LitJson;
using System.IO;

public class PilihLevel : MonoBehaviour {
	public GameObject[] levelHalang;
	int levelBeres;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//TextAsset texLevel = Resources.Load ("level") as TextAsset;
		//string _dataPlayer = texLevel.ToString ();
	

		string _dataPlayer = File.ReadAllText(Application.persistentDataPath + "/level.json");
		JsonData _bacaData = JsonMapper.ToObject (_dataPlayer);
		levelBeres = (int)_bacaData ["level"];

		for(int i = levelBeres; i < levelHalang.Length; i++  ){
			levelHalang [i].gameObject.SetActive (true);
		}	
	
	}
}
