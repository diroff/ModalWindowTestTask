using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Create/Item Data/New Item Data", order = 51)]
public class ItemData : ScriptableObject
{
    [field: SerializeField] public int ID { get; private set; }

    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public string Description { get; private set; }

    [field: SerializeField] public Sprite Sprite { get; private set; }
    [field: SerializeField] public int Cost { get; private set; }
}