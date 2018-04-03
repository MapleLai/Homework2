using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using myGame;

public class View : MonoBehaviour {
	SSDirector ssdirector;
	int isOver = 0;
	// Use this for initialization
	void Start () {
		ssdirector = SSDirector.getInstance ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && isOver == 0) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				if (hit.transform.tag == "Priest" || hit.transform.tag == "Devil") {
					ssdirector.offBoat (hit.collider.gameObject);
					ssdirector.onBoat (hit.collider.gameObject);
				} else if (hit.transform.tag == "Boat") {
					ssdirector.moveBoat ();
					isOver = ssdirector.check ();
				}
			}
		}
	}

	void OnGUI(){
		if (isOver == 1) GUI.Label(new Rect(400,100,100,50),"You win！");
		if (isOver == -1) GUI.Label(new Rect(400,100,100,50),"You lose！");
	}
}
