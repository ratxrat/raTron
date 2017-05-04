using UnityEngine;
using System.Collections;
using System.IO;
using LitJson;


public class saveData : MonoBehaviour {
	void Start(){
		
	}

	
	public static void savePlayer(int darah, int koin, int nyawa){
	Karakter player;
		JsonData playerData;
		player = new Karakter (darah,koin,nyawa);
		playerData = JsonMapper.ToJson (player);
		File.WriteAllText (Application.dataPath + "/playerData.json",playerData.ToString());
	}

	public static void saveLevel(int level){
		Level player;
		JsonData playerData;
		player = new Level (level);
		playerData = JsonMapper.ToJson (player);

		File.WriteAllText (Application.persistentDataPath + "/level.json",playerData.ToString());
	}


}

public class Karakter{
	public int darah;
	public int koin;
	public int nyawa;
	public int level;

	public Karakter(int darah, int koin,  int nyawa){
		this.darah = darah;
		this.koin = koin;
		this.nyawa = nyawa;	
		 
	}

}

public class Level{
	public int level;
	public Level(int level){
		this.level = level;	
	}
		
}