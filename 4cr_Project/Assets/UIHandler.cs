using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class UIHandler : MonoBehaviour
{
    private VisualElement m_Healthbar;
    public static UIHandler instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }
   void Start()
   {
       UIDocument uiDocument = GetComponent<UIDocument>();
       m_Healthbar = uiDocument.rootVisualElement.Q<VisualElement>("HealthBar");
       SetHealthValue(1.0f);
   }


   public void SetHealthValue(float percentage)
   {
       m_Healthbar.style.width = Length.Percent(100 * percentage);
   }


}