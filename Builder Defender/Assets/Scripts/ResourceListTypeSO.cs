using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ResourceListType")]
public class ResourceListTypeSO : ScriptableObject
{
    public List<ResourceTypeSO> list;
}
