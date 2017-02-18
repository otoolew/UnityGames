using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed = 6f;
    Vector3 movement;
    Rigidbody rigBody;
    CapsuleCollider scopeCollider;              
    float deltaTime = 0.0f;        
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 15f;
    public float sensitivityY = 15f;
    public float minimumX = -360f;
    public float maximumX = 360f;
    public float minimumY = -60f;
    public float maximumY = 60f;
    float rotationY = 0f;
    UnityEngine.GameObject tunnel;
    bool tunnelCollide;
    void Awake()
    {
        rigBody = GetComponent<Rigidbody>();
        scopeCollider = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        if (axes == RotationAxes.MouseXAndY)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        else if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        }
    }

    void FixedUpdate()
    {      
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");   
        Move(horizontal, vertical);
    }

    void OnTriggerEnter(Collider other)
    {       
        if (other.gameObject == tunnel)
        {
            Debug.Log("Scope Hit Wall!");       
            tunnelCollide = true;
        }
    }


    void OnTriggerExit(Collider other)
    {      
        if (other.gameObject == tunnel)
        {           
            tunnelCollide = false;
        }
    }

    void Move(float h, float v)
    {
        // Set the movement vector based on the axis input.
        movement.Set(h, v, 0f);

        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        rigBody.MovePosition(transform.position + movement);
    }

    void OnGUI()
    {
        int w = Screen.width;
        int h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperRight;
        style.fontSize = h * 2 / 100;
        //10, 10, 70, 30
        style.normal.textColor = new Color(10f, 10f, 70f, 30f);
        Vector3 xRot = rigBody.transform.eulerAngles;
        string text = string.Format("{0}", xRot);
        GUI.Label(rect, text, style);
    }


}
