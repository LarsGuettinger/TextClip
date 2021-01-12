using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Timeline;
using Unity.Collections;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class ClipTextSOInspector : OdinMenuEditorWindow
    {
        [MenuItem("Custom/ClipTextInspector")]
        public static void ShowWindow()
        {
            var window = GetWindow<ClipTextSOInspector>();
            window.titleContent = new GUIContent("Clip Text Inspector");
            window.Show();
        }

        private void OnFocus()
        {
            BuildMenuTree();
        }

        protected override OdinMenuTree BuildMenuTree()
        {
            OdinMenuTree tree = new OdinMenuTree(supportsMultiSelect: true) { };

            var sos = AssetDatabase.FindAssets("t:ClipTextSO");


            foreach (var so in sos)
            {
                string path = AssetDatabase.GUIDToAssetPath(so);
                ClipTextSO clipTextSo = (ClipTextSO) AssetDatabase.LoadAssetAtPath(path, typeof(ClipTextSO));
                tree.Add(path.Replace(".asset", ""), clipTextSo);
            }

            return tree;
        }
    }
}

//     [SerializeField] private Tree tree = new Tree();
//
//     [MenuItem("Custom/ClipTextInspector")]
//     private static void ShowWindow()
//     {
//         var window = GetWindow<ClipTextSOInspector>();
//         window.titleContent = new GUIContent("Clip Text Inspector");
//         window.Show();
//     }
//
//     private void OnGUI()
//     {
//     }
//
//     private void OnFocus()
//     {
//         var sos = AssetDatabase.FindAssets("t:ClipTextSO");
//         foreach (var so in sos)
//         {
//             string path = AssetDatabase.GUIDToAssetPath(so);
//             var dirs = path.Split('/');
//             for (int i = 0; i < dirs.Length; i++)
//             {
//                 if (!tree.ExistsOnDepth(0, dirs[i]))
//                     tree.CreateOnDepth(0, dirs[i]);
//             }
//         }
//     }
// }
//
// [Serializable]
// public class Tree
// {
//     [SerializeField] List<Folder> folders = new List<Folder>();
//
//     public Folder Create(string folderName)
//     {
//         var folder = new Folder(folderName);
//         folders.Add(folder);
//         return folder;
//     }
//     
//     public Folder CreateOnDepth(int depth, string folderName)
//     {
//         return depth == 0 ? Create(folderName) : folders.First(x => x.FolderName == folderName);
//     }
//
//     private bool Exists(string folderName)
//     {
//         return folders.Exists(x => x.FolderName == folderName);
//     }
//
//     public bool ExistsOnDepth(int depth, string folderName)
//     {
//         if (depth == 0)
//             return Exists(folderName);
//         else
//         {
//             depth--;
//             return folders.Exists(x => x.ExistsOnDepth(depth, folderName));
//         }
//     }
// }
//
// [Serializable]
// public class Folder
// {
//     [SerializeField, ReadOnly] private string folderName;
//     [SerializeField] public string FolderName => folderName;
//
//     List<Folder> folders = new List<Folder>();
//     [SerializeField] List<string> fileNames = new List<string>();
//
//     public Folder(string folderName)
//     {
//         this.folderName = folderName;
//     }
//
//     public Folder Create(string folderName)
//     {
//         var folder = new Folder(folderName);
//         folders.Add(folder);
//         return folder;
//     }
//     
//     public Folder CreateOnDepth(int depth, string folderName)
//     {
//         return depth == 0 ? Create(folderName) : folders.First(x => x.FolderName == folderName);
//     }
//
//     private bool Exists(string folderName)
//     {
//         return folders.Exists(x => x.folderName == folderName);
//     }
//
//     public bool ExistsOnDepth(int depth, string folderName)
//     {
//         if (depth == 0)
//             return Exists(folderName);
//         else
//         {
//             depth--;
//             return folders.Exists(x => x.ExistsOnDepth(depth, folderName));
//         }
//     }