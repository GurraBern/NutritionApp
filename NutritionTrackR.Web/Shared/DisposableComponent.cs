using Microsoft.AspNetCore.Components;

namespace NutritionTrackR.Web.Shared;

public class CancellableComponent : ComponentBase, IDisposable
{
    protected CancellationTokenSource Cts = new();

    void IDisposable.Dispose()
    {
        Cts.Cancel();
        Cts.Dispose();
        
        GC.SuppressFinalize(this);
    }
}