using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class NonSelectButton : MonoBehaviour
{
    private Button _button;
    
    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(DeselectButton);
    }

    private void DeselectButton()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }
}