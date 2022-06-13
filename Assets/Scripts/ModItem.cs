using UnityEngine;
using UnityEngine.UI;
using ModTool;

public class ModItem : MonoBehaviour {

    public Text modName;
    public Text modType;
    public Mod mod;

	public void Initialize(Mod mod, Transform menuContentPanel)
    {
        this.mod = mod;

        transform.SetParent(menuContentPanel);

        modName.text = mod.name;
        modType.text = mod.contentType.ToString();
    }   
}
