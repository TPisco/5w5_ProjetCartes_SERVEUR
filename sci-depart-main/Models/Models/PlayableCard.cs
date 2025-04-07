using Models.Interfaces;

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
           

            if(Card.CardPowers.Any(p => p.Id == powerId))
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
            if (Card.CardPowers.Any(p => p.Id == powerId))
            {
                //Chiffre placeholder pour le moment, puisque j'ai oublié comment aller chercher la valeur d'un power
                return 1;
            }
            else
            {
                return 0;
            }

        }

    }
}

