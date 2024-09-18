using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingDemolishBtn : MonoBehaviour
{
    [SerializeField] private Building building;
    private void Awake()
    {
        transform.Find("button").GetComponent<Button>().onClick.AddListener(
            () => {
                BuildingTypeSO buildingType =  building.GetComponent<BuildingTypeHolder>().buildingType;
                foreach (ResourceAmount resrouceAmount in buildingType.contructionResourceCostArray) {
                    ResourceManager.Instance.AddResource(resrouceAmount.resourceType, Mathf.FloorToInt(resrouceAmount.amount * 0.6f));
                }
                Destroy(building.gameObject);

            }
            );
    }
}
