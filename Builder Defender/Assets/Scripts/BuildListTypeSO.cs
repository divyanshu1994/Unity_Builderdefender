using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/BuildingListType")]
public class BuildListTypeSO : ScriptableObject
{
    public List<BuildingTypeSO> list;
}
