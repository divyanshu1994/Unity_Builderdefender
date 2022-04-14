using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceUI : MonoBehaviour
{
    private ResourceListTypeSO resourceListType;
    Transform resourceTemplate;
    Dictionary<ResourceTypeSO, Transform> dict;


    // Start is called before the first frame update
    void Awake()
    {
        resourceListType = Resources.Load<ResourceListTypeSO>(typeof(ResourceListTypeSO).Name);
        resourceTemplate = transform.Find("ResourceTemplate");
        resourceTemplate.gameObject.SetActive(false);

        int index = 0;

        dict = new Dictionary<ResourceTypeSO, Transform>();

        foreach (ResourceTypeSO resource in resourceListType.list)
        {
            Transform resourceTrans = Instantiate(resourceTemplate,transform);
            resourceTrans.gameObject.SetActive(true);

            float gap = -200;

            resourceTrans.GetComponent<RectTransform>().anchoredPosition = new Vector2(index * gap, 0);
            resourceTrans.Find("Image").GetComponent<Image>().sprite = resource.sprite;

            dict[resource] = resourceTrans;

            index++;
        }
    }

    private void Start()
    {
        ResourceManager.Instance.onResouceAmountChanged += ResourceManager_onResouceAmountChanged;
        updateResources();

    }

    private void ResourceManager_onResouceAmountChanged(object sender, System.EventArgs e)
    {
        updateResources();
    }

    private void updateResources()
    {
        foreach (ResourceTypeSO resource in resourceListType.list)
        {
            Transform resourceTrans = dict[resource];

            int amount = ResourceManager.Instance.GetResourceAmount(resource);
            resourceTrans.Find("Text").GetComponent<TextMeshProUGUI>().SetText(amount.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
