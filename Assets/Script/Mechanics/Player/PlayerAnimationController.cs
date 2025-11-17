using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Gun,
    Melee
}
public class PlayerAnimationController : MonoBehaviour
{
    public static PlayerAnimationController Instance;
    public Animator gunAnimator;
    public Animator meleeAnimator;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TriggerAnimation(WeaponType weaponType, string triggerName)
    {
        switch (weaponType)
        {
            case WeaponType.Gun:
                if (gunAnimator != null) gunAnimator.SetTrigger(triggerName);
                break;
            case WeaponType.Melee:
                if (meleeAnimator != null) meleeAnimator.SetTrigger(triggerName);
                break;
        }
    }

    public void SwitchWeapon(WeaponType weaponType)
    {
        if (gunAnimator != null) gunAnimator.gameObject.SetActive(weaponType == WeaponType.Gun);
        if (meleeAnimator != null) meleeAnimator.gameObject.SetActive(weaponType == WeaponType.Melee);
    }
}
