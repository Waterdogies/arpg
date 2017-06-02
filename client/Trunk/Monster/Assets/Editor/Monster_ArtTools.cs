using UnityEditor;
using UnityEditor.SceneManagement;

public class Monster_ArtTools
{
    [MenuItem("Tools/Art/OpenPreLoadScene %H", false)]
    public static void OpenPreloadScene()
    {
        if (EditorApplication.isPlaying)
            return;
        EditorSceneManager.OpenScene("Assets/Scenes/Preload.unity");
        EditorApplication.isPlaying = true;
    }
}
