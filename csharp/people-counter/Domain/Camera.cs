using System;

namespace Domain
{
    public class Camera
    {
        private readonly HttpClient _httpClient;
        private readonly string _name;
        private readonly string _ip;
        public int TotalIn;
        public int TotalOut;
        private string _friendlyName;
        private DateTime _lastUpdate;
        private string _serial;
        private CurrentCount _currentCount;

        public Camera(HttpClient httpClient, string name, string ip)
        {
            _httpClient = httpClient;
            _name = name;
            _ip = ip;
            this.Update();
        }

        public void Update()
        {
            try
            {
                var data = this._httpClient.fetch("http://${ip}/people-counter/api/live.json");
                this.TotalIn = data.InAmount;
                this.TotalOut = data.OutAmount;
                this._currentCount = new CurrentCount(data.InAmount, data.OutAmount);
                this._friendlyName = data.Name;
                this._lastUpdate = data.Timestamp;
                this._serial = data.Serial;
            } catch (Exception)
            {
                this._friendlyName = "error connectiong to ${name}";
            }
        }

    }
}