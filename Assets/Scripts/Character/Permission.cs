using UnityEngine;
using System.Collections.Generic;
using System;

namespace Assets.Scripts.Character
{
    /// <summary>
    /// Проверяет разрешение на выполнения действия
    /// </summary>
    [Serializable]
    public class Permission
    {
        /// <summary>
        /// Список сосстояний в которых действие разрешено
        /// </summary>
        [SerializeField] private List<UnitState> ListAllowedStates;

        /// <summary>
        /// Возвращает true если содержит состояние
        /// </summary>
        /// <param name="unitState"></param>
        /// <returns></returns>
        public bool IsAllowed(UnitState unitState)
        {
            return ListAllowedStates.Contains(unitState);
        }
    }
}
