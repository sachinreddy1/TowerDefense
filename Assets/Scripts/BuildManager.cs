﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;
    
    void Awake() {
        if (instance != null)
        {
            Debug.Log("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;
    public GameObject laserBeamerPrefab;

    public GameObject buildEffect;
    public GameObject sellEffect;
    public GameObject destroyEffect;

    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    public NodeUI nodeUI;

    public bool CanBuild { get { return turretToBuild != null; } }

    public TurretBlueprint GetTurretToBuild() { return turretToBuild; }

    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.costs[0]; } }

    public void SelectNode (Node node) {

        if (selectedNode == node) {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode() {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild(TurretBlueprint turret) {
        turretToBuild = turret;
        DeselectNode();
    }
}
