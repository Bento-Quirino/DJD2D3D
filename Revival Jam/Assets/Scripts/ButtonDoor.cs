using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 



public class ButtonDoor : MonoBehaviour
{
    [SerializeField] private Button ButtonClose; 
    [SerializeField] private Animator animator;

    private void Awake()
    {
        ButtonClose.onClick.AddListener(OnButtonClose);
    }

    private void OnButtonClose()
    {
        Close(); 
    }

    public void Close()
    {
        if (animator != null)
        {
            animator.SetTrigger("CloseTrigger"); 
        }
        else
        {
            Debug.LogError("Animator não está atribuído ao botão.");
        }
    }
}
/* if dick is erect
           {
               animate sex
           }
    }

    if broxa == 0
        {
         animate sex {
                        if sex == good= new broxa();
                     }      
        } */
