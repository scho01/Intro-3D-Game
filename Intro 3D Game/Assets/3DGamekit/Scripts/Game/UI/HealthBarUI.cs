using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Gamekit3D
{
    public class HealthBarUI : MonoBehaviour
    {
        public Damageable representedDamageable;
        public Slider slider;
        void Start()
        {
            slider.maxValue = (float)representedDamageable.maxHitPoints;
            slider.value = (float)representedDamageable.currentHitPoints;
        }
        void FixedUpdate()
        {
            slider.value = (float)representedDamageable.currentHitPoints;
        }
    }
}
