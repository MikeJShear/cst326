using Unity.VisualScripting;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
     public GameObject buildEffect;
     private TurretBlueprint turretToBuild;
     
     private Node selectedNode;
    public nodeUI nodeUI;

     void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
        }
        instance = this;
    }

    public bool CanBuild{get { return turretToBuild != null;}}
    public bool HasMoney{get { return PlayerStats.Money >= turretToBuild.cost;}}


    public void SelectNode (Node node)
	{
		

        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
		turretToBuild = null;

        if (node.turret != null)
        {
		    nodeUI.SetTarget(node);
        }

	}



    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
       
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public TurretBlueprint getTurretToBuild()
    {
        return turretToBuild;
    }
}
