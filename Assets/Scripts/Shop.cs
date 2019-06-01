using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    
    BuildManager buildManager;

    void Start () {
        buildManager = BuildManager.instance;
    }

    public void PurchaseStandardTurret() {
        Debug.Log("Standard Turret purchased.");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void PurchaseAnotherTurret() {
        Debug.Log("Another Turret purchased.");
        buildManager.SetTurretToBuild(buildManager.anotherTurretPrefab);
    }

}
