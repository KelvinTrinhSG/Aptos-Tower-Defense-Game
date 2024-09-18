using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; private set; }

    public event EventHandler OnResourceAmountChanged;

    [SerializeField] private List<ResourceAmount> startingResourceAmountList;

    private Dictionary<ResourceTypeSO, int> resourceAmountDictionary;
    private void Awake()
    {
        Instance = this;

        resourceAmountDictionary = new Dictionary<ResourceTypeSO, int>();

        ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);

        foreach (ResourceTypeSO resourceType in resourceTypeList.list) {
            resourceAmountDictionary[resourceType] = 0;
        }

        foreach (ResourceAmount resourceAmount in startingResourceAmountList) {
            Debug.Log(resourceAmount.resourceType.nameString);
            if (resourceAmount.resourceType.nameString == "Wood") {
                AddResource(resourceAmount.resourceType, ResourceBoost.Instance.woodBoost + 100 * (ResourceBoost.Instance.resourceBoost - 1));
            }
            else if (resourceAmount.resourceType.nameString == "Stone") {
                AddResource(resourceAmount.resourceType, ResourceBoost.Instance.stoneBoost + 100 * (ResourceBoost.Instance.resourceBoost - 1));
            }
            else if (resourceAmount.resourceType.nameString == "Gold")
            {
                AddResource(resourceAmount.resourceType, ResourceBoost.Instance.goldBoost + 100 * (ResourceBoost.Instance.resourceBoost - 1));
            }
        }
    }
    private void TestLogResourceAmountDictionary()
    {
        foreach (ResourceTypeSO resourceType in resourceAmountDictionary.Keys)
        {
            Debug.Log(resourceType.nameString + ": " + resourceAmountDictionary[resourceType]);
        }
    }

    public void AddResource(ResourceTypeSO resourceType, int amount) {
        resourceAmountDictionary[resourceType] += amount;

        OnResourceAmountChanged?.Invoke(this, EventArgs.Empty);

        
    }

    public int GetResourceAmount(ResourceTypeSO resourceType) {
        return resourceAmountDictionary[resourceType];
    }

    public bool CanAfford(ResourceAmount[] resourceAmountArray) {
        foreach (ResourceAmount resourceAmount in resourceAmountArray) {
            if (GetResourceAmount(resourceAmount.resourceType) >= resourceAmount.amount)
            {

            }
            else {
                return false;
            }            
        }
        return true;
    }

    public void SpendResources(ResourceAmount[] resourceAmountArray)
    {
        foreach (ResourceAmount resourceAmount in resourceAmountArray)
        {
            resourceAmountDictionary[resourceAmount.resourceType] -= resourceAmount.amount;
        }
    }
}
