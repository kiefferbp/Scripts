using UnityEngine;
using System.Collections;

public class GameSetup : MonoBehaviour {

    private GridSquare[][] baord;
    private Player player;
	private int numPiecesLeft; 

    public GameSetup(GridSquare[][] board)
    {
        this.baord = board;
        numPiecesLeft = 32;

    }


    //public 




}
