using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts.Helpers
{
    /// <summary>
    /// Служит для определения является ли игровой объект
    /// интерактивным для помошника тригера Trigger
    /// </summary>
    public class InterativeObjectTrigger : MonoBehaviour
    {
        /// <summary>
        /// Массив id зон с которыми объект может взаимодействовать
        /// </summary>
        [field : SerializeField] public List<int> TriggersId { get; private set; }
    }
}
