using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Heart _heartTemplate;

    private List<Heart> _hearts = new List<Heart>();

    private void OnEnable()
    {
        _player.HealthChanged += onHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= onHealthChanged;
    }

    private void onHealthChanged(int val)
    {
        if (_hearts.Count < val)
        {
            int createHealth = val - _hearts.Count;

            for (int i = 0; i < createHealth; i++)
            {
                CreateHeart();

            }


        }
        else if (_hearts.Count > val && _hearts.Count!=0)
        {
            int delHealth = _hearts.Count - val;

            for (int i = 0; i < delHealth; i++) {

                DestroyHeart(_hearts[_hearts.Count - 1]);
            }
               
        }
    }

    private void DestroyHeart(Heart heart)
    {
        _hearts.Remove(heart);
            heart.ToEmpty();
    }

    private void CreateHeart() {

        Heart newHeart = Instantiate(_heartTemplate, transform);

        _hearts.Add(newHeart.GetComponent<Heart>());

        newHeart.ToFill();



    }






}
