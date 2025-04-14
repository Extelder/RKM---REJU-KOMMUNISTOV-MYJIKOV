/*****************************************************
Copyright © 2025 Michael Kremmel
https://www.michaelkremmel.de
All rights reserved
*****************************************************/
#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Configuration = MK.Toon.Editor.InstallWizard.Configuration;
using System.Text;
using UnityEditor.PackageManager.UI;

namespace MK.Toon.Editor
{
    public sealed class VariantsManager : UnityEditor.EditorWindow
    {
        private static GUIStyle _flowTextStyle { get { return new GUIStyle(EditorStyles.label) { wordWrap = true }; } }
        
        public static string UnifyPath(string path)
        {
            #if UNITY_EDITOR_WIN
            return path.Replace("\\", "/");
            #else
            return path;
            #endif
        }

        private static StringBuilder _projectPath = new StringBuilder("");
        private static string projectPath
        {
            get
            {   
                if(_projectPath.ToString() == string.Empty)
                {
                    _projectPath = new StringBuilder(UnityEngine.Application.dataPath);
                    _projectPath.Remove(_projectPath.Length - 7, 7);

                    _projectPath.Append("/");
                    _projectPath = new StringBuilder(UnifyPath(_projectPath.ToString()));
                }
                return _projectPath.ToString();
            }
        }

        private static bool _requiresUpdate = true;

        private static VariantsManager _window;
        private static readonly Vector2Int _referenceResolution = new Vector2Int(2560, 1440);
        private static float _sizeScale;
        private static int _scaledWidth;
        private static int _scaledHeight;
        private static Vector2 _windowScrollPos;

        private static readonly int _rawWidth = 360;
        private static readonly int _rawHeight = 535;
        private static readonly string _title = "MK Toon Variants Manager";

        private static readonly VariantSet[] _variantSets = new VariantSet[]
        {
            new VariantSet("Albedo Map", "__ _MK_ALBEDO_MAP"),
            new VariantSet("Surface Type", "__ _MK_SURFACE_TYPE_TRANSPARENT"),
            new VariantSet("Alpha Clip", "__ _MK_ALPHA_CLIPPING"),
            new VariantSet("Alpha Blend Style", "__ _MK_BLEND_PREMULTIPLY _MK_BLEND_ADDITIVE _MK_BLEND_MULTIPLY"),
            new VariantSet("Emission Map", "__ _MK_EMISSION_MAP"),
            new VariantSet("Reflections", "__ _MK_ENVIRONMENT_REFLECTIONS_AMBIENT _MK_ENVIRONMENT_REFLECTIONS_ADVANCED"),
            new VariantSet("Heigt Map", "__ _MK_HEIGHT_MAP"),
            new VariantSet("Parallax", "__ _MK_PARALLAX"),
            new VariantSet("PBS Workflow", "__ _MK_WORKFLOW_SPECULAR _MK_WORKFLOW_ROUGHNESS"),
            new VariantSet("Workflow Map 0", "__ _MK_PBS_MAP_0"),
            new VariantSet("Workflow Map 1", "__ _MK_PBS_MAP_1"),
            new VariantSet("Specular (Simple)", "__ _MK_SPECULAR_ISOTROPIC"),
            new VariantSet("Specular (PBS)", "__ _MK_SPECULAR_ISOTROPIC _MK_SPECULAR_ANISOTROPIC"),
            new VariantSet("Normal Map", "__ _MK_NORMAL_MAP"),
            new VariantSet("Detail Map", "__ _MK_DETAIL_MAP"),
            new VariantSet("Detail Blend", "__ _MK_DETAIL_BLEND_MIX _MK_DETAIL_BLEND_ADD"),
            new VariantSet("Detail Normal Map", "__ _MK_DETAIL_NORMAL_MAP"),
            new VariantSet("Light Transmission", "__ _MK_LIGHT_TRANSMISSION_TRANSLUCENT _MK_LIGHT_TRANSMISSION_SUB_SURFACE_SCATTERING"),
            new VariantSet("Thickness Map", "__ _MK_THICKNESS_MAP"),
            new VariantSet("Occlusion Map", "__ _MK_OCCLUSION_MAP"),
            new VariantSet("Receive Shadows", "__ _MK_RECEIVE_SHADOWS"),
            new VariantSet("Color Grading", "__ _MK_COLOR_GRADING_ALBEDO _MK_COLOR_GRADING_FINAL_OUTPUT"),
            new VariantSet("Rim (Forward Pass)", "__ _MK_RIM_DEFAULT _MK_RIM_SPLIT"),
            new VariantSet("Rim (Forward Add Pass)", "__ _MK_RIM_SPLIT"),
            new VariantSet("Light Style", "__ _MK_LIGHT_CEL _MK_LIGHT_BANDED _MK_LIGHT_RAMP"),
            new VariantSet("Threshold Map", "__ _MK_THRESHOLD_MAP"),
            new VariantSet("Artistic Style", "__ _MK_ARTISTIC_DRAWN _MK_ARTISTIC_HATCHING _MK_ARTISTIC_SKETCH"),
            new VariantSet("Artistic Projection", "__ _MK_ARTISTIC_PROJECTION_SCREEN_SPACE"),
            new VariantSet("Artistic Stutter", "__ _MK_ARTISTIC_ANIMATION_STUTTER"),
            new VariantSet("Vertex Animation", "__ _MK_VERTEX_ANIMATION_SINE _MK_VERTEX_ANIMATION_PULSE _MK_VERTEX_ANIMATION_NOISE"),
            new VariantSet("Vertex Animation Stutter", "__ _MK_VERTEX_ANIMATION_STUTTER"),
            new VariantSet("Vertex Animation Map", "__ _MK_VERTEX_ANIMATION_MAP"),
            new VariantSet("Dissolve", "__ _MK_DISSOLVE_DEFAULT _MK_DISSOLVE_BORDER_COLOR _MK_DISSOLVE_BORDER_RAMP"),
            new VariantSet("Diffuse Style", "__ _MK_DIFFUSE_OREN_NAYAR _MK_DIFFUSE_MINNAERT"),
            new VariantSet("Iridescence", "__ _MK_IRIDESCENCE_DEFAULT"),
            new VariantSet("Gooch Bright Map", "__ _MK_GOOCH_BRIGHT_MAP"),
            new VariantSet("Gooch Dark Map", "__ _MK_GOOCH_DARK_MAP"),
            new VariantSet("Gooch Ramp", "__ _MK_GOOCH_RAMP"),
            new VariantSet("Wrapped Diffuse", "__ _MK_WRAPPED_DIFFUSE")
        };

