using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(RawImage))]

public class Paralax : MonoBehaviour
{

    [SerializeField] private float _speed;

    private RawImage _image;

    private float _imagePositionX;
    
    void Start()
    {

        _image = GetComponent<RawImage>();

    }

    
    void Update()
    {
        if (_imagePositionX > 1)
            _imagePositionX = 0;

        _imagePositionX += _speed * Time.deltaTime;
        _image.uvRect = new Rect(_imagePositionX,0, _image.uvRect.width, _image.uvRect.height);

    }
}
