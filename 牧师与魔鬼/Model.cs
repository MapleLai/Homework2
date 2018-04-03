using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using myGame;

public class Model : MonoBehaviour {

	SSDirector ssDirector;
	Vector3 leftBank = new Vector3(-8,-2,0);
	Vector3 rightBank = new Vector3(8,-2,0);
	Vector3 rightBoat = new Vector3(3,-2,-1);
	Vector3 leftBoat = new Vector3(-3,-2,-1);
	Vector3[] rightPriestPosition = { new Vector3 (7, -1, -2), new Vector3 (7, -1, 0), new Vector3 (7, -1, 2) };
	Vector3[] leftPriestPosition = { new Vector3 (-7, -1, -2), new Vector3 (-7, -1, 0), new Vector3 (-7, -1, 2) };
	Vector3[] rightDevilPosition = { new Vector3 (9, -1, -2), new Vector3 (9, -1, 0), new Vector3 (9, -1, 2) };
	Vector3[] leftDevilPosition = { new Vector3 (-9, -1, -2), new Vector3 (-9, -1, 0), new Vector3 (-9, -1, 2) };
	GameObject [] rightPriest = new GameObject[3];
	GameObject [] leftPriest = new GameObject[3];
	GameObject [] rightDevil = new GameObject[3];
	GameObject [] leftDevil = new GameObject[3];
	GameObject[] passenger = new GameObject[2];
	GameObject boat;

	// Use this for initialization
	void Start () {
		ssDirector = SSDirector.getInstance ();
		ssDirector.setModel (this);

		Instantiate(Resources.Load("Prefabs/Bank"), leftBank, Quaternion.identity);  
		Instantiate(Resources.Load("Prefabs/Bank"), rightBank, Quaternion.identity);  
		boat = Instantiate(Resources.Load("Prefabs/Boat"), rightBoat, Quaternion.identity) as GameObject; 
		for (int i=0;i<3;i++)
			rightPriest[i] = Instantiate(Resources.Load("Prefabs/Priest"), rightPriestPosition[i], Quaternion.identity) as GameObject; 
		for (int i=0;i<3;i++)
			rightDevil[i] = Instantiate(Resources.Load("Prefabs/Devil"), rightDevilPosition[i], Quaternion.identity) as GameObject; 
	}
		

	public void onBoat(GameObject gameObject){
		int num = 0;
		for (int i = 0; i < 2; i++)
			if (passenger [i] != null)
				num++;
		if (num != 2 && gameObject != passenger[0] && gameObject != passenger[1]) {
			gameObject.transform.parent = boat.transform;
			if (passenger [0] == null) {
				gameObject.transform.localPosition = new Vector3 (0, 1, 0);
				passenger [0] = gameObject;
			} else {
				gameObject.transform.localPosition = new Vector3 (0, 2, 0);
				passenger [1] = gameObject;
			}
		}
	}

	public void offBoat(GameObject gameObject){
		for (int j = 0; j < 2; j++) {
			if (gameObject == passenger [j]) {
				gameObject.transform.parent = null;
				if (gameObject.tag == "Priest") {
					if (boat.transform.position == leftBoat) {
						for (int i = 0; i < 3; i++)
							if (leftPriest [i] == null) {
								leftPriest [i] = gameObject;
								gameObject.transform.localPosition = leftPriestPosition [i];
								break;
							}
					} 
					else {
						for (int i = 0; i < 3; i++)
							if (rightPriest [i] == null) {
								rightPriest [i] = gameObject;
								gameObject.transform.localPosition = rightPriestPosition [i];
								break;
							}
					}
				} 
				else {
					if (boat.transform.position == leftBoat) {
						for (int i = 0; i < 3; i++)
							if (leftDevil [i] == null) {
								leftDevil [i] = gameObject;
								gameObject.transform.position = leftDevilPosition [i];
								break;
							}
					} 
					else {
						for (int i = 0; i < 3; i++)
							if (rightDevil [i] == null) {
								rightDevil [i] = gameObject;
								gameObject.transform.position = rightDevilPosition [i];
								break;
							}
					}
				}
			}
		}
	}
		

	public void moveBoat(){
		int num = 0;
		for (int i = 0; i < 2; i++)
			if (passenger [i] != null)
				num++;
		if (num != 0) {
			if (boat.transform.position == rightBoat)
				boat.transform.position = leftBoat;
			else boat.transform.position = rightBoat;
		}			
	}

	public int check(){
		return 0;
	}


	// Update is called once per frame
	void Update () {
		
	}
}
