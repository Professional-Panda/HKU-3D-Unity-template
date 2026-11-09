using UnityEngine;
using UnityEngine.InputSystem;

public class Sword_attack : MonoBehaviour
{
    //This code was made with the following Unity Discussions: https://discussions.unity.com/t/how-do-make-an-object-move-in-a-circle-around-the-player/221685/2
    public Transform Target;
    public float RotationSpeed = 1.0f;
    public float CircleRadius = 1.0f;
    public float ElevationOffset = 0.0f;

    public InputActionAsset InputActions;
    private InputAction playerAttackAction;

    private Vector3 positionOffset;
    private float angle;

    private bool attacking = false;

    private void OnEnable()
    {
        InputActions.FindActionMap("Player").Enable();

    }

    private void OnDisable()
    {
        InputActions.FindActionMap("Player").Disable();
    }

    private void Awake()
    {
        playerAttackAction = InputSystem.actions.FindAction("Attack");
    }

    void LateUpdate()
    {
        if (playerAttackAction.WasPressedThisFrame())
        {
            attacking = true;
        }
        if (angle < 3.0 && attacking == true)
        {
            positionOffset.Set(Mathf.Cos(angle) * CircleRadius,
                ElevationOffset,
                Mathf.Sin(angle) * CircleRadius);
            transform.position = Target.position + positionOffset;

            //change the angle of the blade
            Vector3 outwardDirection = transform.position - Target.position;

            transform.rotation = Quaternion.LookRotation(outwardDirection);

            angle += Time.deltaTime * RotationSpeed;
            Debug.Log("PositionOffset" + positionOffset);
        }
        else
        {
            angle = 1 * Target.rotation.y;
            attacking = false;
        }

    }

    
}
