using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Super_Cartes_Infinies.Data;

namespace Super_Cartes_Infinies.Hubs;

public static class UserHandler
{
    public static HashSet<string> ConnectedIds = new HashSet<string>();
}



[Authorize]
public class MatchHub : Hub
{

    ApplicationDbContext _context;

    public MatchHub(ApplicationDbContext context) 
    {
        _context = context;
    }
    //Connexion
    public override async Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();
        UserHandler.ConnectedIds.Add(Context.ConnectionId);
        await Clients.All.SendAsync("UserCount", UserHandler.ConnectedIds.Count);
    }

    //Déconnexion
    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        UserHandler.ConnectedIds.Remove(Context.ConnectionId);
        await Clients.All.SendAsync("UserCount", UserHandler.ConnectedIds.Count);
        await base.OnDisconnectedAsync(exception);
    }


}


//Tentative d'ajouter le SignalR, si plus rien ne fonctionne, retirer le nouveau code de cette page