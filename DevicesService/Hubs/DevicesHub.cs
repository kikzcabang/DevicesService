using Microsoft.AspNetCore.SignalR;

namespace DevicesService.Hubs
{
    public class DevicesHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        #region FingerprintReader

   
        public async Task StartFingerprintScanning()
        {
            await Clients.All.SendAsync("Client_StartFingerprintScanning");
        }

        public async Task CancelFingerprintScanning()
        {
            await Clients.All.SendAsync("Client_CancelFingerprintScanning");
        }

        public async Task CompleteFingerprintScanning()
        {
            await Clients.All.SendAsync("Client_CompleteFingerprintScanning");
        }

        #endregion


        #region PassportReader

        public async Task StartPassportScanning()
        {
            await Clients.All.SendAsync("Client_StartPassportScanning");
        }

        public async Task CompletePassportScanning()
        {
            await Clients.All.SendAsync("Client_CompletePassportScanning");
        }


        #endregion

        #region SignatureReader

        public async Task StartSignatureScanning()
        {
            await Clients.All.SendAsync("Client_StartSignatureScanning");
        }

        public async Task CancelSignatureScanning()
        {
            await Clients.All.SendAsync("Client_CancelSignatureScanning");
        }

        public async Task CompleteSignatureScanning()
        {
            await Clients.All.SendAsync("Client_CompleteSignatureScanning");
        }

        #endregion

    }
}
