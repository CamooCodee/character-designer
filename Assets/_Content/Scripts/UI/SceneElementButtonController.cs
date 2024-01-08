using System;
using UnityEngine;
using UnityEngine.UI;

public enum ButtonAction
{
    Increment,
    Decrement
}

[RequireComponent(typeof(Button))]
public class SceneElementButtonController : MonoBehaviour
{
    [SerializeField] private ButtonAction action;
    private SceneElement _targetElement;
    private SceneElementSprites _elementSprites;
    private Button _button;

    private void Awake() => 
        _button = GetComponent<Button>();

    public void Initialize(SceneElement element)
    {
        _targetElement = element;
    }

    private void OnEnable() => _button.onClick.AddListener(HandleButtonClicked);
    private void OnDisable() => _button.onClick.RemoveListener(HandleButtonClicked);

    private void HandleButtonClicked()
    {
        switch (action)
        {
            case ButtonAction.Increment:
                Increment();
                break;
            case ButtonAction.Decrement:
                Decrement();
                break;
        }
    }

    private void Increment() => 
        _targetElement.SetNextElement();

    private void Decrement() => 
        _targetElement.SetPreviousElement();
}
