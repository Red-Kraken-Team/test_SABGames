using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] private Transform map;
    [SerializeField] private Vector2Int mapSize = new Vector2Int(2, 2);
    private Vector2 bordersSide;
    private Vector2 bordersUpDown;

    [ContextMenu("SetMapSize")]
    public void SetMapSize()
    {
        map.localScale = new Vector3(mapSize.x, map.localScale.y, mapSize.y);
        bordersSide = new Vector2(map.position.x - map.localScale.x/2, map.position.x + map.localScale.x/2);
        bordersUpDown = new Vector2(map.position.z - map.localScale.z/2, map.position.z + map.localScale.z/2);
    }

    public Vector2 GetBordersSide()
    {
        return bordersSide;
    }

    public Vector2 GetBordersUpDown()
    {
        return bordersUpDown;
    }

    private void Awake()
    {
        SetMapSize();
    }
}
