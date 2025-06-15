using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonObject<GameManager>
{
    private static ObjectManager _object;

    public static ObjectManager Object => _object;

    protected override void Awake()
    {
        base.Awake();

        _object = GetComponentInChildren<ObjectManager>();

        DontDestroyOnLoad(this);

        Application.targetFrameRate = 60;
    }

    public void StartStage()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToLobby()
    {
        SceneManager.LoadScene(0);
    }
}
