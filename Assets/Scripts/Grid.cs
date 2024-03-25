using System;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int columns = 3;
    public int rows = 3;

    public int cellSize = 1;
    private void OnEnable()
    {
        ClickableObject.Reached += NewLvl;
    }

    private void NewLvl(int howMuchToRaise)
    {
        rows += howMuchToRaise;
    }

    private void OnDrawGizmos()
    {
        DrawGrid();
    }

    private void DrawGrid()
    {
        Gizmos.color = Color.blue;

        for (int x = 0; x < columns; x++)
        {
            for (int z = 0; z < rows; z++)
            {
                Vector3 topLeft = transform.position + new Vector3(x * cellSize, z * cellSize, 0f);
                Vector3 topRight = transform.position + new Vector3((x + 1) * cellSize, z * cellSize, 0f);
                Vector3 bottomLeft = transform.position + new Vector3(x * cellSize, (z + 1) * cellSize, 0f);
                Vector3 bottomRight = transform.position + new Vector3((x + 1) * cellSize, (z + 1) * cellSize, 0f);

                Debug.DrawLine(topLeft, topRight);
                Debug.DrawLine(topRight, bottomRight);
                Debug.DrawLine(bottomRight, bottomLeft);
                Debug.DrawLine(bottomLeft, topLeft);
            }
        }
    }
    private void OnDisable()
    {
        ClickableObject.Reached -= NewLvl;
    }
}
