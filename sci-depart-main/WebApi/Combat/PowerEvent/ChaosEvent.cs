using Models.Models;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat.PowerEvent
{
    public class ChaosEvent :MatchEvent
    {
        public override string EventType => "Chaos";
        //Quelles données est-ce que Chaos devrait contenir?


        //TODO : MODIFIER LES DONNÉES DU CHAOSEVENT
        public int TargetCardId { get; set; }
        public int PlayerId { get; set; }

        public int Health { get; set; }
        public int Attack { get; set; }

        //PlayableCard attackingCard, PlayableCard defendingCard, MatchPlayerData defender
        //Est-ce que le ChaosEvent doit recevoir deux listes entières en paramètres? À DEMANDER AU PROF.
        public ChaosEvent(PlayableCard chaosCard, List<PlayableCard> attackerCards, List<PlayableCard> defenderCards)
        {
            //PlayerId = defender.PlayerId;
            //TargetCardId = defendingCard.Id;
         
            // À décommenter si nécessaire : rien n'a été dit sur si le ChaosEvent peut être appliqué plusieurs fois à la même carte, inversant les valeurs sans fin
            //Si le Chaos ne peut fonctionner uniquement une seule fois pour chaque carte, il faudra ajout une propriété bool HasChaosEffect pour traquer si une carte a déja recu l'évènement
            // À AJOUTER DANS PlayableCard.cs :  public bool HasChaosEffect { get; set; } = false;
            //Ligne 
            // defendingCard.HasChaosEffect = true;

           // if (!defendingCard.HasChaosEffect)
           //{
                // Inverser les valeurs Attack et Health
                //int originalAttack = defendingCard.Attack;
                //defendingCard.Attack = defendingCard.Health;
                //defendingCard.Health = originalAttack;

                // Marquez la carte comme ayant subi un ChaosEvent
               // defendingCard.HasChaosEffect = true;

                // Stocke les nouvelles valeurs pour référence
                //Attack = defendingCard.Attack;
                //Health = defendingCard.Health;
            //}
            //else
            //{
            //    // Si la carte a déjà subi un ChaosEvent, aucune action n'est effectuée
            //    Attack = defendingCard.Attack;
            //    Health = defendingCard.Health;
            //}






            //LOGIQUE #2 (JSP LEQUEL UTILISER)
            if (chaosCard.HasTriggeredChaos)
            {
                return; // Si oui, ne faites rien
            }

            // Marquez la carte comme ayant déclenché un ChaosEvent
            chaosCard.HasTriggeredChaos = true;

            // Appliquez l'effet Chaos aux cartes de l'attaquant
            ApplyChaosEffect(attackerCards);

            // Appliquez l'effet Chaos aux cartes du défenseur
            ApplyChaosEffect(defenderCards);
        }

        // Méthode pour appliquer l'effet Chaos à une liste de cartes
        private void ApplyChaosEffect(List<PlayableCard> cards)
        {
            foreach (var card in cards)
            {
                // Inversez les valeurs Attack et Health
                int originalAttack = card.Attack;
                card.Attack = card.Health;
                card.Health = originalAttack;
            }
        }

    }

    
}
