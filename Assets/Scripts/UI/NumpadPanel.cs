using System.Collections;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace Scripts.UI
{
    public class NumpadPanel : BaseUIWindow
    {

        [SerializeField] private Button primaryButton;
        [SerializeField] private TMP_Text _label;
        [SerializeField] private Image _spriteRenderer;

        [Header("Main")]
        [SerializeField] private string _code;
        [SerializeField] UnityEvent successesInput;
        [SerializeField] UnityEvent wrongInput;

        private int MaxCodeLength = 4;

        public void PickKey(string value)
        {
            if (_label.text.Length < MaxCodeLength)
            {
                _label.text += value;
            }
        }
        public void CheckCode()
        {
            if (_label.text == _code)
            {
                OnSuccesses();
            }
            else
            {
                wrongInput.Invoke();
                OnError();
            }
        }
        public void OnError()
        {
            StartCoroutine(AnimateHealing());

            IEnumerator AnimateHealing()
            {
                _spriteRenderer.color = new Color(0.7f, 0, 0);
                _label.text = "ERROR";
                yield return new WaitForSecondsRealtime(0.4f);
                _spriteRenderer.color = FromHex("589B25");
                Clean();
            }
        }
        public static Color FromHex(string hex)
        {
            if (hex.Length < 6)
            {
                throw new System.FormatException("Needs a string with a length of at least 6");
            }

            var r = hex.Substring(0, 2);
            var g = hex.Substring(2, 2);
            var b = hex.Substring(4, 2);
            string alpha;
            if (hex.Length >= 8)
                alpha = hex.Substring(6, 2);
            else
                alpha = "FF";

            return new Color((int.Parse(r, NumberStyles.HexNumber) / 255f),
                            (int.Parse(g, NumberStyles.HexNumber) / 255f),
                            (int.Parse(b, NumberStyles.HexNumber) / 255f),
                            (int.Parse(alpha, NumberStyles.HexNumber) / 255f));
        }
        public void OnSuccesses()
        {
            StartCoroutine(AnimateHealing());

            IEnumerator AnimateHealing()
            {
                _spriteRenderer.color = new Color(0, 0.7f, 0);
                yield return new WaitForSecondsRealtime(0.4f);
                successesInput.Invoke();
            }
        }
        public void Clean()
        {
            _label.text = "";
        }
        public override void Open()
        {
            base.Open();
            primaryButton.Select();
            Clean();
        }

    }
}