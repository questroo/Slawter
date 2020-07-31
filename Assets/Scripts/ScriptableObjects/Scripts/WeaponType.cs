using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponType : ScriptableObject
{
    public eWeaponType myType;
    public enum eWeaponType
    {
        Normal,      // White
        Fire,        // Red
        Shock,       // Blue
        Explosive,   // Brown
        Piercing     // Silver
    }

    public float CalculateDamageVsEnemyType(eWeaponType eWeaponType, EnemyType.eEnemyType eEnemyType, float baseDamage)
    {
        switch (eWeaponType)
        {
            case eWeaponType.Normal:
                switch (eEnemyType)
                {
                    case EnemyType.eEnemyType.Red:
                        return baseDamage;
                    case EnemyType.eEnemyType.Yellow:
                        return baseDamage;
                    case EnemyType.eEnemyType.Blue:
                        return baseDamage;
                    default:
                        break;
                }
                break;
            case eWeaponType.Fire:
                switch (eEnemyType)
                {
                    case EnemyType.eEnemyType.Red:
                        return baseDamage;
                    case EnemyType.eEnemyType.Yellow:
                        return baseDamage * 2.0f;
                    case EnemyType.eEnemyType.Blue:
                        return baseDamage * 0.5f;
                    default:
                        break;
                }
                break;
            case eWeaponType.Shock:
                switch (eEnemyType)
                {
                    case EnemyType.eEnemyType.Red:
                        return baseDamage;
                    case EnemyType.eEnemyType.Yellow:
                        return baseDamage * 0.5f;
                    case EnemyType.eEnemyType.Blue:
                        return baseDamage * 2.0f;
                    default:
                        break;
                }
                break;
            case eWeaponType.Piercing:
                switch (eEnemyType)
                {
                    case EnemyType.eEnemyType.Red:
                        return baseDamage * 2.0f;
                    case EnemyType.eEnemyType.Yellow:
                        return baseDamage;
                    case EnemyType.eEnemyType.Blue:
                        return baseDamage * 0.5f;
                    default:
                        break;
                }
                break;
            case eWeaponType.Explosive:
                switch (eEnemyType)
                {
                    case EnemyType.eEnemyType.Red:
                        return baseDamage;
                    case EnemyType.eEnemyType.Yellow:
                        return baseDamage;
                    case EnemyType.eEnemyType.Blue:
                        return baseDamage;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
        return 0.0f;
    }
}