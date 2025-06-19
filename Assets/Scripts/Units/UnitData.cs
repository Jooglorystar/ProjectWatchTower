using UnityEngine;

[CreateAssetMenu(fileName = "DefaultUnitData", menuName = "SO/UnitData")]
[System.Serializable]
public class UnitData : ScriptableObject
{
    public int UnitID;
    public int UnitCost;
    public int UnitMaxHealth;
    public int UnitAttack;
    public float UnitAttackDelay;
    public float UnitSpeed;
    public float UnitAttackRange;
    public LayerMask TargetLayerMask;
}
