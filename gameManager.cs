using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using LitJson;
using System.IO;
using UnityEngine.SceneManagement;
using Baca;

public class gameManager : MonoBehaviour {

	public Karakter _player;

	public static int koin ;
	public static int nyawa ;
	public static int darah ;
	public static int konci = 0;
	public static int needKey;
	public static int konci_kurang;
	public static int beres = 0;
	public static int paeh = 0;


	public int konciDibutuhkan;

	public Image ui_darah;
	public Image ui_nyawa;
	public Image ui_konci;
	public Image ui_koin1;
	public Image ui_koin2;

	public Text konciKurang;
	public GameObject uiGameOver;
	public GameObject uiFinish;
	public GameObject loading;

	public Sprite[] angka;
	//private Animator anim_konci;
	public AudioSource BackSound;
	public AudioSource GameOverSound;
	public AudioSource FinishSound;

	GameObject player;
	GameObject UiStats;
	JsonData playerData;

	int playGameOver = 0;
	int playfinish = 0;



	// Use this for initialization

	void Start () {
		//needKey = konciDibutuhkan;
		//anim_konci = konciKurang.gameObject.GetComponent<Animator> ();
		player = GameObject.Find ("player");
		UiStats = GameObject.Find ("Ui_status");
		LoadData.Load ("darah");
		LoadData.Load ("koin");
		LoadData.Load ("nyawa");

	}
	
	// Update is called once per frame
	void Update () {
		
		// ui koin
		/*string hasil_koin = "" + koin;
		string[] angka_koin = new string[hasil_koin.Length];
		for (int i = 0; i < hasil_koin.Length; i++)
		{
			angka_koin[i] = System.Convert.ToString(hasil_koin[i]);
		}

		if (angka_koin.Length == 1) {
			//tidie ui awalna 0
			int akhirnya = int.Parse (angka_koin [0]);
			ui_koin1.sprite = angka [0];
			ui_koin2.sprite = angka [akhirnya];
		} else {
		
			int akhirnya = int.Parse (angka_koin [0]);
			int akhirnya2 = int.Parse (angka_koin [1]);
			ui_koin1.sprite = angka [akhirnya];
			ui_koin2.sprite = angka [akhirnya2];
		}

		// ui darah
		ui_darah.sprite = angka[darah];
		if (darah > 5 ){
			darah = 5;
			ui_darah.sprite = angka[5];
		}
		// ui konci
		if(konci <= 9){
			ui_konci.sprite = angka [konci];
		}
		if(konci > 9){
			ui_konci.sprite = angka [9];
			
		}


		// UI nyawa
		if (nyawa <= 9) {
			ui_nyawa.sprite = angka [nyawa];
		}
		if (nyawa >= 9 ){
			nyawa = 9;
			ui_nyawa.sprite = angka [9];
		}*/
		/*if (konci_kurang == 1) {
			int kurangna = konciDibutuhkan - konci;
			konciKurang.text = "Kurang " + kurangna + " Kunci";
			anim_konci.SetBool ("aktif", true);
			anim_konci.SetInteger ("hide", 0);



			
		} else {
			anim_konci.SetInteger ("hide", 1);
			anim_konci.SetBool ("aktif", false);

		}*/
		if(beres == 1){			
			uiFinish.SetActive (true);
			string namaScene = SceneManager.GetActiveScene ().name;
			int beresss = int.Parse (namaScene); // 1+1 = 2
			string _dataPlayer = File.ReadAllText (Application.persistentDataPath + "/level.json");
			//string _dataPlayer = texLevel.ToString ();
			JsonData _bacaData = JsonMapper.ToObject (_dataPlayer);
			int levelBeres = (int)_bacaData ["level"]; // 3
			Debug.Log("level di save: "+levelBeres);
			Debug.Log("level ayena: "+beresss);
			Debug.Log (_dataPlayer);
			playfinish += 1;
			
			
		if (levelBeres <= beresss) {
				saveData.saveLevel (beresss + 1);
			}
			

			
		}

		// cek darah lamu 0 paeh
		if(paeh == 1){
			
			uiGameOver.SetActive (true);
			UiStats.SetActive (false);
			player.SetActive (false);
			playGameOver = 1;
			paeh = 0;		
			//nyawa -= 1;
			//darah = 3;
			//string namaScene = SceneManager.GetActiveScene ().name;
			//saveData.savePlayer (darah, koin, nyawa );
			//saveData.saveLevel (int.Parse(namaScene));

		}
	if (playGameOver == 1){
		GameOverSound.Play ();
			BackSound.Stop ();
			playGameOver = 0;
			
	}
	if (playfinish == 1){
			
			
			FinishSound.Play ();
			BackSound.Stop ();

	}
	}
	
	public void restart(){
		
		uiGameOver.SetActive (false);
		string namaScene = SceneManager.GetActiveScene ().name;
		SceneManager.LoadScene (namaScene);
		paeh = 0;
		beres = 0;
		
	}
	public void home(){
		paeh = 0;
		beres = 0;
		SceneManager.LoadScene ("pilihlevel");
		
	}
	IEnumerator buka(string level){
	AsyncOperation bukaScene = SceneManager.LoadSceneAsync (level);
	loading.gameObject.SetActive (true);
	yield return bukaScene;
	uiFinish.SetActive (false);

	}
	public void next(){
		string namaScene = SceneManager.GetActiveScene ().name;
		int nextLevel = int.Parse (namaScene) + 1;
		string selanjutnya = "" + nextLevel;
		Debug.Log (selanjutnya);
		paeh = 0;
		beres = 0;
		StartCoroutine (buka (selanjutnya));
	}

}

