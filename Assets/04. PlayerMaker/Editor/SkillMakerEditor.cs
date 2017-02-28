using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class SkillMakerEditor : EditorWindow {
    //[System.Serializable]
    public class Skill
    {
        public string Name;
        public float UseDistance;
        public float CooldownDuration;
        public float Cooldown;
        public float CastingDuration;
        public float Casting;
        public Sprite Icon;
    }

    public List<Skill> skills = new List<Skill>();

    Classes.Name ClassesKind;
    Vector2 ScrollPosition;
    GameObject skillBook;
    GameObject castingBar;

    [MenuItem("Game Editor/Make Skills")]
    static public void ShowWindow()
    {
        EditorWindow window = (SkillMakerEditor)GetWindow(typeof(SkillMakerEditor));
        window.titleContent = new GUIContent("Skill Setting");
        window.Show();
    }

    void OnGUI()
    {
        EditorGUILayout.HelpBox("Simple dynamic list editor.\nPress Enter to apply field changes.", MessageType.Info);

        EditorGUILayout.BeginVertical();
        {
            ScrollPosition = EditorGUILayout.BeginScrollView(ScrollPosition);
            ClassesKind   = (Classes.Name)EditorGUILayout.EnumPopup("Classes", ClassesKind);

            foreach (Skill val in skills)
            {
                EditorGUILayout.BeginVertical();
                {
                    EditorGUILayout.BeginHorizontal();
                    {
                        EditorGUILayout.BeginVertical();
                        {
                            val.Name = EditorGUILayout.TextField("Name", val.Name);
                            val.UseDistance = EditorGUILayout.FloatField("UseDistance", val.UseDistance);
                            val.CooldownDuration = EditorGUILayout.FloatField("CooldownDuration", val.CooldownDuration);
                            val.Cooldown = EditorGUILayout.FloatField("Cooldown", val.Cooldown);
                            val.CastingDuration = EditorGUILayout.FloatField("CastingDuration", val.CastingDuration);
                            val.Casting = EditorGUILayout.FloatField("CastingTime", val.Casting);
                        }
                        EditorGUILayout.EndVertical();
                        val.Icon = (Sprite)EditorGUILayout.ObjectField("Sprite", val.Icon, typeof(Sprite), false);
                    }
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                }
                EditorGUILayout.EndVertical();
            }
        }

        if (GUILayout.Button("Add Skill"))
        {
            skills.Add(new Skill());
        }

        if (GUILayout.Button("Create Skill"))
        {
            GameObject skillCanvas = PrefabLoader.LoadPrefab(PrefabLoader.cSkills, "SkillCanvas");
            skillBook = PrefabLoader.LoadPrefab(PrefabLoader.cSkills, "SkillBook");
            GameObject skillWindow = PrefabLoader.LoadPrefab(PrefabLoader.cSkills, "SkillWindow");
            GameObject cooldownManager = PrefabLoader.LoadPrefab(PrefabLoader.cSkills, "CooldownManager");
            castingBar = PrefabLoader.LoadPrefab(PrefabLoader.cSkills, "CastingBar");

            skillCanvas.AddChild(skillBook, new Vector3(-150f, 78, 0), new Vector2(682, 462));
            skillCanvas.AddChild(skillWindow);
            skillCanvas.AddChild(cooldownManager);
            skillCanvas.AddChild(castingBar);

            for (int i = 0; i < skills.Count; i++)
            {
                GameObject skillObject = PrefabLoader.LoadPrefab(PrefabLoader.cSkills, "SkillObject");
                skillObject.GetComponent<Image>().sprite = skills[i].Icon;
                skillObject.GetComponent<Button>().image.sprite = skills[i].Icon;
                skillObject.GetComponent<Button>().onClick.AddListener(skillObject.GetComponent<CoolDown>().StartCoolDown);
                skillObject.GetComponent<CoolDown>().icon = skillObject.GetComponent<Image>();
                skillObject.GetComponent<CoolDown>().duration = skills[i].CooldownDuration;
                skillObject.GetComponent<CoolDown>().cooldown = 0f;
                skillObject.GetComponent<CoolDown>().castingBar = castingBar.GetComponent<Slider>();
                skillObject.GetComponent<CoolDown>().castingDuration = skills[i].CastingDuration;
                skillObject.GetComponent<CoolDown>().castingTime = 0f;
                skillObject.transform.GetChild(0).GetComponentInChildren<Image>().sprite = skills[i].Icon;

                skillBook.AddChild(skillObject);
            }
        }
        EditorGUILayout.EndScrollView();
        EditorGUILayout.EndVertical();
    }
}
