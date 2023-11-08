using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public int width;
    public int height;
    public GameObject tileObject;

    public float cameraSizeOffset;
    public float cameraVerticalOffset;

    private Piece[,] grid; // Utiliza una matriz de Pieces.

    void Start()
    {
        SetupBoard();
        PositionCamera();
    }

    private void PositionCamera()
    {
        float newPosX = 6f;
        float newPosY = 3.3f;
        Camera.main.transform.position = new Vector3(newPosX - 0.5f, newPosY - 0.5f + cameraVerticalOffset, -10f);
    }

    private void SetupBoard()
    {
        grid = new Piece[width, height]; // Inicializa la matriz.

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var o = Instantiate(tileObject, new Vector3(x, y, -5), Quaternion.identity);
                o.transform.parent = transform;
                o.GetComponent<Tile>()?.Setup(x, y, this);
            }
        }
    }

    public bool IsValidPosition(int newX, int newY)
    {
        // Verifica si la posición está dentro de la cuadrícula.
        if (newX >= 0 && newX < width && newY >= 0 && newY < height)
        {
            // Verifica si la posición no está ocupada por otra pieza.
            if (grid[newX, newY] == null)
            {
                return true;
            }
        }
        return false;
    }

    public void OccupyPosition(int x, int y, Piece piece)
    {
        // Marca la posición como ocupada por la pieza dada.
        grid[x, y] = piece;
    }

    public void VacatePosition(int x, int y)
    {
        // Marca la posición como desocupada.
        grid[x, y] = null;
    }

    void Update()
    {
        // Puedes agregar lógica adicional aquí si es necesario.
    }
}
 