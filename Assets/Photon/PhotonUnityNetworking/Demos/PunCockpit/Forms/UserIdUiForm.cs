
// Adapted from the original file to work with TextMeshPro instead of Text components
// Michael Auß e00525937

// original copyright:
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserIdUiForm.cs" company="Exit Games GmbH">
//   Part of: Pun Cockpit Demo
// </copyright>
// <author>developer@exitgames.com</author>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.Events;
using TMPro;

namespace Photon.Pun.Demo.Cockpit.Forms
{
    /// <summary>
    /// User Id UI form.
    /// </summary>
    public class UserIdUiForm : MonoBehaviour
    {
        public const string UserIdPlayerPref = "PunUserId";
        public TMP_InputField idInputTmp;

        [System.Serializable]
        public class OnSubmitEvent : UnityEvent<string> { }

        public OnSubmitEvent OnSubmit;

        public void Start()
        {

            string prefsName = PlayerPrefs.GetString(UserIdUiForm.UserIdPlayerPref);
            if (!string.IsNullOrEmpty(prefsName))
            {
             //   this.idInput.text = prefsName;
                this.idInputTmp.text = prefsName;
            }
        }


        // new UI will fire "EndEdit" event also when loosing focus. So check "enter" key and only then StartChat.
        public void EndEditOnEnter()
        {
            if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
            {
                this.SubmitForm();
            }
        }

        public void SubmitForm()
        {
            PlayerPrefs.SetString(UserIdUiForm.UserIdPlayerPref, idInputTmp.text);
            OnSubmit.Invoke(idInputTmp.text); 
        }
    }
}