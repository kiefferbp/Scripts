using UnityEngine;
using System.Collections;

public class ChessPiece : MonoBehaviour {

    private string type;
    private bool hasMoved;
    public ChessPiece(string name)
    {
        type = name.ToLower();
        hasMoved = false;
    }
	
    public void movePiece()
    {
        hasMoved = true;
    }

    public bool firstMove()
    {
        return !hasMoved;
    }

 
}
