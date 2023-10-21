using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIView : MonoBehaviour
{
    [SerializeField] private Text _resourceText;

    public void SetCurrentResource(int value)
    {
        _resourceText.text = value.ToString();
    }
}
