using UnityEngine;

public class GameManager : SingletonObject<GameManager>
{
    public ObjectManager Object;

    protected override void Awake()
    {
        base.Awake();

        Object = GetComponent<ObjectManager>();

        DontDestroyOnLoad(this);
    }
}
