using System.Collections;
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

        sellAmount.text = "$" + target.turretBlueprint.sellAmount;

        if(!target.isUpgraded) {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else {
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
        }
        
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
