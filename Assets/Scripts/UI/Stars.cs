using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stars : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _starsText;
    void Awake()
    {
        UIManager.Instance.starsUpdate.AddListener(UpdateStars);
    }
    private void UpdateStars(string newStars)
    {
        _starsText.text = newStars;
    }
}
