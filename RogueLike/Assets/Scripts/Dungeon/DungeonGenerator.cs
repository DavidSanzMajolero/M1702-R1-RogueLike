using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public DungeonGenerationData dungeonGenerationData;
    private List<Vector2Int> dungeonRooms;

    private void Start()
    {
        dungeonRooms = DungeonCrawlerController.GenerationDungeon(dungeonGenerationData);
        SpawnRooms(dungeonRooms);
    }

    private void SpawnRooms(IEnumerable<Vector2Int> rooms)
    {
        // Cargar la sala inicial
        RoomController.instance.LoadRoom("Start", 0, 0);

        // Selecciona una posición aleatoria para la sala "Shop"a
        Vector2Int shopPosition = rooms.OrderBy(x => Random.value).FirstOrDefault();

        foreach (Vector2Int roomLocation in rooms)
        {
            if (roomLocation == shopPosition)
            {
                RoomController.instance.LoadRoom("Shop", roomLocation.x, roomLocation.y);
            }
            else
            {
                string sceneName = "Empty" + (Random.Range(0, 2)); // Cambia entre salas vacías
                RoomController.instance.LoadRoom(sceneName, roomLocation.x, roomLocation.y);
            }
        }
    }
}
