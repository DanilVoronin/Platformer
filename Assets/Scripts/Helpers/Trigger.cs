using Assets.Scripts.Helpers;
using UnityEngine;
using UnityEngine.Events;
using System;

/// <summary>
/// Вызывает метод OnTriggerEnter при срабатывании триггера
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class Trigger : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private UnityEvent OnTriggerEnter;

    public event Action OnEnter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<InterativeObjectTrigger>(out var interativeObjectTrigger))
        {
            if (interativeObjectTrigger.TriggersId.Contains(id))
            {
                OnTriggerEnter?.Invoke();
                OnEnter?.Invoke();
            }
        }
    }
}


