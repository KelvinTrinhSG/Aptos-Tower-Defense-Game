using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBoost : MonoBehaviour
{
    // Singleton instance
    public static ResourceBoost Instance { get; private set; }

    // Variable to store the resource boost value
    public int resourceBoost = 1;
    public int goldBoost = 0;
    public int woodBoost = 0;
    public int stoneBoost = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ResetBoostValue()
    {
        resourceBoost = 1;
        goldBoost = 0;
        woodBoost = 0;
        stoneBoost = 0;

        Debug.Log("resourceBoost: " + resourceBoost);
        Debug.Log("goldBoost: " + goldBoost);
        Debug.Log("woodBoost: " + woodBoost);
        Debug.Log("stoneBoost: " + stoneBoost);
    }
}
