using UnityEngine ;
using UnityEngine.UI ;
using DG.Tweening ;

public class ModeSwitch : MonoBehaviour {
   [SerializeField] RectTransform uiHandleRectTransform ;
   [SerializeField] Color backgroundActiveColor ;
   [SerializeField] Color handleActiveColor ;

   Image backgroundImage, handleImage ;

   Color backgroundDefaultColor, handleDefaultColor ;

   Toggle toggle ;

   Vector2 handlePosition ;
   public GameObject[] objects;
   public GameObject cube;

   void Awake ( ) {
      toggle = GetComponent <Toggle> ( ) ;

      handlePosition = uiHandleRectTransform.anchoredPosition ;

      backgroundImage = uiHandleRectTransform.parent.GetComponent <Image> ( ) ;
      handleImage = uiHandleRectTransform.GetComponent <Image> ( ) ;

      backgroundDefaultColor = backgroundImage.color ;
      handleDefaultColor = handleImage.color ;

      toggle.onValueChanged.AddListener (OnSwitch) ;

      if (toggle.isOn)
         OnSwitch (true) ;
   }

   void OnSwitch (bool on) {
      
      uiHandleRectTransform.DOAnchorPos (on ? handlePosition * -1 : handlePosition, .4f).SetEase (Ease.InOutBack) ;
      
      foreach (GameObject images in objects){
      images.SetActive (on ? false : true);
      }
      
      
      cube.SetActive (on ? true : false);
      
     
   }

   void OnDestroy ( ) {
      toggle.onValueChanged.RemoveListener (OnSwitch) ;
   }
}