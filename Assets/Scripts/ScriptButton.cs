using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptButton : MonoBehaviour
{
    public string MainMenu;
    public string MenuMulai;
    public string MenuPanduan;
    public string MenuTentang;

    public void gotoMainMenu() {
        Application.LoadLevel(MainMenu);
    }

    public void gotoMenuMulai() {
        Application.LoadLevel(MenuMulai);
    }

    public void gotoMenuPanduan() {
        Application.LoadLevel(MenuPanduan);
    }
    
    public void gotoMenuTentang() {
        Application.LoadLevel(MenuTentang);
    }

    public void exitApplication() {
        Application.Quit();
    }

    public void gotoGithubPage() {
        Application.OpenURL("https://github.com/glenaldinlim");
    }
}
