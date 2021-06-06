using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwervingController : MonoBehaviour
{

    [SerializeField] float _forwardSpeed = 5f;
    [SerializeField] float _lerpSpeed = 5f;
    [SerializeField] float _playerXValue = 2f;
    [SerializeField] Vector2 _clampValues = new Vector2(-3, 3);
    private Rigidbody _rb;
    public static float _newXPos;
    private float _startXPos;
    private float distance;
    private Vector3 _lastTouchPos;
    private Vector3 _deltaPos;

    public static bool AllowedToMove = true;
    public static bool ReturZero = false;


    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _startXPos = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Vector3 currentPos = Input.mousePosition;
            if (_lastTouchPos == Vector3.zero)
                _lastTouchPos = currentPos;
            _deltaPos = currentPos - _lastTouchPos;
            _lastTouchPos = currentPos;
            Vector3 force = new Vector3(_deltaPos.x, 0, 0);
            _newXPos = Mathf.Clamp(transform.position.x + force.x * _playerXValue, _startXPos + _clampValues.x, _startXPos + _clampValues.y);
        }
        else
            _lastTouchPos = Vector2.zero;


    }
    private void FixedUpdate()
    {

        if (StartCountdown.CountownOver)
        {
            distance = Vector3.Distance(Vector3.zero, transform.position);
            if (distance > 10)
            {
                Time.timeScale = (1 + (distance / 100));
            }
            else
            {
                Time.timeScale = 1;
            }
            if (AllowedToMove)
            {
                _rb.MovePosition(new Vector3(Mathf.Lerp(transform.position.x, _newXPos, _lerpSpeed * Time.fixedDeltaTime), _rb.velocity.y, transform.position.z + _forwardSpeed * Time.fixedDeltaTime));

            }

        }
        if (ReturZero)
        {
            this.gameObject.transform.position = Vector3.zero;
            ReturZero = false;
            _newXPos = 0;
        }
    }

    
}
