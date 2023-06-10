using System;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule
{
    public class FinishUI : MonoBehaviour
    {
        [SerializeField] private Button returnInMenuButton;

        public event Action ReturnToLevelSelectionButtonClicked;

        public void Init()
        {
            returnInMenuButton.onClick.AddListener( OnReturnSelectionLevelButtonClicked );
        }

        private void OnReturnSelectionLevelButtonClicked()
        {
            ReturnToLevelSelectionButtonClicked?.Invoke();
            gameObject.SetActive(false);
        }
    }
}