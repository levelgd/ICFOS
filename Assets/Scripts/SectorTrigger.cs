using UnityEngine;
using System.Collections;

public enum NextSector : int{
	none = -1,xPlus,xMinus,yPlus,yMinus,zPlus,zMinus
}

public class SectorTrigger : MonoBehaviour {

	public NextSector nextSector;
	// Use this for initialization
	/*void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}*/
}
