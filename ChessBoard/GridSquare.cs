using UnityEngine;
using System.Collections;

public class GridSquare : MonoBehaviour {

    private Player player;
    private ChessPiece piece;
    private bool trigger, isActive;
    private int row, col;
    private Color c;

    private Renderer rn;

    void Start()
    {
        rn = GetComponent<Renderer>();
        player = null;
        piece = null;
        trigger = false;
        isActive = false;
        row = -1; col = -1;
        c = rn.material.color;
    }

    public void setActive(bool active)
    {
        isActive = active;
    }

    public void empty()
    {
        player = null;
        piece = null;
        trigger = false;
        isActive = false;
    }

    public bool active()
    {
        return isActive;
    }

    public void triggerSquare()
    {

        trigger = !trigger;
    }

    public bool isTriggered()
    {
        return trigger;
    }






    /// <summary>
    /// Handles square colors for making moves
    /// Mark open moves - squares without enemy pieces
    /// Mark attack moves - squares with enemy pieces
    /// Reset - reset square color after a move is made
    /// </summary>
    
    public void markOpenPath()
    {
        rn.material.color = Color.green;
    }

    public void markEnemy()
    {
        rn.material.color = Color.red;
    }

    public void resetColor()
    {
        rn.material.color = c;
    }

    void OnMouseDown()
    {
        if (isActive)
            triggerSquare();
    }

    public void setCor(int row, int col)
    {
        this.row = row;
        this.col = col;
    }

    public int getRow()
    {
        return row;
    }

    public int getCol()
    {
        return col;
    }

    public Player getPlayer() { return player; }

    public ChessPiece getPiece() { return piece; }

    public void setPlayer(Player player)
    {
        this.player = player;
    }

    public void setPiece(ChessPiece piece)
    {
        this.piece = piece;
    }

}
