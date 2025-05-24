using UnityEngine;

public class SpawnButton : MonoBehaviour
{
    public void Spawn()
    {
        UnitManager.Instance.SpawnPlayerUnit();
    }
}
