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



        //public bool HasStatus(int statusID)
        //{
        //    // Retourne true si la carte possède ce pouvoir.
        //    // On peut utiliser LINQ pour faire ça en une ligne
        //    //Remplace la proppriété CardPowers par une méthode
        //    // On pourrait aussi faire un Contains() sur la liste de pouvoirs
        //    //CardPowers.Contains(powerId);
        //    if (Card == null)
        //    {
        //        return false;
        //    }

        //    if (.Any(c => c))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        //public int GetStatusValue(int statusID)
        //{
        //    // Retourne les valeur du pouvoir pour cette carte.
        //    // Simplement retourner 0 si la carte ne possède pas ce pouvoir.

        //    CardPower cardPower = Card.CardStatus.FirstOrDefault(p => p.Power.Id == powerId);
        //    if (cardPower != null && cardPower.Power.Value == 0) return cardPower != null ? cardPower.Value : 0;
        //    return cardPower != null ? cardPower.Power.Value : 0;

        //}



    }
}

