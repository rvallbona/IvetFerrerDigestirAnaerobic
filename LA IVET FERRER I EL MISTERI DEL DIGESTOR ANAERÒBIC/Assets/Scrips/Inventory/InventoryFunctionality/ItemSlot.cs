using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _itemName;
    public string _itemId;

    [SerializeField]
    private Image _itemIcon;

    [SerializeField]
    private GameObject _stackObj;

    [SerializeField]
    private TextMeshProUGUI _stackNumber;

    public void Set(InventoryItem item)
    {
        _itemName.text = item.data.itemName;
        _itemIcon.sprite = item.data.itemIcon;
        _itemId = item.data.id;

        if (item.stackSize <= 1)
        {
            _stackObj.SetActive(false);
            return;
        }

        _stackNumber.text = item.stackSize.ToString();
    }
}
