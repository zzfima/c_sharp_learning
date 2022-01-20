namespace BL
{
    class ServiceEx : IService
    {
        private readonly string _serviceName;

        public ServiceEx(string serviceName)
        {
            _serviceName = serviceName;
        }

        public string GetServiceName()
        {
            return _serviceName;
        }
    }
}