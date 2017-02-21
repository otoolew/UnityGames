using UnityEngine;

namespace UnitySampleAssets.Vehicles.Ball
{
    public class BallUserControl : MonoBehaviour
    {
        private Ball ball; // Reference to the ball controller.

        private Vector3 move; // the world-relative desired move direction, calculated from the camForward and user input.     
        private bool jump; // whether the jump button is currently pressed

        private void Awake()
        {
            // Set up the reference.
            ball = GetComponent<Ball>();           
        }

        private void Update()
        {
            // Get the axis and jump input.
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            jump = Input.GetButton("Jump");        
            // we use world-relative directions in the case of no main camera
            move = (v * Vector3.forward + h * Vector3.right).normalized;            
        }

        private void FixedUpdate()
        {
            // Call the Move function of the ball controller 
            ball.Move(move, jump);
            jump = false;
        }
    }
}