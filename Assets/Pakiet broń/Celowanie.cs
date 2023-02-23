using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Celowanie : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private Transform camera;
    public Animation animation;
    void Start()
    {
        
    }

    [SerializeField]private bool isAiming = false;
    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (!isAiming)
            {
                //gameObject.transform.position = Vector3.Lerp(posA, posB, 1) + camera.position;
                animation.Play("ScopeIn");
                isAiming = true;
            }
            else
            {
                animation.Play("ScopeOut");
                isAiming = false;
            }
        }
    }
}
