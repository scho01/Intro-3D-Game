using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gamekit3D
{
    public class FruitUI : MonoBehaviour
    {
        public Slider slider;
        public TextMeshProUGUI text;
        public bool apple;
        public void Start()
        {
            slider.maxValue = 1;
            if (apple)
                slider.value = (float)Food.appleFreshness;
            else
                slider.value = (float)Food.pearFreshness;
        }
        void FixedUpdate()
        {
            if (apple)
            {
                slider.value = (float)Food.appleFreshness;
                text.text = Food.numApples.ToString();
            }
            else
            {
                slider.value = (float)Food.pearFreshness;
                text.text = Food.numPears.ToString();
            }
        }
    }
}
