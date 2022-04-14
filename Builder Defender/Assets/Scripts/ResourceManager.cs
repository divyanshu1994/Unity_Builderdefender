using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; private set; }

    ResourceListTypeSO resouceListType;
    Dictionary<ResourceTypeSO, int> resourceDict;
    public event EventHandler onResouceAmountChanged;

    private void Awake()
    {
        Instance = this;
        resouceListType = Resources.Load<ResourceListTypeSO>(typeof(ResourceListTypeSO).Name);

        resourceDict = new Dictionary<ResourceTypeSO, int>();


        foreach (ResourceTypeSO resource in resouceListType.list)
        {

            resourceDict[resource] = 0;
        }

    }

    private void Start()
    {

        PrintResoucres();
    }

    private void PrintResoucres()
    {
        foreach(ResourceTypeSO r in resourceDict.Keys)
        {
            Debug.Log(r.nameString + " : " + resourceDict[r]);
        }
    }

    public void AddResource(ResourceTypeSO resource, int amount)
    {
        resourceDict[resource] += amount;

        onResouceAmountChanged?.Invoke(this, EventArgs.Empty);

        PrintResoucres();
    }

    public int GetResourceAmount(ResourceTypeSO r)
    {
        return resourceDict[r];
    }
}
