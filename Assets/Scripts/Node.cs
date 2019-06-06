using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    //public bool isUpgraded = false;
    public int upgradeLevel = 0;

    private Renderer rend;
    private Color startColor;
    BuildManager buildManager;

    void Start () {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition() {
        return transform.position + positionOffset;
    }

    void OnMouseDown() {
        if(EventSystem.current.IsPointerOverGameObject()){
            return;
        }

        if (turret != null) {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild) {
            return;
        }

        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret (TurretBlueprint blueprint) {
        if (PlayerStats.Money < blueprint.costs[0])
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        PlayerStats.Money -= blueprint.costs[0];

        GameObject _turret = (GameObject)Instantiate(blueprint.prefabs[0], GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        upgradeLevel = 0;
        Debug.Log("Turret built!");
    }

    // public void UpgradeTurret() {
    //     if (PlayerStats.Money < turretBlueprint.upgradeCost)
    //     {
    //         Debug.Log("Not enough money to upgrade that!");
    //         return;
    //     }

    //     PlayerStats.Money -= turretBlueprint.upgradeCost;

    //     // Get rid of old turret
    //     Destroy(turret);
    //     // Build a new one
    //     GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
    //     turret = _turret;

    //     GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
    //     Destroy(effect, 5f);

    //     isUpgraded = true;

    //     Debug.Log("Turret upgraded!");
    // }

    public void UpgradeTurret() {
        
        if (PlayerStats.Money < turretBlueprint.costs[upgradeLevel+1])
        {
            Debug.Log("Not enough money to upgrade that!");
            return;
        }

        upgradeLevel++;
        
        PlayerStats.Money -= turretBlueprint.costs[upgradeLevel];

        // Get rid of old turret
        Destroy(turret);
        Debug.Log(upgradeLevel);
        // Build a new one
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.prefabs[upgradeLevel], GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret upgraded!");
    }

    public void SellTurret() {

        PlayerStats.Money += turretBlueprint.sellAmount;
        // Get rid of old turret
        Destroy(turret);
        turretBlueprint = null;

        GameObject sell_effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        GameObject destroy_effect = (GameObject)Instantiate(buildManager.destroyEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(sell_effect, 5f);
        Destroy(destroy_effect, 3f);

        upgradeLevel = 0;
        Debug.Log("Turret Sold!");
    }

    void OnMouseEnter() {
        if(EventSystem.current.IsPointerOverGameObject()){
            return;
        }

        if (!buildManager.CanBuild) {
            return;
        }

        if (buildManager.HasMoney) {
            rend.material.color = hoverColor;
        }
        else {
            rend.material.color = notEnoughMoneyColor;
        }
        
    }

    void OnMouseExit() {
        rend.material.color = startColor;
    }

}
