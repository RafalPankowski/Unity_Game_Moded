using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using ModTool;
using Game_DLL_RP;
using UnityEngine.SceneManagement;

public class ModMenu : MonoBehaviour
{
    private ModManager modManager;
    
    private Dictionary<Mod, ModItem> modItems;

    public Transform menuContentPanel;

    public ModItem modItemPrefab;
        
    void Start()
    {
        modItems = new Dictionary<Mod, ModItem>();
        
        modManager = ModManager.instance;

        modManager.refreshInterval = 2;

        foreach (Mod mod in modManager.mods)
            OnModFound(mod);

        modManager.ModFound += OnModFound;
        modManager.ModRemoved += OnModRemoved;
        modManager.ModLoaded += OnModLoaded;
        modManager.ModUnloaded += OnModUnloaded;
        
        Application.runInBackground = true;

        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    public void OnSceneLoaded(Scene s, LoadSceneMode mode)
    {
        Load();
    }

    public void OnSceneUnloaded(Scene s)
    {
        Unload();
    }

    private void OnModFound(Mod mod)
    {
        ModItem modItem = Instantiate(modItemPrefab);
        modItem.Initialize(mod, menuContentPanel);
        mod.isEnabled = true;
        modItems.Add(mod, modItem);
    }

    private void OnModRemoved(Mod mod)
    {
        ModItem modItem;

        if(modItems.TryGetValue(mod, out modItem))
        {
            modItems.Remove(mod);
            Destroy(modItem.gameObject);
        }
    }
 

    private void Load()
    {
        //load mods
        foreach (Mod mod in modItems.Keys)
        {
            if(mod.isEnabled)
                mod.LoadAsync();
        }
    }

    private void Unload()
    {   
        foreach (Mod mod in modItems.Keys)
        {
            mod.Unload();
        }
    }
    
    private void OnModLoaded(Mod mod)
    {
        Debug.Log("Loaded Mod: " + mod.name);
        ModScene scene = mod.scenes.FirstOrDefault();
        if (scene != null)
            scene.LoadAsync();       
    }

    private void OnModUnloaded(Mod mod)
    {
        Debug.Log("Unloaded Mod: " + mod.name);
    }
}