using TMPro;
using UnityEngine;

public class WeaponDisplayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _weaponName;
    [SerializeField] private TextMeshProUGUI _weaponData;
    private float _showTime = 5f;
    private float _closeTime = 0;

    public static WeaponDisplayer Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_closeTime <= Time.time)
        {
            gameObject.SetActive(false);
        }
    }

    public void DisplayWeapon(string weaponName, string weaponData)
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }

        _weaponName.text = weaponName;
        _weaponData.text = weaponData;
        
        _closeTime = Time.time + _showTime;
    }
}
