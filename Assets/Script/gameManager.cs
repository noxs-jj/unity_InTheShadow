using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {
	private GameObject[]	tabColliderObject;
	private sphCollider[]	tabColliderScript;
	private bool[]			tabIsActive;
	public bool				isWin = false;

	void Start () {
		this.tabColliderObject = GameObject.FindGameObjectsWithTag ("sphere_collider");
		int i = 0;
		int tabLen = this.tabColliderObject.Length;
		Time.timeScale = 1.0f;
		
		this.tabColliderScript = new sphCollider[tabLen];
		foreach (GameObject sphereObject in this.tabColliderObject) {
			this.tabColliderScript[i] = sphereObject.GetComponent<sphCollider>();
		}
		this.tabIsActive = new bool[tabLen];
		while (i < tabLen) {
			this.tabIsActive[i] = false;
			i++;
		}
	}
	
	void Update () {
		keyboard_event ();
		if (true == check_collider_win() && Application.loadedLevelName != "intro_start") {
			Time.timeScale = 0.0f;
			sphCollider.instance.reset_static_id();
			this.isWin = true;
		}
	}

	public void	setActive(int id){ this.tabIsActive [id] = true; }
	
	public void	setInactive(int id) { this.tabIsActive [id] = false; }

	private bool check_collider_win(){
		bool isAllTrue = true;

		foreach (bool isactive in this.tabIsActive) {
			if (isactive == false) {
				isAllTrue = false;
			}
		}
		return isAllTrue;
	}
	
	private void keyboard_event(){
		if (Input.GetKeyDown (KeyCode.S)) {
			debug_printSphereTabId();
		}
		if (Input.GetKeyDown (KeyCode.Q)) {
			Application.Quit();
		}
	}
	
	private void debug_printSphereTabId() {
		foreach(sphCollider scriptObj in this.tabColliderScript) {
			Debug.Log("sphereID = " + scriptObj.get_idCurrent());
		}
	}
	
	private void loadNextLevel(){
		if (Application.loadedLevelName == "intro_start"){
			sphCollider.instance.reset_static_id();
			Application.LoadLevel ("scene_item_teaPot");
		} else if (Application.loadedLevelName == "scene_item_teaPot"){
			sphCollider.instance.reset_static_id();
			Application.LoadLevel ("scene_elephant");
		} else if (Application.loadedLevelName == "scene_elephant"){
			sphCollider.instance.reset_static_id();
			Application.LoadLevel ("scene_globe");
		} else if (Application.loadedLevelName == "scene_globe"){
			sphCollider.instance.reset_static_id();
			Application.LoadLevel ("scene_bonus");
		} else if (Application.loadedLevelName == "scene_bonus"){
			sphCollider.instance.reset_static_id();
			Application.LoadLevel ("scene_bonus1");
		} else if (Application.loadedLevelName == "scene_bonus1"){
			sphCollider.instance.reset_static_id();
			Application.LoadLevel ("intro_start");
		}
	}
}
