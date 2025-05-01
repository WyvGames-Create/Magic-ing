using UnityEngine;

[CreateAssetMenu(fileName = "Form", menuName = "ScriptableObjects/FormSO")]
public class FormSO : ScriptableObject
{
    [field: SerializeField] public string id {get; private set;} = "None";
    [field: SerializeField] public float damage {get; private set;} = 10f;
    [field: SerializeField] public float speed {get; private set;} = 10f;
    [field: SerializeField] public float range {get; private set;} = 10f;
    [field: SerializeField] public int maxBounce {get; private set;} = 0;
}
