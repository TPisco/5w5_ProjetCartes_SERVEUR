using Models.Models;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;
using WebApi.Combat.PowerEvent;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApi.Combat
{
    public class CardActivationEvent : MatchEvent
    {
        public override string EventType => "CardActivation";
        public int PlayerId { get; set; }

        public CardActivationEvent(Match match, MatchPlayerData attacker, MatchPlayerData defender)
        {
            PlayerId = attacker.PlayerId;
            Events = new List<MatchEvent>();

            //Les pouvoirs d'affliger un status et les spells devraient être fait pour les cartes qui attaquent, le poison dmg doit être géré pour les cartes du defender ( la cible) 
            for (int i = attacker.BattleField.Count - 1; i >= 0; i--)
            {
                
                var atkCard = attacker.BattleField[i];
                //Ici qu'on gère si les cartes on un status qu'ils peuvent infliger
                //Gère aussi les dmg d'un status avant que la carte attaque
                //Event pour affliger du poison
                //Event pour prendre du dmg du poison


                //Dmg du poison : Regarde si une carte a du poison d'affligé, Va chercher la Value dans CardStatus,
                //utilise cette propriété et le donne à PoisonDamageEvent, le PoisonDamageEvent appelle un CardCamageEvent avec Value comme paramètre pour le dmg
                //RAPPEL : Poison perd 1 stack à chaque round
                //C'est dans les attackers qu'on regarde le PoisonDamage


                //
              


                //Modifier apres avec SHIELD_ID
                if (atkCard.HasPower(Power.SHIELD_ID))
                    Events.Add(new ShieldEvent(attacker, atkCard));


                //Ajouter le ChaosEvent
                if (atkCard.HasPower(Power.CHAOS_ID) && atkCard.HasTriggeredChaos == false)
                {
                    Events.Add(new ChaosEvent(atkCard, attacker.BattleField, defender.BattleField));


                }

                //Vérifier qu'une carte n'est pas stunned, sinon elle ne fait rien
                //    //If(card.HasStatus(Status.STUNNEX_ID)){
                //    return;
                //}

                if (i < defender.BattleField.Count)
                {
                    var defCard = defender.BattleField[i];

                    if (!atkCard.HasStatus(Status.STUNNEDX_ID))
                    {
                        if (atkCard.HasPower(Power.FIRST_STRIKE_ID))
                        {
                            if (defCard.Health - atkCard.Attack <= 0)
                            {
                                Events.Add(new FirstStrikeEvent(match, attacker, defender, i));
                                continue;
                            }
                        }

                        if (defCard.HasPower(Power.THORNS_ID))
                        {
                            Events.Add(new ThornsEvent(defCard, atkCard, attacker));
                            if (atkCard.Health - defCard.GetPowerValue(Power.THORNS_ID) <= 0) continue;
                        }


                     
                        if (atkCard.HasStatus(Status.DAMAGE_DOWNX_ID))
                        {
                            Events.Add(new DamageDownEvent(atkCard, defCard, defender));
                        }
                        else
                        {
                            Events.Add(new CardDamageEvent(atkCard.Attack, defCard, defender));

                        }

                        if (atkCard.HasPower(Power.HEAL_ID))
                            Events.Add(new HealEvent(attacker, atkCard));

                        //On vérifie si la carte attaquante possède le pouvoir PoisonAttack. Si oui, on applique l'effet à la carte adverse
                        if (atkCard.HasPower(Power.POISON_ATTACK_ID))
                        {

                            //Requête LINQ pour chercher dans la liste de CardStatus de la carte le poison qu'il a déjà sur lui
                            //PRendre la Value du poisonAttack : getPowerValue
                            //Faire ci-dessus dans ApplyPoisonEvent ^^^^^^

                            //Ajout d'un ApplyPoisonEvent (quand il sera créé) prend attacker, atkCard et Value du poison en paramètres

                            Events.Add(new ApplyPoisonEvent(atkCard, defCard, defender));
                        }
                        //On vérifie si la carte attaquante possède le pouvoir StunAttack. Si oui, on applique l'effet à la carte adverse
                        if (atkCard.HasPower(Power.STUN_ATTACK_ID))
                        {


                            Events.Add(new ApplyStunEvent(atkCard, defCard, defender));
                        }

                        //On vérifie si la carte attaquante possède le pouvoir DamageDown. Si oui, on applique l'effet à la carte adverse
                        if (atkCard.HasPower(Power.DAMAGE_DOWN_ATTACK_ID))
                        {


                            Events.Add(new ApplyDamageDownEvent(atkCard, defCard, defender));
                          //  Events.Add(new DamageDownEvent(defCard, defender));
                        }





                       
                        if (defCard.HasStatus(Status.DAMAGE_DOWNX_ID)) {
                            Events.Add(new DamageDownEvent(defCard, atkCard, attacker));
                            
                        }
                        else
                        {
                            Events.Add(new CardDamageEvent(defCard.Attack, atkCard, attacker));
                        }
                            
                    }
                    else
                    {
                        Events.Add(new StunEvent(atkCard,attacker));
                    }
                    //if (atkCard.HasPower(Power.FIRST_STRIKE_ID))
                    //{
                    //    if (defCard.Health - atkCard.Attack <= 0)
                    //    {
                    //        Events.Add(new FirstStrikeEvent(match, attacker, defender, i));
                    //        continue;
                    //    }
                    //}

                    //if (defCard.HasPower(Power.THORNS_ID))
                    //{
                    //    Events.Add(new ThornsEvent(defCard, atkCard, attacker));
                    //    if (atkCard.Health - defCard.GetPowerValue(Power.THORNS_ID) <= 0) continue;
                    //}

                    //Events.Add(new CardDamageEvent(atkCard.Attack, defCard, defender));

                    //if (atkCard.HasPower(Power.HEAL_ID))
                    //    Events.Add(new HealEvent(attacker, atkCard));

                    ////On vérifie si la carte attaquante possède le pouvoir PoisonAttack. Si oui, on applique l'effet à la carte adverse
                    //if (atkCard.HasPower(Power.POISON_ATTACK_ID))
                    //{
                 
                    //    //Requête LINQ pour chercher dans la liste de CardStatus de la carte le poison qu'il a déjà sur lui
                    //    //PRendre la Value du poisonAttack : getPowerValue
                    //    //Faire ci-dessus dans ApplyPoisonEvent ^^^^^^

                    //    //Ajout d'un ApplyPoisonEvent (quand il sera créé) prend attacker, atkCard et Value du poison en paramètres

                    //    Events.Add(new ApplyPoisonEvent(atkCard, defCard, defender));
                    //}
                    ////On vérifie si la carte attaquante possède le pouvoir StunAttack. Si oui, on applique l'effet à la carte adverse
                    //if (atkCard.HasPower(Power.STUN_ATTACK_ID))
                    //{


                    //    Events.Add(new ApplyStunEvent(atkCard, defCard, defender));
                    //}

                    ////On vérifie si la carte attaquante possède le pouvoir DamageDown. Si oui, on applique l'effet à la carte adverse
                    //if (atkCard.HasPower(Power.DAMAGE_DOWN_ATTACK_ID))
                    //{


                    //    Events.Add(new ApplyDamageDownEvent(atkCard, defCard, defender));
                    //}

                    ////Ajouter le ChaosEvent

                    ////TODO :Ajouter le ApplyStunEvent

                    //Events.Add(new CardDamageEvent(defCard.Attack, atkCard, attacker));

                    if (defCard.HasStatus(Status.POISONX_ID))
                    {
                        Events.Add(new PoisonDamageEvent(defCard, defender));

                    }

                 
                    //Ajouter le Chaos





                }
                else
                {
                    Events.Add(new PlayerDamageEvent(atkCard.Attack, defender, match, attacker));
                }

             

                if (atkCard.HasStatus(Status.POISONX_ID))
                {
                    Events.Add(new PoisonDamageEvent(atkCard, attacker));

                }
            }
        }
    }
}

