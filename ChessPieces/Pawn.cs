using UnityEngine;
using System.Collections;

public class Pawn : ChessPiece {

    private bool openingMove;
    private int[] openingMoves;
    private int[] moves;
	void Start () {
        openingMove = true;
        openingMoves = new int[4] { 0, 1, 0, 2 };
        moves = new int[2] { 0, 1 };
    }
	

	void Update () {
	    
	}

    override public int[] moveDescription() {
        if(openingMove) {
            openingMove = false;
            return openingMoves;
        }
        return moves;
    }
}
