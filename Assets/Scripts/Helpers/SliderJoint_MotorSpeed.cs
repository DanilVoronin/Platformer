using UnityEngine;

/// <summary>
/// Изменяет скорость мотора на SliderJoint
/// </summary>
[RequireComponent(typeof(SliderJoint2D))]
public class SliderJoint_MotorSpeed : MonoBehaviour
{
    [SerializeField] private SliderJoint2D sliderJoint2;

    private void OnValidate()
    {
        sliderJoint2 = GetComponent<SliderJoint2D>();
    }

    public void SetMotorSpeed(float speed)
    {
        JointMotor2D jointMotor2D = sliderJoint2.motor;
        jointMotor2D.motorSpeed = speed;
        sliderJoint2.motor = jointMotor2D;
    }
}
