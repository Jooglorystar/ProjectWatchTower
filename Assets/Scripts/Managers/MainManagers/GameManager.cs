using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonObject<GameManager>
{
    private static ObjectManager _object;
    private static DatabaseManager _database;
    public static ObjectManager Object => _object;
    public static DatabaseManager Database => _database;

    public PlayerData PlayerData;

    protected override void Awake()
    {
        base.Awake();

        _object = GetComponentInChildren<ObjectManager>();
        _database = GetComponentInChildren<DatabaseManager>();

        DontDestroyOnLoad(this);

        PlayerData = new PlayerData();

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
