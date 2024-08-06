namespace GameJamProject.Health
{
    public interface IDamageable
    {
        void TakeDamage(int amount);
        void Heal(int amount);
    }
}