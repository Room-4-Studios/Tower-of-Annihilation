using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Mode : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private bool _isOn = false;
    public bool isOn
    {
        get
        {
            return _isOn;
        }
    }

    public delegate void ValueChanged(bool value);
    public event ValueChanged valueChanged;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Toggle(bool value)
    {
        if(value != isOn)
        {
            _isOn = value;
            
            if(valueChanged != null)
            {
                valueChanged(isOn);
                Debug.Log("Value Changed!");
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Toggle(!isOn); //flip the switch when clicked
    }
}
