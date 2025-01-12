using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;


public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;

    [HideInInspector]
    public GameObject turret;

    [HideInInspector]
    public TurretBlueprint turretBlueprint;

    [HideInInspector]
    public bool isUpgraded = false;

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
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
    void OnMouseDown()
    {

        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        if(turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }
        
        if(!buildManager.CanBuild)
        {
            return;
        }

        BuildTurret(buildManager.getTurretToBuild());
    }


    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money to nuild that turret");
            return;
        }

        PlayerStats.Money -= blueprint.cost;
        GameObject _turret = (GameObject)Instantiate(blueprint.prefab,GetBuildPosition(),Quaternion.identity);
        turret = _turret;
        turretBlueprint = blueprint;
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect,GetBuildPosition(),Quaternion.identity);
        Destroy(effect,5f);
        Debug.Log("Turret built! Money Remaining: " + PlayerStats.Money);
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money to nuild that turret");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;
        // get rid of old turret
        Destroy(turret);

        // build new one
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab,GetBuildPosition(),Quaternion.identity);
        turret = _turret;
        
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect,GetBuildPosition(),Quaternion.identity);
        Destroy(effect,5f);

        isUpgraded = true;

        Debug.Log("Turret upgraded Money Remaining: " + PlayerStats.Money);
    }

    void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if(!buildManager.CanBuild)
        {
            return;
        }

        if(buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }

        else
        {
        rend.material.color = notEnoughMoneyColor;
        }

    }

    void OnMouseExit()
    {
        rend.material.color = StartColor;
    }

    

}
