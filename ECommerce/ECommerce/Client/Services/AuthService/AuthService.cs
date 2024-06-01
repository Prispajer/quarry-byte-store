using System.Net.NetworkInformation;

namespace ECommerce.Client.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private Session _session;
        public event Action OnChange;

        public Session GetCurrentSession()
        {
            return _session;
        }

        public void SetCurrentSession(Session session)
        {
            _session = session;
            NotifyStateChanged();
        }

        public void ClearCurrentSession()
        {
            _session = null;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}

