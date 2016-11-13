using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    public static GridSquare[,] grid = new GridSquare[8,8];

    public GameObject wPlayer, bPlayer;

    private Player whitePlayer, blackPlayer;
    private List<GridSquare> whitePieces, blackPieces;
    private bool whiteTurn, moveMade;

    IEnumerator Start()
    {
        whitePlayer = wPlayer.GetComponent<Player>();
        blackPlayer = bPlayer.GetComponent<Player>();

        whitePieces = new List<GridSquare>();
        blackPieces = new List<GridSquare>();

        whiteTurn = true;
        moveMade = false;

        yield return new WaitForSeconds(0.01f);

        initializePieces();
        for (int i = 0; i < 8; i++)
        {
            grid[0, i].setPlayer(blackPlayer);
            grid[1, i].setPlayer(blackPlayer);
            blackPieces.Add(grid[0, i]);
            blackPieces.Add(grid[0, i]);

            grid[6, i].setPlayer(whitePlayer);
            grid[7, i].setPlayer(whitePlayer);
            grid[6, i].setActive(true);
            grid[7, i].setActive(true);
            whitePieces.Add(grid[6, i]);
            whitePieces.Add(grid[7, i]);
        }
        wPlayer.SetActive(true);
    }

    void Update()
    {
        if (moveMade)
            whiteTurn = !whiteTurn;
    }

    

    

    public List<GridSquare> getMoves(GridSquare g)
    {
        List<GridSquare> possibleMoves = new List<GridSquare>();
        bool whitePlayer = g.getPlayer().isWhitePlayer();
        int row = g.getRow();
        int col = g.getCol();
        GridSquare check;

        if (whitePlayer)
            check = grid[row - 1, col];

        else
            check = grid[row + 1, col];

        if (check.getPlayer() == null)
        {
            possibleMoves.Add(check);
            check.markOpenPath();
        }
        else if (check.getPlayer() != g.getPlayer())
        {
            possibleMoves.Add(check);
            check.markEnemy();
        }
        else { }

        return possibleMoves;
    }

    public void makeMove(GridSquare from, GridSquare to)
    {
        bool whitePlayer = from.getPlayer().isWhitePlayer();
        if(to.getPlayer() != null) //attack
        {
            if (whitePlayer)
                blackPieces.Remove(to);
            else
                whitePieces.Remove(to);
        }
        to.setPlayer(from.getPlayer());
        to.setPiece(from.getPiece());
        from.empty();
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
        }
    }

    public List<GridSquare> getPieces(Player p)
    {
        if (p.isWhitePlayer())
            return whitePieces;
        return blackPieces;
    }

    public bool isWhiteTurn()
    {
        return whiteTurn;
    }

    public void initializePieces()
    {
        for (int i = 0; i < 8; i++)
        {
            grid[1, i].setPiece(new ChessPiece("pawn"));
            grid[6, i].setPiece(new ChessPiece("pawn"));
        }

        grid[0, 0].setPiece(new ChessPiece("rook"));
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
        grid[7, 4].setPiece(new ChessPiece("king"));
    }
}
