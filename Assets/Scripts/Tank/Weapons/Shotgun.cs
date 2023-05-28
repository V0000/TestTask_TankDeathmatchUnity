using UnityEngine;

namespace Tank.Weapons
{
    public class Shotgun : WeaponBase
    {
        [SerializeField] private int numberPerShot = 5;


        public override void Shoot()
        {
            for (int i = 0; i < numberPerShot; i++)
            {
                base.Shoot();
  
            }
        }

    }
}
