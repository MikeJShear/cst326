using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
         private GameObject turretToBuild;
     public GameObject standardTurretPrefab;
     public GameObject anotherTurretPrefab;
     public GameObject ultimateTurretPrefab;
     void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
        }
        instance = this;
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
}
