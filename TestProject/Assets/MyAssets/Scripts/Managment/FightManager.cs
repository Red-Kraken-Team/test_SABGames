using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    [Min(2)]
    [SerializeField] int unitCount = 2;
    [SerializeField] private GameObject unitPrefab;
    private List<GameObject> allUnits = new List<GameObject>();
    private MapManager mapManager;

    public void StartFight()
    {
        List<GameObject> copy = new List<GameObject>(allUnits);
        while(copy.Count > 1)
        {
            FindNearest(copy[0], ref copy);
        }
    }

    private void Start()
    {
        InitializeComponents();
        InstantiateUnits();
    }

    private void InitializeComponents()
    {
        if (TryGetComponent(out MapManager mm))
            mapManager = mm;
        else
            mapManager = FindObjectOfType<MapManager>();
    }

    private void InstantiateUnits()
    {
        for(int i = 0; i < unitCount; i++)
        {
            InstantiateUnit();
        }
    }

    private void InstantiateUnit()
    {
        GameObject unit = Instantiate(unitPrefab, GetRandomPosition(), Quaternion.identity);
        allUnits.Add(unit);
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 newPos = new Vector3(GetRandomFloat(mapManager.GetBordersSide()), 0, GetRandomFloat(mapManager.GetBordersUpDown()));
        return newPos;
    }
    
    private float GetRandomFloat(Vector2 random)
    {
        return Random.Range(random.x, random.y);
    }

    private void FindNearest(GameObject start, ref List<GameObject> allTargets)
    {
        float dist = 100000;
        GameObject go = null;
        foreach(GameObject target in allTargets)
        {
            float currentDist = (target.transform.position - start.transform.position).magnitude;
            if (currentDist < dist && currentDist > 0)
            {
                go = target;
                dist = currentDist;
            }
        }
        start.SendMessage("SetTarget", go.transform);
        go.SendMessage("SetTarget", start.transform);
        allTargets.Remove(start);
        allTargets.Remove(go);
    }
}
