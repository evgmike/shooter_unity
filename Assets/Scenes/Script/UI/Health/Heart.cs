using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]


public class Heart : MonoBehaviour
{

   [SerializeField] private float _lerpDuration; 

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.fillAmount = 1;

    }



    public void ToFill() {
        StartCoroutine(Filling(0,1, _lerpDuration, Fill));
    }

    public void ToEmpty() {
        StartCoroutine(Filling(1,0, _lerpDuration, Destroy));
    }

    private IEnumerator Filling(float startVal, float endVal, float duration, UnityAction<float> lerpingEnd) {

        float elapsed = 0;
        float nextVal ;


        while (elapsed < duration) {

            nextVal = Mathf.Lerp(startVal, endVal, elapsed / duration);

            _image.fillAmount = nextVal;
            elapsed += Time.deltaTime;

            yield return null;

        }

        lerpingEnd?.Invoke(endVal);

    }



    private void Destroy(float value) {

        _image.fillAmount = value;
        Destroy(gameObject);
    }

    private void Fill(float value) {

        _image.fillAmount = value;
    }

}
