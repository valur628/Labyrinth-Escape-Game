// Copyright 2021, Infima Games. All Rights Reserved.

using System.Globalization;
using UnityEngine;

namespace InfimaGames.LowPolyShooterPack.Interface
{
    /// <summary>
    /// Total Ammunition Text.
    /// </summary>
    public class TextAmmunitionGunName : ElementText
    {
        #region METHODS

        [Tooltip("Rifle Ammunition.")]
        [SerializeField]
        private int ammunitionRifle= 40;

        [Tooltip("Pistol Ammunition.")]
        [SerializeField]
        private int ammunitionPistol = 12;

        /// <summary>
        /// Tick.
        /// </summary>
        protected override void Tick()
        {
            //Gun Name.
            float total = equippedWeapon.GetAmmunitionTotal();
            string GunName = "Rifle";

            if (total == ammunitionRifle) {
                GunName = "Rifle";
            }
            else if (total == ammunitionPistol) {
                GunName = "Pistol";
            }
            
            //Update Text.
            textMesh.text = GunName.ToString(CultureInfo.InvariantCulture);
        }
        
        #endregion
    }
}