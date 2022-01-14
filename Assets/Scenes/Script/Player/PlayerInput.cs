using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerMoover))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMoover _mover;

    void Start()
    {

        _mover = GetComponent<PlayerMoover>();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _mover.TryMoveUp();
        }
        else if (Input.GetKeyDown(KeyCode.S))
            _mover.TryMoveDown();


        if (Input.GetKeyDown(KeyCode.A))
        {
            _mover.TryMoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.D))
            _mover.TryMoveRight();



       


    }
}
