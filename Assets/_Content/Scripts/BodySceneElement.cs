using System;
using UnityEngine;

public class BodySceneElement : SceneElement
{
    [SerializeField] private SceneElement[] dependentElements;

    private int _bodyCategory;
    
    private void Start()
    {
        UpdateBodyCategory();
        SetDependentElementsToBodyCategory();
    }

    protected override void UpdateSceneElement()
    {
        base.UpdateSceneElement();
        int prev = _bodyCategory;
        UpdateBodyCategory();
        if(prev != _bodyCategory)
            SetDependentElementsToBodyCategory();
    }

    private void UpdateBodyCategory()
    {
        _bodyCategory = image.sprite.name.GetSceneElementCategory();
    }

    private void SetDependentElementsToBodyCategory()
    {
        foreach (var element in dependentElements) 
            element.SetElementCategory(_bodyCategory);
    }
}
