using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    Camera cam;
    [SerializeField]
    BuildingTypeSO activeBuildingSO;
    BuildListTypeSO buildingTypes;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        buildingTypes = Resources.Load<BuildListTypeSO>(typeof(BuildListTypeSO).Name);
        activeBuildingSO = buildingTypes.list[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(activeBuildingSO.Prefab,GetMouseToWorldPos(),Quaternion.identity);
        }

        if(Input.GetKeyDown(KeyCode.T))
        {
            activeBuildingSO = buildingTypes.list[0];
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            activeBuildingSO = buildingTypes.list[1];
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            activeBuildingSO = buildingTypes.list[2];
        }
    }

    private Vector3 GetMouseToWorldPos()
    {
        Vector3 pos = cam.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        return pos;
        
    }
}
