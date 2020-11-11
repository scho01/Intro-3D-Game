using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Gamekit3D
{
    public class Food : MonoBehaviour
    {
        static public int numApples = 0;
        static public int numPears = 0;
        static public double appleFreshness =  0;
        static public double pearFreshness = 0;
        private int appleRestoreValue = 20;
        private int pearRestoreValue = 40;
        private float fruitDecayRate = 0.01f;

        public void GainApple()
        {
            numApples++;
            Debug.Log(numApples);
            appleFreshness = (1 + appleFreshness) / numApples;
        }
        public void GainPear()
        {
            numPears++;
            pearFreshness = (1 + pearFreshness) / numPears;
        }

        public double Consume(bool apple)
        {
            if (apple)
            {
                if (numApples <= 0)
                    return 0;
                numApples--;
                return appleFreshness * appleRestoreValue;
            }
            if (numPears <= 0)
                return 0;
            numPears--;
            return pearFreshness * pearRestoreValue;
        }

        public void Decay()
        {
            if (numApples > 0)
                appleFreshness -= Time.deltaTime * fruitDecayRate / numApples;
            else
                appleFreshness = 0;
            if (numPears > 0)
                pearFreshness -= Time.deltaTime * fruitDecayRate / numPears;
            else
                pearFreshness = 0;
        }

        void Awake()
        {
        numApples = 0;
        numPears = 0;
        appleFreshness = 0;
        pearFreshness = 0;
        }
    }
}
