public class StageManager : SingletonObject<StageManager>
{
    private static UnitManager _unit;
    private static EnemyManager _enemy;
    public static UnitManager Unit => _unit;
    public static EnemyManager Enemy => _enemy;

    protected override void Awake()
    {
        base.Awake();

        _unit = GetComponentInChildren<UnitManager>();
        _enemy = GetComponentInChildren<EnemyManager>();
    }
}