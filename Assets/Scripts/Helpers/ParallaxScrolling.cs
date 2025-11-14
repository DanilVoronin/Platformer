using UnityEngine;
using System.Collections.Generic;
using System;

namespace Assets.Scripts.Helpers
{
    /// <summary>
    /// Эффект смещения заднего фона с различной скоростью от переднего
    /// </summary>
    class ParallaxScrolling : MonoBehaviour
    {
        [SerializeField] private new Camera camera;
        [SerializeField] private List<ParallaxScrollingSettings> parallaxScrollingSettings;

        private void Awake()
        {
            foreach (ParallaxScrollingSettings parallaxScrollingSettings in parallaxScrollingSettings)
            {
                parallaxScrollingSettings.StartPosition = parallaxScrollingSettings.Transform.position;
            }
        }

        private void FixedUpdate()
        {
            foreach (ParallaxScrollingSettings parallaxScrollingSettings in parallaxScrollingSettings)
            {
                parallaxScrollingSettings.Transform.position =
                    parallaxScrollingSettings.StartPosition +
                    (camera.transform.position * parallaxScrollingSettings.Multiplier) - camera.transform.position;
            }
        }
    }

    [Serializable]
    public class ParallaxScrollingSettings
    {
        /// <summary>
        /// Объект который будет смещаться
        /// </summary>
        public Transform Transform;
        /// <summary>
        /// Множитель смещения, влияет на скорость смещения
        /// </summary>
        public float Multiplier;
        /// <summary>
        /// Стартовая позиция объекта
        /// </summary>
        public Vector3 StartPosition;
    }
}
