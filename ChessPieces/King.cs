using UnityEngine;
using System.Collections;

public class King : ChessPiece {
    private int[] moves;    // Move description after opening move

    void Start() {
        /*
         * 
         * */
        //Row Col
        moves = new int[4] { 2,  1,
                             1,  2};
    }

    override public int[] moveDescription() {
        return moves;
    }
}
