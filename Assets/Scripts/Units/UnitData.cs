using UnityEngine;

[CreateAssetMenu(fileName = "DefaultUnitData", menuName = "SO/UnitData")]
[System.Serializable]
public class UnitData : ScriptableObject
{
    public int UnitMaxHealth;
    public int UnitAttack;
    public float UnitSpeed;
    public LayerMask TargetLayerMask;
}
