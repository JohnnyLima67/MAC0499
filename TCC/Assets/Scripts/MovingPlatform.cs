using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




// Different types of movements for the platform
public enum MovementType {
    line,
    circular,
    zigzag
};

// Movement orientation for line movement type
public enum LineMovementOrientation {
    horizontal,
    vertical
}

// Movement orientation for circular movement type
public enum CircularMovementOrientation {
    clockwise,
    counterclockwise
}

public class MovingPlatform : MonoBehaviour
{

    // General vars (affect all types of movemens)
    
    [SerializeField]
    MovementType movementType;
    Vector3 startPosition;
    public Color gizmoColor = Color.yellow;

    Collision2D playerRef = null;

    // Line movement vars
        [Tooltip("Local offsets from starting position")]
        [SerializeField] private Vector2[] _points = new Vector2[] { Vector2.left, Vector2.right };
        [SerializeField] private float _speed = 1.5f;
        [SerializeField] private bool _looped;
        [SerializeField] private bool _ascending;

        private Vector2 _startPos;
        private Vector2 Target => _startPos + _points[_index];
        private int _index = 0;

    // Circle movement vars
    public CircularMovementOrientation circularMovementOrientation;
    public float circleRadius = 5f;

    // Zigzag movement vars
    public int zigzagLines = 4;
    public float zigzagLineDistance = 2;
    float zigzagStep;
    bool zigzagMovingPositive = true;

    // Start is called before the first frame update
    void Start()
    {
        // Set start position
        startPosition = this.transform.position;
        _startPos = this.transform.position;
        zigzagStep = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerRef != null)
        {
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                playerRef.transform.SetParent(null);
            }
            else
            {
                playerRef.transform.SetParent(transform);
            }
        }

        // Manage how the platform have to move according to movementType var
        switch (movementType) {
            case MovementType.line:
                moveInAStraightLine();
            break;
            case MovementType.circular:
                MoveInCircles();
            break;
            case MovementType.zigzag:
                MoveInZigzag();
            break;
        }
    }


    // Move the platform in a straight line in movementOrientation
    public void moveInAStraightLine() 
    {
        if ((Vector2)transform.position == Target){
            if (_looped)
                _index = (_ascending ? _index + 1 : _index + _points.Length - 1) % _points.Length;
            else { // ping-pong
                if (_index >= _points.Length - 1) _ascending = false;
                else if (_index <= 0) _ascending = true;
                _index = Mathf.Clamp(_index + (_ascending ? 1 : -1), 0, _points.Length - 1);
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, Target, _speed * Time.fixedDeltaTime);
    
    }

    public void MoveInCircles() 
    {
        // Calculating direction (CW or CCW)
        int direction = (circularMovementOrientation == CircularMovementOrientation.counterclockwise)?1:-1;

        // Calculating coordenates 
        float x = startPosition.x + Mathf.Cos(Time.time * _speed * direction) * circleRadius;
        x -= circleRadius;
        float y = startPosition.y + Mathf.Sin(Time.time * _speed * direction) * circleRadius;
        float z = transform.position.z;

        // Moving Platform
        this.transform.position = new Vector3(x,y,z);

    }


    public void MoveInZigzag() 
    {   
        // Changing direction when the platform reach the limits 
        if (transform.position.x >= startPosition.x + zigzagLineDistance * zigzagLines) {
            zigzagMovingPositive = false;
        } else if (transform.position.x <= startPosition.x) {
            zigzagMovingPositive = true;
        }

        // Calculating coordenates
        float factor = (Mathf.Acos(Mathf.Cos(zigzagStep * (float)Math.PI)) / (float)Math.PI);
        float x = startPosition.x + zigzagStep * zigzagLineDistance;
        float y = startPosition.y + factor * zigzagLineDistance;
        
        if (zigzagMovingPositive) {
            zigzagStep += _speed/50;
        } else {
            zigzagStep -= _speed/50;
        }

        // keep platform within the limits
        zigzagStep = Mathf.Clamp(zigzagStep, 0, zigzagLines);


        // Moving platform 
        this.transform.position = new Vector3(x,y);
    }

    // Funtion to see the platform path (only for debugging)
    private void OnDrawGizmos() {
        Gizmos.color = gizmoColor;
        Vector3 src = Vector3.zero;
        Vector3 dest = Vector3.zero;

        switch (movementType) {
            case MovementType.line:
                float lineDistanceX = _points[1].x - _points[0].x;
                src = new Vector3 (startPosition.x + lineDistanceX, startPosition.y);
                dest = new Vector3 (startPosition.x - lineDistanceX, startPosition.y); 
                Gizmos.DrawLine(src, dest);
                src = new Vector3 (startPosition.x, startPosition.y + _points[0].y);
                dest = new Vector3 (startPosition.x, startPosition.y - _points[0].y); 
                Gizmos.DrawLine(src, dest);
            break;
            case MovementType.circular:
                // Cicular movement 
                src = new Vector3(startPosition.x - circleRadius, startPosition.y);
                Gizmos.DrawWireSphere(src, circleRadius);
            break;
            case MovementType.zigzag:
                float x = startPosition.x;
                float y = startPosition.y;

                for(int i = 0; i < zigzagLines; i++){
                    
                    // Current position
                    src = new Vector3(x, y);
                    
                    // Calculating next position
                    x += zigzagLineDistance;

                    // If "i" is even draw line going up, else, draw line going down
                    // the zigzag movement always start going up
                    y = (i%2 == 0)?startPosition.y + zigzagLineDistance:startPosition.y;

                    dest = new Vector3(x,y);

                    // Drawing line
                    Gizmos.DrawLine(src, dest);

                }
            break;
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if (IsOnTop(col.GetContact(0).normal))
        {
            col.transform.SetParent(transform);
            playerRef = col;
        }
    }

    void OnCollisionExit2D(Collision2D col) {
        col.transform.SetParent(null);
        playerRef = null;
    }

    bool IsOnTop(Vector2 normal) => Vector2.Dot(transform.up, normal) < -0.5f;
}

