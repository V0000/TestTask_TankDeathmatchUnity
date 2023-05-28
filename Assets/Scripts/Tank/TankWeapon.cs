using System.Collections.Generic;
using UnityEngine;
using Tank.Weapons;

namespace Tank
{
    public class TankWeapon : MonoBehaviour
    {
        [SerializeField] private Transform weaponsContainer; // Ссылка на объект-контейнер "weapons"
        private List<IWeapon> _weaponsList;
        private int _activeWeaponIndex = 0;
        void Start()
        {
            _weaponsList = new List<IWeapon>();
            foreach (Transform weapon in weaponsContainer)
            {
                IWeapon weaponComponent = weapon.GetComponent<IWeapon>();
                if (weaponComponent != null)
                {
                    _weaponsList.Add(weaponComponent);
                    weapon.gameObject.SetActive(false); // Отключаем все оружия по умолчанию
                }
            }
            
            if (_weaponsList.Count > 0)
            {
                _weaponsList[_activeWeaponIndex].SetActive(true); // Включаем первое оружие в списке
            }
            
        }
        
        private void Update()
        {
            // Переключение оружия при нажатии кнопок Q и E
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SwitchToPreviousWeapon();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                SwitchToNextWeapon();
            }
            if (Input.GetMouseButtonDown(0))
            {
                _weaponsList[_activeWeaponIndex].Shoot();
            }
        }
        
        private void SwitchToPreviousWeapon()
        {
            _weaponsList[_activeWeaponIndex].SetActive(false); // Отключаем текущее активное оружие
            _activeWeaponIndex--;
            if (_activeWeaponIndex < 0)
            {
                _activeWeaponIndex = _weaponsList.Count - 1;
            }
            _weaponsList[_activeWeaponIndex].SetActive(true); // Включаем новое активное оружие
        }

        private void SwitchToNextWeapon()
        {
            _weaponsList[_activeWeaponIndex].SetActive(false); 
            _activeWeaponIndex++;
            if (_activeWeaponIndex >= _weaponsList.Count)
            {
                _activeWeaponIndex = 0;
            }
            _weaponsList[_activeWeaponIndex].SetActive(true); 
        }


    }
}
