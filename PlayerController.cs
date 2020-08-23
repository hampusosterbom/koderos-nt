
using System.Security.Cryptography;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    
    public float speed = 5f;

    public float lookSensitivity = 3f;

    public float thrusterForce = 1000f;

    public PlayerMotor motor;

    void Start ()
    {
        motor = GetComponent<PlayerMotor>();

    }

    void Update ()
    {
        //calculate movement velocity as a 3d vector
        float _zMov = Input.GetAxis("Vertical");
        float _xMov = Input.GetAxis("Horizontal");

        Vector3 _movVertical = transform.right * _zMov; 
        Vector3 _movHorizontal = transform.forward * _xMov;

        // Final movement vector
        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

        //apply movement
        motor.Move(_velocity);

        //Calculate rotation as a 3d vector (turning around)
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;

        //apply rotation
        motor.Rotate(_rotation);

        //Calculate camera rotation as a 3d vector (turning around)
        float _xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 _cameraRotation = new Vector3(_xRot, 0f, 0f) * lookSensitivity;

        //apply camera rotation
        motor.RotateCamera(_cameraRotation);

        //apply thruster force
        Vector3 _thrusterForce = Vector3.zero;
        if(Input.GetButton("Jump"))
        {

            _thrusterForce = Vector3.up * thrusterForce;
        }

        motor.ApplyThruster(_thrusterForce);
    }
}
