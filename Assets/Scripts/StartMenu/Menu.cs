using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Menu : MonoBehaviour
{

    protected static Stack<Menu> _nesting;

    public virtual void GotoMenu(Menu nextMenu)
    {
        if (_nesting == null)
        {
            _nesting = new Stack<Menu>();
        }

        Unload();
        nextMenu.Load();
        _nesting.Push(nextMenu);

    }
    public void Back()
    {
        _nesting.Pop().Unload();
        _nesting.Peek().Load();
    }
    public virtual void Load()
    {
        gameObject.SetActive(true);
    }
    public virtual void Unload()
    {
        gameObject.SetActive(false);
    }
}
