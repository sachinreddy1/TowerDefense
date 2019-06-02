﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    BuildManager buildManager;

    void Start () {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret() {
        Debug.Log("Standard Turret purchased.");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher() {
        Debug.Log("Missile Launcher purchased.");
        buildManager.SelectTurretToBuild(missileLauncher);
    }

}
