using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class uiManager : MonoBehaviour {
	private GameObject		buttonClassicModeObject;
	private GameObject		buttonTestModeObject;
	private GameObject		buttonBackIntroObject;
	private GameObject		menuInterfaceEscapeObject;
	private GameObject		panelLevelSelectObject;
	private GameObject[]	tabSphereObjects;
	private GameObject[]	tabBarObjects;
	private bool			isMenuDraw;
	private bool			isSoluceDraw = false;
	
	void Start () {
		this.buttonClassicModeObject = GameObject.Find ("button_classic_mode");
		this.buttonTestModeObject = GameObject.Find ("button_test_mode");
		this.buttonBackIntroObject = GameObject.Find ("button_back_to_intro");
		this.menuInterfaceEscapeObject = GameObject.Find ("menuInterface_escape");
		this.panelLevelSelectObject = GameObject.Find ("panel_level_select");
		this.tabBarObjects = GameObject.FindGameObjectsWithTag ("barre_impact_collider");
		this.tabSphereObjects = GameObject.FindGameObjectsWithTag ("sphere_collider");
		this.panelLevelSelectObject.SetActive (false);
		this.menuInterfaceEscapeObject.SetActive (true);
		soluce_draw();
		if (Application.loadedLevelName == "intro_start") {
			this.isMenuDraw = true;
			this.menuInterfaceEscapeObject.SetActive(true);
		} else {
			this.isMenuDraw = false;
			this.menuInterfaceEscapeObject.SetActive(this.isMenuDraw);
		}
	}
	
	void Update () {
		keyboard_event ();
	}
	
	public void activateTestPanelSelect(){ this.panelLevelSelectObject.SetActive (true); }
	public void desactivateTestPanelSelect(){ this.panelLevelSelectObject.SetActive (false); }
	public void activateClassicPanelSelect(){ this.panelLevelSelectObject.SetActive (true); }
	public void desactivateClassicPanelSelect(){ this.panelLevelSelectObject.SetActive (false); }
	
	public void launchLevelTeaPot(){ Application.LoadLevel ("scene_item_teaPot"); }
	public void launchLevelElephant(){ Application.LoadLevel ("scene_elephant"); }
	public void launchLevelGlobe(){ Application.LoadLevel ("scene_globe"); }
	public void launchLevelBonus(){ Application.LoadLevel ("scene_bonus"); }
	public void launchIntroStart(){ Application.LoadLevel ("intro_start"); }
	
	private void keyboard_event(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (Application.loadedLevelName == "intro_start") {
				this.menuInterfaceEscapeObject.SetActive(true);
				this.isMenuDraw = true;
			} else {
				this.isMenuDraw = (this.isMenuDraw == true) ? false : true;
				this.menuInterfaceEscapeObject.SetActive(this.isMenuDraw);
			}
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			this.isSoluceDraw = (this.isSoluceDraw == true) ? false : true;
			soluce_draw();
		}
	}

	private void soluce_draw(){
		if (true == this.isSoluceDraw) {
			foreach (GameObject obj in this.tabBarObjects) {
				obj.GetComponent<MeshRenderer> ().enabled = true;
			}
			foreach (GameObject obj in this.tabSphereObjects) {
				obj.GetComponent<MeshRenderer> ().enabled = true;
			}
		} else {
			foreach (GameObject obj in this.tabBarObjects) {
				obj.GetComponent<MeshRenderer> ().enabled = false;
			}
			foreach (GameObject obj in this.tabSphereObjects) {
				obj.GetComponent<MeshRenderer> ().enabled = false;
			}
		}
	}
}
