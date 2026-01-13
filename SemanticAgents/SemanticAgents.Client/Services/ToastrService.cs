using Microsoft.JSInterop;
using SemanticAgents.Client.Abstractions;

namespace MusicAgent.Blazor.Client.Services
{
    public class ToastrService : IToastrService
    {
        private IJSRuntime _jsRuntime;

        public ToastrService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task ShowToastrSuccess(string message) => await _jsRuntime.InvokeVoidAsync("ShowToastr", "success", message);
        public async Task ShowToastrInfo(string message) => await _jsRuntime.InvokeVoidAsync("ShowToastr", "info", message);
        public async Task ShowToastrError(string message) => await _jsRuntime.InvokeVoidAsync("ShowToastr", "error", message);
    }
}
