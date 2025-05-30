using UnityEngine;

public class SpawnButton : MonoBehaviour
{
    public void Spawn()
    {
        StageManager.Unit.SpawnPlayerUnit();
    }
}
