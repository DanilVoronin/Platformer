using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.UI
{
    /// <summary>
    /// Кнопка работающая в 3d пространстве
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer))]
    public class ButtonSpriteRender : MonoBehaviour
    {
        [SerializeField] private Color32 target;
        [SerializeField] private Color32 click;

        [SerializeField] private UnityEvent onClick;
        
        private SpriteRenderer spriteRenderer;
        private Color32 start;

        private void Awake()
        {
            TryGetComponent(out spriteRenderer);
            start = spriteRenderer.color;
        }

        private void OnMouseEnter()
        {
            spriteRenderer.color = target;
        }

        private void OnMouseExit()
        {
            spriteRenderer.color = start; 
        }

        /// <summary>
        /// Вообще надо настроить через систему ввода чтобы работал 
        /// контроллер и другие устройства кроме мышки. Но пока так :)
        /// </summary>
        private void OnMouseUp()
        {
            spriteRenderer.color = click;
            onClick?.Invoke();
        }
    }
}
