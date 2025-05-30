using UnityEngine;

public class StageManager : SingletonObject<StageManager>
{
    public static UnitManager Unit;

    protected override void Awake()
    {
        base.Awake();

        Unit = GetComponent<UnitManager>();
    }
}
