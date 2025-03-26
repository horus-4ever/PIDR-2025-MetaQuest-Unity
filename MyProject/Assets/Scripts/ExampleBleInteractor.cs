using UnityEngine;
using Android.BLE;
using Android.BLE.Commands;
using UnityEngine.Android;

public class ExampleBleInteractor : MonoBehaviour
{
    [SerializeField]
    private DeviceRowView _deviceButton;
    [SerializeField]
    private Transform _deviceList;

    [SerializeField]
    private int _scanTime = 10;

    private float _scanTimer = 0f;

    private bool _isScanning = false;

    private void Start()
    {
        ScanForDevices();
    }

    public void ScanForDevices()
    {
        if (!_isScanning)
        {
            _isScanning = true;
            var discoverDevice = new DiscoverDevices(OnDeviceFound, _scanTime * 1000); // s'arete de scanner au bout de 10s
            print("commence à scanner");
            BleManager.Instance.QueueCommand(discoverDevice);
        }
    }

    private void Update()
    {
        if(_isScanning)
        {
            _scanTimer += Time.deltaTime; // fait un scan environ toutes les 5ms
            if(_scanTimer > _scanTime)
            {
                _scanTimer = 0f;
                _isScanning = false;
            }
            //print("scanTimer = "+ _scanTimer+ ", scantime = "+ _scanTime );
        }
    }

    private void OnDeviceFound(string name, string device)
    {
        print("found");
        DeviceRowView button = Instantiate(_deviceButton, _deviceList);
        button.Show(name, device);
    }
}
