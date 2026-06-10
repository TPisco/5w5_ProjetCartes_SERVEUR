using Models.Interfaces;
using Models.Models;

namespace Super_Cartes_Infinies.Models
{
	public class PlayableCard : IModel
    {
		public PlayableCard()
		{
		}

        public PlayableCard(Card c)
        {
			Card = c;
            Health = c.Health;
            Attack = c.Attack;
        }

        public int Id { get; set; }
		public virtual Card Card { get; set; }
		public int Health { get; set; }
        public int Attack { get; set; }

        // Nouvelle propriùtù pour suivre la rùduction cumulative de l'attaque
       // public int TotalDamageDown { get; set; } = 0;

        //Ajouter cette propriùtù si nùcessaire pour le ChaosEvent
        public bool HasTriggeredChaos { get; set; } = false;

        public virtual List<CardStatus> CardStatus { get; set; } = [];

        //Ajout des mùthodes pour le premier livrable d'ùquipe
        public bool HasPower(int powerId)
        {
            // Retourne true si la carte possùde ce pouvoir.
            // On peut utiliser LINQ pour faire ùa en une ligne
            //Remplace la proppriùtù CardPowers par une mùthode
            // On pourrait aussi faire un Contains() sur la liste de pouvoirs
            //CardPowers.Contains(powerId);
            if (Card.CardPowers == null)
            {
                return false;
            }

            if(Card.CardPowers.Any(p => p.Power.Id == powerId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int GetPowerValue(int powerId)
        {
            // Retourne les valeur du pouvoir pour cette carte.
            // Simplement retourner 0 si la carte ne possùde pas ce pouvoir.

            CardPower? cardPower = Card.CardPowers?.FirstOrDefault(p => p.Power.Id == powerId);
            return cardPower?.Value ?? 0;
            
        }
        //public void ApplySatus()


        public bool HasStatus(int statusId)
        {
            // Retourne true si la carte possùde ce pouvoir.
            // On peut utiliser LINQ pour faire ùa en une ligne
            //Remplace la proppriùtù CardPowers par une mùthode
            // On pourrait aussi faire un Contains() sur la liste de pouvoirs
            //CardPowers.Contains(powerId);
            CardStatus cardStatus = CardStatus.FirstOrDefault(s => s.StatusId == statusId);
            if(CardStatus.Any(s => s.StatusId == statusId))
            {
                return true;
            }
            else
            {
                return false;
            }
            //if (CardStatus == null)
            //{
            //    return false;
            //}

            ////Aller chercher le Status dans le DbContext?
            ////Aller chercher le cardStatus dans le dbContext avec le statusId et playableCardId?
            ////Vùrifier si le cardStatus n'est pas null?


            //if (.Any(c => c))
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        //Cherche la valeur d'un status que la 
        public int GetStatusValue(int statusId)
        {
            // Retourne les valeur du pouvoir pour cette carte.
            // Simplement retourner 0 si la carte ne possùde pas ce pouvoir.

            CardStatus? cardStatus = CardStatus.FirstOrDefault(s => s.StatusId == statusId);
            return cardStatus?.Value ?? 0;

        }



    }
}

