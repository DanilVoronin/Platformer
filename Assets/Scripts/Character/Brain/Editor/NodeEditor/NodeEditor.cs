using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace Assets.Scripts.NodeEditor.Brain
{ 
    public class NodeEditor : EditorWindow
    {
        public List<Node> nodes = new List<Node>();
        public List<Connection> connections = new List<Connection>();

        private ConnectPoint selectedInputNode;
        private ConnectPoint selectedOutputNode;

        public Vector2 offset;
        private Vector2 drag;

        [MenuItem("Window/Node Editor")]
        public static void ShowWindow()
        {
            GetWindow<NodeEditor>("Node Editor");
        }

        private void OnGUI()
        {
            GUI.Label(new Rect(position.width - 300, 10, 300, 20), $"offset: x:{offset.x} y:{offset.y}");
            GUI.Label(new Rect(position.width - 300, 30, 300, 20), $"selectedInputNode: {selectedInputNode}");
            GUI.Label(new Rect(position.width - 300, 50, 300, 20), $"selectedOutputNode: {selectedOutputNode}");

            GUI.color = Color.red;
            GUI.Box(new Rect(offset, new Vector2(10,10)),"");

            Event e = Event.current;
            ProcessEvents(e);

            DrawGrid();
            DrawNodes();
            DrawConnections();
            DrawCurrentConnect();

            //DrawMinimap();
                
            if (GUI.changed)
                Repaint();
        }

        #region Отрисовка элементов
        private void DrawGrid()
        {
            int gridSize = 20;
            Handles.color = new Color(0.2f, 0.2f, 0.2f, 0.5f);

            for (float x = offset.x % gridSize; x < position.width; x += gridSize)
                Handles.DrawLine(new Vector2(x, 0), new Vector2(x, position.height));

            for (float y = offset.y % gridSize; y < position.height; y += gridSize)
                Handles.DrawLine(new Vector2(0, y), new Vector2(position.width, y));

            Handles.color = Color.white;
        }
        private void DrawNodes()
        {
            foreach (Node node in nodes)
            {
                node.Draw();
            }
        }
        private void DrawConnections()
        {
            foreach (Connection connection in connections)
                connection.Draw();
        }
        private void DrawCurrentConnect()
        {
            if (selectedInputNode != null) Handles.DrawLine(selectedInputNode.Position.center, Event.current.mousePosition);
            if (selectedOutputNode != null) Handles.DrawLine(selectedOutputNode.Position.center, Event.current.mousePosition);
        }
        #endregion

        /// <summary>
        /// Обрабатывает события 
        /// </summary>
        /// <param name="e"></param>
        private void ProcessEvents(Event e)
        {
            foreach (Node node in nodes)
            {
                node.ProcessEvents(e);
            }

            if (e.type == EventType.MouseDown)
            {
                if (e.button == 1) ShowContextMenu(e.mousePosition);
                if (e.button == 2) drag = e.mousePosition;
            }

            if (e.type == EventType.MouseUp)
            {
                if (e.button == 0)
                {
                    ConnectNodes();
                }
            }

            //Перемещение поля
            if (e.type == EventType.MouseDrag && e.button == 2)
            {
                offset += e.mousePosition - drag;
                drag = e.mousePosition;
                GUI.changed = true;
            }
        }
        private void ShowContextMenu(Vector2 position)
        {
            GenericMenu menu = new GenericMenu();
            menu.AddItem(new GUIContent("Create Node"), false, () => CreateNode(position));
            menu.ShowAsContext();
        }
        private void CreateNode(Vector2 position)
        {
            nodes.Add(new Node(position, this));
        }
        public void DeleteConnection(Connection connection)
        {
            connections.Remove(connection);
        }
        private void DrawMinimap()
        {
            GUI.Box(new Rect(position.width - 150, 10, 140, 100), "Minimap");
            // Простая миникарта, можно улучшить
        }
        private void ConnectNodes()
        {
            if (selectedOutputNode != null && selectedInputNode != null 
                && selectedOutputNode != selectedInputNode &&
                selectedOutputNode.Node != selectedInputNode.Node)
            { 
                connections.Add(new Connection(selectedOutputNode, selectedInputNode));
            }
            selectedOutputNode = null;
            selectedInputNode = null;
        }

        /// <summary>
        /// Нажали на связь выхода
        /// </summary>
        public void SelectedInputNode(ConnectPoint input)
        {
            selectedInputNode = input;
        }
        /// <summary>
        /// Нажали на связь выхода
        /// </summary>
        public void SelectedOutputNode(ConnectPoint output)
        {
            selectedOutputNode = output;
        }
    }
}