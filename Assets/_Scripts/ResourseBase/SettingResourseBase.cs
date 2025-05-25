using UnityEngine;

[CreateAssetMenu(fileName = "SettingBase", menuName = "Scriptable Objects/SettingBase")]
public class SettingResourseBase : ScriptableObject
{
    [field: SerializeField] public TypeFfraction TypeFractionBase { get; private set; }

    [field: SerializeField] public Sprite SpriteBase { get; private set; }

}
