using UnityEngine;

public class Sword_attack : MonoBehaviour
{
    //This code was made with the following Unity Discussions: https://discussions.unity.com/t/how-do-make-an-object-move-in-a-circle-around-the-player/221685/2
    public Transform Target;
    public float RotationSpeed = 1.0f;
    public float CircleRadius = 1.0f;
    public float ElevationOffset = 0.0f;

    private Vector3 positionOffset;
    private float angle;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void LateUpdate()
    {
        positionOffset.Set(Mathf.Cos(angle) * CircleRadius,
            ElevationOffset,
            Mathf.Sin(angle) * CircleRadius);
        transform.position = Target.position + positionOffset;
        //change the angle of the blade z needs to be the thing that moves
       // Quaternion newRotation = transform.rotation;

        Vector3 outwardDirection = transform.position - Target.position;
        //newRotation.z = Quaternion.LookRotation(outwardDirection).z;
        
        //newRotation.z = 90 + angle;
        transform.rotation = Quaternion.LookRotation(outwardDirection);
        
        angle += Time.deltaTime * RotationSpeed;
        Debug.Log("PositionOffset" + positionOffset);
    }
}
