using Blazored.LocalStorage;
using ECommerce.Client.Services.AuthService;
using ECommerce.Shared.Models;

public class AuthService : IAuthService
{
    private readonly ILocalStorageService _localStorage;
    private Session? _session;
    public event Action? OnChange;

    public AuthService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task<Session?> GetCurrentSession()
    {
        if (_session == null)
        {
            try
            {
                _session = await _localStorage.GetItemAsync<Session>("session");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd pobierania sesji: {ex.Message}");
                return null;
            }
        }
        return _session;
    }

    public async Task SetCurrentSession(Session session)
    {
        if (_session == null || _session.Username != session.Username)
        {
            _session = session;
            await _localStorage.SetItemAsync("session", session);
            NotifyStateChanged();
        }
    }

    public async Task ClearCurrentSession()
    {
        _session = null;
        await _localStorage.RemoveItemAsync("session");
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
