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

            tempRotationQuaternion = _limitRotation(tempRotationQuaternion);

            rb.MoveRotation( tempRotationQuaternion );

            return;

        }

        rb.MoveRotation( Quaternion.Lerp(Quaternion.identity, rb.rotation, 0.993f) );
    }

    private Quaternion _limitRotation(Quaternion rotation){ // rotasyon alinir, vector 3 e cevrilir ve 180 derece degerine gore kalibre edilir.
                                                            // sinirlamalar yapilir ve tekrardan quaterniona cevrilir. / Corpyr

        Quaternion tempRotationQuaternion;
        Vector3 tempRotationVector3 = rotation.eulerAngles;
        
        tempRotationVector3.x = (tempRotationVector3.x > 180) ? tempRotationVector3.x - 360 : tempRotationVector3.x;
        tempRotationVector3.x = Mathf.Clamp(tempRotationVector3.x, -1 * maxXRotate, maxXRotate);

        tempRotationVector3.y = (tempRotationVector3.y > 180) ? tempRotationVector3.y - 360 : tempRotationVector3.y;
        tempRotationVector3.y = Mathf.Clamp(tempRotationVector3.y, -1 * maxXRotate, maxXRotate);

        tempRotationVector3.z = 0f;

        tempRotationQuaternion = Quaternion.Euler( tempRotationVector3 );

        return tempRotationQuaternion;

    }
}
