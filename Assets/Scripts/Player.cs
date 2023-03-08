using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace DefaultNamespace
{
    public class Player : MonoBehaviour
    {
        public Gradient healthGradient;
        public Gradient IntensityGradient;
        public Gradient ColorFilterGradient;
        public ColorAdjustments ColorAdjustments;
        public int health;
        public Vignette vignette;
        public Volume Volume;


        void Start()
        {
            // Create an instance of a vignette
            //Volume volumeProfile = GetComponent<Volume>();
            if(!Volume) throw new System.NullReferenceException(nameof(Volume));
// You can leave this variable out of your function, so you can reuse it throughout your class.
            
 
            if(!Volume.profile.TryGet(out vignette)) throw new NullReferenceException(nameof(vignette));
            if(!Volume.profile.TryGet(out ColorAdjustments)) throw new NullReferenceException(nameof(ColorAdjustments));
 
        }

        public void Damage(int damage)
        {
            health -= damage;
        }
        private void FixedUpdate()
        {
            vignette.color.value = healthGradient.Evaluate((float)health / 100);
            vignette.intensity.value = IntensityGradient.Evaluate((float)health / 100).a;

            ColorAdjustments.colorFilter.value = ColorFilterGradient.Evaluate((float)health / 100);
        }
    }
}