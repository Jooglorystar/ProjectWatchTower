public interface IDamagable
{

    public int CurHealth { get; }
    public bool Damaged(int p_value);
}
