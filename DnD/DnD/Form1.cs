using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DnD
{
    public partial class CharacterhStatsForm : Form
    {
        public CharacterhStatsForm()
        {
            InitializeComponent();
        }
        /********************** Level Text Box Controlls ********************/
        private void levelUpButton_Click(object sender, EventArgs e)
        {
            int level = int.Parse(levelTextBox.Text);
            level = level + 1;
            levelTextBox.Text = level.ToString();
        }
        private void levelDownButton_Click(object sender, EventArgs e)
        {
            int level = int.Parse(levelTextBox.Text);
            level = level - 1;
            levelTextBox.Text = level.ToString();
        }
        private void levelTextBox_TextChanged(object sender, EventArgs e)
        {
            if (levelTextBox.Text == "1") { levelDownButton.Enabled = false; }
            else { levelDownButton.Enabled = true; }
        }
        /********************** End Level Text Box Controlls ****************/

        /**************Get ability mod values via text change ***************/
        // ----------------Str Mod---------------
        private void strAbilityScoreTextBox_TextChanged(object sender, EventArgs e)
        {           
            if (string.IsNullOrEmpty(strAbilityScoreTextBox.Text))
                strAbilityScoreTextBox.Text = "0";
            else
                strAbilityModTextBox.Text = getMod(int.Parse(strAbilityScoreTextBox.Text)).ToString();
                strModTotalTextBox.Text = getModTotal(int.Parse(strAbilityScoreTextBox.Text),int.Parse(levelTextBox.Text)).ToString();
        }
        // ----------------Con Mod--------------
        private void conAbilityScoreTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(conAbilityScoreTextBox.Text))
                conAbilityScoreTextBox.Text = "0";
            else
                conAbilityModTextBox.Text = getMod(int.Parse(conAbilityScoreTextBox.Text)).ToString();
                conModTotalTextBox.Text = getModTotal(int.Parse(conAbilityScoreTextBox.Text), int.Parse(levelTextBox.Text)).ToString();
        }
        // --------------Dex Mod-------------
        private void dexAbilityScoreTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(dexAbilityScoreTextBox.Text))
                dexAbilityScoreTextBox.Text = "0";
            else
                dexAbilityModTextBox.Text = getMod(int.Parse(dexAbilityScoreTextBox.Text)).ToString();
                dexModTotalTextBox.Text = getModTotal(int.Parse(dexAbilityScoreTextBox.Text), int.Parse(levelTextBox.Text)).ToString();
                initiaveDexTextBox.Text = getMod(int.Parse(dexAbilityScoreTextBox.Text)).ToString();
                
        }
        // -----------------Int Mod--------------
        private void intAbilityScoreTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(intAbilityScoreTextBox.Text))
                intAbilityScoreTextBox.Text = "0";
            else
                intAbilityModTextBox.Text = getMod(int.Parse(intAbilityScoreTextBox.Text)).ToString();
                intModTotalTextBox.Text = getModTotal(int.Parse(intAbilityScoreTextBox.Text), int.Parse(levelTextBox.Text)).ToString();
        }
        // ---------------Wis Mod--------------
        private void wisAbilityScoreTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(wisAbilityScoreTextBox.Text))
                wisAbilityScoreTextBox.Text = "0";
            else
                wisAbilityModTextBox.Text = getMod(int.Parse(wisAbilityScoreTextBox.Text)).ToString();
                wisModTotalTextBox.Text = getModTotal(int.Parse(wisAbilityScoreTextBox.Text), int.Parse(levelTextBox.Text)).ToString();
        }
        //----------------Cha Mod---------------------
        private void chaAbilityScoreTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(chaAbilityScoreTextBox.Text))
                chaAbilityScoreTextBox.Text = "0";
            else
                chaAbilityModTextBox.Text = getMod(int.Parse(chaAbilityScoreTextBox.Text)).ToString();
                chaModTotalTextBox.Text = getModTotal(int.Parse(chaAbilityScoreTextBox.Text), int.Parse(levelTextBox.Text)).ToString();
        }
        /****************** End get ability mod values via text change ***************/

        /****************** Initiave Section **********************/



        /****************** End Initiave Section ******************/

        //Exit Button close check
        
        private void exitButton_Click(object sender, EventArgs e)
        {
            closeCheck();
        }


        //Helper  Meathods
        private void closeCheck()
        {
            if (MessageBox.Show("Are you sure you want to EXIT, all unsaved data will be lost!", "Exit",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) this.Close();
        }

        private int getMod(int abilityScore)
        { 
            int abilityMod = (abilityScore / 2) - 5;
            return abilityMod;
        }
        private int getModTotal(int abilityScore, int level)
        {
            //double tempTotalAbility = abilityMod * 0.5;
            //int totalAbility = (int)tempTotalAbility;
            //return totalAbility;
            int abilityMod = (abilityScore / 2) - 5;
            double tempModTotal = abilityMod + 0.5 * level;
            int modTotal = (int)tempModTotal;
            return modTotal;
        }
    }
}

