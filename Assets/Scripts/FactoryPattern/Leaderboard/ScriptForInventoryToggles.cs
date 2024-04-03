using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsSpawner : MonoBehaviour
{
    [SerializeField] private TypeHolder allTabContainer;
    [SerializeField] private TypeHolder foodTabContainer;
    [SerializeField] private TypeHolder armorTabContainer;
    [SerializeField] private TypeHolder weaponTabContainer;

    private Dictionary<ItemType, Transform> _tabs = new Dictionary<ItemType, Transform>();
    private List<TypeHolder> _items; 

    private void OnEnable()
    {
       
        _tabs.Clear(); 
        _tabs.Add(ItemType.All, allTabContainer.transform);
        _tabs.Add(ItemType.Food, foodTabContainer.transform);
        _tabs.Add(ItemType.Armor, armorTabContainer.transform);
        _tabs.Add(ItemType.Weapon, weaponTabContainer.transform);

        
        _items = new List<TypeHolder>(allTabContainer.GetComponentsInChildren<TypeHolder>());

        
        foreach (var item in _items)
        {
            if (_tabs.TryGetValue(item.ItemType, out Transform parentTransform))
            {
                Instantiate(item.gameObject, parentTransform, false); 
            }
        }
    }
}

public enum ItemType
{
    All,
    Food,
    Armor,
    Weapon
}

public class TypeHolder : MonoBehaviour
{
    public ItemType ItemType;
}

