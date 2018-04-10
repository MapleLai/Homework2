using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using myGame;

namespace myGame{
	public class SSDirector: System.Object{
		
		private static SSDirector _instance;
		private Model _model;

		public static SSDirector getInstance(){
			if (_instance == null)
				_instance = new SSDirector ();
			return _instance;
		}

		public Model getModel(){
			return _model;
		}

		internal void setModel(Model model){
			_model = model;
		}

		public void moveBoat(){
			_model.moveBoat ();
		}

		public void onBoat(GameObject gameObject){
			_model.onBoat (gameObject);
		}

		public bool offBoat(GameObject gameObject){
			return _model.offBoat (gameObject);
		}
			
		public int checkWin(){
			return _model.checkWin ();
		}

		public int checkLose(){
			return _model.checkLose ();
		}
	}
}

public class Controler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
}
