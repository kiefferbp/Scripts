using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Container class for the chess piece prefabs
 * Made to declutter inspector view 
 * */
[System.Serializable]
public class PiecePrefabs {
    public GameObject wBishop, wKing, wKnight, wPawn, wQueen, wRook,
        bBishop, bKing, bKnight, bPawn, bQueen, bRook;
}

public class GameController : MonoBehaviour {
    private const float VEC_ZERO = 0.0f;
    // Chess piece scaling 
    private const float SCALE_X = 0.7f;     
    private const float SCALE_Y = 0.3f;
    private const float SCALE_Z = 0.7f;

    public static GridSquare[,] grid = new GridSquare[8,8];
    public GameObject wPlayer, bPlayer;                         // Player Gameobjects
    public GameObject chessBoard;                               // Chess board Gameobjects
    public PiecePrefabs piecePrefabs;                          // Chess piece prefabs

    private Player whitePlayer, blackPlayer;                    // Player scripts 
    private List<GridSquare> whitePieces, blackPieces;          // Player pieces 
    private bool whiteTurn, moveMade;

    enum Column { A, B, C, D, E, F, G, H };                     // Enumerated Columns


    IEnumerator Start()
    {
        // Gets player script components 
        whitePlayer = wPlayer.GetComponent<Player>();
        blackPlayer = bPlayer.GetComponent<Player>();
        // Initialize lists 
        whitePieces = new List<GridSquare>();
        blackPieces = new List<GridSquare>();

        whiteTurn = true;   // White player always starts 
        moveMade = false;
  
        yield return new WaitForSeconds(0.01f);
        // Initialize pieces
        initializePieces();
        // Set white in play
        squaresInPlay(whitePieces);
        wPlayer.SetActive(true);
    }

    void Update()
    {
        if (moveMade)
            whiteTurn = !whiteTurn;
    }

    

    

    public List<GridSquare> getMoves(GridSquare g)
    {
        ChessPiece piece = g.getPiece();
        List<GridSquare> possibleMoves = new List<GridSquare>();

        int row = g.getRow();
        int col = g.getCol();
        int[] moveDescriptions = piece.moveDescription();


        GridSquare candidate; 

        if (piece is Pawn) {
            if(whitePlayer) {
                
            }

        }

        

        return possibleMoves;
    }

    public void makeMove(GridSquare from, GridSquare to)
    {

        /*bool whitePlayer = from.getPlayer().isWhitePlayer();
        if(to.getPlayer() != null) //attack
        {
            if (whitePlayer)
                blackPieces.Remove(to);
            else
                whitePieces.Remove(to);
        }
        to.setPlayer(from.getPlayer());
        to.setPiece(from.getPiece());
        //from.empty();
        if (whitePlayer)
        {
            whitePieces.Add(to);
            whiteTurn = false;
            bPlayer.SetActive(true);
        }
        else
        {
            blackPieces.Add(to);
            whiteTurn = true;
            wPlayer.SetActive(true);
        }*/
    }

    public bool boundaryCheck(int row, int col) {
        return row >= 0 && row <= 8 && col >= 0 && col <= 8;
    }

    public List<GridSquare> getPieces()
    {
        if (whiteTurn)
            return whitePieces;
        return blackPieces;
    }

    /*
     * Tells if it's white player's turn
     * */
    public bool isWhiteTurn()
    {
        return whiteTurn;
    }

    /*
     * Sets squares in or out of play - determines if they can be 
     * triggered or ignored. 
     * */
    public void squaresInPlay(List<GridSquare> squares)
    {
        foreach(GridSquare g in squares)
        {
            g.activate();
        }
    }

    public void squaresOutOfPlay(List<GridSquare> squares)
    {
        foreach (GridSquare g in squares)
        {
            g.deactivate();
        }
    }

    /*
     * Player ends turn 
     * */
    public void endTurn()
    {
        whiteTurn = !whiteTurn;
    }




    public void initializePieces() {
        GridSquare wSquare, bSquare;
        ChessPiece wPiece, bPiece;

        // Create pawns
        for (int i = 0; i < 8; i++) {
            wSquare = grid[6, i];
            bSquare = grid[1, i];
            wSquare.setPiece((Instantiate(piecePrefabs.wPawn, wSquare.transform) 
                as GameObject).GetComponent<ChessPiece>());     // Instantiate white pawn and set
            bSquare.setPiece((Instantiate(piecePrefabs.bPawn, bSquare.transform) 
                as GameObject).GetComponent<ChessPiece>());     // Instantiate black pawn and set
        }

        /*grid[0, 0].setPiece(new ChessPiece("rook"));
        grid[0, 7].setPiece(new ChessPiece("rook"));
        grid[7, 0].setPiece(new ChessPiece("rook"));
        grid[7, 7].setPiece(new ChessPiece("rook"));

        grid[0, 1].setPiece(new ChessPiece("knight"));
        grid[0, 6].setPiece(new ChessPiece("knight"));
        grid[7, 1].setPiece(new ChessPiece("knight"));
        grid[7, 6].setPiece(new ChessPiece("knight"));

        grid[0, 1].setPiece(new ChessPiece("knight"));
        grid[0, 6].setPiece(new ChessPiece("knight"));
        grid[7, 1].setPiece(new ChessPiece("knight"));
        grid[7, 6].setPiece(new ChessPiece("knight"));

        grid[0, 2].setPiece(new ChessPiece("bishop"));
        grid[0, 5].setPiece(new ChessPiece("bishop"));
        grid[7, 2].setPiece(new ChessPiece("bishop"));
        grid[7, 5].setPiece(new ChessPiece("bishop"));

        grid[0, 3].setPiece(new ChessPiece("queen"));
        grid[0, 4].setPiece(new ChessPiece("king"));
        grid[7, 3].setPiece(new ChessPiece("queen"));
        grid[7, 4].setPiece(new ChessPiece("king"));*/


        /*
         * Assign players and add pieces to lists
         * */
        for (int i = 0; i < 8; i++) {
            // Assign Players to squares
            //grid[0, i].setPlayer(blackPlayer); // not done
            grid[1, i].setPlayer(blackPlayer); // Pawns
            grid[6, i].setPlayer(whitePlayer); // Pawns
            //grid[7, i].setPlayer(whitePlayer); // not done
            // Add pieces to player lists
           // blackPieces.Add(grid[0, i]);
            blackPieces.Add(grid[1, i]);
            whitePieces.Add(grid[6, i]);
           // whitePieces.Add(grid[7, i]);
        }

        /*
         * Reset positions and re-scale
         * */
        for(int i = 0; i < whitePieces.Count; i++) {
            configureTransform(whitePieces[i].getPiece().gameObject.transform);
            configureTransform(blackPieces[i].getPiece().gameObject.transform);
        } 
    }

    /*
     * Zero's out the position and re-scales 
     * */
    public void configureTransform(Transform t) {
        t.localPosition = new Vector3(VEC_ZERO, VEC_ZERO, VEC_ZERO);
        t.localScale = new Vector3(SCALE_X, SCALE_Y, SCALE_Z);
    }
}
