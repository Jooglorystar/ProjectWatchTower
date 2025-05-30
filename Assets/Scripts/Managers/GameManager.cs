using UnityEngine;

public class GameManager : SingletonObject<GameManager>
{
    private static ObjectManager _object;

    public static ObjectManager Object => _object;

    protected override void Awake()
    {
        base.Awake();

        _object = GetComponentInChildren<ObjectManager>();

        DontDestroyOnLoad(this);
    }
}
