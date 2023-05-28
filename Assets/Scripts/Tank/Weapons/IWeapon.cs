namespace Tank.Weapons
{
    public interface IWeapon
    {
        void SetActive(bool isActive);
        void Shoot();
    }
}
