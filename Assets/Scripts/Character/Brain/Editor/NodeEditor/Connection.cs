using UnityEngine;
using UnityEditor;

namespace Assets.Scripts.NodeEditor.Brain
{
    /// <summary>
    /// Соединение точек нодов
    /// </summary>
    public class Connection
    {
        private ConnectPoint outputPoin;
        private ConnectPoint inputPoin;

        public Connection(ConnectPoint output, ConnectPoint input)
        {
            this.outputPoin = output;
            this.inputPoin = input;
        }

        /// <summary>
        /// Рисует соединение
        /// </summary>
        public void Draw()
        {
            Handles.DrawBezier(
                outputPoin.Position.center + new Vector2(outputPoin.Position.width / 2, 0),
                inputPoin.Position.center - new Vector2(inputPoin.Position.width / 2, 0),
                outputPoin.Position.center + Vector2.right * 50,
                inputPoin.Position.center + Vector2.left * 50,
                Color.white, null, 3f
            );

            if (Handles.Button((outputPoin.Position.center + inputPoin.Position.center) / 2, Quaternion.identity, 10, 10, Handles.RectangleHandleCap))
            {
                inputPoin.Node.Editor.DeleteConnection(this);
            }
        }
        /// <summary>
        /// Рисует соединение по двум точкам
        /// </summary>
        public static void Draw(Vector2 start, Vector2 end)
        {
            Handles.DrawBezier(
                    start, end,
                    start + Vector2.right * 50,
                    end + Vector2.left * 50,
                    Color.white, null, 3f
                );
        }
    }
}
