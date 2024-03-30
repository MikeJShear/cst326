using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    private GameObject turret;
    private Renderer rend;
    private Color StartColor;
    public Vector3 positionOffset;
    BuildManager buildManager;
    void Start()
    {
        rend = GetComponent<Renderer>();
        StartColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    void OnMouseDown()
    {
        if(buildManager.GetTurretToBuild()== null)
        {
            return;
        }
        if(turret != null)
        {
            Debug.Log("Remove Existing Structure");
            return;
        }

        GameObject turretToBuild = buildManager.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild,transform.position + positionOffset,transform.rotation);
    }

    void OnMouseEnter()
    {
        if(buildManager.GetTurretToBuild()== null)
        {
            return;
        }
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = StartColor;
    }

}