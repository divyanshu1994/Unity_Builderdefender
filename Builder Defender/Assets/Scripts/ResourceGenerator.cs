using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour
{
    private float timer;
    private float maxTime;
    private BuildingTypeSO buildingTypeSO;

    // Start is called before the first frame update
    void Start()
    {
        buildingTypeSO = GetComponent<BuildingTypeHolder>().buildingType;
        maxTime = buildingTypeSO.resourceData.maxTime;
 
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer<=0)
        {
            timer += maxTime;
            ResourceManager.Instance.AddResource(buildingTypeSO.resourceData.resource, 1);
        }
    }
}
