using UnityEngine;
using System.Collections;

abstract public class ChessPiece : MonoBehaviour {

    //private string type;
    //private bool hasMoved;
    /*public ChessPiece(string name)
    {
        type = name.ToLower();
        hasMoved = false;
    }*/
	
    

    abstract public int[] moveDescription();

 
}
