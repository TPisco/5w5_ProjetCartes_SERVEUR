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

        public virtual List<CardStatus> CardStatus { get; set; }

        //Ajout des méthodes pour le premier livrable d'équipe
        public bool HasPower(int powerId)
        {
            // Retourne true si la carte possède ce pouvoir.
            // On peut utiliser LINQ pour faire ça en une ligne
            //Remplace la proppriété CardPowers par une méthode
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
            // Simplement retourner 0 si la carte ne possède pas ce pouvoir.

            CardPower cardPower = Card.CardPowers.FirstOrDefault(p => p.Power.Id == powerId);
            if (cardPower != null && cardPower.Power.Value == 0) return cardPower != null ? cardPower.Value : 0;
            return cardPower != null ? cardPower.Power.Value : 0;
            
        }



        public bool HasStatus(int statusId)
        {
            // Retourne true si la carte possède ce pouvoir.
            // On peut utiliser LINQ pour faire ça en une ligne
            //Remplace la proppriété CardPowers par une méthode
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
            ////Vérifier si le cardStatus n'est pas null?


            //if (.Any(c => c))
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }
        public int? GetStatusValue(int statusId)
        {
            // Retourne les valeur du pouvoir pour cette carte.
            // Simplement retourner 0 si la carte ne possède pas ce pouvoir.

            CardStatus cardStatus = CardStatus.FirstOrDefault(s => s.StatusId == statusId);
            if (cardStatus != null && cardStatus.Value == 0) return cardStatus != null ? cardStatus.Value : 0;
            return cardStatus != null ? cardStatus.Value : 0;

        }



    }
}

