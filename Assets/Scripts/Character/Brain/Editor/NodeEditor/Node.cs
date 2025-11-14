using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.NodeEditor.Brain
{ 
    public class Node
    {
        public Rect Rect;
        public NodeEditor Editor { get; private set; }

        private bool isDragging = false;

        private Vector2 position;
        private Vector2 drag;
        private Vector2 offset;

        private Vector2 localPosition { get => position + Editor.offset; }

        private List<ConnectPoint> connectPointsOutput = new List<ConnectPoint>();
        private List<ConnectPoint> connectPointsInput = new List<ConnectPoint>();

        public Node(Vector2 position, NodeEditor editor)
        {
            this.Editor = editor;
            this.position = position - Editor.offset;
            Rect = new Rect(position, new Vector2(150, 200));

            float step = (Rect.size.y - 10) / 3;
            for (int i = 0; i < 3; i++)
            {
                connectPointsOutput.Add(new ConnectPoint(new Rect(Rect.size.x, step * i + (step / 2),20,20), ConnectPointType.Output, this));
            }
            for (int i = 0; i < 1; i++)
            {
                connectPointsInput.Add(new ConnectPoint(new Rect(-20, step * i + (step / 2), 20, 20), ConnectPointType.Output, this));
            }
        }

        public void Draw()
        {
            Rect.position = localPosition + offset;

            GUI.color = Color.gray;
            GUI.Box(Rect, "Node");

            GUI.Label(new Rect(Rect.x + Rect.width / 2 - 75, Rect.y - 20, 150, 20), $"position: x:{position.x} y:{position.y}");
            GUI.Label(new Rect(Rect.x + Rect.width / 2 - 75, Rect.y - 35, 150, 20), $"offset: x:{offset.x} y:{offset.y}");
            GUI.Label(new Rect(Rect.x + Rect.width / 2 - 75, Rect.y - 50, 150, 20), $"drag: x:{drag.x} y:{drag.y}");

            if (GUI.Button(new Rect(Rect.x + Rect.width - 15, Rect.y - 15, 20, 20), "X"))
            {
                Editor.nodes.Remove(this);
            }

            foreach (ConnectPoint connectPoint in connectPointsOutput) connectPoint.DrawPoint(Rect);
            foreach (ConnectPoint connectPoint in connectPointsInput) connectPoint.DrawPoint(Rect);
        }

        public void ProcessEvents(Event e)
        {
            //Проверка взаимодействия с нодами
            if (e.type == EventType.MouseDown || e.type == EventType.MouseUp && e.button == 0)
            {
                foreach (ConnectPoint connectPoint in connectPointsOutput)
                {
                    if (connectPoint.IsPointer(e.mousePosition))
                    {
                        Editor.SelectedOutputNode(connectPoint);
                        return;
                    }
                }
                foreach (ConnectPoint connectPoint in connectPointsInput)
                {
                    if (connectPoint.IsPointer(e.mousePosition))
                    {
                        Editor.SelectedInputNode(connectPoint);
                        return;
                    }
                }
            }

            switch (e.type)
            {
                case EventType.MouseDown:
                    //Проверка перемещения
                    if (Rect.Contains(e.mousePosition) && e.button == 0)
                    {
                        isDragging = true;
                        drag = e.mousePosition;
                        e.Use();
                    }

                    break;

                case EventType.MouseDrag:
                    if (isDragging)
                    {
                        offset = e.mousePosition - drag;
                        e.Use();
                    }
                    break;

                case EventType.MouseUp:
                    isDragging = false;
                    position += offset;
                    offset = Vector2.zero;
                    break;
            }
        }
    }
}