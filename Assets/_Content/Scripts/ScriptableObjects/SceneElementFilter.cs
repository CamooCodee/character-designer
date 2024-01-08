using UnityEngine;

public class SceneElementFilter
{
    public readonly int index;
    public readonly int category;

    public SceneElementFilter(int index, int category)
    {   
        this.index = index;
        this.category = category;
    }
    
    public static SceneElementFilter FromCharacterBody(Sprite body, int index)
    {
        var category = body.name.GetSceneElementCategory();
        return new SceneElementFilter(index, category);
    }
}