using System.IO;
using UnityEditor;
using UnityEngine;

public static class LukasSacherMenu
{
    [MenuItem("Sacher Solutions/Blank Project Setup/Generate Folders")]
    public static void CreateProjectFolderStructure()
    {
        var root = CreateProjFolder(Application.dataPath, "_Content");
        CreateProjFolder(root, "Prefabs");
        var scripts = CreateProjFolder(root, "Scripts");
        CreateProjFolder(scripts, "UI");
        CreateProjFolder(scripts, "Editor");
        var art = CreateProjFolder(root, "Art");
        var visualArt = CreateProjFolder(art, "Visual");
        CreateProjFolder(visualArt, "UI");
        CreateProjFolder(visualArt, "Game");
        CreateProjFolder(art, "Audio");
        CreateProjFolder(root, "UI-Toolkit");
        AssetDatabase.Refresh();
    }

    private static string CreateProjFolder(string basePath, string folder)
    {
        var dir = Path.Combine(basePath, folder);
        Directory.CreateDirectory(dir);
        return dir;
    }
}
