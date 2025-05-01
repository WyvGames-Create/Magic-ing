using UnityEngine;

[CreateAssetMenu(fileName = "Element", menuName = "ScriptableObjects/ElementSO")]
public class ElementSO : ScriptableObject
{
    [field: SerializeField] public string id {get; private set;} = "None";
    [field: SerializeField] public float damageModifier {get; private set;} = 0.8f;
    [field: SerializeField] public float speedModifier {get; private set;} = 0.8f;
    [field: SerializeField] public float rangeModifier {get; private set;} = 0.8f;
    [field: SerializeField] public int maxBounce {get; private set;} = 0;
    [field: SerializeField] public Color color = Color.white;
}
