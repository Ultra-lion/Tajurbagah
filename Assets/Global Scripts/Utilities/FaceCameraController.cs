using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tajurbah_Gah
{
    public class FaceCameraController : MonoBehaviour
    {
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        Transform camera;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

        private void Start()
        {
            camera = Camera.main.transform;
        }

        private void Update()
        {
            transform.rotation = Quaternion.LookRotation(transform.position - camera.transform.position);
        }
    }  
}
