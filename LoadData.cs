using UnityEngine;
using System.Collections;
using System.IO;
using LitJson;
using System.Collections.Generic;

namespace Baca{ 
public class LoadData : MonoBehaviour {
	private  JsonData bacaData;
	private  string dataPlayer;

	public static int darah;
	public static int nyawa;
	public static int koin;
		public static int levelBeres;
	// Use this for initialization
	void Awake (){
		dataPlayer = File.ReadAllText (Application.dataPath + "/playerData.json");
		bacaData = JsonMapper.ToObject (dataPlayer);
		darah = (int)bacaData ["darah"];
		nyawa = (int)bacaData ["nyawa"];
		koin = (int)bacaData ["koin"];
		
	}
		void Update(){
			level ();
		}
	
		public static void Load(string data){
			string _dataPlayer = File.ReadAllText (Application.dataPath + "/playerData.json");
			JsonData _bacaData = JsonMapper.ToObject (_dataPlayer);
			int hasil;
			if(data == "darah"){
				hasil = (int)_bacaData ["darah"];
				gameManager.darah = hasil;
			}
			if(data == "nyawa"){
				hasil = (int)_bacaData ["nyawa"];
				gameManager.nyawa = hasil;
			}
			if(data == "koin"){
				hasil = (int)_bacaData ["koin"];
				gameManager.koin = hasil;
			}

		}
		void level(){
			TextAsset texLevel = Resources.Load ("level") as TextAsset;
			string _dataPlayer = texLevel.ToString ();
			JsonData _bacaData = JsonMapper.ToObject (_dataPlayer);
			levelBeres = (int)_bacaData ["level"];
		
		}
	

}
}
