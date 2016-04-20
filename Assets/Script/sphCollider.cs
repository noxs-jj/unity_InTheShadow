using UnityEngine;
using System.Collections;

public class sphCollider : MonoBehaviour {
	public static int	idSphere = 0;

	private GameObject	managerObject;
	private gameManager managerScript;
	private int			idCurrent;

	void Start () {
		this.idCurrent = idSphere;
		idSphere++;
		this.managerObject = GameObject.Find ("game_manager_object");
		this.managerScript = this.managerObject.GetComponent<gameManager> ();
	}

	public int get_idCurrent(){ return this.idCurrent; }

	void OnTriggerEnter(Collider obj){
		this.managerScript.setActive (this.idCurrent);
		//Debug.Log("OnTriggerEnter setActive ID= " + this.idCurrent.ToString());
	}

	void OnTriggerExit(Collider obj){
		this.managerScript.setInactive (this.idCurrent);
		//Debug.Log("OnTriggerExit setInactive ID= " + this.idCurrent.ToString());
	}
}
