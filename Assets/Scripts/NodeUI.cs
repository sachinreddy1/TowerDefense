﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    private Node target;
    public GameObject ui;
    public Text upgradeCost;
    public Text sellAmount;
    public Button upgradeButton;

    public void SetTarget (Node node) {
        this.target = node;

        transform.position = target.GetBuildPosition();

        if(target.upgradeLevel != target.turretBlueprint.costs.Length-1) {
            upgradeCost.text = "$" + target.turretBlueprint.costs[target.upgradeLevel+1];
            upgradeButton.interactable = true;
        }
        else {
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
        }

        sellAmount.text = "$" + target.turretBlueprint.sellAmount;
        
        ui.SetActive(true);
    }

    public void Hide() {
        ui.SetActive(false);
    }

    public void Upgrade() {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell() {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
