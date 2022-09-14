using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public Rigidbody rb;

    [Header("Bullet Movement Attributes")]
    public float moveSpeed;
    public float rotateSpeed;

    [Header("Bullet Rotate Attributes")]
    public float maxXRotate;
    public float maxYRotate;


    private void Start() {
        
        if(rb == null){

            rb = GetComponent<Rigidbody>();

        }

    }

    void FixedUpdate()
    {
        
        _movement();

    }

    private void _movement(){

        rb.MovePosition(transform.position + transform.forward * moveSpeed * Time.deltaTime);

        if(Input.anyKey != false){
            
            Quaternion tempRotationQuaternion = Quaternion.Euler( -1 * Input.GetAxisRaw("Vertical") * rotateSpeed * Time.deltaTime,
                                                                  Input.GetAxisRaw("Horizontal") * rotateSpeed * Time.deltaTime, 0 ) * rb.rotation;

            /*Vector3 tempRotationVector3 = tempRotationQuaternion.eulerAngles; #FIXME 0 a gelince rotasyon degerleri max degerlere dönuyor / Corpyr

            tempRotationQuaternion = Quaternion.Euler( Mathf.Clamp(tempRotationVector3.x, -1 * maxXRotate, maxXRotate),
                                                       Mathf.Clamp(tempRotationVector3.y, -1 * maxYRotate, maxYRotate),
                                                       0 );*/  

            //rb.MoveRotation( rb.rotation * tempRotationQuaternion );
            rb.MoveRotation( tempRotationQuaternion );

            return;

        }

        rb.MoveRotation( Quaternion.Lerp(Quaternion.identity, rb.rotation, 0.993f) );

    }
}
