using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public int x;
    public int y;
    public Board board;

    public void Setup(int x_, int y_, Board board_)
    {
        x = x_;
        y = y_;
        board = board_;
    }

    public void MovePiece(int newX, int newY)
    {
        // Verifica si la nueva posicion es valida en la cuadricula.
        if (board.IsValidPosition(newX, newY))
        {
            x = newX;
            y = newY;
            // Actualiza la posicion del objeto en Unity.
            Vector3 newPosition = new Vector3(x, y, transform.position.z);
            transform.position = newPosition;
        }
    }
}
