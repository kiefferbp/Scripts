using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
    public GameController controller;
    public bool whitePlayer;

    private bool makingMove, newTurn;
    private List<GridSquare> pieces, moves;

    void Start()
    {
        makingMove = false;
        newTurn = true;
        pieces = null;
        moves = null;
        gameObject.SetActive(false);
    }

    void Update()
    {
        if(myTurn())
        {
            GridSquare from = null;
            if (!makingMove)
            {
                if(newTurn)
                {
                    pieces = controller.getPieces(this);
                    newTurn = false;
                } // optimization

                
                foreach (GridSquare g in pieces)
                {

                    if (g.isTriggered())
                    {
                        from = g;
                        moves = controller.getMoves(g);
                        makingMove = true;
                        foreach (GridSquare k in pieces)
                        {
                            k.setActive(false);
                        }
                        break;
                    }

                }
            }
            else
            {
                foreach (GridSquare g in moves)
                {
                    if (g.isTriggered())
                    {
                        controller.makeMove(from, g);
                    }
                }
                makingMove = true;
                newTurn = true;
                gameObject.SetActive(false);
            }
        }
    }

    public bool isWhitePlayer()
    {
        return whitePlayer;
    }

    public bool myTurn()
    {
        return controller.isWhiteTurn() && whitePlayer ||
            !controller.isWhiteTurn() && !whitePlayer;
    }
}
