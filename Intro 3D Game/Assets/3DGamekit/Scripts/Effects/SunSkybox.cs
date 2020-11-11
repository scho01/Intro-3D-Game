using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit3D
{
    [ExecuteInEditMode]
    public class SunSkybox : MonoBehaviour
    {
        public Material skyboxMaterial;
        int sunDirId, sunColorId;
        Light sun;

        void Awake()
        {
            sun = GetComponent<Light>();
            sunDirId = Shader.PropertyToID("_SunDirection");
            sunColorId = Shader.PropertyToID("_SunColor");
        }

        void Update()
        {
            transform.RotateAround(Vector3.zero, Vector3.right, Time.deltaTime);
            transform.LookAt(Vector3.zero);
            if (skyboxMaterial)
            {
                skyboxMaterial.SetVector(sunDirId, -transform.forward.normalized);
                skyboxMaterial.SetColor(sunColorId, sun.color);
            }
        }
    }
}