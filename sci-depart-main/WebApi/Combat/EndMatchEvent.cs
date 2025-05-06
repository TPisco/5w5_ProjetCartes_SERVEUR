using Microsoft.Extensions.Logging;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class EndMatchEvent : MatchEvent
    {
        public override string EventType { get { return "EndMatch"; } }
        public int WinningPlayerId { get; set; }

        public int ELOWinner { get; set; }
        public int ELOLoser { get; set; }

        public EndMatchEvent(Match match, MatchPlayerData winningPlayerData, MatchPlayerData losingPlayerData)
        {
            // Pour l'instant, on n'arrête pas la simulation sur le serveur lorsqu'on atteint la fin de la partie.
            // Pour éviter qu'un joueur qui a gagné, mais qui meurt dans le même tour ne donne la victoire à l'autre, on vérifie si le match est déjà terminé!
            if (match.IsMatchCompleted)
                return;

            WinningPlayerId = winningPlayerData.PlayerId;

            match.IsMatchCompleted = true;

            string userId;
            if (match.PlayerDataA.PlayerId == winningPlayerData.PlayerId)
                userId = match.UserAId;
            else
                userId = match.UserBId;

            match.WinnerUserId = userId;

            int WinnerElo = winningPlayerData.Player.ELO;
            int LoserElo = losingPlayerData.Player.ELO;

            CalculateELO(ref WinnerElo, ref LoserElo, 1);

            winningPlayerData.Player.ELO = WinnerElo;
            losingPlayerData.Player.ELO = LoserElo;

            ELOLoser = LoserElo;
            ELOWinner = WinnerElo;


        }

        public static void CalculateELO(ref int p1Rating, ref int p2Rating, int p1Outcome)
        {
            int eloK = 32;

            double expectation = ExpectationToWin(p1Rating, p2Rating);
            int delta = (int)(eloK * (p1Outcome - expectation));

            p1Rating += delta;
            p2Rating -= delta;
        }

        private static double ExpectationToWin(int p1Rating, int p2Rating)
        {
            return 1 / (1 + Math.Pow(10, (p2Rating - p1Rating) / 400.0));
        }
    }
}
