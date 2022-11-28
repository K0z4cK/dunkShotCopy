using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Toggle : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    AudioSource audioSource;

    private bool _isOn;

    private void Awake()
    {
        _isOn = true;
        this.GetComponent<Slider>().value = _isOn == true ? 0 : 1;
        audioSource = GetComponent<AudioSource>();
    }

    public void SetStartValue(bool value)
    {
        _isOn = value;
        this.GetComponent<Slider>().value = _isOn == true ? 0 : 1;

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _isOn = !_isOn;
        this.GetComponent<Slider>().value = _isOn == true ? 0 : 1;
        audioSource.Play();
    }
    
}
