using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {

	private GameObject[]	tabColliderObject;

	private sphCollider[]	tabColliderScript;

	// Use this for initialization
	void Start () {
		this.tabColliderObject = GameObject.FindGameObjectsWithTag ("sphere_collider");
		this.tabColliderScript = new tabColliderScript[this.tabColliderObject.Length];
		foreach (GameObject sphereObject in this.tabColliderObject) {
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
