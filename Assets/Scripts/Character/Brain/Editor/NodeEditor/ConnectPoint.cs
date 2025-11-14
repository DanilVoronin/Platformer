using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.NodeEditor.Brain
{ 
   /// <summary>
   /// Точка соединения у нода
   /// </summary>
    public class ConnectPoint
    {
        /// <summary>
        /// Нод которому принадлежит точка
        /// </summary>
        public Node Node { get; private set; }
        /// <summary>
        /// Позиция точки
        /// </summary>
        public Rect Position { get => currentRect; }

        private Rect localRect;
        private ConnectPointType connectPointType;

        private Rect currentRect;
        public ConnectPoint(Rect localRect, ConnectPointType connectPointType, Node node)
        {
            Node = node;
            this.localRect = localRect;
            this.connectPointType = connectPointType;
        }
        /// <summary>
        /// Рисует точку относительно позиции родителя
        /// </summary>
        public void DrawPoint(Rect node)
        {
            currentRect.position = node.position + localRect.position;
            currentRect.size = localRect.size;

            GUI.Button(currentRect, connectPointType == ConnectPointType.Input ? ">" : "<");
        }
        /// <summary>
        /// Если точка находится в пределах точки вернет true, иначе false
        /// </summary>
        /// <returns></returns>
        public bool IsPointer(Vector2 position)
        {
            return currentRect.Contains(position);
        }
    }

    public enum ConnectPointType
    { 
        Input, Output
    }
}
