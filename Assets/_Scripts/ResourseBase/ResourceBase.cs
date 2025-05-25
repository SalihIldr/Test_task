using UnityEngine;

public class ResourceBase : MonoBehaviour
{
    [SerializeField] private SettingResourseBase _setting;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private TypeFfraction _typeFfraction;

    private void Start()
    {
        _spriteRenderer.sprite = _setting.SpriteBase;
        _typeFfraction = _setting.TypeFractionBase;
    }
}