        [MenuItem("Window/MK/Toon/Variants Manager")]
        private static void ShowWindow()
        {
            if(Screen.currentResolution.height > Screen.currentResolution.width)
                _sizeScale = (float) Screen.currentResolution.width / (float)_referenceResolution.x;
            else
                _sizeScale = (float) Screen.currentResolution.height / (float)_referenceResolution.y;

            _scaledWidth = (int)((float)_rawWidth * _sizeScale);
            _scaledHeight = (int)((float)_rawHeight * _sizeScale);
            _window = (VariantsManager) EditorWindow.GetWindow<VariantsManager>(true, _title, true);

            _window.minSize = new Vector2(_scaledWidth, _scaledHeight);
            _window.maxSize = new Vector2(_scaledWidth * 2, _scaledHeight * 2);

            _requiresUpdate = true;

            _window.Show();
        }

        private void UpdateShaderFile(UnityEngine.Object shaderFile)
        {
            StringBuilder buffer = new StringBuilder();
            
            string localAssetPath = AssetDatabase.GetAssetPath(shaderFile);
            string filePath = string.Concat(projectPath, localAssetPath);
            
            if(!System.IO.File.Exists(filePath))
                return;

            using (System.IO.StreamReader reader = new System.IO.StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    for(int i = 0; i < _variantSets.Length; i++)
                    {
                        line = _variantSets[i].ModifyVariant(line);
                    }
                    buffer.AppendLine(line);
                }
            }
            System.IO.File.WriteAllText(filePath, buffer.ToString());
            AssetDatabase.ImportAsset(localAssetPath);
            AssetDatabase.Refresh();
        }

        private void LoadVariantSets(UnityEngine.Object shaderFile)
        {            
            string localAssetPath = AssetDatabase.GetAssetPath(shaderFile);
            string filePath = string.Concat(projectPath, localAssetPath);
            
            if(!System.IO.File.Exists(filePath))
                return;

            using (System.IO.StreamReader reader = new System.IO.StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    for(int i = 0; i < _variantSets.Length; i++)
                    {
                        _variantSets[i].LoadVariantState(line);
                    }
                }
            }
        }
        
        private void OnGUI()
        {
            if(Configuration.isReady)
            {
                if(_requiresUpdate)
                {
                    UnityEngine.Object[] shaderFiles = Configuration.ReceiveShaderFiles();
                    for(int i = 0; i < shaderFiles.Length; i++)
                    {
                        EditorUtility.DisplayProgressBar("MK Toon Variants Manager", "Load variant sets...", 1.0f / shaderFiles.Length * i);
                        LoadVariantSets(shaderFiles[i]);
                    }
                    EditorUtility.ClearProgressBar();
                    _requiresUpdate = false;
                }

                EditorGUILayout.LabelField("Shader variants forced into the build", UnityEditor.EditorStyles.boldLabel);
                EditorGUILayout.LabelField("If you force shader variants into a build keep in mind the compile times and build size may increase.", _flowTextStyle);
                EditorGUILayout.LabelField("Changes here has to be re-done after updating the package.", _flowTextStyle);

                Divider();

                _windowScrollPos = EditorGUILayout.BeginScrollView(_windowScrollPos);

                for(int i = 0; i < _variantSets.Length; i++)
                {
                    _variantSets[i].DrawEditor();
                }
                EditorGUILayout.EndScrollView();

                Divider();

                if(GUILayout.Button("Update Shader's"))
                {
                    UnityEngine.Object[] shaderFiles = Configuration.ReceiveShaderFiles();
                    for(int i = 0; i < shaderFiles.Length; i++)
                    {
                        EditorUtility.DisplayProgressBar("MK Toon Variants Manager", "Updading shader files...", 1.0f / shaderFiles.Length * i);
                        UpdateShaderFile(shaderFiles[i]);
                    }
                    EditorUtility.ClearProgressBar();
                }
                GUI.FocusControl(null);
            }
            else
            {
                Repaint();
            }
        }

        private static void Divider()
        {
            GUILayout.Box("", new GUILayoutOption[] { GUILayout.ExpandWidth(true), GUILayout.Height(2) });
        }
    }
}
#endif