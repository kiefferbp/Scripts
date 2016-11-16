using UnityEngine;
using System.Collections;

abstract public class ChessPiece : MonoBehaviour {
    private int[] moves;    // Each piece needs a move description

    abstract public int[] moveDescription();
}
