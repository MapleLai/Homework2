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

		public void priestOnRightBank(){
			_model.priestOnRightBank ();
		}

		public void priestOnLeftBank(){
			_model.priestOnLeftBank ();
		}

		public void devilOnRightBank(){
			_model.devilOnRightBank ();
		}

		public void devilOnLeftBank(){
			_model.devilOnLeftBank ();
		}

		public void moveBoat(){
			_model.moveBoat ();
		}

		public void offBoatOnRight(){
			_model.priestOnRightBank ();
		}

		public void offBoatOnLeft(){
			_model.priestOnRightBank ();
		}
			
	}
}

public class Controler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
}
