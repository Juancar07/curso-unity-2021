using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyMemberHUD : MonoBehaviour
{
   public Text nameText, lvlText, typeText, hpText;
   public HealthBar healthBar;
   public Image pokemonImage;

   private Pokemon _pokemon;

   [SerializeField] private Color selectedColor = Color.blue;  

   public void SetPokemonData(Pokemon pokemon)
   {
      _pokemon = pokemon;

      nameText.text = pokemon.Base.Name;
      lvlText.text = $"Lv {pokemon.Level}";
      if (pokemon.Base.Type2 == PokemonType.None)
      {
         typeText.text = pokemon.Base.Type1.ToString().ToUpper(); 
      }
      else
      {
         typeText.text = $"{pokemon.Base.Type1.ToString().ToUpper()} - {pokemon.Base.Type2.ToString().ToUpper()}";
      }
      hpText.text = $"{pokemon.HP} / {pokemon.MaxHP}";
      healthBar.SetHP((float)pokemon.HP/pokemon.MaxHP);
      pokemonImage.sprite = pokemon.Base.FrontSprite;

      GetComponent<Image>().color = TypeColor.GetColorFromType(pokemon.Base.Type1);
   }
   
   
   public void SetSelectedPokemon(bool selected)
   {
      if (selected)
      {
         nameText.color = selectedColor;
      }
      else
      {
         nameText.color = Color.black;
      }
   }


}
