using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

public static class ImageDownloader
{
    [DllImport("__Internal")]
    private static extern void DownloadFile(byte[] array, int byteLength, string fileName);
    
    public static Texture2D Get(Camera camera, int width, int height, string name)
    {
        var renderTexture = new RenderTexture(width, height, 16);
        camera.targetTexture = renderTexture;
        RenderTexture.active = renderTexture;
        camera.Render();
        var texture = new Texture2D(width, height, TextureFormat.RGBA32, false) {name = name};
        texture.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        texture.Apply();
        RenderTexture.active = null;
        renderTexture.Release();
        return texture;
    }

    public static void DownloadFrame()
    {
        var cam = Camera.main;
        var texture = Get(cam, cam.pixelWidth, cam.pixelHeight, "screen");
        cam.targetTexture = null;
        byte[] textureBytes = texture.EncodeToPNG();
        DownloadFile(textureBytes, textureBytes.Length, "character.png");
        Object.Destroy(texture);
    }
}
