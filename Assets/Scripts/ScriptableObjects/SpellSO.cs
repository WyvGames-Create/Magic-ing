using UnityEngine;

[CreateAssetMenu(fileName = "Element", menuName = "ScriptableObjects/SpellSO")]
public class SpellSO : ScriptableObject
{
    [field: SerializeField] public ElementSO element;
    [field: SerializeField] public FormSO form;
    [field: SerializeField] public GameObject prefab;
}
