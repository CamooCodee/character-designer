using System;

public static class SceneElementCategoryExtensions
{
    public static int GetSceneElementCategory(this string spriteName) => 
        Convert.ToInt32(spriteName.Split('_')[1]);

    public static bool WorksWithAnything(this int category) =>
        category == 0;
}