using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    public Unit Spawn(Unit unitPrefab, Transform location)
    {
        Unit newUnit = Instantiate(unitPrefab,
            location.position, location.rotation);
        return newUnit;
    }
}
