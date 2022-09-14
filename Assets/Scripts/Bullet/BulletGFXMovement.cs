using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGFXMovement : MonoBehaviour
{
    public Transform parentTransform;
    public float rotate;
    void LateUpdate()
    {

        _rotate();

    }

    private void _rotate(){
        
        Vector3 tempRotation =  new Vector3( parentTransform.rotation.eulerAngles.x, 
                                             parentTransform.rotation.eulerAngles.y * rotate, 
                                             parentTransform.rotation.eulerAngles.z );

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(tempRotation), 10);

    }
}
