using UnityEngine;

public class SpawnPosition : MonoBehaviour
{
    [SerializeField] private int _unitDirection;

    public int UnitDirection => _unitDirection;

    public void SetPosition(float p_coreDistance)
    {
        transform.position = new Vector3(p_coreDistance, -1, 0);
    }
}
