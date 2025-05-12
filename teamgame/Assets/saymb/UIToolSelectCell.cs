using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EToolType { 

    None = 0,
    Ship = 1,
}

public class UIToolSelectCell : MonoBehaviour
{
    [SerializeField]
    private Button btn;

    [SerializeField]
    private EToolType toolType;

    public delegate void OnButtonClickCallback(EToolType toolType);
    public event OnButtonClickCallback OnButtonClick;

    public void SetButtonClickCallback(OnButtonClickCallback callback) => OnButtonClick = callback;

    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(() => {
            OnButtonClick?.Invoke(toolType);
            this.btn.interactable = false;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// interactable ‚ÌƒŠƒZƒbƒg
    /// </summary>
    public void ResetButtonInteractable()
    {
        this.btn.interactable = true;
    }
}
