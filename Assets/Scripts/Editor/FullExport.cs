using UnityEditor;
using UnityEngine;

public class FullExport : MonoBehaviour
{


    [MenuItem("Tools/Full Export")]
    private static void NewMenuOption()
    {
        string fileName = "FullProject_Export.unitypackage";
        AssetDatabase.ExportPackage("Assets", fileName, ExportPackageOptions.Interactive | ExportPackageOptions.Recurse | ExportPackageOptions.IncludeLibraryAssets | ExportPackageOptions.IncludeDependencies);
        Debug.Log(fileName + " is located in this projects root folder");
    }
}