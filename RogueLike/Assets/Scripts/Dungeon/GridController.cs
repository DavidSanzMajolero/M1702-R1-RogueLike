using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public int offSetWidth = 6;
    public int offSetHeight = 7;
    public Room room;
    [System.Serializable]
    public struct Grid
    {
        public int columns;
        public int rows;
        public float verticalOffset;
        public float horizontalOffset;
    }
    public Grid grid;
    public GameObject gridTile;
    public List<Vector2> aviablePoints = new List<Vector2>();

    private void Awake()
    {
        room = GetComponentInParent<Room>();
        grid.columns = room.Width - offSetWidth; 
        grid.rows = room.Height - offSetHeight; 
        GenerateGrid();
    }
    public void GenerateGrid()
    {
        grid.verticalOffset += room.transform.localPosition.y;
        grid.verticalOffset += room.transform.localPosition.x;
        for (int y = 0; y < grid.rows; y++) 
        {
            for (int x = 0; x < grid.columns; x++)
            {
                GameObject go = Instantiate(gridTile, transform);
                go.GetComponent<Transform>().position = new Vector2(x - (grid.columns - grid.horizontalOffset), y - (grid.rows - grid.verticalOffset)); 
                go.name = "X: " + x + " Y: " + y;
                aviablePoints.Add(go.transform.position);
                go.SetActive(false);
            }
        }
        GetComponentInParent<ObjectRoomSpawner>().InitialiseObjectSpawning();
    }

}
