using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMoover : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _stepSize;
    [SerializeField] private float _stepSizeHorizont;
    [SerializeField] private float _maxHeigth;
    [SerializeField] private float _minHeigth;

    [SerializeField] private float _maxWidth;
    [SerializeField] private float _minWidth;

    

    private Rigidbody2D _rigitBody;

    private Vector3 _targetPosition;


    private void Start()
    {

        Debug.Log(new Vector2(0.2f, -0.5f).normalized);

        _targetPosition = transform.position;
        _rigitBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
       // _rigitBody.velocity = new Vector3(_moveSpeed, _rigitBody.velocity.y, 0);

        // Debug.Log(_targetPosition);
        //if (transform.position != _targetPosition)
        // transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
    }


    public void TryMoveUp() {
      
      //  if(_targetPosition.y < _maxHeigth)

            _rigitBody.velocity = new Vector3(_moveSpeed, _rigitBody.velocity.y, 0);
    }
    public void TryMoveDown() {
      
      //  if (_targetPosition.y > _minHeigth)
            _rigitBody.velocity = new Vector3(_rigitBody.velocity.x, -_moveSpeed, 0);
    }


    public void TryMoveLeft()
    {
        
        Debug.Log(_targetPosition.x +" = "+ _minWidth);
        //if (_targetPosition.x > _minWidth)
            SetNextPositionHorizontal(-_stepSizeHorizont);
    }
    public void TryMoveRight()
    {
      

        _rigitBody.velocity = new Vector3(_moveSpeed, _rigitBody.velocity.y, 0);
    }



    private void SetNextPositionVertical(float _stepSize) {

        _rigitBody.velocity = new Vector3(_moveSpeed, 0, 0);

       // _targetPosition = new Vector2(_targetPosition.x, _targetPosition.y + _stepSize);

    }
    
    private void SetNextPositionHorizontal(float _stepSizeHorizont) {

      //  _targetPosition = new Vector2(_targetPosition.x + _stepSizeHorizont, _targetPosition.y);

    }


    public void VelocityStop() {

        _rigitBody.velocity = new Vector3(0, 0, 0);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(eventData + "Игровой объект нажат!");
    }
}
