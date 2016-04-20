using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class uiManager : MonoBehaviour {

	private GameObject	buttonClassicModeObject;
	private GameObject	buttonTestModeObject;
	private GameObject	panelLevelSelectObject;
	private GameObject	maskTeaPotObject;
	private GameObject	maskElephantObject;
	private GameObject	maskGlobeObject;
	private GameObject	maskTBonusObject;

	void Start () {
		this.buttonClassicModeObject = GameObject.Find ("button_classic_mode");
		this.buttonTestModeObject = GameObject.Find ("button_test_mode");
		this.panelLevelSelectObject = GameObject.Find ("panel_level_select");
		this.maskTeaPotObject = GameObject.Find ("mask_image_teaPot");
		this.maskElephantObject = GameObject.Find ("mask_image_elephant");
		this.maskGlobeObject = GameObject.Find ("mask_image_globe");
		this.maskTBonusObject = GameObject.Find ("mask_image_bonus");

		this.panelLevelSelectObject.SetActive (false);
	}
	
	void Update () {
	
	}

	public void activateTestPanelSelect(){ this.panelLevelSelectObject.SetActive (true); }
	public void desactivateTestPanelSelect(){ this.panelLevelSelectObject.SetActive (false); }
	public void activateClassicPanelSelect(){ this.panelLevelSelectObject.SetActive (true); }
	public void desactivateClassicPanelSelect(){ this.panelLevelSelectObject.SetActive (false); }
}
